using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.Entidades
{
    //    [Table("Shoes")]

    public  class Shoes
    {
        public int ShoeId { get; set; }
        public int BrandId { get; set; }
        public int SportId { get; set; }
        public int GenreId { get; set; }
        [StringLength(10)]
        public string Model { get; set; } = null!;
     //   [StringLength(int.MaxValue)]

        public string Descripcion { get; set; } = null!;
        public decimal Price { get; set; }
        public Brands? brand { get; set; }
        public Sports? sport { get; set; }
        public Genres? genre { get; set; }
        public bool Active { get; set; }

        public ICollection<ShoeSize> shoesize { get; set; } = new List<ShoeSize>();



    }
}
