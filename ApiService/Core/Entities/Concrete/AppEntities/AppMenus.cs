using Core.Entities.Abstract;
using Entities.Concrete.AppEntities;

namespace Core.Entities.Concrete.AppEntities
{
    public class AppMenus : BaseEntity
    {
        public int AppId { get; set; }
        public string MenuName {  get; set; }
        public string MenuDescription { get; set; }

        #region Navigation Property
        public AppClaim AppClaim { get; set; }  
        public AppApplications AppApplications{ get; set; }
        #endregion

    }
}
