using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.Genre.GenreListVm
{
    public class GenreListVm
    {
        public int GenreId { get; set; }
        [DisplayName("GenreName")]

        public string GenreName { get; set; } = null!;

    }
}
