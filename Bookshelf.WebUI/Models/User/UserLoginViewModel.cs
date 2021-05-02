using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.WebUI.Models.User
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adınız"), Required(ErrorMessage = "Lütfen boş bırakmayın"),StringLength(50,ErrorMessage ="Kullanıcı adınız bu kadar uzun olamaz")]
        public string UserNickname { get; set; }
        [Display(Name = "Şifreniz"),DataType(DataType.Password), Required(ErrorMessage = "Lütfen boş bırakmayın"),StringLength(20,ErrorMessage = "Şifreniz bu kadar uzun olamaz")]
        public string UserPassword { get; set; }
    }
}
