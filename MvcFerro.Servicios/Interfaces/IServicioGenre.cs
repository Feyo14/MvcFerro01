using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioGenre
    {
        IEnumerable<Genres>? GetAll(Expression<Func<Genres, bool>>? filter = null,
          Func<IQueryable<Genres>, IOrderedQueryable<Genres>>? orderBy = null,
          string? propertiesNames = null);
        List<Genres> GetLista();
        void Agregar(Genres genre);
        void Borrar(Genres genre);
        void Editar(Genres genre);
        public bool existe(Genres b);
        Genres? GetGenrePorId(int b);
        Genres? GetPorName(string nombre);


    }
}
