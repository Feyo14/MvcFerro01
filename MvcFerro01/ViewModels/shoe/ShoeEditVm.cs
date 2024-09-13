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
        [Range(1,int.MaxValue,ErrorMessage ="You must select a {0}")]
        [DisplayName("Brand")]
        public int BrandId { get; set; }
        [DisplayName("Sport")]
        public int SportId { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
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
