﻿namespace ControleEstoqueApp.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
