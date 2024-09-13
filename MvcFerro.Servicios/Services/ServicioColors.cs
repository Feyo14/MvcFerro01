using EFCore3.DATOS.Repositorio;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;
using MvcFerro.Servicios.Interfaces;
using System.Linq.Expressions;

namespace EFCore3.Servicios.Servicios
{
    public class ServicioColors : IServicioColors
    {
        private readonly EFCoresDbContext context;
        private readonly IRepositorioColors repo;
        public ServicioColors()
        {
            context=new EFCoresDbContext();
            repo = new RepositorioColors(context);
        }
        public void Agregar(Colors c)
        {
            try
            {
                if (c.ColorId == 0)
                {
                    repo.Agregar(c);
                }
                else
                {
                    repo.Editar(c);
                }
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Borrar(Colors col)
        {

            var colorInDb = context.Colors.Find(col.ColorId);
            if (colorInDb != null)
            {
                context.Colors.Remove(colorInDb);
                context.SaveChanges();
                Console.WriteLine($"Color:  {colorInDb.ColorName} borrado!!!");
            }
            else
            {
                Console.WriteLine("ID de Color no existente!!!");
            }
        }

        public void Editar(Colors b)
        {
            throw new NotImplementedException();

        }

        public bool existe(Colors b)
        {
            try
            {
                return repo.existe(b);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Colors? GetColorsPorId(int b)
        {
            return repo.GetColorsPorId(b);
        }

        public List<Colors> GetLista()
        {
            
                return repo.GetLista(); 
            


        }
        public IEnumerable<Colors>? GetAll(Expression<Func<Colors, bool>>? filter = null, Func<IQueryable<Colors>, IOrderedQueryable<Colors>>? orderBy = null, string? propertiesNames = null)
        {
            return repo!.GetAll(filter, orderBy, propertiesNames);
        }


    }

     //   public Paise GetPaisporId(int paisId)
      //  {
          //  throw new NotImplementedException();
       // }
    }
