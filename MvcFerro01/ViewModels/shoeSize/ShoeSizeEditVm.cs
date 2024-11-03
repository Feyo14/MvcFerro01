using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcFerro01.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.ShoeSize.ShoeSizeEditVm
{
    public class ShoeSizeEditVm
    {
      
   
        public int ShoeSizeId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a {0}")]
        [DisplayName("Shoe")]
        public int ShoeId { get; set; }
        [DisplayName("Size")]
        public int SizeId { get; set; }
        public int QuantityInStock { get; set; }

        [ValidateNever]

        public IEnumerable<SelectListItem> Shoe { get; set; } = null!;
        [ValidateNever]

        public IEnumerable<SelectListItem> Size { get; set; } = null!;


    }
}
