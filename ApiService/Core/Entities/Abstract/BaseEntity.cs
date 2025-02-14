
namespace Core.Entities.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get ; set ; }
        public bool IsActive { get ; set ; }
        public DateTime? CreatedDate { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; } = DateTime.Now;
        public int CreatedUserId { get ; set ; }
        public string? CreatedUserName { get ; set ; }
        public int ModifiedUserId { get ; set ; }
        public string? ModifiedUserName { get ; set ; }
    }
}
