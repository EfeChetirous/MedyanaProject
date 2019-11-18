using Mapster;
using Medyana.Data;
using Medyana.Data.Dto;
using Medyana.Data.Dto.Result;
using Medyana.Data.Model;
using Medyana.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Service.Services
{
    public class EquipmentService : IEquipmentService
    {
        protected readonly MedyanaContext _dbContext;

        public EquipmentService(MedyanaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Result GetAllEquipments()
        {
            try
            {
                var equipments = _dbContext.MedEquipment.Include(x=>x.Clinic).Where(x => x.IsActive).ToList();
                var model = equipments.Adapt<List<MedEquipmentDto>>();
                return new SuccessResult(model, "");
            }
            catch
            {
                return new FailureResult();
            }
        }

        public async Task<Result> AddEquipmentAsync(MedEquipmentDto equipment)
        {
            try
            {
                MedEquipment entity = equipment.Adapt<MedEquipment>();
                entity.IsActive = true;
                _dbContext.Add(entity);
                await _dbContext.SaveChangesAsync();
                entity.Clinic = await _dbContext.MedClinic.FindAsync(entity.ClinicId);
                equipment = entity.Adapt<MedEquipmentDto>();
                return new SuccessResult(equipment, "Record has been added.");
            }
            catch(Exception ex)
            {
                return new FailureResult();
            }
        }
        public async Task<Result> UpdateEquipmentAsync(MedEquipmentDto equipment)
        {
            try
            {
                var entity = await _dbContext.FindAsync<MedEquipment>(equipment.Id);
                entity.ClinicId = equipment.ClinicId;
                entity.CountInfo = equipment.CountInfo;
                entity.IsActive = true;
                entity.Name = equipment.Name;
                entity.ProvideDate = equipment.ProvideDate;
                entity.UsageRate = equipment.UsageRate;
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return new SuccessResult(entity, "Record has been updated.");
            }
            catch (Exception ex)
            {
                return new FailureResult(ex.Message);
            }
        }
        public async Task<Result> SoftDeleteEquipmentAsync(int id)
        {
            try
            {
                var entity = await _dbContext.FindAsync<MedEquipment>(id);
                entity.IsActive = false;
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return new SuccessResult(true,"Record has been deleted.");
            }
            catch(Exception ex)
            {
                return new FailureResult(ex.Message);
            }
        }

        public async Task<Result> PermanentDeleteEquipmentAsync(int id)
        {
            try
            {
                var entity = await _dbContext.FindAsync<MedEquipment>(id);
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return new SuccessResult(true, "Record has been deleted.");
            }
            catch(Exception ex)
            {
                return new FailureResult(ex.Message);
            }
        }
    }
}
