using EFCoresFerro.Datos.Repositorio;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;

namespace EFCore3.DATOS.Repositorio
{
    public class RepositorioGenre : GenericRepository<Genres>, IRepositorioGenre
    {
        private readonly EFCoresDbContext context;
        public RepositorioGenre(EFCoresDbContext db) : base(db)
        {
            context = db ?? throw new ArgumentNullException(nameof(db));
        }
      //  public RepositorioGenre(EFCoresDbContext context)
       // {
        //    this.context = context;
        //}
        public bool existe(Genres brand)
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
        public Genres? GetGenrePorId(int b)
        {
            return context.Genres
                 .FirstOrDefault(t => t.GenreId == b);
        }
        public Genres? GetPorName(string nombre)
        {
            return context.Genres
                         .FirstOrDefault(te => te.GenreName == nombre);
        }
        public void Agregar(Genres g)
        {
            context.Genres.Add(g);
        }

        public void Borrar(Genres g)
        {
            context.Genres.Remove(g);
        }

        public void Editar(Genres g)
        {
            context.Genres.Update(g);      
        }

        
        public List<Genres> GetLista()
        {
            return context.Genres
                .OrderBy(p=>p.GenreName)
                .ToList();
        }
         
       
    }
}
