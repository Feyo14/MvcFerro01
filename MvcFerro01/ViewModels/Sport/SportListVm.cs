using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.Sport.SportListVm
{
    public class SportListVm
    {
        public int SportId { get; set; }
        [DisplayName("SportName")]

        public string SportName { get; set; } = null!;
        public bool Active { get; set; }


    }
}
