using System.ComponentModel.DataAnnotations;

namespace TPTE02_Cadastro_Com_Banco.Model
{
    public class ProdutoModel
    {
        [Key]
        public long ProdutoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}