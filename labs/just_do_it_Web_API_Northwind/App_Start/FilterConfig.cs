using System.Web;
using System.Web.Mvc;

namespace just_do_it_Web_API_Northwind
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
