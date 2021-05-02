using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.Models.Bookshelf
{
    public class BookshelfBook
    {
        public Entity.Concrete.Bookshelf Bookshelf { get; set; }
        public List<Entity.Concrete.Book> Book { get; set; }
    }
}
