using EFCore3.DATOS.Repositorio;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;
using MvcFerro.Servicios.Interfaces;
using System.Linq.Expressions;

namespace EFCore3.Servicios.Servicios
{
    public class ServicioSize :  IServicioSize
    {
        private readonly EFCoresDbContext context;
        private readonly IRepositorioSize repo;
        public ServicioSize()
        {
            context=new EFCoresDbContext();
            repo = new RepositorioSize(context);
        }

        public Size? Get(Expression<Func<Size, bool>> filter, string? propertiesNames = null, bool tracked = true)
        {
            if (repo == null)
            {
                throw new ApplicationException("Dependency not set");
            }

            return repo.Get(filter, propertiesNames, tracked);
        }

        public IEnumerable<Size>? GetAll(Expression<Func<Size, bool>>? filter = null, Func<IQueryable<Size>, IOrderedQueryable<Size>>? orderBy = null, string? propertiesNames = null)
        {
            return repo!.GetAll(filter, orderBy, propertiesNames);
        }

        public List<Size> GetLista()
        {
            
                return repo.GetLista(); 
            


        }

        public Size? GetPorName(decimal descrip)
        {
            return repo.GetPorName(descrip);
        }
    }

     //   public Paise GetPaisporId(int paisId)
      //  {
          //  throw new NotImplementedException();
       // }
    }
