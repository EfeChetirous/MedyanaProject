using Medyana.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Data.Model
{
    public class MedEquipment : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? ProvideDate { get; set; }
        public int CountInfo { get; set; }
        public double UnitPrice { get; set; }
        public double UsageRate { get; set; }
        public int ClinicId { get; set; }

        public MedClinic Clinic { get; set; }
    }
}
