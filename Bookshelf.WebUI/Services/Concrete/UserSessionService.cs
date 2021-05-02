using Bookshelf.Entity.Concrete;
using Bookshelf.WebUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Bookshelf.WebUI.ExtensionMethod;

namespace Bookshelf.WebUI.Services.Concrete
{
    public class UserSessionService : IUserSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public UserSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User UserGetSession(string key = "User")
        {
            User user = _httpContextAccessor.HttpContext.Session.GetObject<User>(key);
            return user;
        }

        public void UserRemoveSession(string key = "User")
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }

        public void UserSetSession(User user, string key = "User")
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key,user);
        }
    }
}
