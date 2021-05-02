using Bookshelf.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.Services.Abstract
{
    public interface IUserSessionService
    {
        void UserSetSession(User user, string key = "User");
        void UserRemoveSession(string key = "User");
        User UserGetSession(string key = "User");
    }
}
