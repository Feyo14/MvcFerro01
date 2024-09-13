using EFCore3.DATOS.Repositorio;
using Microsoft.EntityFrameworkCore;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;
using MvcFerro.Servicios.Interfaces;
using System.Linq.Expressions;
using NuGet.Protocol.Core.Types;

namespace EFCore3.Servicios.Servicios
{
    public class ServicioShoes : IServicioShoes
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioShoes repo;
private readonly EFCoresDbContext _dbContext;

        public ServicioShoes()
        {
            _dbContext = new EFCoresDbContext();
            repo = new RepositorioShoes(_dbContext);
        }

        public ServicioShoes(IRepositorioShoes repositor)
        {
            _dbContext = new EFCoresDbContext();
            repo = repositor ?? throw new ArgumentNullException(nameof(repositor));

        }

        public ServicioShoes(IRepositorioShoes repositor, IUnitOfWork unitOfWork)
        {
            repo = repositor ?? throw new ArgumentNullException(nameof(repositor));
            _unitOfWork = unitOfWork;
            _dbContext = new EFCoresDbContext();
        }
        public void Agregar(Shoes shoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (shoe.ShoeId == 0)
                {
                    shoe.Genre = null;
                    shoe.Sport = null;
                    shoe.Brand = null;
                    repo.Agregar(shoe);
                   _unitOfWork.SaveChanges(); // Guardar cambios para obtener el id de la planta agregada

                }
                else
                {
                    repo.Editar(shoe);
                    _unitOfWork.SaveChanges(); // Guardar cambios para obtener el id de la planta agregada

                }
                 _unitOfWork.SaveChanges(); // Guardar todos los cambios al final
                 _unitOfWork.Commit(); // Confirmar los cambios
               // _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Borrar(Shoes s)
        {
            _unitOfWork.BeginTransaction();

            Shoes gInDb = repo.GetShoePorId(s.ShoeId);
            if (gInDb != null)
            {
                s.Sport = null;
                s.Genre = null;
                s.Brand = null;
                repo.Borrar(gInDb);
                _unitOfWork.SaveChanges(); // Guardar cambios para confirmar eliminación 

                _unitOfWork.Commit(); // Confirmar los cambios
                Console.WriteLine($"Shoe:  {gInDb.Descripcion} borrado!!!");
            }
            else
            {
                _unitOfWork.Rollback();

                Console.WriteLine("ID de Shoe no existente!!!");
            }
        }

        public void Editar(Shoes s)
        {
            _unitOfWork.BeginTransaction();
          
            repo.Editar(s);
            _unitOfWork.Commit();

        }

        public bool existe(Shoes d)
        {
            return repo.existe(d);
        }

        public bool existeShoeSize(int s)
        {
            return repo.existeShoeSize(s);
        }

        public List<Shoes> GetLista()
        {
            
                return repo.GetLista(); 
            
        }

        public Shoes? GetPorName(string descrip)
        {
            return repo.GetPorName(descrip);
                }

        public Shoes? GetShoePorId(int id)
        {
          return   repo.GetShoePorId(id);    
        }
        public IEnumerable<Shoes>? GetAll(Expression<Func<Shoes, bool>>? filter = null, Func<IQueryable<Shoes>, IOrderedQueryable<Shoes>>? orderBy = null, string? propertiesNames = null)
        {
            return repo!.GetAll(filter, orderBy, propertiesNames);
        }

        public Shoes? Get(Expression<Func<Shoes, bool>> filter, string? propertiesNames = null, bool tracked = true)
        {
            if (repo == null)
            {
                throw new ApplicationException("Dependency not set");
            }

            return repo.Get(filter, propertiesNames, tracked);
        }
    }

  
    }
