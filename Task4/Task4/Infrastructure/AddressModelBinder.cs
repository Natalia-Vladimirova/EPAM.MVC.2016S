using System.Web.Mvc;
using Task4.Models;

namespace Task4.Infrastructure
{
    public class AddressModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Address model = bindingContext.Model as Address ?? new Address();
            model.Line1 = GetValue(bindingContext, "Line1");
            model.Line2 = GetValue(bindingContext, "Line2");
            model.City = GetValue(bindingContext, "City");
            model.PostalCode = GetValue(bindingContext, "PostalCode");
            model.Country = GetValue(bindingContext, "Country");

            if (IsNotDefinedOrEmpty(model.PostalCode) || IsNotDefinedOrEmpty(model.City) || IsNotDefinedOrEmpty(model.Line1))
            {
                model.Summary = "No personal address";
            }
            else
            {
                model.Summary = $"{model.PostalCode} {model.City}, {model.Line1}";
            }

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
                    if (result?.AttemptedValue == null || result.AttemptedValue.Length < 6)
                    {
                        return "<not-defined>";
                    }
                    break;
            }

            return result?.AttemptedValue;
        }

        private bool IsNotDefinedOrEmpty(string line)
        {
            return string.IsNullOrWhiteSpace(line) || line == "<not-defined>";
        }
    }
}