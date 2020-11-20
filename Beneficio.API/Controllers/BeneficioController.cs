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
    public class BeneficioController : ControllerBase
    {
        private readonly IBeneficioServidorService _beneficioServidorService;

        public BeneficioController(IBeneficioServidorService beneficioServidorService)
        {
            _beneficioServidorService = beneficioServidorService;
        }

        // GET: api/<BeneficioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BeneficioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _beneficioServidorService.GetAsyncById(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        [HttpGet("getByMatricula/{matricula}")]
        public async Task<IActionResult> Get(string matricula)
        {
            try
            {
                var results = await _beneficioServidorService.GetAsyncByMatricula(matricula);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        // POST api/<BeneficioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BeneficioServidor beneficioServidor)
        {
            try
            {
                _beneficioServidorService.Add(beneficioServidor);
                
                return Created($"/api/beneficio/{beneficioServidor.Id}", beneficioServidor);
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
            return BadRequest();
        }

        // PUT api/<BeneficioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BeneficioServidor beneficioServidor)
        {
            try
            {
                var results = await _beneficioServidorService.GetAsyncById(id);

                if (results == null)
                {
                    return NotFound();
                }

                _beneficioServidorService.Update(id, beneficioServidor);
                
                return Created($"/api/beneficio/{beneficioServidor.Id}", beneficioServidor);
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        // DELETE api/<BeneficioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var results = await _beneficioServidorService.GetAsyncById(id);

                if (results == null)
                {
                    return NotFound();
                }

                _beneficioServidorService.Delete(id);
                
                return Ok();
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }
    }
}
