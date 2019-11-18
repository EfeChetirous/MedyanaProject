using Medyana.Data.Model;
using Medyana.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Medyana.Project.Core
{
    public class ValidatorActionFilter : IAsyncActionFilter
    {
        private readonly ILogService _logService;
        public ValidatorActionFilter(ILogService logService)
        {
            _logService = logService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            try
            {
                ActionControllerLog actionController = new ActionControllerLog();

                actionController.DisplayName = filterContext.ActionDescriptor.DisplayName;
                actionController.ControllerName = (string)filterContext.RouteData.Values["Controller"];
                actionController.ActionName = (string)filterContext.RouteData.Values["Action"];
                actionController.UserName = "SYS";
                actionController.CreatedDate = DateTime.Now;
                actionController.IsActive = true;
                await _logService.CreateActionControllerLog(actionController);
                if (!filterContext.ModelState.IsValid)
                {
                    filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
                }
            }
            catch 
            {
            }
            
            await next();

            // logic after the action goes here
        }
    }
}
