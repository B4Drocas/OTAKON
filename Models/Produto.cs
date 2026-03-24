namespace OTAKON.Models
{
    public class Produto
    {
        public int IDProduto { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public string Editora { get; set; }

        public decimal Preco { get; set; }

        public string Imagem { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public int Quantidade { get; set; }
    }
}