using Microsoft.AspNetCore.Mvc;
using OTAKON.Models;
using System.Collections.Generic;
using System.Linq;

public class LojaController : Controller
{
    // 🔹 ACTION 1 - Lista de produtos
    public IActionResult Index()
    {
        List<Produto> produtos = GetProdutos();
        return View(produtos);
    }

    // 🔹 ACTION 2 - Detalhe do produto
    public IActionResult Detalhe(int id)
    {
        List<Produto> produtos = GetProdutos();

        var produto = produtos.FirstOrDefault(p => p.IDProduto == id);

        if (produto == null)
            return NotFound();

        return View(produto);
    }

    // 🔹 MÉTODO AUXILIAR (fica aqui embaixo 👇)
    private List<Produto> GetProdutos()
    {
        return new List<Produto>
        {
            new Produto
            {
                IDProduto = 1,
                Nome = "DanDaDan Vol.1",
                Autor = "Yukinobu Tatsu",
                Editora = "Shueisha",
                Preco = 15.90m,
                Imagem = "/images/dandadan.png"
            },
            new Produto
            {
                IDProduto = 2,
                Nome = "Vinland Saga Vol.1",
                Autor = "Makoto Yukimura",
                Editora = "Kodansha",
                Preco = 14.90m,
                Imagem = "/images/vinland.png"
            },
            new Produto
            {
                IDProduto = 3,
                Nome = "Evangelion Vol.1",
                Autor = "Yoshiyuki Sadamoto",
                Editora = "Kadokawa",
                Preco = 19.90m,
                Imagem = "/images/evangelion.png"
            },
            new Produto
            {
                IDProduto = 4,
                Nome = "Solo Leveling Vol.1",
                Autor = "Chugong",
                Editora = "D&C Media",
                Preco = 15.90m,
                Imagem = "/images/sololeveling.png"
            },
            new Produto
            {
                IDProduto = 5,
                Nome = "Berserk Vol.1",
                Autor = "Kentaro Miura",
                Editora = "Hakusensha",
                Preco = 19.90m,
                Imagem = "/images/berserk.png"
            },
            new Produto
            {
                IDProduto = 6,
                Nome = "Akira (One Shot)",
                Autor = "Katsuhiro Otomo",
                Editora = "Kodansha",
                Preco = 20.90m,
                Imagem = "/images/akira.png"
            }
        };
    }
}