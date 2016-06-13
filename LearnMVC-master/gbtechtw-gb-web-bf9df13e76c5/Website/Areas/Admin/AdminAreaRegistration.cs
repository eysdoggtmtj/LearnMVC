using Website.Areas.Admin.Controllers;
using System.Web.Mvc;

namespace Website.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            string[] nameSpace = new string[] { typeof(AdminController).Namespace };
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional },
                namespaces: nameSpace
            );
        }
    }
}