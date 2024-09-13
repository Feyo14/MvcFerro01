using AutoMapper;
using MvcFerro.Entidades;
using MvcFerro01.ViewModels.Brand.BrandEditVm;
using MvcFerro01.ViewModels.Brand.BrandListVm;
using MvcFerro01.ViewModels.Color.ColorEditVm;
using MvcFerro01.ViewModels.Color.ColorListVm;
using MvcFerro01.ViewModels.Genre.GenreEditVm;
using MvcFerro01.ViewModels.Genre.GenreListVm;
using MvcFerro01.ViewModels.Shoe.ShoeEditVm;
using MvcFerro01.ViewModels.Sport.SportEditVm;
using MvcFerro01.ViewModels.Sport.SportListVm;

namespace MvcFerro01.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadBrandMapping();
            LoadShoeMapping();
            LoadGenreMapping();
            LoadSportMapping();
            LoadColorMapping();

        }

        private void LoadColorMapping()
        {
            CreateMap<Colors, ColorListVm>();

            CreateMap<Colors, ColorEditVm>().ReverseMap();
        }

        private void LoadSportMapping()
        {
            CreateMap<Sports, SportListVm>();

            CreateMap<Sports, SportEditVm>().ReverseMap();
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
