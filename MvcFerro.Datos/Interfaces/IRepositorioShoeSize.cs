
using EFCoresFerro.Datos.Interfaces;
using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioShoeSize : IGenericRepository<ShoeSize>
    {
        List<ShoeSize> GetLista();
        void Agregar(ShoeSize shoesize);
        void Borrar(ShoeSize shoeSize);
        void Editar(ShoeSize shoeSize);
        ShoeSize? GetShoeSizePorId(int id);
        public bool existe(ShoeSize d);
        IEnumerable<ShoeSize>? GetAll(Expression<Func<ShoeSize, bool>>? filter, Func<IQueryable<ShoeSize>, IOrderedQueryable<ShoeSize>>? orderBy, string? propertiesNames);


    }
}
