using MvcFerro.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioGenre
    {
        IEnumerable<Genre>? GetAll(Expression<Func<Genre, bool>>? filter = null,
          Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null,
          string? propertiesNames = null);
        List<Genre> GetLista();
        void Agregar(Genre genre);
        void Borrar(Genre genre);
        void Editar(Genre genre);
        public bool existe(Genre b);
        Genre? GetGenrePorId(int b);
        Genre? GetPorName(string nombre);


    }
}
