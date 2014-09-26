using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AutoPopulateSourceCodeAttribute());
        }
    }
}
