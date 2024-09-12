using MvcFerro.Entidades;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioGenre
    {
        List<Genre> GetLista();
        void Agregar(Genre genre);
        void Borrar(Genre genre);
        void Editar(Genre genre);
        public bool existe(Genre b);
        Genre? GetGenrePorId(int b);
        Genre? GetPorName(string nombre);

    }
}
