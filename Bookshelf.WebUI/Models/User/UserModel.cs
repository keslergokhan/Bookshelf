using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.Models.User
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Display(Name = "Kullanıcı adı"), StringLength(50, ErrorMessage = "Lütfen {1} karakteri geçmeyin")]
        public string UserName { get; set; }
        [Display(Name = "Kullanıcı Soyadı"),StringLength(50, ErrorMessage = "Lütfen {1} karakteri geçmeyin")]
        public string UserSurname { get; set; }
        [Display(Name = "Kullanıcı Takma Ad"),StringLength(50, ErrorMessage = "Lütfen {1} karakteri geçmeyin")]
        public string UserNickname { get; set; }
        [MaxLength, Display(Name = "Kullanıcı Resim")]
        public string UserImg { get; set; }
        [Display(Name = "Kullanıcı Email"),DataType(DataType.EmailAddress, ErrorMessage = "Lütfen doğru Email adresi giriniz !"), StringLength(100, ErrorMessage = "Lütfen {1} karakteri geçmeyin")]
        public string UserEmail { get; set; }
        [Display(Name = "Kullanıcı şifre"), DataType(DataType.Password), StringLength(20, ErrorMessage = "Lütfen {1} karakteri geçmeyin")]
        public string UserNewPassword { get; set; }
        [Display(Name = "Kullanıcı şifre"),DataType(DataType.Password), StringLength(20, ErrorMessage = "Lütfen {1} karakteri geçmeyin")]
        public string UserPassword { get; set; }
        [Compare(nameof(UserPassword), ErrorMessage = "Şifre eşleşmiyor !"), Display(Name = "Kullanıcı şifre kontrol"), DataType(DataType.Password), StringLength(20, ErrorMessage = "Lütfen {0} karakteri geçmeyin")]
        public string UserPasswordControl { get; set; }

    }
}
