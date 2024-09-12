using Microsoft.EntityFrameworkCore;
using EFCoresFerro.Datos.Repositorio;
using MvcFerro.Entidades;
using MvcFerro.Datos.Interfaces;
using MvcFerro.Datos;

namespace EFCoresFerro.DATOS.Repositorio
{
    public class RepositorioBrands : GenericRepository<Brand>, IRepositorioBrands
    {
        private readonly EFCoresDbContext context;

        public RepositorioBrands(EFCoresDbContext db):base(db)
        {
            context = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Agregar(Brand brands)
        {
            context.Brands.Add(brands);
        }

        public void Borrar(Brand brands)
        {
            context.Brands.Remove(brands);
        }
        public bool existe(Brand brand)
        {
            if (brand.BrandId == 0)
            {
                return context.Brands.Any(p => p.BrandName == brand.BrandName);
            }
            else
            {
                return context.Brands.Any(p => p.BrandName == brand.BrandName && p.BrandId != brand.BrandId);
            }

        }
        public void Editar(Brand brands)
        {
            context.Brands.Update(brands);      
        }

        
        public List<Brand> GetLista()
        {
            return context.Brands
                .OrderBy(p=>p.BrandName)
                                .AsNoTracking()

                .ToList();
        }
        public Brand? GetBrandsPorId(int b)
        {
            return context.Brands
                 .FirstOrDefault(t => t.BrandId == b);
        }
        public Brand? GetPorName(string nombre)
        {
            return context.Brands
                         .FirstOrDefault(te => te.BrandName == nombre);
        }


    }
}
