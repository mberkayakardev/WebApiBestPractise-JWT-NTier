using Core.Utilities.Results.MVC.ComplexTypes;
using TrendMusic.ECommerce.Core.Extentions.ComplexTypes;

namespace Core.Utilities.Results.MVC.BaseResult
{
    public class ApiResult : IApiResult
    {
        public string Messages { get; }
        public ApiResultStatus Status { get; }
        public IEnumerable<ErrorModel> ValidationErrors { get; }
        public ApiResult(ApiResultStatus status, string StatusMessages, IEnumerable<ErrorModel> Errors) : this(status, StatusMessages)
        {
            ValidationErrors = Errors;
        }

        public ApiResult(ApiResultStatus status, string StatusMessages) : this(status)
        {
            Messages = StatusMessages;
        }

        public ApiResult(ApiResultStatus status)
        {
            Status = status;
        }

        public ApiResult(ApiResultStatus status, IEnumerable<ErrorModel> Errors) : this(status, string.Empty, Errors)
        {

        }

        #region Static Methods Created Result 

        public static ApiResult SuccessResult()
        {
            return new ApiResult(ApiResultStatus.Ok);
        }
        public static ApiResult SuccessResult(string Message)
        {
            return new ApiResult(ApiResultStatus.Ok, Message);
        }

        #endregion

    }
}
