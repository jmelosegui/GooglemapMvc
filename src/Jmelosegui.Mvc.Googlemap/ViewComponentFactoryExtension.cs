using System;
using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap
{
    public static class HtmlHelperExtension
    {
        public static MapBuilder GoogleMap(this HtmlHelper helper)
        {
            if (helper == null) throw new ArgumentNullException("helper");

            return new MapBuilder(helper.ViewContext);
        }
    }
}