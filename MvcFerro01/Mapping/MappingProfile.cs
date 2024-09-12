using AutoMapper;
using MvcFerro.Entidades;
using MvcFerro01.ViewModels.Brand.BrandEditVm;
using MvcFerro01.ViewModels.Brand.BrandListVm;
using MvcFerro01.ViewModels.Genre.GenreEditVm;
using MvcFerro01.ViewModels.Genre.GenreListVm;
using MvcFerro01.ViewModels.Shoe.ShoeEditVm;

namespace MvcFerro01.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadBrandMapping();
            LoadShoeMapping();
            LoadGenreMapping();


        }

        private void LoadGenreMapping()
        {

            CreateMap<Genre, GenreListVm>();

            CreateMap<Genre, GenreEditVm>().ReverseMap();
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
