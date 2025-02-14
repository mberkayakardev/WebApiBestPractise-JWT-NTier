using System.Security.Principal;

namespace TrendMusic.ECommerce.Core.Utilities.Pagination.ComplexTypes
{
    public class PagerResultViewModel<T>
    {
        public MetaData MetaData { get; }
        public T Data { get; }
        public PagerResultViewModel(MetaData metaData, T data)
        {
            MetaData = metaData;
            Data = data;
        }
    }
}
