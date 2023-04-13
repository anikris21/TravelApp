using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace MVCApplication.Middleware
{
    public class FeatureSwitchAuthMiddleware
    {
        private RequestDelegate _next;

        public FeatureSwitchAuthMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext context, IConfiguration configuration)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint != null)
            {
                var switches = configuration.GetSection("FeatureSwitches")
                    .GetChildren().FirstOrDefault( x => x.Key == "contact-us");

                if (switches != null && !bool.Parse(switches.Value))
                {
                    context.SetEndpoint(new Endpoint((context) =>
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        return Task.CompletedTask;
                    },
                    EndpointMetadataCollection.Empty, "Feature Not Found")
                        );

                }

            }

            await _next(context);


        }

    }
}
