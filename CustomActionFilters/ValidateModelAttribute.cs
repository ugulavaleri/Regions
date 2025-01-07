using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestDotnet.CustomActionFilters;

public class ValidateModelAttribute : ActionFilterAttribute
{
    // in different class. ValidateModel + Attribute
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid == false)
        {
            context.Result = new BadRequestResult();
        }
    }
}