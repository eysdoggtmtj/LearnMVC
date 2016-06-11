using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Website;
using System.Threading.Tasks;
using Kernel.Models;
using Kernel.DAL;
using System.Web.Routing;

namespace Website.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext dbContext;

        public AdminController()
        {
            
        }

        //public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) : base()
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
        }



        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public async Task<ActionResult> Index()
        {

            var user = new ApplicationUser { UserName = "eric870713", Email = "eric870713@gmail.com" };
            var result = await UserManager.CreateAsync(user, "Ntust09008");

            string id = this.User.Identity.GetUserId();
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                id = user.Id;

            }

            return this.Json(new { user = this.dbContext.Users.FirstOrDefault(q=> q.Id == id), errors = result.Errors }, JsonRequestBehavior.AllowGet);
        }
    }
}