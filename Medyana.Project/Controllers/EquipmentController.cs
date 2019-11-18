using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medyana.Data.Dto;
using Medyana.Data.Dto.Result;
using Medyana.Project.Core;
using Medyana.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medyana.Project.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidatorActionFilter))]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [Route("GetAllEquipments")]
        public Result GetAllEquipments()
        {
            Result result = _equipmentService.GetAllEquipments();
            return result;
        }

        [HttpPost]
        [Route("AddEquipmentAsync")]
        public async Task<ActionResult<Result>> AddEquipmentAsync(MedEquipmentDto equipment)
        {
            var result = await _equipmentService.AddEquipmentAsync(equipment);
            return result;
        }

        [HttpPut]
        [Route("UpdateEquipmentAsync")]
        public async Task<ActionResult<Result>> UpdateEquipmentAsync(MedEquipmentDto equipment)
        {
            var result = await _equipmentService.UpdateEquipmentAsync(equipment);
            return result;
        }

        [HttpDelete]
        [Route("SoftDeleteEquipmentAsync/{id}")]
        public async Task<ActionResult<Result>> SoftDeleteEquipmentAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Result result = await _equipmentService.SoftDeleteEquipmentAsync(id);
            return result;
        }

        [HttpDelete]
        [Route("PermanentDeleteEquipmentAsync/{id}")]
        public async Task<ActionResult<Result>> PermanentDeleteEquipmentAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Result result = await _equipmentService.PermanentDeleteEquipmentAsync(id);
            return result;
        }
    }
}