using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Entity.Concrete
{
    public class BookshelfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-EFM1DKV\SQLEXPRESS;Database=Bookshelf;Trusted_Connection=True;User Id=gkhnk;Password=;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bookshelf> Bookshelf { get; set; }
        public DbSet<AccessRole> AccessRoles { get; set; }
        public DbSet<BookPage> BookPages { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
