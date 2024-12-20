﻿using EFCoresFerro.Datos.Repositorio;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;

namespace EFCore3.DATOS.Repositorio
{
    public class RepositorioColors : GenericRepository<Colors>, IRepositorioColors
    {
        private readonly EFCoresDbContext context;

        public RepositorioColors(EFCoresDbContext db) : base(db)
        {
            context = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Agregar(Colors colors)
        {
            context.Colors.Add(colors);
        }

        public void Borrar(Colors colors)
        {
            context.Colors.Remove(colors);
        }

        public void Editar(Colors colors)
        {
            context.Colors.Update(colors);      
        }

        public bool existe(Colors colors)
        {
              if (colors.ColorId == 0)
            {
                return context.Colors.Any(p => p.ColorName == colors.ColorName);
            }
            else
            {
                return context.Colors.Any(p => p.ColorName == colors.ColorName && p.ColorId != colors.ColorId);
            }
        }

        public Colors? GetColorsPorId(int b)
        {
            return context.Colors
               .FirstOrDefault(t => t.ColorId == b);
        }

        public List<Colors> GetLista()
        {
            return context.Colors
                .OrderBy(p=>p.ColorName)
                .ToList();
        }
         
       
    }
}
