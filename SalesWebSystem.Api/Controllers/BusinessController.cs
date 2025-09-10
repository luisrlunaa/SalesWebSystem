using Microsoft.AspNetCore.Mvc;
using SalesWebSystem.Application.Services.Abstracts;
using SalesWebSystem.Models.Models.DTO.BusinessDTO;

namespace SalesWebSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessServices _businessServices;
        public BusinessController(IBusinessServices businessServices)
        {
            _businessServices = businessServices;
        }

        [HttpGet("LastBoxId")]
        public ActionResult<BoxDTO> GetLastBoxId(int Id)
        {
            var box = _businessServices.LastBoxbyBusinessId(Id);
            if (box == null) 
                return NotFound();

            return Ok(box);
        }
    }
}
