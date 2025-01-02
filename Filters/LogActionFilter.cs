using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class LogActionFilter : Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            Console.WriteLine("Executing IActionFilter.OnActionExecuting {0} - {1}", actionName, controllerName);
            foreach (var item in context.ActionDescriptor.RouteValues)
            {
                Console.WriteLine("key:{0} value:{1}", item.Key, item.Value);
            }
            /*
            context.Result = new ContentResult()
            {
                Content = "IActionFilter - Short-circuiting ",
            };
            */
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            Console.WriteLine($"Executing IActionFilter.OnActionExecuted: cancelled {actionName} {controllerName}");

            //context.ExceptionHandled = true;
            //context.Result = new ContentResult()
            //{
            //    Content = "IActionFilter - convert to success ",
            //};
        }
    }
}
