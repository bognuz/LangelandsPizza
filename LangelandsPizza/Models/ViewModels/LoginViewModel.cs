using System.ComponentModel.DataAnnotations;

namespace LangelandsPizza.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Skriv venligst din mail adresse")]
        [Required(ErrorMessage = "Skriv venligst din mail adresse")]
        public string EmailAdress { get; set; }

        [Display(Name = "Skriv venligst din password")]
        [Required(ErrorMessage = "Skriv venligst din password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
