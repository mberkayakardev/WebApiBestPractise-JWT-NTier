namespace TrendMusic.ECommerce.Core.Utilities.Results.BaseResult
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
