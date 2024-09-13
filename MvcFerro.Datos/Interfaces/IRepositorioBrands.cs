using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioBrands
    {
        List<Brands> GetLista();
        void Agregar(Brands brands);
        void Borrar(Brands brands);
        void Editar(Brands brands);
        public bool existe(Brands brands);
        Brands? GetBrandsPorId(int BrandsId);
            Brands? GetPorName(string nombre);
        IEnumerable<Brands>? GetAll(Expression<Func<Brands, bool>>? filter, Func<IQueryable<Brands>, IOrderedQueryable<Brands>>? orderBy, string? propertiesNames);
    }
}
