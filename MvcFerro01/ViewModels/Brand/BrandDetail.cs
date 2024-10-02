using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;


namespace MvcFerro01.ViewModels.Brand.BrandDetail
{
    //  [Index(nameof(BrandName), nameof(Brands.BrandName), IsUnique = true)]

    public  class BrandDetail
    {
      
        public int BrandId { get; set; }
        [StringLength(50)]
        public string BrandName { get; set; } = null!;
        public bool Active { get; set; }//
                public string? ImageUrl { get; set; }


    }
}
