
using EFCoresFerro.Datos;
using EFCoresFerro.Datos.Repositorio;
using Microsoft.EntityFrameworkCore;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;
using System;
using System.Numerics;

namespace EFCore3.DATOS.Repositorio
{
    public class RepositorioShoeSize : GenericRepository<ShoeSize>, IRepositorioShoeSize
    {
        private readonly EFCoresDbContext context;

        public RepositorioShoeSize(EFCoresDbContext db) : base(db)
        {
            context = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Agregar(ShoeSize shoes)
        {
            context.ShoeSize.Add(shoes);
        }

        public void Borrar(ShoeSize shoe)
        {
            context.ShoeSize.Remove(shoe);
        }

        public void Editar(ShoeSize shoe)
        {
            int stock = shoe.QuantityInStock;

            var s = context.ShoeSize
        .FirstOrDefault(t => t.ShoeSizeId == shoe.ShoeSizeId);
            var Sho = context.Shoes
        .FirstOrDefault(t => t.ShoeId == shoe.ShoeId);
            var size = context.Size
              .FirstOrDefault(t => t.SizeId == shoe.SizeId);
     
            /*
        
            */
            if (s != null)
            {
                context.Attach(s);
                shoe = s;

            }
            if (Sho != null)
            {
                context.Attach(Sho);
                s.Shoe = Sho;

            }
            if (size != null)
            {
                context.Attach(size);
                s.Size = size;

            }
            s.QuantityInStock = stock;
            context.ShoeSize.Update(s);      
        }

        public bool existe(ShoeSize d)
        {
            if (d.ShoeSizeId == 0)
            {
                return context.ShoeSize.Any(

               p => p.ShoeId == d.ShoeId &&
                    p.SizeId == d.SizeId);
            }
            else
            {
                return context.ShoeSize.Any(
                     p => p.ShoeSizeId == d.ShoeSizeId);
                      //  p.SizeId == d.SizeId);
             //  p.ShoeSizeId != p.ShoeSizeId);
            }
        }

        public List<ShoeSize> GetLista()
        {
            return context.ShoeSize
                .Include(p => p.Shoe)
                .Include(p => p.Size)
                          .AsNoTracking()
                .ToList();
        
        }

        public ShoeSize? GetShoeSizePorId(int id)
        {
            return context.ShoeSize
                                .FirstOrDefault(t => t.ShoeSizeId == id);
        }
    }
}
