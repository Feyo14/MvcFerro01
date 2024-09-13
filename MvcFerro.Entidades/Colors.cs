using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcFerro.Entidades
{
    // [Table("Colors")]

    //  [Index(nameof(ColorName), nameof(Colors.ColorName), IsUnique = true)]
    public class Colors
    {
        public int ColorId { get; set; }
        [StringLength(50)]
        public string ColorName { get; set; } = null!;
        public bool Active { get; set; }
        public ICollection<Shoes> shoes { get; set; } = new List<Shoes>();

    }
}
