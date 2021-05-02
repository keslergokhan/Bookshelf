using Bookshelf.Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Business.Abstract
{
    public interface IAccessRoleService
    {
        List<AccessRole> GetAll();

        List<SelectListItem> GetSelectListAll();
    }
}
