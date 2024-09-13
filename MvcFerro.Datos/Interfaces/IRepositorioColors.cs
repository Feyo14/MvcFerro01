

using MvcFerro.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioColors
    {
        List<Colors> GetLista();
        void Agregar(Colors colors);
        void Borrar(Colors colors);
        void Editar(Colors colors);
        public bool existe(Colors colors);
        Colors? GetColorsPorId(int b);
        IEnumerable<Colors>? GetAll(Expression<Func<Colors, bool>>? filter, Func<IQueryable<Colors>, IOrderedQueryable<Colors>>? orderBy, string? propertiesNames);

    }
}
