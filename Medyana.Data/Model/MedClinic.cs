using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Medyana.Data.Model
{
    public class MedClinic : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<MedEquipment> Equipments { get; set; }
    }
}
