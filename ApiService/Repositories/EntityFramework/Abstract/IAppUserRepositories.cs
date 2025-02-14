using ApiService.Entities.Concrete.AppEntities;
using Core.Repositories.EntityFramework.Abstract;

namespace QuizApp.Repositories.EntityFramework.Abstract
{
    public interface IAppUserRepositories : IEfGenericRepositories<AppUser>
    {

    }
}
