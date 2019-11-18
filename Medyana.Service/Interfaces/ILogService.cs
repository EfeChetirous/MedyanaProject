using Medyana.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Service.Interfaces
{
    public interface ILogService
    {
        public Task CreateActionControllerLog(ActionControllerLog actionController);
        public Task CreateExceptionLog(ExceptionLog exceptionLog);
    }
}
