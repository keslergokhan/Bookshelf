using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.WebUI.Models;
using Bookshelf.Entity.Concrete;
using Bookshelf.WebUI.Models.User;
using Bookshelf.WebUI.Services.Abstract;
using Bookshelf.Business.Abstract;
using Bookshelf.ACore.Abstract;
using Bookshelf.ACore.Concrete;
using Microsoft.AspNetCore.Http;

namespace Bookshelf.WebUI.Controllers
{
    public class UserController : Controller
    {
        IUserSessionService _userSesssionService;
        IUserService _userService;
        IFileService _fileService;


        public UserController(IUserSessionService userSesssionService, IUserService userService, IFileService fileService = null)
        {
            _userSesssionService = userSesssionService;
            _userService = userService;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.title = "Woheap kayıt ol";

            var model = new UserRegisterViewModel
            {
                User = new UserModel()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                IReturnException<object> returnRegister = new ReturnException<object>();
                User UserNicknameControl = _userService.getNickname(user.UserNickname);

                if (UserNicknameControl == null)
                {
                    returnRegister = _userService.Add(user);
                }
                else
                {
                    returnRegister.Message = UserNicknameControl.UserNickname+" zaten kullanılıyor !";
                    return Redirect("/User/Register?status"+returnRegister.Status+"&message="+returnRegister.Message);
                }

                if (returnRegister.Status)
                {
                    returnRegister.SetReturnException(Status:true,Message:"Aramıza hoş geldin, giriş yapmaya hazırsın !",Data:user);
                    return Redirect("/User/Register?status=" + returnRegister.Status+"&message="+ returnRegister.Message);
                }
                else
                {
                    return Redirect("/User/Register?status="+ returnRegister.Status+"&message="+ returnRegister.Message);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Woheap giriş";

            var model = new UserLoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel User)
        {
            IReturnException<object> returnUserLogin = new ReturnException<object>();

            if (ModelState.IsValid)
            {
                returnUserLogin = _userService.UserLogin(User.UserNickname,User.UserPassword);
                
                if (returnUserLogin.Status)
                {
                    User user = (User)returnUserLogin.Data;
                    _userSesssionService.UserSetSession(user);
                    return Redirect("/Bookshelf/Index");
                }
                else
                {
                    return Redirect("/User/login?status="+returnUserLogin.Status+"&message="+returnUserLogin.Message);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _userSesssionService.UserRemoveSession();
            return Redirect("/User/Index");
        }

        [HttpGet]
        public IActionResult Profil()
        {
            Entity.Concrete.User user = _userSesssionService.UserGetSession();

            var model = new UserProfileViewModel
            {
                User = new UserModel
                {
                    UserID = user.UserID,
                    UserEmail = user.UserEmail,
                    UserImg = user.UserImg,
                    UserName = user.UserName,
                    UserNickname = user.UserNickname,
                    UserPassword = user.UserPassword,
                    UserPasswordControl = user.UserPasswordControl,
                    UserSurname = user.UserSurname
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult ProfilUpdate(UserModel User,IFormFile UserImg)
        {
            IReturnException<object> returnImagesException = new ReturnException<object>();
            IReturnException<object> returnException = new ReturnException<object>();

            User.UserID = _userSesssionService.UserGetSession().UserID;
            Entity.Concrete.User UserReal = _userService.Get(User.UserID);
            if (ModelState.IsValid)
            {
                if (UserImg != null)
                {
                    returnImagesException = _fileService.FileUpload(UserImg, "/wwwroot/dimg/User",true,User.UserName);
                    if(returnImagesException.Status)
                    {
                        _fileService.FileRemove("/wwwroot/dimg/User/"+UserReal.UserImg, true);
                        UserReal.UserImg = returnImagesException.Data.ToString();
                    }
                }
                else
                {
                    returnImagesException.Status = true;
                }

                if(!string.IsNullOrEmpty(User.UserNewPassword))
                {
                    if (UserReal.UserPassword == User.UserPassword)
                    {
                        UserReal.UserPassword = User.UserNewPassword;
                    }
                }

                returnException = _userService.Update(UserReal);

                if (returnImagesException.Status)
                {
                    _userSesssionService.UserSetSession(UserReal);
                    return Redirect("/User/Profil/?status="+returnException.Status+"&message="+returnException.Message);
                }
                else
                {
                    return Redirect("/User/Profil/?status=" + returnException.Status + "&message=" + returnException.Message+"<br> Uyarı !: Resim yüklenemedi.");
                }
            }
            else
            {
                return View(UserReal);
            }

        }

        
    }
}
