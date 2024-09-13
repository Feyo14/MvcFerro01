using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.Color.ColorEditVm
{
    public class ColorEditVm
    {
        public int ColorId { get; set; }
        [Required(ErrorMessage ="{0} is required")]
        [StringLength(200,ErrorMessage ="{0} must have between {2} and {1} characters", MinimumLength =3)]
        [DisplayName("ColorName")]
        [MaxLength(256, ErrorMessage = "{0} must have less than 257 characters")]
        public string ColorName { get; set; } = null!;
        [ValidateNever]
        public bool Active { get; set; }



    }
}
