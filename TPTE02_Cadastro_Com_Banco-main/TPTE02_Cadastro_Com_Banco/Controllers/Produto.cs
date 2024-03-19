using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPTE02_Cadastro_Com_Banco.Data;
using TPTE02_Cadastro_Com_Banco.Model;

namespace TPTE02_Cadastro_Com_Banco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoItemController : ControllerBase
    {

        private readonly ProdutoContext _context;

        public ProdutoItemController(ProdutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  ActionResult<List<ProdutoModel>> Produtos() {
            // return Created();
            return _context.ProdutoItems.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel?>> ProdutoByID(long id) {
            return await _context.ProdutoItems.Where(i => i.ProdutoID.Equals(id)).FirstAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Produtos(ProdutoModel produto) {
            _context.Add(produto);
            await _context.SaveChangesAsync();

            // return Created();
            return CreatedAtAction("Produtos", produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Produtos(long id, ProdutoModel produto) {
            if (id != produto.ProdutoID) {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            // return Created();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> ProdutoDelete(long id) {
            var produto =await ProdutoByID(id);
            _context.Remove<ProdutoModel>(produto.Value!);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}