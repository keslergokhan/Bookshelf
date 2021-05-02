using Bookshelf.ACore.Abstract;
using Bookshelf.ACore.Concrete;
using Bookshelf.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Business.Abstract
{
    public interface IUserService
    {
        IReturnException<object> Add(User user);
        IReturnException<object> Update(User user);
        User getNickname(string UserNickname);
        IReturnException<object> UserLogin(string UserNickname,string UserPassword);
        User Get(int UserID);
    }
}
