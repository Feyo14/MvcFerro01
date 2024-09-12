

using MvcFerro.Entidades;

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



    }
}
