
using EFCoresFerro.DATOS.Repositorio;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro.Entidades;
using MvcFerro.Servicios.Interfaces;
using System.Linq.Expressions;

namespace EFCore3.Servicios.Servicios
{
    public class ServicioBrands : IServicioBrands
    {
        private readonly EFCoresDbContext context;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepositorioBrands repo;
        public ServicioBrands()
        {
            context=new EFCoresDbContext();
            repo = new RepositorioBrands(context);
        }
        public void Agregar(Brand brands)
        {
            try
            {
                if (brands.BrandId == 0)
                {
                    repo.Agregar(brands);
                }
                else
                {
                    repo.Editar(brands);
                }
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Borrar(Brand Brand)
        {
            var BrandInDb = context.Brands.Find(Brand.BrandId);
            if (BrandInDb != null)
            {
                context.Brands.Remove(BrandInDb);
                context.SaveChanges();
                Console.WriteLine($"Autor {BrandInDb.BrandName} borrado!!!");
            }
            else
            {
                Console.WriteLine("ID de autor no existente!!!");
            }
        }

        public void Editar(Brand pais)
        {
            throw new NotImplementedException();
        }
        public bool existe(Brand b)
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


        public List<Brand> GetLista()
        {
            
                return repo.GetLista(); 
            


        }
        public Brand? GetBrandsPorId(int b)
        {
            return repo.GetBrandsPorId(b);
        }

        public Brand? GetPorName(string nombre)
        {
            return repo.GetPorName(nombre);
        }

        public IEnumerable<Brand>? GetAll(Expression<Func<Brand, bool>>? filter = null, Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? orderBy = null, string? propertiesNames = null)
        {
            return repo!.GetAll(filter, orderBy, propertiesNames);
        }
    }

     //   public Paise GetPaisporId(int paisId)
      //  {
          //  throw new NotImplementedException();
       // }
    }
