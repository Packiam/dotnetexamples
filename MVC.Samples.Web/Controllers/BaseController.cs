using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using static MVC.Samples.Web.Controllers.CustomAuthorizeAttribute;

namespace MVC.Samples.Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            string name = Session["LOGIN_USERNAME"]?.ToString();
            if (!string.IsNullOrEmpty(name)) { filterContext.HttpContext.User = new ClaimsPrincipal(new CustomIdentity(name)); }

            //var a = new ClaimsPrincipal(new CustomIdentity(name));
            //var claims = new List<Claim> { new Claim("Role", "SomeValue") };
            base.OnAuthentication(filterContext);
        }

        public ActionResult ErrorView(string message)
        {
            ViewBag.Message = message;
            return View("Error");
        }
        public ActionResult ErrorView(Exception ex)
        {
            ViewBag.Message = ex.Message;
            return View("Error");
        }

    }

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedRoles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            string name = httpContext.Session["Role"]?.ToString();
            if(allowedRoles.Contains(name)) { authorize = true; }
            return authorize;
        }
    }
    public class CustomAuthorize1Attribute : ActionFilterAttribute
    {
        private readonly string[] allowedRoles;
        public CustomAuthorize1Attribute(params string[] roles)
        {
            this.allowedRoles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string name = filterContext.HttpContext.Session["Role"]?.ToString();
            if (!allowedRoles.Contains(name)) { filterContext.Result = new ViewResult() { ViewName = "AuthorizeError" }; }
            base.OnActionExecuting(filterContext);
        }
    }
    public class CustomIdentity : IIdentity
    {
        private readonly string _name;
        public CustomIdentity(string name) { this._name = name; }

        public string Name { get { return _name; } }

        public string AuthenticationType { get { return "MyCustom"; } }

        public bool IsAuthenticated { get { return (string.IsNullOrEmpty(this.Name) == false); } }
    }

}