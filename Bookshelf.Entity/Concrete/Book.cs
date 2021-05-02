using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Bookshelf.ACore.Abstract;

namespace Bookshelf.Entity.Concrete
{
    public class Book : IEntity
    {
        [Key]
        public int BookID { get; set; }
        [ForeignKey("BookshelfID")]
        public Entity.Concrete.Bookshelf Bookshelf { get; set; }
        [Required(ErrorMessage = "Lütfe Boş Geçmeyin !"),Display(Name = "Kitaplık")]
        public int BookshelfID { get; set; }
        [Required(ErrorMessage = "Lütfen Boş Geçmeyin !"),Display(Name = "Kitap Adı"),StringLength(100,ErrorMessage = "Lütren {1} karakteri geçmeyin !"),Column(TypeName = "varchar")]
        public string BookName { get; set; }
        [Display(Name = "Kitap Açıklama"),StringLength(300,ErrorMessage = "Lütfen {1} karakteri geçmeyin !")]
        public string BookExplain { get; set; }

        public ICollection<BookPage> BookPages { get; set; }
    }
}
