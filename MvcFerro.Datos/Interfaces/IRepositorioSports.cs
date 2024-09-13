
using MvcFerro.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioSports
    {
        List<Sports> GetLista();
        void Agregar(Sports sport);
        void Borrar(Sports sport);
        void Editar(Sports sport);

        public bool existe(Sports brand);
        Sports? GetSportsPorId(int b);
        Sports? GetPorName(string nombre);
        IEnumerable<Sports>? GetAll(Expression<Func<Sports, bool>>? filter, Func<IQueryable<Sports>, IOrderedQueryable<Sports>>? orderBy, string? propertiesNames);


    }
}
