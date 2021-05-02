using Bookshelf.ACore.Concrete;
using Bookshelf.Business.Abstract;
using Bookshelf.DataAccess.Abstract;
using Bookshelf.Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Business.Concrete
{
    public class AccessRoleService: ServiceBase<IAccessRoleDal,AccessRole>,IAccessRoleService
    {
        public AccessRoleService(IAccessRoleDal accessRoleDal):base(accessRoleDal)
        {
        }

        public List<AccessRole> GetAll()
        {
            return base.GetAll();
        }

        public List<SelectListItem> GetSelectListAll()
        {
            return base.GetAll().Select(a => new SelectListItem { Value = a.AccessRoleID.ToString(), Text = a.AccessRoleExplain.ToString() }).ToList();
        }
    }
}
