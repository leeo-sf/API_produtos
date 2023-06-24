using api_produtos.Models;
using api_produtos.Repositorio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _iCategoria;

        public CategoriaController(ICategoria iCategoria)
        {
            _iCategoria = iCategoria;
        }

        [HttpGet("ListarTodasCategorias")]
        public async Task<ActionResult<List<Categoria>>> ListarTodasCategorias()
        {
            var lista = await _iCategoria.ListarTodasCategorias();
            return Ok(lista);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            var obj = await _iCategoria.BuscarPorId(id);
            return Ok(obj);
        }

        [HttpPost("CadastrarCategoria")]
        public async Task<ActionResult> CadastrarCategoria([FromBody] Categoria categ)
        {
            await _iCategoria.CadastrarCategoria(categ);
            return Ok();
        }


        [HttpPut("EditarCategoria")]
        public async Task<ActionResult> EditarCategoria([FromHeader] int id_editar, [FromBody] Categoria categ)
        {
            if (categ.Id != id_editar)
            {
                categ.Id = id_editar;
            }

            try
            {
                await _iCategoria.AlterarCategoria(id_editar, categ);
                return Ok();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("DeletarCategoria")]
        public async Task<ActionResult> ApagarCategoria([FromHeader] int id_deletar)
        {
            var obj = await _iCategoria.BuscarPorId(id_deletar);
            if (obj == null)
            {
                return BadRequest($"ID: {id_deletar} inexistente.");
            }

            try
            {
                await _iCategoria.ApagarCategoria(id_deletar);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
