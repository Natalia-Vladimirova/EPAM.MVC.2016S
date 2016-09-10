using System.Web.Mvc;
using Task4.Models;

namespace Task4.Infrastructure
{
    public class RoleModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string value = bindingContext.ValueProvider.GetValue("Role")?.AttemptedValue;

            if (string.IsNullOrWhiteSpace(value))
            {
                return Role.Guest;
            }

            switch (value.ToLowerInvariant())
            {
                case "admin":
                    if (controllerContext.RequestContext.HttpContext.Request.IsLocal)
                    {
                        return Role.Admin;
                    }
                    return Role.User;
                case "user":
                    return Role.User;
                default:
                    return Role.Guest;
            }
        }
    }
}