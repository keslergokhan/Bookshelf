using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.Models.Bookshelf
{
    public class BookshelfUpdateViewModel
    {
        public Entity.Concrete.Bookshelf Bookshelf { get; set; }
        public List<SelectListItem> AccessRoles { get; set; }
    }
}
