
using Microsoft.EntityFrameworkCore;
namespace MvcFerro01.Entidades
{
    //    [Table("ShoeSize")]

    public class ShoeSizee
    {
      
        public int ShoeSizeId { get; set; }
        public int ShoeId { get; set; }
        public int SizeId { get; set; }
        public int QuantityInStock { get; set; }

        public Shoes? Shoe { get; set; }
        public Size? Size { get; set; }



    }
}
