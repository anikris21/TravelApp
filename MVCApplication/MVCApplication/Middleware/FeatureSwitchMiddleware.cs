using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Patterns;

namespace MVCApplication.Middleware
{
    public class FeatureSwitchMiddleware
    {
        private RequestDelegate _next;
        public FeatureSwitchMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext context, IConfiguration configuration )
        {
            if(context.GetEndpoint() is null) 
            {
                // End point not selected.

            } else
            {
                RoutePattern? r = null;
                if(context.GetEndpoint() is RouteEndpoint routeEndpoint) {
                    r = routeEndpoint.RoutePattern;
                }
                //await context.Response.WriteAsync($"End point {context.GetEndpoint()?.DisplayName}  selected!");
                // await context.Response.WriteAsync("End point selected!");
               // return;

            }

            if (context.Request.Path.Value.Contains("/features"))
            {
                var switches = configuration.GetSection("FeatureSwitches");
                var report = switches.GetChildren().Select(x => $"{x.Key} :  {x.Value}");
                await context.Response.WriteAsync(string.Join(Environment.NewLine, report));
            } else
            {
                context.Items.Add("Greetings", "switch moddleware");
                await _next(context);
            }

        }

    }
}
