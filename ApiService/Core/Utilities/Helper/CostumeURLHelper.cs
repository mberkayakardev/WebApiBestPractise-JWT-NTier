using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Core.Utilities.Helper
{
    public class CostumeURLHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static string GetActiveClass(string ControllerName, string ActionName)
        {
            var routeData = _httpContextAccessor.HttpContext.GetRouteData();

            // Controller ve Action bilgilerini routeData'dan alıyoruz
            string instantControllerName = routeData.Values["controller"]?.ToString();
            string instantActionName = routeData.Values["action"]?.ToString();

            // Eğer parametreler ile şu anki sayfa uyuyorsa "active" döndür
            if (string.Equals(instantControllerName, ControllerName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(instantActionName, ActionName, StringComparison.OrdinalIgnoreCase))
            {
                return "active";
            }

            return string.Empty;
        }
    }
}
