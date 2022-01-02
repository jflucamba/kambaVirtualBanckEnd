using KV.Core.Domain;
using KV.Core.Shared.ModelView.SubCategoria;
using KV.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        private readonly ISubCategoriaManager manager;

        public SubCategoriaController(ISubCategoriaManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SubCategoria), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await manager.GetSubCategoriasAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SubCategoria), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await manager.GetSubCategoriaAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SubCategoria), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovaSubCategoria novaCategoria)
        {
            var categoria = await manager.InsertSubCategoriaAsync(novaCategoria);
            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlterarSubCategoria alterCategoria)
        {
            var categoria = await manager.UpdateSubCategoriaAsync(alterCategoria);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SubCategoria), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await manager.DeleteSubCategoriaAsync(id);
            return NoContent();
        }
    }
}