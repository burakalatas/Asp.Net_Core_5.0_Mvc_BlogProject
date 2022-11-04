using System.ComponentModel.DataAnnotations;

namespace BurakWebCoreMVC.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string password { get; set; }
    }
}
