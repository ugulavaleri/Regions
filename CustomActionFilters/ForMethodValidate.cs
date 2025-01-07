using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestDotnet.CustomActionFilters;

public class ForMethodValidate : ActionFilterAttribute
{
    private string _name;
    public ForMethodValidate(string name = "maxo")
    {
        _name = name;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // var values = new
        // {
        //     ModelState = context.ModelState.IsValid,
        //     RouteData = context.RouteData.Values,
        //     Arguments = context.ActionArguments,
        //     Path = context.HttpContext.Request.Path.Value,
        //     Method = context.HttpContext.Request.Method,
        //     name = _name
        // };
        // context.Result = new JsonResult(values);
        // return ;
        
        if (_name != "tst")
        {
            context.Result = new BadRequestResult();
        }
    }
}