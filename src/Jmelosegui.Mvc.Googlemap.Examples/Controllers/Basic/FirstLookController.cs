﻿namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public partial class BasicController
    {
        public ActionResult FirstLook(int? height, int? width)
        {
            this.ViewData["height"] = height ?? 0;
            this.ViewData["width"] = width ?? 0;
            return this.View();
        }
    }
}