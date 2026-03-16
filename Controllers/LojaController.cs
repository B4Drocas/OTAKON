using Microsoft.AspNetCore.Mvc;
using SeuProjeto.Models;

public class LojaController : Controller
{
    public IActionResult Index()
    {
        var produtos = new List<Produto>
        {
            new Produto
            {
                IDProduto = 1,
                Nome = "DanDaDan Vol.1",
                Autor = "Yukinobu Tatsu",
                Editora = "Shueisha",
                Preco = 34.90m,
                Imagem = "/images/dandadan.jpg"
            },
            new Produto
            {
                IDProduto = 2,
                Nome = "Vinland Saga Vol.1",
                Autor = "Makoto Yukimura",
                Editora = "Kodansha",
                Preco = 39.90m,
                Imagem = "/images/vinland.jpg"
            },
            new Produto
            {
                IDProduto = 3,
                Nome = "Evangelion Vol.1",
                Autor = "Yoshiyuki Sadamoto",
                Editora = "Kadokawa",
                Preco = 36.90m,
                Imagem = "/images/evangelion.jpg"
            },
            new Produto
            {
                IDProduto = 4,
                Nome = "Solo Leveling Vol.1",
                Autor = "Chugong",
                Editora = "D&C Media",
                Preco = 42.90m,
                Imagem = "/images/sololeveling.jpg"
            },
            new Produto
            {
                IDProduto = 5,
                Nome = "Berserk Vol.1",
                Autor = "Kentaro Miura",
                Editora = "Hakusensha",
                Preco = 44.90m,
                Imagem = "/images/berserk.jpg"
            },
            new Produto
            {
                IDProduto = 6,
                Nome = "Akira (One Shot)",
                Autor = "Katsuhiro Otomo",
                Editora = "Kodansha",
                Preco = 49.90m,
                Imagem = "/images/akira.jpg"
            }
        };

        return View(produtos);
    }
}