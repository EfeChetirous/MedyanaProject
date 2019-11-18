using Medyana.Data;
using Medyana.Data.Model;
using Medyana.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Service.Services
{
    public class LogService : ILogService
    {
        protected readonly MedyanaContext _dbContext;
        public LogService(MedyanaContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task CreateActionControllerLog(ActionControllerLog actionController)
        {
            try
            {
                actionController.IsActive = true;
                _dbContext.Add(actionController);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // while logging if there is a trouble, don't interrupt the process of app.
            }            
        }

        public async Task CreateExceptionLog(ExceptionLog exceptionLog)
        {
            try
            {
                exceptionLog.IsActive = true;
                _dbContext.Add(exceptionLog);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // while logging if there is a trouble, don't interrupt the process of app.
            }
        }
    }
}
