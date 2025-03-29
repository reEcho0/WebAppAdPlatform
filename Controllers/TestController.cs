﻿using Microsoft.AspNetCore.Mvc;

namespace WebAppAdPlatforms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Server is running!");
        }
    }
}
