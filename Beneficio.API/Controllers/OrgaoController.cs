using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beneficio.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Beneficio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgaoController : ControllerBase
    {
        private readonly IOrgaoService _orgaoService;

        public OrgaoController(IOrgaoService orgaoService)
        {
            _orgaoService = orgaoService;
        }

        // GET: api/<OrgaoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _orgaoService.GetAllOrgaoAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

        }

        // GET api/<OrgaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrgaoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrgaoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrgaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
