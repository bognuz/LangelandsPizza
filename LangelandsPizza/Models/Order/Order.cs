using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LangelandsPizza.Models.Order
{
    public class Order
    {
        
        public int Id { get; set; }
        [Display(Name = "Skriv venligst dit fornavn")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Navnet skal være mellem 3 og 25 bogstaver")]
        [Required(ErrorMessage = "Navnet må ikke være tomt")]

        public string Name { get; set; }

        [Display(Name = "Skriv venligst dit Efternavn")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Efternavnet skal være mellem 3 og 25 bogstaver")]
        [Required(ErrorMessage = "Efternavnet må ikke være tomt")]
        public string Surname { get; set; }

        [Display(Name = "Skriv venligst din email adresse")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Udfyld din email adresse korrekt")]
        public string Email { get; set; }

        [Display(Name = "Skriv venligst dit Telefon nummer")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Telefon nummer skal være på 8 tegn ")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon nummer skal være udfyldt")]
        public string TelefonNumber { get; set;}

      
        public List<OrderItem> OrderItems { get; set;  }

        public bool isCompleted { get; set;  }
    }
}
