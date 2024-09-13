using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioGenre
    {
        List<Genres> GetLista();
        void Agregar(Genres genre);
        void Borrar(Genres genre);
        void Editar(Genres genre);
        public bool existe(Genres genre);
        Genres? GetGenrePorId(int genreid);
        Genres? GetPorName(string nombre);

        IEnumerable<Genres>? GetAll(Expression<Func<Genres, bool>>? filter, Func<IQueryable<Genres>, IOrderedQueryable<Genres>>? orderBy, string? propertiesNames);



    }
}
