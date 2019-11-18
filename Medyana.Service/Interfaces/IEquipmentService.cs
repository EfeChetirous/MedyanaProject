using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Medyana.Data.Dto;
using Medyana.Data.Dto.Result;

namespace Medyana.Service.Interfaces
{
    public interface IEquipmentService
    {
        public Result GetAllEquipments();
        Task<Result> AddEquipmentAsync(MedEquipmentDto equipment);
        Task<Result> UpdateEquipmentAsync(MedEquipmentDto equipment);
        Task<Result> SoftDeleteEquipmentAsync(int id);
        Task<Result> PermanentDeleteEquipmentAsync(int id);
    }
}
