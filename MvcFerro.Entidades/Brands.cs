using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.Entidades
{
    //  [Index(nameof(BrandName), nameof(Brands.BrandName), IsUnique = true)]

    public  class Brands
    {
      
        public int BrandId { get; set; }
        [StringLength(50)]
        public string BrandName { get; set; } = null!;
        public bool Active { get; set; }//
                public string? ImageUrl { get; set; }

      //  public ICollection<Shoes> shoes { get; set; } = new List<Shoes>();



    }
}
