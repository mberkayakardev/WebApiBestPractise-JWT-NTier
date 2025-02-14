
using ApiService.Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuizApp.Repositories.EntityFramework.Concrete.EntityConfigurations.AppEntities
{
    public class AppUserSeeds : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            
        }
    }
}
