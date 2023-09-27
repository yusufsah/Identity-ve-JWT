using System.ComponentModel.DataAnnotations;

namespace Identitygiriş.Models
{
    public class LoginviewModel
    {

        [Required(ErrorMessage = "Kullanıcı Adı Alanı Zorunludur.")]
        public string username { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Zorunludur.")]
        public string password { get; set; }

    }
}
