using MvcFerro.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioGenre
    {
        List<Genre> GetLista();
        void Agregar(Genre genre);
        void Borrar(Genre genre);
        void Editar(Genre genre);
        public bool existe(Genre genre);
        Genre? GetGenrePorId(int genreid);
        Genre? GetPorName(string nombre);

        IEnumerable<Genre>? GetAll(Expression<Func<Genre, bool>>? filter, Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy, string? propertiesNames);



    }
}
