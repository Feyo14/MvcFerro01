﻿
using EFCoresFerro.Datos;
using EFCoresFerro.Datos.Repositorio;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro01.Entidades;

namespace EFCore3.DATOS.Repositorio
{
    public class RepositorioSports : GenericRepository<Sports>, IRepositorioSports
    {
        private readonly EFCoresDbContext context;

        public RepositorioSports(EFCoresDbContext db) : base(db)
        {
            context = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Agregar(Sports sports)
        {
            context.Sports.Add(sports);
        }

        public void Borrar(Sports sports)
        {
            context.Sports.Remove(sports);
        }

        public void Editar(Sports sports)
        {
            context.Sports.Update(sports);      
        }

        public bool existe(Sports brand)
        {

            if (brand.SportId == 0)
            {
                return context.Sports.Any(p => p.SportName == brand.SportName);
            }
            else
            {
                return context.Sports.Any(p => p.SportName == brand.SportName && p.SportId != brand.SportId);
            }
        }

        public List<Sports> GetLista()
        {
            return context.Sports
                
                .ToList();
        }

        public Sports? GetSportsPorId(int b)
        {
            return context.Sports
                 .FirstOrDefault(t => t.SportId == b);
        }
        public Sports? GetPorName(string nombre)
        {
            return context.Sports
                         .FirstOrDefault(te => te.SportName == nombre);
        }
    }
}
