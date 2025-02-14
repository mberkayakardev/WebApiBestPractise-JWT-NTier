using TrendMusic.ECommerce.Core.Extentions.ComplexTypes;
using TrendMusic.ECommerce.Core.Utilities.Results.ComplexTypes;

namespace TrendMusic.ECommerce.Core.Utilities.Results.BaseResult
{
    public class Result : IResult
    {
        public string Messages { get; }
        public MVCResultStatus Status { get; }
        public IEnumerable<ErrorModel> ValidationErrors { get; }
        public Result(MVCResultStatus status, string StatusMessages, IEnumerable<ErrorModel> Errors) : this(status, StatusMessages)
        {
            ValidationErrors = Errors;
        }

        public Result(MVCResultStatus status, string StatusMessages) : this(status)
        {
            this.Messages = StatusMessages;
        }

        public Result(MVCResultStatus status)
        {
            this.Status = status;
        }

        public Result(MVCResultStatus status, IEnumerable<ErrorModel> Errors) : this(status, string.Empty, Errors)
        {

        }
    }
}
