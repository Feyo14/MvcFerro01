
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.Entidades
{
   //[Index(nameof(BrandName), nameof(Brands.BrandName), IsUnique = true)]

    public  class ShoeSize
    {
      
        public int ShoeSizeId { get; set; }
        public int ShoeId { get; set; }
        public int SizeId { get; set; }
        public int QuantityInStock { get; set; }

        public Shoes? Shoe { get; set; }
        public Size? Size { get; set; }



    }
}
