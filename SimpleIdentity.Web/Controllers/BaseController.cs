namespace SimpleIdentity.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using System.Web;
    public class BaseController : Controller
    {
        protected ContentResult StringifyModelStateErrors(ModelStateDictionary modelState)
        {
            string errorMessage = string.Empty;
            if (!this.ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(er => er.ErrorMessage));
                errorMessage = string.Format("Invalid Parameters: {0}", string.Join(", ", errors));
            }

            return this.Content(errorMessage);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (this.Request.IsAjaxRequest())
            {
                var exception = filterContext.Exception as HttpException;

                if (exception != null)
                {
                    this.Response.StatusCode = exception.GetHttpCode();
                    this.Response.StatusDescription = exception.Message;
                }
            }
            else
            {
                var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
                var actionName = ControllerContext.RouteData.Values["action"].ToString();
                this.View("Errors", new HandleErrorInfo(filterContext.Exception, controllerName, actionName)).ExecuteResult(this.ControllerContext);
            }

            filterContext.ExceptionHandled = true;
        }
    }
}