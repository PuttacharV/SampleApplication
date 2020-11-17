using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Common.Models;
using Sample.Service.IServices;

namespace SampleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {        
        private readonly ILogger<MedicineController> _logger;
        private readonly IMedicineService _medicineService;

        public MedicineController(ILogger<MedicineController> logger, IMedicineService sampleService)
        {
            _logger = logger;
            _medicineService = sampleService;
        }


        /// <summary>
        /// Get list of medicines
        /// </summary>
        /// <returns>All Medicine Object</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Medicine> result = await _medicineService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }

        }

        /// <summary>
        /// Get medicine details by id
        /// </summary>
        /// <param name="medicineId">Unique Medicine Identifier</param>
        /// <returns>Medicine Object</returns>
        [HttpGet("{medicineId}")]
        public async Task<IActionResult> GetById(int medicineId)
        {
            try
            {
                Medicine result = await _medicineService.GetById(medicineId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
            
        }

        /// <summary>
        /// Insert new medicine
        /// </summary>
        /// <param name="medicine">Medicine details</param>
        /// <returns>Create medicine object</returns>
        [HttpPost()]
        public async Task<IActionResult> PostMedicine([FromBody]Medicine medicine)
        {
            try
            {
                Medicine result = await _medicineService.InsertMedicine(medicine);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }

        }

        /// <summary>
        /// Insert new medicine
        /// </summary>
        /// <param name="medicine">Medicine details</param>
        /// <param name="medicineId">Medicine Identifier</param>
        /// <returns>Updated medicine object</returns>
        [HttpPut("{medicineId}")]
        public async Task<IActionResult> PutMedicine(int medicineId, [FromBody] Medicine medicine)
        {
            try
            {
                Medicine result = await _medicineService.UpdateMedicinet(medicineId, medicine);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete medicine
        /// </summary>
        /// <param name="medicineId">Medicine Identifier</param>
        /// <returns>success/failure status</returns>
        [HttpDelete("{medicineId}")]
        public async Task<IActionResult> DeleteMedicine(int medicineId)
        {
            try
            {
                if(await _medicineService.DeleteMedicine(medicineId))
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Oops, Something went wrong while deleting records, execution exited without exception!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
