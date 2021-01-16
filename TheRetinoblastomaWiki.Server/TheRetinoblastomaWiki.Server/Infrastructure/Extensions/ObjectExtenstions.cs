using Microsoft.AspNetCore.Mvc;

namespace TheRetinoblastomaWiki.Server.Infrastructure.Extensions
{
    public static class ObjectExtenstions
    {
        public static ActionResult<TModel> OrNotFound<TModel>(this TModel model)
        {
            if (model == null)
            {
                return new NotFoundResult();
            }

            return model;
        }
    }
}
