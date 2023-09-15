using Business.InterfaceProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Produto;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {

        private readonly IProduto _IProduto;

        public ProdutosController(IProduto iproduto)
        {
            _IProduto = iproduto;
        }

        [HttpGet("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos()
        {
            return Json(await _IProduto.List());
        }

        [HttpPost("ObterProdutoPorId")]
        public async Task<IActionResult> ObterProdutoPorId(int Id)
        {
            return Json(await _IProduto.GetEntityById(Id));
        }


        [HttpPost("AdicionarProduto")]
        public async Task AdicionarProduto(ProdutoViewModel produto)
        {
            await _IProduto.Add(produto);
        }

        [HttpPost("AtualizarProduto")]
        public async Task AtualizarProduto(ProdutoViewModel produto)
        {
            await _IProduto.Update(produto);
        }

        [HttpPost("RemoverProduto")]
        public async Task RemoverProduto(ProdutoViewModel produto)
        {
            await _IProduto.Delete(produto);
        }

    }
}
