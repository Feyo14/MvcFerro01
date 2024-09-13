using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcFerro01.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.Shoe.ShoeListVm
{
    public class ShoeListVm
    {
        public int ShoeId { get; set; }
       
        public string Descripcion { get; set; } = null!;
        public int BrandId { get; set; }
        public int GenreId { get; set; }
        public int SportId { get; set; }
        public bool Active { get; set; }
      

        public string Model { get; set; } = null!;
        //   [StringLength(int.MaxValue)]
        public decimal Price { get; set; }
      public Brands? brand { get; set; }

       public Sports? sport { get; set; }
      public Genres? genre { get; set; }
        public ICollection<ShoeSize> shoesize { get; set; } = new List<ShoeSize>();

    }
}
