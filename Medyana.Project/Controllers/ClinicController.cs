using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medyana.Data.Dto.Result;
using Medyana.Data.Model;
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
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;
        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpGet]
        [Route("GetAllClinics")]
        public Result GetAllClinics()
        {
            var clinics = _clinicService.GetAllClinics();
            return clinics;   
        }

        [HttpPost]
        [Route("AddClinicAsync")]
        public async Task<ActionResult<Result>> AddClinicAsync(MedClinic clinic)
        {
            var result = await _clinicService.AddClinicAsync(clinic);
            return result;
        }

        [HttpPut]
        [Route("UpdateClinicAsync")]
        public async Task<ActionResult<Result>> UpdateClinicAsync(MedClinic clinic)
        {
            var result = await _clinicService.UpdateClinicAsync(clinic);
            return result;
        }

        [HttpDelete]
        [Route("SoftDeleteClinicAsync/{id}")]
        public async Task<ActionResult<Result>> SoftDeleteClinicAsync(int id)
        {
            var result = await _clinicService.SoftDeleteClinicAsync(id);
            return result;
        }

        [HttpDelete]
        [Route("PermanentDeleteClinicAsync/{id}")]
        public async Task<ActionResult<Result>> PermanentDeleteClinicAsync(int id)
        {
            var result = await _clinicService.PermanentDeleteClinicAsync(id);
            return result;
        }
    }
}