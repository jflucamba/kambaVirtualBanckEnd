using KV.Core.Domain;
using KV.Core.Shared.ModelView.Autor;
using KV.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorManager manager;

        public AutorController(IAutorManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await manager.GetAutoresAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await manager.GetAutorAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoAutor novoAutor)
        {
            var autor = await manager.InsertAutorAsync(novoAutor);
            return CreatedAtAction(nameof(Get), new { id = autor.Id }, autor);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlterarAutor alterAutor)
        {
            var autor = await manager.UpdateAutorAsync(alterAutor);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await manager.DeleteAutorAsync(id);
            return NoContent();
        }
    }
}
