using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Abstract;

namespace Entities.Concrete.AppEntities
{
    public class AppUserClaims : BaseEntity
    {
        public int UserId { get; set; }

        public int ClaimId { get; set; }

        #region Navigation Property
        public AppUser AppUser { get; set; }
        public AppClaim AppClaim { get; set; }
        #endregion
    }
}
