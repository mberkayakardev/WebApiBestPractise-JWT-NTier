using Core.Entities.Abstract;
using Entities.Concrete.AppEntities;

namespace Core.Entities.Concrete.AppEntities
{
    
    public class AppRole: BaseEntity
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        #region Navigation Property
        public List<AppUserRoles> AppUserRoles { get; set; }
        public List<AppRoleClaim> AppRoleClaims { get; set; }

        #endregion
    }
}
