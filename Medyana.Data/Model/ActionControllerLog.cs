using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Data.Model
{
    public class ActionControllerLog : BaseEntity
    {
        public string DisplayName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
