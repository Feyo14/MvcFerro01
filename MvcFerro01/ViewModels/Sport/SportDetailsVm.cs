using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MvcFerro01.ViewModels.Shoe.ShoeListVm;
using System.ComponentModel;
using X.PagedList;

namespace MvcFerro01.ViewModels.Sport.SportDetailsVm
{
    public class SportDetailsVm
    {
        public int SportId { get; set; }
        [DisplayName("Sport")]
        public string SportName { get; set; } = null!;
        public bool Active { get; set; }

        public IPagedList<ShoeListVm>? Shoes { get; set; }
    }
}
