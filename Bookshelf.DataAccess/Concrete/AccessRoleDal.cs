using Bookshelf.ACore.Concrete;
using Bookshelf.DataAccess.Abstract;
using Bookshelf.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.DataAccess.Concrete
{
    public class AccessRoleDal : RepositoryBase<BookshelfContext,AccessRole>, IAccessRoleDal
    {
    }
}
