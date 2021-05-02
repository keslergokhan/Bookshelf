using Bookshelf.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshelf.ACore.Concrete;
using Bookshelf.Entity.Concrete;
using Bookshelf.DataAccess.Abstract;
using Bookshelf.DataAccess.Concrete;
using Bookshelf.ACore.Abstract;

namespace Bookshelf.Business.Concrete
{
    public class UserService : ServiceBase<IUserDal,User>, IUserService
    {
        public UserService(IUserDal userDal) : base(userDal)
        {
        }

        public User Get(int UserID)
        {
            return base.Get(u=>u.UserID == UserID);
        }

        public User getNickname(string UserNickname)
        {
            return base.Get(u => u.UserNickname.ToLower().Contains(UserNickname.ToLower()));
        }

        public IReturnException<object> UserLogin(string UserNickname, string UserPassword)
        {
            IReturnException<object> returnUserLogin = new ReturnException<object>();
            if (!string.IsNullOrEmpty(UserNickname) && !string.IsNullOrEmpty(UserPassword))
            {
                User user = base.Get(u=>u.UserNickname.ToLower().Contains(UserNickname.ToLower()) && u.UserPassword == UserPassword);

                if (user != null)
                {
                    returnUserLogin.SetReturnException(Status: true, Message: "Hoş geldiniz "+user.UserName+" "+user.UserSurname+".", user);
                }
                else
                {
                    returnUserLogin.SetReturnException(Status: false, Message: "Şifre veya kullanıcı adı yanlış !", UserPassword);
                }
            }
            else
            {
                returnUserLogin.SetReturnException(Status: false, Message: "Lütfen boş geçmeyin !", UserPassword);
            }

            return returnUserLogin;
        }
    }

    
}
