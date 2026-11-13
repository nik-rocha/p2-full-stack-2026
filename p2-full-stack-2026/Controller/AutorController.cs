using Microsoft.AspNetCore.Mvc;
using p2_full_stack_2026.DTO;
using p2_full_stack_2026.Interfaces;

namespace p2_full_stack_2026.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var autores = _autorService.GetAll();
            return Ok(autores);
        }

        [HttpGet("{id:int}")] // :int faz a validação do parâmetro id para ser um número inteiro
        public IActionResult GetById(int id)
        {
            try
            {
                var autor = _autorService.GetById(id);
                return Ok(autor);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] AutorRequisicao requisicao)
        {
            try
            {
                var autorCriado = _autorService.Create(requisicao);
                return CreatedAtAction(nameof(GetById), new { id = autorCriado.Id }, autorCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] AutorRequisicao requisicao)
        {
            try
            {
                var autorAtualizado = _autorService.Update(id, requisicao);
                return Ok(autorAtualizado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _autorService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
