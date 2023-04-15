using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace MVCApplication
{
    public class OutageAuthFilter : System.Attribute, IAuthorizationFilter
    {
        private IConfiguration _config; 

        public OutageAuthFilter(IConfiguration config)
        {
            _config = config;
        }
    
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var switches = _config.GetSection("FeatureSwitches")
                    .GetChildren().FirstOrDefault(x => x.Key == "Outage");

            if (switches != null && bool.Parse(switches.Value))
            {
                context.Result = new ViewResult() { ViewName = "Outage" };
            }

            /*
            throw new System.NotImplementedException();
            */
        }
    }
}
