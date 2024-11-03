





using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioShoeSize
    {
        List<ShoeSize> GetLista();
        void Agregar(ShoeSize shoe);
        void Borrar(ShoeSize shoe);
        void Editar(ShoeSize shoe);
        ShoeSize? GetShoeSizePorId(int id);
        public bool existe(ShoeSize d);
        IEnumerable<ShoeSize>? GetAll(Expression<Func<ShoeSize, bool>>? filter = null,
 Func<IQueryable<ShoeSize>, IOrderedQueryable<ShoeSize>>? orderBy = null,
 string? propertiesNames = null);

        ShoeSize? Get(Expression<Func<ShoeSize, bool>> filter,
          string? propertiesNames = null,
          bool tracked = true);
    }
}
