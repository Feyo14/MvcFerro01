using EFCoresFerro.Datos.Repositorio;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;

namespace EFCore3.DATOS.Repositorio
{
    public class RepositorioSize : GenericRepository<Size>, IRepositorioSize
    {
        private readonly EFCoresDbContext context;

        public RepositorioSize(EFCoresDbContext db) : base(db)
        {
            context = db ?? throw new ArgumentNullException(nameof(db));
        }

        public List<Size> GetLista()
        {
            return context.Size
            //    .OrderBy(p=>p.size)
                .ToList();
        }

        public Size? GetPorName(decimal descrip)
        {
            return context.Size
                                                .FirstOrDefault(te => te.sizeNumber == descrip);
        }
    }
}
