
using MvcFerro.Entidades;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioSports
    {
        List<Sports> GetLista();
        void Agregar(Sports sports);
        void Borrar(Sports sports);
        void Editar(Sports sports);
        public bool existe(Sports b);
        Sports? GetSportsPorId(int b);
        Sports? GetPorName(string nombre);

    }
}
