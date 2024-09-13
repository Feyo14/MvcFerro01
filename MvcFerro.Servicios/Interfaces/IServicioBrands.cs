using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioBrands
    {
        IEnumerable<Brands>? GetAll(Expression<Func<Brands, bool>>? filter = null,
          Func<IQueryable<Brands>, IOrderedQueryable<Brands>>? orderBy = null,
          string? propertiesNames = null);
        List<Brands> GetLista();
        void Agregar(Brands brands);
        void Borrar(Brands brands);
        void Editar(Brands brands);
        public bool existe(Brands b);
        Brands? GetBrandsPorId(int b);
        Brands? GetPorName(string nombre);

    }
}
