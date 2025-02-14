using Core.Utilities.Results.MVC.ComplexTypes;
using TrendMusic.ECommerce.Core.Extentions.ComplexTypes;

namespace Core.Utilities.Results.MVC.BaseResult
{
    public class ApiDataResult<T> : ApiResult, IApiDataResult<T>
    {
        public ApiDataResult(T data, ApiResultStatus status, string Messages) : base(status, Messages)
        {
            Data = data;
        }
        public ApiDataResult(T data, ApiResultStatus status) : base(status)
        {
            Data = data;

        }
        public ApiDataResult(T data, ApiResultStatus status, IEnumerable<ErrorModel> Errors) : base(status, "", Errors)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
