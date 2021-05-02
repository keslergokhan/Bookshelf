using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bookshelf.ACore.Abstract;
using System.ComponentModel;

namespace Bookshelf.Entity.Concrete
{
    public class Bookshelf : IEntity
    {
        [Key]
        public int BookshelfID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        [Display(Name = "Kullanıcı"), Required(ErrorMessage = "Lütfen boş bırakmayın !")]
        public int UserID { get; set; }
        [Display(Name = "Kitaplık Adı"), Required(ErrorMessage = "Lütfen boş bırakmayın !"), StringLength(150, ErrorMessage = "Lürfen {1} karakteri geçmeyin"), Column(TypeName = "varchar")]
        public string BookshelfName { get; set; }
        [Display(Name = "Kitaplık Kategori"), Required(ErrorMessage = "Lütfen boş bırakmayın !"), StringLength(150, ErrorMessage = "Lürfen {1} karakteri geçmeyin"), Column(TypeName = "varchar")]
        public string BookshelfCategory { get; set; }

        [Display(Name = "Kitaplık Açıklama"), MaxLength, Required(ErrorMessage = "Lütfen boş bırakmayın !")]
        public string BookshelfExplain { get; set; }

        [ForeignKey("AccessRoleID")]
        public AccessRole AccessRole { get; set; }
        [Required(ErrorMessage = "Lütfen boş bırakmayın"),DefaultValue(value:1),Display(Name = "Kitaplık Erişebilirlik")]
        public int AccessRoleID { get; set; }

        public ICollection<Book> Books { get; set; }


    }
}
