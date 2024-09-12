
using MvcFerro.Entidades;

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


    }
}
