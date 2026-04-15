using Microsoft.AspNetCore.Mvc;
using OTAKON.Data;
using OTAKON.Models;
using System.Linq;

public class LojaController : Controller
{
    private readonly ApplicationDbContext _context;

    public LojaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 🛍️ LISTA DE PRODUTOS (COM PESQUISA)
    public IActionResult Index(string pesquisa)
    {
        var produtos = _context.Produtos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pesquisa))
        {
            pesquisa = pesquisa.ToLower();

            produtos = produtos.Where(p =>
                p.Nome.ToLower().Contains(pesquisa) ||
                p.Autor.ToLower().Contains(pesquisa) ||
                p.Categoria.ToLower().Contains(pesquisa)
            );
        }

        return View(produtos.ToList());
    }

    // 📄 DETALHE DO PRODUTO
    public IActionResult Detalhe(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.IDProduto == id);

        if (produto == null)
            return NotFound();

        return View(produto);
    }

}