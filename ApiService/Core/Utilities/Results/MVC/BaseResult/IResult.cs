using TrendMusic.ECommerce.Core.Extentions.ComplexTypes;
using TrendMusic.ECommerce.Core.Utilities.Results.ComplexTypes;

namespace TrendMusic.ECommerce.Core.Utilities.Results.BaseResult
{
    public interface IResult
    {
        public MVCResultStatus Status { get; }
        public string Messages { get; }
        public IEnumerable<ErrorModel> ValidationErrors { get; }
    }
}
