using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Core.Entities.Abstract
{
    public interface IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedUserId { get; set; }
        public string? CreatedUserName { get; set; }
        public int ModifiedUserId { get; set; }
        public string? ModifiedUserName { get; set; }
    }
}
