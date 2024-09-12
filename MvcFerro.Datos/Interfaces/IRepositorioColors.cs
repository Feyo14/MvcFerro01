

using MvcFerro.Entidades;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioColors
    {
        List<Colors> GetLista();
        void Agregar(Colors colors);
        void Borrar(Colors colors);
        void Editar(Colors colors);
        public bool existe(Colors colors);
        Colors? GetColorsPorId(int b);
    }
}
