
using MvcFerro.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioSports
    {
        IEnumerable<Sports>? GetAll(Expression<Func<Sports, bool>>? filter = null,
      Func<IQueryable<Sports>, IOrderedQueryable<Sports>>? orderBy = null,
      string? propertiesNames = null);
        List<Sports> GetLista();
        void Agregar(Sports sports);
        void Borrar(Sports sports);
        void Editar(Sports sports);
        public bool existe(Sports b);
        Sports? GetSportsPorId(int b);
        Sports? GetPorName(string nombre);

    }
}
