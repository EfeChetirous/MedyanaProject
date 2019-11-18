using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Medyana.Data.Dto
{
    public class MedEquipmentDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? ProvideDate { get; set; }
        [Required]
        [Range(1,Int32.MaxValue)]
        public int CountInfo { get; set; }
        
        [Required]
        [Range(0.01, Int32.MaxValue)]
        public double UnitPrice { get; set; }
        [Required]
        [Range(0.0, 100)]
        public double UsageRate { get; set; }
        [Required]
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }

        //public MedClinic Clinic { get; set; }
    }
}
