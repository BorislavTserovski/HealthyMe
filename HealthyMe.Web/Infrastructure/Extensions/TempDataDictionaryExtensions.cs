using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HealthyMe.Web.Infrastructure.Extensions
{
    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.SuccessMessageKey] = message;
        }
    }
}