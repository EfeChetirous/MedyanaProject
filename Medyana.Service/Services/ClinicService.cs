using Medyana.Data;
using Medyana.Data.Dto.Result;
using Medyana.Data.Model;
using Medyana.Resource;
using Medyana.Service.Interfaces;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Service.Services
{
    public class ClinicService : IClinicService
    {
        protected readonly MedyanaContext _dbContext;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        public ClinicService(MedyanaContext dbContext, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _dbContext = dbContext;
            _sharedLocalizer = sharedLocalizer;
        }
        public Result GetAllClinics()
        {
            try
            {
                var clinics = _dbContext.MedClinic.Where(x => x.IsActive == true).ToList();
                return new SuccessResult(clinics, _sharedLocalizer["SuccessMessage"]);
            }
            catch (Exception ex)
            {
                return new FailureResult();
            }
        }

        public async Task<Result> AddClinicAsync(MedClinic clinic)
        {
            try
            {
                clinic.IsActive = true;
                _dbContext.Add(clinic);
                await _dbContext.SaveChangesAsync();
                return new SuccessResult(clinic, _sharedLocalizer["InsertMessage"]);
            }
            catch (Exception ex)
            {
                return new FailureResult(ex.Message);
            }
        }

        public async Task<Result> UpdateClinicAsync(MedClinic clinic)
        {
            try
            {

                var entity = await _dbContext.FindAsync<MedClinic>(clinic.Id);
                entity.Name = clinic.Name;
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return new SuccessResult(entity,_sharedLocalizer["UpdateMessage"]);
            }
            catch (Exception ex)
            {
                return new FailureResult();
            }
        }

        public async Task<Result> SoftDeleteClinicAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new FailureResult(_sharedLocalizer["IdRequired"]);
                }
                var entity = await _dbContext.FindAsync<MedClinic>(id);
                entity.IsActive = false;
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return new SuccessResult(true, _sharedLocalizer["DeleteMessage"]);
            }
            catch
            {
                return new FailureResult();
            }
        }
        public async Task<Result> PermanentDeleteClinicAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new FailureResult(_sharedLocalizer["IdRequired"]);
                }
                var entity = await _dbContext.FindAsync<MedClinic>(id);
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return new SuccessResult(true, _sharedLocalizer["DeleteMessage"]);
            }
            catch
            {
                return new FailureResult();
            }
        }
    }
}
