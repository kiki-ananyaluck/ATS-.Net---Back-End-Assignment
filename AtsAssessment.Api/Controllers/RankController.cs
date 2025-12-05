using AtsAssessment.Application.Interfaces;
using AtsAssessment.Application.Validators;
using AtsAssessment.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtsAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class RankController : ControllerBase
    {
        private readonly IRankService _service;

        public RankController(IRankService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult ProcessRank([FromBody] RankRequest request)
        {
            // 1) Validate
            var (IsValid, Error) = RankValidator.Validate(request);
            if (!IsValid)
                return BadRequest(new { error = Error });

            // 2) Call Service
            var result = _service.ProcessRank(request);

            // 3) Format ให้ตรงกับโจทย์
            var response = result.Select(x => new { rank = x });

            return Ok(response);
        }
    }
}
