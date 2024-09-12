
using MvcFerro.Entidades;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioShoeSize
    {
        List<ShoeSize> GetLista();
        void Agregar(ShoeSize shoesize);
        void Borrar(ShoeSize shoeSize);
        void Editar(ShoeSize shoeSize);
        ShoeSize? GetShoeSizePorId(int id);
        public bool existe(ShoeSize d);

    }
}
