using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Data.Model
{
    public class ExceptionLog : BaseEntity
    {
        public string ExceptionMessage { get; set; }
        public string StackMessage { get; set; }
        public string ActionName { get; set; }
        public string ControlllerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
    }
}
