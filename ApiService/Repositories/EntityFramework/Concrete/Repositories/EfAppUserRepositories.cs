using ApiService.Entities.Concrete.AppEntities;
using Core.Repositories.EntityFramework.Concrete;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Repositories.EntityFramework.Concrete.Contexts;

namespace QuizApp.Repositories.EntityFramework.Concrete.Repositories
{
    public class EfAppUserRepositories : EfGenericRepositories<AppUser>, IAppUserRepositories
    {
        public EfAppUserRepositories(AppDbContext context) : base(context)
        {

        }
    }
}
