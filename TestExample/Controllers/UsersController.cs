using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestExample.Models;
using TestExample.Service;

namespace TestExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IReqResTestService _reqResTestService;

        public UsersController(IReqResTestService reqResTestService) => this._reqResTestService = reqResTestService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            try
            {
                var user = await this._reqResTestService.GetUserAsync(id);
                if(user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                //logging needed.
                return new StatusCodeResult(500);
            }
        }
    }
}
