

using MvcFerro01.Entidades;

namespace MvcFerro.Datos.Interfaces
{
    public interface IRepositorioSize
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

    }
}
