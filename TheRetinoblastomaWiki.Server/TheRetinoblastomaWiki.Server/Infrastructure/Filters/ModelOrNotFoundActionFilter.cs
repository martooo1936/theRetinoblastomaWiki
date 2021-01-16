using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TheRetinoblastomaWiki.Server.Infrastructure.Filters
{
    public class ModelOrNotFoundActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // check if the result is an object result

            if (context.Result is ObjectResult result)
            {
                var model = result.Value;

                if (model == null)
                {
                    context.Result = new NotFoundResult();
                }
            }

        }
    }
}
