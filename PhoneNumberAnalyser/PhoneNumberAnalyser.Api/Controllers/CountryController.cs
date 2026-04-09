using Microsoft.AspNetCore.Mvc;
using PhoneNumberAnalyser.Application.DTOs;
using PhoneNumberAnalyser.Application.Interfaces.IServices;

namespace PhoneNumberAnalyser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IDecoderService _decoder;

        public CountryController(IDecoderService decoder)
        {
            _decoder = decoder;
        }


        [HttpPost("decode")]
        public IActionResult Decode([FromBody] PhoneNumberRequestDto dto)
        {
            var result = _decoder.DecodeCountry(dto.PhoneNumber);
            return StatusCode(result.StatusCode, result);
        }



    }
}
