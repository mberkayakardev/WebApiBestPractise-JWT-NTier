namespace Core.Dtos.Abstract
{
    public class BaseUpdateDtos : BaseDtos, IUpdateDtos
    {
        public int Id { get; set; }
    }
}
