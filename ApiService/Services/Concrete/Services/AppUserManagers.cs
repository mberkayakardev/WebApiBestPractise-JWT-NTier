using AutoMapper;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Services.Abstract.Base;

namespace QuizApp.Services.Concrete.Services
{
    public class AppUserManagers : BaseServices
    {
        public AppUserManagers(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }


    }
}
