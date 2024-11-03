using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioSize
    {
        List<Size> GetLista();
        Size? GetPorName(decimal descrip);

        IEnumerable<Size>? GetAll(Expression<Func<Size, bool>>? filter = null,
    Func<IQueryable<Size>, IOrderedQueryable<Size>>? orderBy = null,
    string? propertiesNames = null);

        Size? Get(Expression<Func<Size, bool>> filter,
           string? propertiesNames = null,
           bool tracked = true);

    }
}
