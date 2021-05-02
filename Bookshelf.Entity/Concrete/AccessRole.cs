using Bookshelf.ACore.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Entity.Concrete
{
    public class AccessRole :IEntity
    {
        [Key]
        public int AccessRoleID { get; set; }
        [Required(ErrorMessage = "Lütfen boş geçmeyin !"), Display(Name = "Erişim Rolü"),StringLength(100,ErrorMessage = "Lütfen {1} karakteri geçmeyin !"),Column(TypeName = "varchar")]
        public string AccessRoleExplain { get; set; }

        public ICollection<Bookshelf> Bookshelf { get; set; }
    }
}
