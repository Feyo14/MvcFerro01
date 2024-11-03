

using EFCoresFerro.Datos.Interfaces;
using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioSize : IGenericRepository<Size>
    {
        List<Size> GetLista();
        Size? GetPorName(decimal descrip);

        /*
                void Agregar(Genre genre);
                void Borrar(Genre genre);
                void Editar(Genre genre);
                public bool existe(Genre genre);
                Genre? GetGenrePorId(int genreid);
                Genre? GetPorName(string nombre);
                */
        IEnumerable<Size>? GetAll(Expression<Func<Size, bool>>? filter, Func<IQueryable<Size>, IOrderedQueryable<Size>>? orderBy, string? propertiesNames);

    }
}
