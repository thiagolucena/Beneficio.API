using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public class AnexoBeneficioController : ControllerBase
    {
        private readonly IAnexoBeneficioService _service;

        public AnexoBeneficioController(IAnexoBeneficioService service)
        {
            _service = service;
        }

        // GET: api/<AnexoBeneficioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnexoBeneficioController>/5
        [HttpGet("getById/{id}")]
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

        [HttpGet("getByBeneficio/{beneficioId}")]
        public async Task<IActionResult> GetByBeneficio(int beneficioId)
        {
            try
            {
                var results = await _service.GetAsyncByBeneficioId(beneficioId);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        // POST api/<AnexoBeneficioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnexoBeneficio anexoBeneficio)
        {
            try
            {
                _service.Add(anexoBeneficio);
                
                return Created($"/api/anexoBeneficio/getById/{anexoBeneficio.Id}", anexoBeneficio);
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
            return BadRequest();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "PDF");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest("Erro ao tentar realizar upload");
        }

        // PUT api/<AnexoBeneficioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AnexoBeneficio anexoBeneficio)
        {
            try
            {
                var results = await _service.GetAsyncById(id);

                if (results == null)
                {
                    return NotFound();
                }
                _service.Update(id, anexoBeneficio);
                
                return Created($"/api/anexoBeneficio/getById/{anexoBeneficio.Id}", anexoBeneficio);
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        // DELETE api/<AnexoBeneficioController>/5
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
