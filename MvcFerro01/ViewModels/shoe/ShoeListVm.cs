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
        public Brands? Brand { get; set; }

        public Sports? Sport { get; set; }
        public Genres? Genre { get; set; }
      
        public string Model { get; set; } = null!;

        public string Descripcion { get; set; } = null!;
        public decimal Price { get; set; }

        public bool Active { get; set; }


        public int BrandId { get; set; }
        public int SportId { get; set; }
        public int GenreId { get; set; }
        //   [StringLength(int.MaxValue)]

        public ICollection<ShoeSize> shoesize { get; set; } = new List<ShoeSize>();

    }
}
