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
    public class MedicineOrderController : ControllerBase
    {        
        private readonly ILogger<MedicineController> _logger;
        private readonly IMedicineOrderService _medicineOrderService;

        public MedicineOrderController(ILogger<MedicineController> logger, IMedicineOrderService medicineOrderService)
        {
            _logger = logger;
            _medicineOrderService = medicineOrderService;
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
                List<Order> result = await _medicineOrderService.GetAll();
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
        /// <param name="medicineOrderId">Unique Medicine Identifier</param>
        /// <returns>Medicine Object</returns>
        [HttpGet("{medicineOrderId}")]
        public async Task<IActionResult> GetById(int medicineOrderId)
        {
            try
            {
                Order result = await _medicineOrderService.GetById(medicineOrderId);
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
        /// <param name="medicineOrder">Medicine details</param>
        /// <returns>Create medicine object</returns>
        [HttpPost()]
        public async Task<IActionResult> PostMedicine([FromBody] Order medicineOrder)
        {
            try
            {
                Order result = await _medicineOrderService.InsertMedicineOrder(medicineOrder);
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
        /// <param name="medicineOrder">Medicine details</param>
        /// <param name="medicineId">Medicine Identifier</param>
        /// <returns>Updated medicine object</returns>
        [HttpPut("{medicineId}")]
        public async Task<IActionResult> PutMedicine(int medicineId, [FromBody] Order medicineOrder)
        {
            try
            {
                Order result = await _medicineOrderService.UpdateMedicineOrder(medicineId, medicineOrder);
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
        /// <param name="medicineOrderId">Medicine Order Identifier</param>
        /// <returns>success/failure status</returns>
        [HttpDelete("{medicineOrderId}")]
        public async Task<IActionResult> DeleteMedicine(int medicineOrderId)
        {
            try
            {
                if(await _medicineOrderService.DeleteMedicineOrder(medicineOrderId))
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
