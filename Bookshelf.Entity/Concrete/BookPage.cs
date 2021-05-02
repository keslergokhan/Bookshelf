using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Threading.Tasks;
using Bookshelf.ACore.Abstract;

namespace Bookshelf.Entity.Concrete
{
    public class BookPage : IEntity
    {
        [Key]
        public int BookPageID { get; set; }
        [StringLength(350,ErrorMessage = "Lütfen {1} karakteri geçmeyin !"),Display(Name = "Sayfa Başlığı")]
        public string BookPageTitle { get; set; }

        [MaxLength, Display(Name = "Sayfa İçeriği")]
        public string BookPageText { get; set; }


        [ForeignKey("BookID")]
        public Book Book { get; set; }
        [Required(ErrorMessage = "Lütfen boş geçmeyin !"), Display(Name = "Kitap")]
        public int BookID { get; set; }
    }
}
