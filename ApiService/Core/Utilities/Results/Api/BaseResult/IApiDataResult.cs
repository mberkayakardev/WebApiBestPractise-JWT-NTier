namespace Core.Utilities.Results.MVC.BaseResult
{
    public interface IApiDataResult<T> : IApiResult
    {
        T Data { get; }


    }
}
