using DataExporter.Dtos;
using DataExporter.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataExporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService) 
        {
            _policyService = policyService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPolicies([FromBody]CreatePolicyDto createPolicyDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var result = await _policyService.CreatePolicyAsync(createPolicyDto);

            if (result is null)
                return BadRequest();

            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            return Ok(await _policyService.ReadPoliciesAsync());
        }

        [HttpGet("{policyId:int}")]
        public async Task<IActionResult> GetPolicy(int policyId)
        {
            var result = await _policyService.ReadPolicyAsync(policyId);

            if(result is null)
                return NotFound("Not Found");

            return Ok(result);
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportData([FromQuery]DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await _policyService.ExportData(startDate, endDate);

            if (result.Any())
                return Ok(result);

            return NotFound("Not Found");
        }
    }
}
