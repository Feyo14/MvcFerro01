






using   MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioColors
    {
        IEnumerable<Colors>? GetAll(Expression<Func<Colors, bool>>? filter = null,
      Func<IQueryable<Colors>, IOrderedQueryable<Colors>>? orderBy = null,
      string? propertiesNames = null);
        List<Colors> GetLista();
        void Agregar(Colors color);
        void Borrar(Colors color);
        void Editar(Colors color);
        public bool existe(Colors b);
        Colors? GetColorsPorId(int b);
    }
}
