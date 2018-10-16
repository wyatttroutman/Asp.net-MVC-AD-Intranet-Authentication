[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class IntranetAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
{
    protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
    {
        if (filterContext.HttpContext.Request.IsAuthenticated)
        {
            throw new HttpException(403, "Access Denied");
        }
        else
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}
