using EFCoresFerro.Datos.Repositorio;
using Microsoft.EntityFrameworkCore;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;

namespace EFCore3.DATOS.Repositorio
{
    public class RepositorioShoes : GenericRepository<Shoes>, IRepositorioShoes
    {
        private readonly EFCoresDbContext context;

        public RepositorioShoes(EFCoresDbContext db) : base(db)
        {
            context = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Agregar(Shoes shoe)
        {
            context.Shoes.Add(shoe);
        }

        public void Borrar(Shoes shoe)
        {
            context.Shoes.Remove(shoe);
        }

        public void Editar(Shoes shoe)
        {
            string descprip = shoe.Descripcion;
            decimal val = shoe.Price;
            string model = shoe.Model;
            var s = context.Shoes
        .FirstOrDefault(t => t.ShoeId == shoe.ShoeId);
            var sport = context.Sports
              .FirstOrDefault(t => t.SportId == shoe.SportId);
            var genre= context.Genres
              .FirstOrDefault(t => t.GenreId == shoe.GenreId);
            var brand = context.Brands
            .FirstOrDefault(t => t.BrandId == shoe.BrandId);
            /*
        
            */
            if (s != null)
            {
                context.Attach(s);
                shoe = s;

            }
            if (sport != null)
            {
                context.Attach(sport);
                s.sport = sport;

            }
            if (genre != null)
            {
                context.Attach(genre);
                s.genre = genre;

            }
            if (brand != null)
            {
                context.Attach(brand);
                s.brand = brand;

            }
          

            s.Descripcion =descprip;
          s.Price =val;
            s.Model = model;

            context.Shoes.Update(s);      
        }

        public bool existe(Shoes d)
        {
            if (d.ShoeId == 0)
            {
                return context.Shoes.Any(
                    p => p.Descripcion == d.Descripcion &&
                    p.BrandId == d.BrandId &&
                    p.GenreId == d.GenreId &&
                    p.Model == d.Model &&
                    p.SportId == d.SportId);
            }
            return context.Shoes.Any(
                p => p.Descripcion == d.Descripcion &&
                    p.BrandId == d.BrandId &&
                    p.GenreId == d.GenreId &&
                    p.Model == d.Model &&
                    p.SportId == d.SportId &&
            p.ShoeId != p.ShoeId);
        }

        public bool existeShoeSize(int s)
        {
            return context.ShoeSize.Any(
                  p => p.ShoeId == s);
        }

        public List<Shoes> GetLista()
        {
            return context.Shoes
                .Include(p => p.brand)
                .Include(p => p.sport)
                .Include(p => p.genre)
                      //.OrderBy(p => p.Model)
                          .AsNoTracking()
                .ToList();
             //  .OrderBy(p=>p.Price)
        
        }

        public Shoes? GetPorName(string descrip)
        {
            return context.Shoes
                                     .FirstOrDefault(t => t.Descripcion == descrip);
        }

        public Shoes? GetShoePorId(int id)
        {
            return context.Shoes
                                .FirstOrDefault(t => t.ShoeId == id);
        }
    }
}
