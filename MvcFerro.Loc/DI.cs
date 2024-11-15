using EFCore3.DATOS.Repositorio;
using EFCore3.Servicios.Servicios;
using EFCoresFerro.DATOS.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcFerro.Datos;
using MvcFerro.Datos.Interfaces;
using MvcFerro.Servicios.Interfaces;

namespace MvcFerro.Loc;
public static class DI
    {
        public static IServiceProvider ConfigurarServicios()
        {
            var servicios = new ServiceCollection();

            servicios.AddScoped<IRepositorioBrands,
                RepositorioBrands>();
            servicios.AddScoped<IRepositorioGenre, 
                RepositorioGenre>(); 
            servicios.AddScoped<IRepositorioSports,RepositorioSports>();
        servicios.AddScoped<IRepositorioColors, RepositorioColors>();
        servicios.AddScoped<IRepositorioShoes, RepositorioShoes>();

       
        servicios.AddScoped<IRepositorioShoeSize, RepositorioShoeSize>();
        servicios.AddScoped<IRepositorioSize, RepositorioSize>();



        servicios.AddScoped<IServicioBrands,
                ServicioBrands>();
            servicios.AddScoped<IServicioGenre, ServicioGenre>();
            servicios.AddScoped<IServicioSports, ServicioSports>();
        servicios.AddScoped<IServicioColors, ServicioColors>();
        servicios.AddScoped<IServicioShoes, ServicioShoes>();


        
        servicios.AddScoped<IServicioShoeSize, ServicioShoeSize>();
        servicios.AddScoped<IServicioSize, ServicioSize>();


        servicios.AddScoped<IUnitOfWork, UnitOfWork>();


        servicios.AddDbContext<EFCoresDbContext>(optiones =>
            {
                optiones.UseSqlServer(@"Data Source=.; 
                        Initial Catalog=EFCoresFerro; 
                        Trusted_Connection=true; 
                        TrustServerCertificate=true;");
            });

            return servicios.BuildServiceProvider();
        }
    public static void  ConfigurarServiciosWeb(IServiceCollection servicios, IConfiguration configuration)
    {

        servicios.AddScoped<IRepositorioBrands,
            RepositorioBrands>();
        servicios.AddScoped<IRepositorioGenre,
            RepositorioGenre>();
        servicios.AddScoped<IRepositorioSports, RepositorioSports>();
        servicios.AddScoped<IRepositorioColors, RepositorioColors>();
        servicios.AddScoped<IRepositorioShoes, RepositorioShoes>();

        
        servicios.AddScoped<IRepositorioShoeSize, RepositorioShoeSize>();
        servicios.AddScoped<IRepositorioSize, RepositorioSize>();



        servicios.AddScoped<IServicioBrands,
                ServicioBrands>();
        servicios.AddScoped<IServicioGenre, ServicioGenre>();
        servicios.AddScoped<IServicioSports, ServicioSports>();
        servicios.AddScoped<IServicioColors, ServicioColors>();
        servicios.AddScoped<IServicioShoes, ServicioShoes>();


       
        servicios.AddScoped<IServicioShoeSize, ServicioShoeSize>();
        servicios.AddScoped<IServicioSize, ServicioSize>();


        servicios.AddScoped<IUnitOfWork, UnitOfWork>();


        servicios.AddDbContext<EFCoresDbContext>(optiones =>

        {
            optiones.UseSqlServer(@"Data Source=.; 
                        Initial Catalog=EFCoresFerro; 
                        Trusted_Connection=true; 
                        TrustServerCertificate=true;");
        });

    }

}

