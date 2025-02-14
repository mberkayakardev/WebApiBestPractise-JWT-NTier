namespace TrendMusic.ECommerce.Core.Utilities.Pagination.ComplexTypes
{
    public abstract class RequestParameters // Master Pagination 
    {
        const int MaxPageSize = 8;
        public int PageNumber { get {  return (_pageNumber == 0 ? 1 : _pageNumber); } set { _pageNumber = value; } } // Atılan Sayfa numarası
        public int _pageNumber { get; set; }

        private int _pageSize; // sayfa içerisinde maksimum item sayısı yani bir sayfada 1000 tane gözüksün istemiyorum örneğin
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (MaxPageSize < value)
                {
                    _pageSize = MaxPageSize;
                }
                else
                {
                    _pageSize = value;
                }

            }
        }

    }
}
