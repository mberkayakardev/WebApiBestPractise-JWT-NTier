using Core.Entities.Abstract;
using Core.Entities.Concrete.AppEntities;
using Entities.Concrete.AppEntities;

namespace ApiService.Entities.Concrete.AppEntities
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string NormalizedUserName {  get; set; }
        public string UserEmail { get; set; }
        public string NormalizedUserEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string UserFullName { get; set; }
        public string UserPassword { get; set; }
        public bool IsBlocked { get; set; }
        public int FalseEntryCount { get; set; }



        #region Navigation Property
        public AppToken UserToken { get; set; }
        public List<AppUserClaims> AppUserClaims { get; set; }
        public List<AppUserRoles> AppUserRoles { get; set; }
        #endregion


    }
}
