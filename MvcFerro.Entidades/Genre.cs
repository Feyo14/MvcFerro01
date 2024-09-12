using MvcFerro.Entidades;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro.Entidades
{
    //  [Table("Genre")]

    // [Index(nameof(GenreName), nameof(Genre.GenreName), IsUnique = true)]

    public  class Genre
    {
        public int GenreId { get; set; }
        [StringLength(10)]
        public string GenreName { get; set; } = null!;
        public ICollection<Shoes> shoes { get; set; } = new List<Shoes>();

    }
}
