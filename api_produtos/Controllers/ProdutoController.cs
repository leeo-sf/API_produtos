using api_produtos.Models;
using api_produtos.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api_produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto _iProduto;
        private readonly IFabricante _iFabricante;
        private readonly ICategoria _iCategoria;

        public ProdutoController(IProduto iProduto, IFabricante iFabricante, ICategoria iCategoria)
        {
            _iProduto = iProduto;
            _iFabricante = iFabricante;
            _iCategoria = iCategoria;
        }

        [HttpGet("ListarTodosProdutos")]
        public async Task<ActionResult<List<Produto>>> BuscarTodosProdutos()
        {
            var produtos = await _iProduto.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("BuscarPorId")]
        public async Task<ActionResult<Produto>> BuscarPorId([FromHeader] int id)
        {
            var produto = await _iProduto.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost("CadastrarProduto")]
        public async Task<ActionResult> CadastrarNovoProduto([FromBody] Produto produto)
        {
            var categoria = await _iCategoria.CategoriaExiste(produto.IdCategoria);
            var fabricante = await _iFabricante.FabricanteExiste(produto.IdFabricante);

            if (categoria && fabricante)
            {
                await _iProduto.CadastrarNovoProduto(produto);
                return Ok("Produto cadastrado.");
            }

            return BadRequest("Verifique os ID categoria e fabricante. Eles não coincidem com o banco de dados.");
        }
        
        [HttpPut("EdtarProduto")]
        public async Task<ActionResult> AtualizarDadosProduto([FromHeader] int id, [FromBody] Produto produto)
        {
            if (produto.Id != id)
            {
                produto.Id = id;
            }

            if (id == 0)
            {
                return BadRequest($"Necessário informar o ID que será editado.");
            }

            try
            {
                var categoria = await _iCategoria.CategoriaExiste(produto.IdCategoria);
                var fabricante = await _iFabricante.FabricanteExiste(produto.IdFabricante);

                if (categoria && fabricante)
                {
                    await _iProduto.EditarProduto(id, produto);
                    return Ok();
                }
                return BadRequest("Verifique os ID categoria e fabricante. Eles não coincidem com o banco de dados.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarProduto")]
        public async Task<ActionResult> ApagarProduto([FromHeader] int id_deletar)
        {
            var obj = await _iProduto.BuscarPorId(id_deletar);
            if (obj == null)
            {
                return BadRequest($"ID: {id_deletar} inexistente.");
            }

            try
            {
                await _iProduto.ApagarProduto(id_deletar);
                return Ok();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
