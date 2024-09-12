using MvcFerro.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioBrands
    {
        IEnumerable<Brand>? GetAll(Expression<Func<Brand, bool>>? filter = null,
          Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? orderBy = null,
          string? propertiesNames = null);
        List<Brand> GetLista();
        void Agregar(Brand brands);
        void Borrar(Brand brands);
        void Editar(Brand brands);
        public bool existe(Brand b);
        Brand? GetBrandsPorId(int b);
        Brand? GetPorName(string nombre);

    }
}
