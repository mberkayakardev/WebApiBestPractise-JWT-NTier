using Core.Utilities.Results.MVC.ComplexTypes;
using TrendMusic.ECommerce.Core.Extentions.ComplexTypes;

namespace Core.Utilities.Results.MVC.BaseResult
{
    public interface IApiResult
    {
        public ApiResultStatus Status { get; }
        public string Messages { get; }
        public IEnumerable<ErrorModel> ValidationErrors { get; }
    }
}
