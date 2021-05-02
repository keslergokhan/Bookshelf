using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bookshelf.ACore.Abstract;

namespace Bookshelf.Entity.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "Kullanıcı adı"),Required(ErrorMessage = "Lütfen boş bırakmayın"), StringLength(50,ErrorMessage = "Lütfen {1} karakteri geçmeyin"),Column(TypeName ="varchar")]
        public string UserName { get; set; }
        [Display(Name = "Kullanıcı Soyadı"),Required(ErrorMessage = "Lütfen boş bırakmayın"), StringLength(50, ErrorMessage = "Lütfen {1} karakteri geçmeyin"), Column(TypeName = "varchar")]
        public string UserSurname { get; set; }
        [Display(Name = "Kullanıcı Takma Ad"),Required(ErrorMessage = "Lütfen boş bırakmayın"), StringLength(50, ErrorMessage = "Lütfen {1} karakteri geçmeyin"), Column(TypeName = "varchar")]
        public string UserNickname { get; set; }
        [MaxLength]
        public string UserImg { get; set; }
        [Display(Name = "Kullanıcı Email"), Required(ErrorMessage = "Lütfen boş bırakmayın"), DataType(DataType.EmailAddress,ErrorMessage ="Lütfen doğru Email adresi giriniz !"), StringLength(100, ErrorMessage = "Lütfen {1} karakteri geçmeyin"), Column(TypeName = "varchar")]
        public string UserEmail { get; set; }
        [Display(Name = "Kullanıcı şifre"), Required(ErrorMessage = "Lütfen boş bırakmayın"), DataType(DataType.Password), StringLength(20, ErrorMessage = "Lütfen {1} karakteri geçmeyin")]
        public string UserPassword { get; set; }
        [Compare(nameof(UserPassword),ErrorMessage = "Şifre eşleşmiyor !"), Display(Name = "Kullanıcı şifre kontrol"), DataType(DataType.Password), StringLength(20, ErrorMessage = "Lütfen {0} karakteri geçmeyin")]
        public string UserPasswordControl { get; set; }

        public ICollection<Bookshelf> Bookshelf { get; set; }

    }
}
