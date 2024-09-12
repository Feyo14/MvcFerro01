using AutoMapper;
using EFCoresFerro.Web2.ViewModels.Brand.BrandEditVm;
using EFCoresFerro.Web2.ViewModels.Brand.BrandListVm;
using EFCoresFerro.Web2.ViewModels.Shoe.ShoeEditVm;
using MvcFerro.Entidades;

namespace MvcFerro.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadBrandMapping();
            LoadShoeMapping();

            
        }

        private void LoadShoeMapping()
        {
            CreateMap<Shoes, ShoeEditVm>().ReverseMap();
        }

        private void LoadBrandMapping()
        {
            CreateMap<Brand, BrandListVm>();

            CreateMap<Brand, BrandEditVm>().ReverseMap();
        }
    }
}
