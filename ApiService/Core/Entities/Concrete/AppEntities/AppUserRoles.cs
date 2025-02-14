using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete.AppEntities
{
    public class AppUserRoles : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        #region Navigation Property
        public AppUser AppUser { get; set; }
        public AppRole Role { get; set; }   
        #endregion

    }
}
