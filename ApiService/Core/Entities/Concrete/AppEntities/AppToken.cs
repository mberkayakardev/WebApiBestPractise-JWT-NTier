using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Abstract;

namespace Entities.Concrete.AppEntities
{
    public class AppToken : BaseEntity
    {
        public int AppUserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsUsed { get; set; }

        #region Navigation Property
        public AppUser AppUser { get; set; }
        #endregion

    }
}
