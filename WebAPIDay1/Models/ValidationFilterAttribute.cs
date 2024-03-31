using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIDay1.Models
{
    public class ValidationFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var args = context.ActionArguments["newDept"] as Department;
            if (args != null)
            {
                if(args.Name!="xyz")
                {
                    context.ModelState.AddModelError("NAme", "ay haga");
                }
            }
            
        }
    }
}
