using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcFerro01.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.Shoe.ShoeEditVm
{
    public class ShoeEditVm
    {
        public int ShoeId { get; set; }
       
        [Required(ErrorMessage ="{0} is required")]
        [StringLength(200,ErrorMessage ="{0} must have between {2} and {1} characters", MinimumLength =3)]
        [DisplayName("Descripcion")]
        [MaxLength(256, ErrorMessage = "{0} must have less than 257 characters")]
        public int BrandId { get; set; }
        [DisplayName("Brand")]

        public int SportId { get; set; }
        [DisplayName("Sport")]
        public int GenreId { get; set; }
        [DisplayName("Genre")]
        public string Model { get; set; } = null!;

        public string Descripcion { get; set; } = null!;
        public string Price { get; set; }

        public bool Active { get; set; }

        [ValidateNever]



        public IEnumerable<SelectListItem> Brand { get; set; } = null!;
        [ValidateNever]
        //  public Brands? brand { get; set; }

        public IEnumerable<SelectListItem> Sport { get; set; } = null!;
        [ValidateNever]

        public IEnumerable<SelectListItem> Genre { get; set; } = null!;

   

       
  
  

    }
}
