using Core.Entities.Abstract;
using Core.Entities.Concrete.AppEntities;

namespace Entities.Concrete.AppEntities
{
    public class AppClaim : BaseEntity
    {
        public string ClaimName { get; set; }
        public string ClaimDescription { get; set; }

        #region Navigation Property
        public List<AppUserClaims> AppUserClaims { get; set; }
        public List<AppRoleClaim> AppRoleClaims { get; set; }
        public List<AppMenus> AppMenus { get; set; }
        #endregion

    }
}
