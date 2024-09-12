using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro.Entidades
{
  //  [Index(nameof(BrandName), nameof(Brands.BrandName), IsUnique = true)]

    public  class Size
    {
      
        public int SizeId { get; set; }
       public decimal sizeNumber { get; set; }
             public ICollection<ShoeSize> shoesize { get; set; } = new List<ShoeSize>();



    }
}
