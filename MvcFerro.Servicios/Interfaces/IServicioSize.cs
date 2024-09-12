using MvcFerro.Entidades;

namespace MvcFerro.Servicios.Interfaces
{
    public interface IServicioSize
    {
        List<Size> GetLista();
        Size? GetPorName(decimal descrip);

    }
}
