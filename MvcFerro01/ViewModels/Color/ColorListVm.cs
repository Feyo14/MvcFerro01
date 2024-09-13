using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.Color.ColorListVm
{
    public class ColorListVm
    {
        public int ColorId { get; set; }
        [DisplayName("ColorName")]

        public string ColorName { get; set; } = null!;
        public bool Active { get; set; }


    }
}
