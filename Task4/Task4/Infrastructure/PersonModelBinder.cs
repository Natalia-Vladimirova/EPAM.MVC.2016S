using System;
using System.Globalization;
using System.Web.Mvc;
using Task4.Models;

namespace Task4.Infrastructure
{
    public class PersonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person model = bindingContext.Model as Person ?? new Person();
            model.FirstName = GetValue(bindingContext, "FirstName");
            model.LastName = GetValue(bindingContext, "LastName");
            model.BirthDate = ParseDate(GetValue(bindingContext, "BirthDate"));
            model.Role = (Role)new RoleModelBinder().BindModel(controllerContext, bindingContext);

            bindingContext.ModelName = "HomeAddress";
            model.HomeAddress = (Address)new AddressModelBinder().BindModel(controllerContext, bindingContext);
            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            string fullName = (context.ModelName == "" ? "" : context.ModelName + ".") + name;

            ValueProviderResult result = context.ValueProvider.GetValue(fullName);
            
            switch (name)
            {
                case "Line1":
                    if (result?.AttemptedValue == null || result.AttemptedValue.ToUpperInvariant().Contains("PO BOX"))
                    {
                        return "<not-defined>";
                    }
                    break;
                case "Line2":
                    if (string.IsNullOrEmpty(result?.AttemptedValue) || result.AttemptedValue.ToUpperInvariant().Contains("PO BOX"))
                    {
                        return "<not-defined>";
                    }
                    break;
                case "PostalCode":
                    if (result?.AttemptedValue == null || result.AttemptedValue.ToUpperInvariant().Contains("PO BOX"))
                    {
                        return "<not-defined>";
                    }
                    break;
            }

            return result?.AttemptedValue;
        }

        private DateTime ParseDate(string date)
        {
            DateTime result;
            DateTime.TryParseExact(date, "dd+MM+yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            return result;
        }
    }
}