using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro.Entidades;

namespace EFCore3.DATOS.Repositorio
{
    public class RepositorioGenre : IRepositorioGenre
    {
        private readonly EFCoresDbContext context;

        public RepositorioGenre(EFCoresDbContext context)
        {
            this.context = context;
        }
        public bool existe(Genre brand)
        {
            if (brand.GenreId == 0)
            {
                return context.Genres.Any(p => p.GenreName == brand.GenreName);
            }
            else
            {
                return context.Genres.Any(p => p.GenreName == brand.GenreName && p.GenreId != brand.GenreId);
            }

        }
        public Genre? GetGenrePorId(int b)
        {
            return context.Genres
                 .FirstOrDefault(t => t.GenreId == b);
        }
        public Genre? GetPorName(string nombre)
        {
            return context.Genres
                         .FirstOrDefault(te => te.GenreName == nombre);
        }
        public void Agregar(Genre g)
        {
            context.Genres.Add(g);
        }

        public void Borrar(Genre g)
        {
            context.Genres.Remove(g);
        }

        public void Editar(Genre g)
        {
            context.Genres.Update(g);      
        }

        
        public List<Genre> GetLista()
        {
            return context.Genres
                .OrderBy(p=>p.GenreName)
                .ToList();
        }
         
       
    }
}
