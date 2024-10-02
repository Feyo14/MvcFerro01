using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;


namespace MvcFerro01.Sport.SportDetail
{
    //  [Index(nameof(BrandName), nameof(Brands.BrandName), IsUnique = true)]

    public  class SportDetail
    {
      
        public int SportId { get; set; }
        [StringLength(50)]
        public string SportName { get; set; } = null!;
        public bool Active { get; set; }//

    }
}
