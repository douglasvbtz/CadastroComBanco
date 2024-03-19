using TPTE02_Cadastro_Com_Banco.Model;
using Microsoft.EntityFrameworkCore;

namespace TPTE02_Cadastro_Com_Banco.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) {

        }

        public DbSet<ProdutoModel> ProdutoItems { get; set; }// = null!;
    }
}