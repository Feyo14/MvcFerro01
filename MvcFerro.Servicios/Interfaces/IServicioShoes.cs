
using MvcFerro01.Entidades;
using System.Linq.Expressions;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioShoes
    {
        IEnumerable<Shoes>? GetAll(Expression<Func<Shoes, bool>>? filter = null,
      Func<IQueryable<Shoes>, IOrderedQueryable<Shoes>>? orderBy = null,
      string? propertiesNames = null);
        List<Shoes> GetLista();
        void Agregar(Shoes shoe);
        void Borrar(Shoes shoe);
        void Editar(Shoes shoe);
        Shoes? GetShoePorId(int id);
        public bool existe(Shoes d);
        Shoes? GetPorName(string descrip);
        public bool existeShoeSize(int s);
        Shoes? Get(Expression<Func<Shoes, bool>> filter,
            string? propertiesNames = null,
            bool tracked = true);
    }
}
