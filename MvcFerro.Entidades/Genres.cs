using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcFerro01.Entidades
{
    //  [Table("Genre")]

   //  [Index(nameof(GenreName), nameof(Genre.GenreName), IsUnique = true)]

    public  class Genres
    {
        public int GenreId { get; set; }
        [StringLength(10)]
        public string GenreName { get; set; } = null!;
        public ICollection<Shoes> shoes { get; set; } = new List<Shoes>();

    }
}
