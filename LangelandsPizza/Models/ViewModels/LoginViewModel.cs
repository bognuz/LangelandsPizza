using System.ComponentModel.DataAnnotations;

namespace LangelandsPizza.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Skirv din mail adresse")]
        [Required(ErrorMessage = "Du skal skrive mailadressen ind")]
        public string EmailAdress { get; set; }

        [Display(Name = "Skirv din mail adresse")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
