namespace MvcModels.Infrastructure
{
    using System.Globalization;
    using System.Web.Mvc;

    public class CountryValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("country", System.StringComparison.Ordinal) > -1;
        }

        public ValueProviderResult GetValue(string key)
        {
            return ContainsPrefix(key) 
                ? new ValueProviderResult("USA", "USA", CultureInfo.InvariantCulture) 
                : null;
        }
    }
}