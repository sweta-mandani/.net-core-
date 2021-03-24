using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Human_Resource_Mangement
{

    public class CustomActionFilter : IActionFilter
    {
        private ILogger _logger;
        public CustomActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CustomActionFilter>();
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
           
            //To do : before the action executes  
            _logger.LogInformation("OnActionExecuting");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
            //To do : after the action executes  
            _logger.LogInformation("OnActionExecuted");
        }
    }
}
