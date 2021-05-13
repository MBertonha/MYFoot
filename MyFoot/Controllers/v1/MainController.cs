using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemNome.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>        
        [HttpGet]
        public IActionResult Delete(long id)
        {
            return NoContent();
        }

    }
}
