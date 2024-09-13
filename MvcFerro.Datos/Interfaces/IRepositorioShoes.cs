

using MvcFerro.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioShoes
    {
        List<Shoes> GetLista();
        void Agregar(Shoes shoe);
        void Borrar(Shoes shoe);
        void Editar(Shoes shoe);
        Shoes? GetShoePorId(int id);
        public bool existe(Shoes d);
        Shoes? GetPorName(string descrip);
        public bool existeShoeSize(int s);
        IEnumerable<Shoes>? GetAll(Expression<Func<Shoes, bool>>? filter, Func<IQueryable<Shoes>, IOrderedQueryable<Shoes>>? orderBy, string? propertiesNames);




    }
}
