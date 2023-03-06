namespace ControleEstoqueApp.Models
{
    public class Estoque
    {
        public int ItemEstoqueId { get; set; }
        public string? Nome { get; set; }
        public int ProdutoId { get; set; }
        public int LojaId { get; set; }
    }
}
