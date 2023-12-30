using Microsoft.AspNetCore.Mvc;
using MovieApp.Model;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffCredentialController : ControllerBase
    {
        private readonly IStaffCredentialService _service;

        public StaffCredentialController(IStaffCredentialService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] StaffCredential request)
        {
            try
            {
                return Ok(_service.Add(request));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] StaffCredential request)
        {
            try
            {
                _service.Update(request);
                return Ok("Record updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Record deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _service.Get(id);
                if (response == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"Record not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _service.GetAll();
                if (response == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"Record not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }
    }
}