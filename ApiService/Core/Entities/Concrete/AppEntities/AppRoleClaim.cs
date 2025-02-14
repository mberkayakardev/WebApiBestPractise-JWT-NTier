using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Abstract;
using Entities.Concrete.AppEntities;

namespace Core.Entities.Concrete.AppEntities
{
    public class AppRoleClaim : BaseEntity
    {
        public int ClaimId { get; set; }

        public int RoleId { get; set; }

        #region Navigation Property
        public AppRole AppRoles { get; set; } 
        public AppClaim AppClaims{ get; set; } 
        #endregion

    }
}
