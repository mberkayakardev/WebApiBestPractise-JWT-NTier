using FluentValidation.Results;
using TrendMusic.ECommerce.Core.Extentions.ComplexTypes;

namespace Core.Extentions.Concrete.FluentApi
{
    public static class FluentApiExtentions
    {
        public static List<ErrorModel> GetErrrors(this ValidationResult result)
        {
            var ResultList = new List<ErrorModel>();
            foreach (var error in result.Errors)
            {
                ResultList.Add(new ErrorModel { PropertyName = error.PropertyName, ErrorDescription = error.ErrorMessage });
            }

            return ResultList;
        }
    }
}
