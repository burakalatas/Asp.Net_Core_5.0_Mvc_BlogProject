using System.ComponentModel.DataAnnotations;

namespace BurakWebCoreMVC.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Ad soyad boş geçilemez!")]
        public string NameSurname { get; set; }
        
        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Şifre boş geçilemez!")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage ="Şifreler uyuşmuyor!")]
        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail adresi boş geçilemez!")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }
    }
}
