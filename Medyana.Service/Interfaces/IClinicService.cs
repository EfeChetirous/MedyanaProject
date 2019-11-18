using Medyana.Data.Dto.Result;
using Medyana.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Service.Interfaces
{
    public interface IClinicService
    {
        Result GetAllClinics();
        Task<Result> AddClinicAsync(MedClinic clinic);
        Task<Result> UpdateClinicAsync(MedClinic clinic);
        Task<Result> SoftDeleteClinicAsync(int id);
        Task<Result> PermanentDeleteClinicAsync(int id);
    }
}
