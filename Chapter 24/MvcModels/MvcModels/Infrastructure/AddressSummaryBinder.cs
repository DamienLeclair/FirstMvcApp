namespace MvcModels.Infrastructure
{
    using System.Web.Mvc;
    using MvcModels.Models;
    using IModelBinder = System.Web.Mvc.IModelBinder;
    using ModelBindingContext = System.Web.Mvc.ModelBindingContext;

    public class AddressSummaryBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (AddressSummary)bindingContext.Model ?? new AddressSummary();

            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");

            return model;
        }

        string GetValue(ModelBindingContext context, string name)
        {
            name = (context.ModelName == string.Empty ? string.Empty : context.ModelName + ".") + name;

            var result = context.ValueProvider.GetValue(name);

            if (result == null || result.AttemptedValue == string.Empty)
            {
                return "<Not Specified>";
            }

            return result.AttemptedValue;
        }
    }
}