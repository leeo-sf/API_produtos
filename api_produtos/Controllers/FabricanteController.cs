using api_produtos.Models;
using api_produtos.Repositorio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly IFabricante _iFabricante;

        public FabricanteController(IFabricante iFabricante)
        {
            _iFabricante = iFabricante;
        }

        [HttpGet("ListarTodosFabricantes")]
        public async Task<ActionResult<List<Fabricante>>> ListarTodosFabricantes()
        {
            var lista = await _iFabricante.BuscarTodosFabricantes();
            return Ok(lista);
        }

        [HttpGet("BuscarPorId")]
        public async Task<ActionResult<Fabricante>> BuscarPorId([FromHeader] int id_fabricante)
        {
            var fabricante = await _iFabricante.BuscarPorId(id_fabricante);
            return Ok(fabricante);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult> Inserir([FromBody] Fabricante fabricante)
        {
            await _iFabricante.CadastrarFabricante(fabricante);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<ActionResult> EditarFabricante([FromHeader] int id_editar, [FromBody] Fabricante fabricante)
        {
            if (fabricante.Id != id_editar)
            {
                fabricante.Id = id_editar;
            }

            if (id_editar == 0)
            {
                return BadRequest($"Necessário informar o ID que será editado.");
            }

            try
            {
                await _iFabricante.EditarFabricante(id_editar, fabricante);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Deletar")]
        public async Task<ActionResult> ApagarFabricante([FromHeader] int id_deletar)
        {
            try
            {
                await _iFabricante.DeletarFabricante(id_deletar);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
