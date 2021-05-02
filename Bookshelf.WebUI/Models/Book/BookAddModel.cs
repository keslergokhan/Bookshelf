using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.Models.Book
{
    public class BookAddModel
    {
        [Required(ErrorMessage = "Lütfe Boş Geçmeyin !"), Display(Name = "Kitaplık")]
        public int BookshelfID { get; set; }
        [Required(ErrorMessage = "Lütfen Boş Geçmeyin !"), Display(Name = "Kitap Adı"), StringLength(100, ErrorMessage = "Lütren {1} karakteri geçmeyin !"), Column(TypeName = "varchar")]
        public string BookshelfName { get; set; }
        public string BookName { get; set; }
        [Display(Name = "Kitap Açıklama"), StringLength(300, ErrorMessage = "Lütfen {1} karakteri geçmeyin !")]
        public string BookExplain { get; set; }
    }
}
