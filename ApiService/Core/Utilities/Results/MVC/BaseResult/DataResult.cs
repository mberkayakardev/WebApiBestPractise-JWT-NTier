using TrendMusic.ECommerce.Core.Extentions.ComplexTypes;
using TrendMusic.ECommerce.Core.Utilities.Results.ComplexTypes;

namespace TrendMusic.ECommerce.Core.Utilities.Results.BaseResult
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, MVCResultStatus status, string Messages) : base(status, Messages)
        {
            this.Data = data;
        }
        public DataResult(T data, MVCResultStatus status) : base(status)
        {
            this.Data = data;

        }
        public DataResult(T data, MVCResultStatus status, IEnumerable<ErrorModel> Errors) : base(status, "", Errors)
        {
            this.Data = data;

        }
        public T Data { get; }
    }
}
