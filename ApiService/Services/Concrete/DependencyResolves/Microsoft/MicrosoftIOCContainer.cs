using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Repositories.EntityFramework.Concrete.Contexts;
using QuizApp.Repositories.EntityFramework.Concrete.UnitOfWorks;
using System.Reflection;

namespace ApiService.Services.Concrete.DependencyResolves.Microsoft
{
    public static class MicrosoftIOCContainer
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);

            AddConfiguration(services, configuration);

            AddServices(services, configuration);

            AddUnitOfWork(services, configuration);

            AddAutoMapper(services, configuration);

            AddFluentValidation(services, configuration);
        
        }

     
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
        }

        private static void AddServices(IServiceCollection services, IConfiguration configuration)
        {

        }

        private static void AddAutoMapper(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        private static void AddFluentValidation(IServiceCollection services, IConfiguration configuration)
        {

        }

        private static void AddConfiguration(IServiceCollection services, IConfiguration configuration)
        {
        }

        private static void AddUnitOfWork(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}
