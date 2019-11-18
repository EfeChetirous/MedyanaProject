using Medyana.Data.Model;
using Medyana.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Project.Core
{
    public class ApiExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogService _logService;        
        public ApiExceptionFilter(ILogService logService)
        {
            _logService = logService;
        }
        
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            try
            {
                ExceptionLog log = new ExceptionLog();
                log.ActionName = (string)context.RouteData.Values["Action"];
                log.ControlllerName = (string)context.RouteData.Values["Controller"];
                log.CreatedDate = DateTime.Now;
                log.ExceptionMessage = context.Exception.Message;
                log.StackMessage = context.Exception.StackTrace;
                log.UserName = "SYS";
                await _logService.CreateExceptionLog(log);
            }
            catch
            {
            }
        }
    }
}
