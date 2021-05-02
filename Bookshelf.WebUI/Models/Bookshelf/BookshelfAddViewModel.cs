using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookshelf.WebUI.Models.Bookshelf
{
    public class BookshelfAddViewModel
    {
        public Entity.Concrete.Bookshelf Bookshelf { get; set; }
        public List<SelectListItem> AccessRoles { get; set; }
    }
}
