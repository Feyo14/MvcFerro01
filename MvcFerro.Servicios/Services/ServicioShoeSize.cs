using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;
using MvcFerro.Servicios.Interfaces;

namespace EFCore3.Servicios.Servicios
{
    public class ServicioShoeSize : IServicioShoeSize
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioShoeSize repo;
private readonly EFCoresDbContext _dbContext;
    

        public ServicioShoeSize(IRepositorioShoeSize repositor, IUnitOfWork unitOfWork)
        {
            repo = repositor ?? throw new ArgumentNullException(nameof(repositor));
            _unitOfWork = unitOfWork;
            _dbContext = new EFCoresDbContext();
        }
        public void Agregar(ShoeSize shoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (shoe.ShoeSizeId == 0)
                {
                    shoe.Size = null;
                    shoe.Shoe = null;
                 
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

        public void Borrar(ShoeSize s)
        {
            _unitOfWork.BeginTransaction();

            ShoeSize gInDb = repo.GetShoeSizePorId(s.ShoeSizeId);
            if (gInDb != null)
            {
                string tex = s.Shoe.Descripcion;
                s.Size = null;
                s.Shoe = null;
              
                repo.Borrar(gInDb);
                _unitOfWork.SaveChanges(); // Guardar cambios para confirmar eliminación 

                _unitOfWork.Commit(); // Confirmar los cambios
                Console.WriteLine($"Shoe:  {tex} borrado!!!");
            }
            else
            {
                _unitOfWork.Rollback();

                Console.WriteLine("ID de Shoe no existente!!!");
            }
        }

        public void Editar(ShoeSize s)
        {
            _unitOfWork.BeginTransaction();
          
            repo.Editar(s);
            _unitOfWork.Commit();

        }

        public bool existe(ShoeSize d)
        {
            return repo.existe(d);
        }

        public List<ShoeSize> GetLista()
        {
            
                return repo.GetLista(); 
            
        }

        public ShoeSize? GetShoeSizePorId(int id)
        {
          return   repo.GetShoeSizePorId(id);        }
    }

     //   public Paise GetPaisporId(int paisId)
      //  {
          //  throw new NotImplementedException();
       // }
    }
