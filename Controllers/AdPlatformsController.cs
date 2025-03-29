using Microsoft.AspNetCore.Mvc;
using WebAppAdPlatforms.Models;

namespace WebAppAdPlatforms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdPlatformsController : ControllerBase
    {
        private static readonly AdPlatformStorage Storage = new();

        // POST: api/adplatforms/load
        [HttpPost("load")]
        public IActionResult LoadPlatforms()
        {
            try
            {
                using var reader = new StreamReader(Request.Body);
                var content = reader.ReadToEndAsync().Result;
                Storage.LoadFromText(content);
                return Ok(new { message = "Platforms loaded successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Invalid file format" });
            }
        }

        // GET: api/adplatforms/search?location=/ru/svrd
        [HttpGet("search")]
        public IActionResult SearchPlatforms([FromQuery] string location)
        {
            if (string.IsNullOrEmpty(location))
                return BadRequest(new { error = "Location is required" });

            var platforms = Storage.FindPlatforms(location);
            return Ok(new { location, platforms });
        }
    }
}
