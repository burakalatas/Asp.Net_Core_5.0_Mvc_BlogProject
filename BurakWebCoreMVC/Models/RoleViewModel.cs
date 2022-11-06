using System.ComponentModel.DataAnnotations;

namespace BurakWebCoreMVC.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Rol adı boş geçilemez.")]
        public string name { get; set; }
    }
}
