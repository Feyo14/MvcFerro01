using MvcFerro.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioBrands
    {
        List<Brand> GetLista();
        void Agregar(Brand brands);
        void Borrar(Brand brands);
        void Editar(Brand brands);
        public bool existe(Brand brands);
        Brand? GetBrandsPorId(int BrandsId);
        Brand? GetPorName(string nombre);
        IEnumerable<Brand>? GetAll(Expression<Func<Brand, bool>>? filter, Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? orderBy, string? propertiesNames);
    }
}
