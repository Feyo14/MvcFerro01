using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MvcFerro01.ViewModels.Shoe.ShoeListVm;
using System.ComponentModel;
using X.PagedList;

namespace MvcFerro01.ViewModels.Brand.BrandDetailsVm
{
    public class BrandDetailsVm
    {
        public int BrandId { get; set; }
        [DisplayName("Brand")]
        public string BrandName { get; set; } = null!;
        public bool Active { get; set; }

        public IPagedList<ShoeListVm>? Shoes { get; set; }
    }
}
