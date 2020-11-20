using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beneficio.Domain.Entities;
using Beneficio.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Beneficio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoBeneficioService _service;

        public MovimentacaoController(IMovimentacaoBeneficioService service)
        {
            _service = service;
        }

        // GET: api/<MovimentacaoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MovimentacaoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _service.GetAsyncById(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        // POST api/<MovimentacaoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimentacaoBeneficio movimentacaoBeneficio)
        {
            try
            {
                _service.Add(movimentacaoBeneficio);
                
                return Created($"/api/movimentacao/{movimentacaoBeneficio.Id}", movimentacaoBeneficio);
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
            return BadRequest();
        }

        // PUT api/<MovimentacaoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MovimentacaoBeneficio movimentacaoBeneficio)
        {
            try
            {
                var results = await _service.GetAsyncById(id);

                if (results == null)
                {
                    return NotFound();
                }

                _service.Update(id, movimentacaoBeneficio);
                
                return Created($"/api/movimentacao/{movimentacaoBeneficio.Id}", movimentacaoBeneficio);
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        // DELETE api/<MovimentacaoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var results = await _service.GetAsyncById(id);

                if (results == null)
                {
                    return NotFound();
                }

                _service.Delete(id);

                return Ok();
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }
    }
}
