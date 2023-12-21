using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace WebAppProCodeGuide.Samples.FeatureFlagsDemo.Handlers
{
    public class CustomDisabledFeatureHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            context.Result = new ContentResult
            {
                ContentType = "text/plain",
                Content = "This feature is not available please try again later - " + String.Join(',', features),
                StatusCode = 404
            };
            return Task.CompletedTask;
        }
    }
}
