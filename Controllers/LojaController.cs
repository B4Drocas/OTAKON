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
                Imagem = "/images/dandadan.png",    
                Descricao = "Um garoto cético e uma garota espiritualista se veem envolvidos em um acidente que muda suas vidas para sempre. Quando ambos desmaiam e acordam em corpos diferentes, precisam descobrir o mistério por trás dos poderes sobrenaturais e alistar-se nesta aventura repleta de ação, humor e romance. Uma série que redefine o gênero supernatural com personagens memoráveis e uma trama altamente viciante que prende desde o primeiro capítulo."
            },
            new Produto
            {
                IDProduto = 2,
                Nome = "Vinland Saga Vol.1",
                Autor = "Makoto Yukimura",
                Editora = "Kodansha",
                Preco = 14.90m,
                Imagem = "/images/vinland.png",
                Descricao = "Acompanhe Thorfinn, um jovem guerreiro viking determinado a encontrar o homem responsável pela morte de seu pai e derrotá-lo em combate honrado. Sua jornada o leva através de terras selvagens e mares tempestuosos, mas o caminho da vingança é muito mais complexo do que ele jamais imaginou. Uma narrativa épica que combina combates intensos, profundidade emocional e reflexões sobre a vida, morte e redenção em um mundo medieval brutalmente realista."
            },
            new Produto
            {
                IDProduto = 3,
                Nome = "Evangelion Vol.1",
                Autor = "Yoshiyuki Sadamoto",
                Editora = "Kadokawa",
                Preco = 19.90m,
                Imagem = "/images/evangelion.png",
                Descricao = "Em um futuro apocalíptico, humanoides gigantescos conhecidos como Anjos atacam a civilização. A última esperança da humanidade repousa em adolescentes escolhidos para pilotar Evas - máquinas biomecânicas de poder incompreensível. Quando Shinji Ikari é convocado para salvar o mundo, ele descobre que a responsabilidade é muito maior do que esperava. Uma obra-prima psicológica que questiona identidade, propósito e a natureza das conexões humanas através de simbolismo rico e narração visceral."
            },
            new Produto
            {
                IDProduto = 4,
                Nome = "Solo Leveling Vol.1",
                Autor = "Chugong",
                Editora = "D&C Media",
                Preco = 15.90m,
                Imagem = "/images/sololeveling.png",
                Descricao = "Em um mundo onde portais misteriosos aparecem subitamente, possibilitando a existência de monstros e poderes extraordinários, Sung Jinwoo é um caçador fraco, o mais fraco em sua classe. Mas quando ele sobrevive a uma morte certa em uma dungeon, descobre um sistema secreto que o permite ganhar poder exponencialmente. Sua jornada transformará não apenas sua vida, mas o destino do mundo inteiro. Ação arrebatadora, estratégia brilhante e um protagonista fascinante fazem desta série absolutamente imperdível."
            },
            new Produto
            {
                IDProduto = 5,
                Nome = "Berserk Vol.1",
                Autor = "Kentaro Miura",
                Editora = "Hakusensha",
                Preco = 19.90m,
                Imagem = "/images/berserk.png",
                Descricao = "Guts é um guerreiro de poder inumano, condenado a uma existência solitária de luta constante. Carregando uma espada colossal e uma maldição que o torna alvo de criaturas demoníacas, ele atravessa um mundo de fantasia sombria em busca de vingança e redenção. Sua história é uma odisseia de sofrimento, determinação e desejo de superação. Berserk é uma obra monumental que redefine dark fantasy com arte extraordinária, personagens profundos e uma narrativa que desafia as convenções do gênero."
            },
            new Produto
            {
                IDProduto = 6,
                Nome = "Akira (One Shot)",
                Autor = "Katsuhiro Otomo",
                Editora = "Kodansha",
                Preco = 20.90m,
                Imagem = "/images/akira.png",
                Descricao = "Em Neo-Tokyo, uma metrópole cyberpunk pós-apocalíptica, dois amigos de infância encontram-se em lados opostos de um conflito que mudará o futuro da humanidade. Tetsuo e Kaneda enfrentam conspiração governamental, poderes psíquicos devastadores e a possibilidade de destruição total. A história explora temas de poder, amizade, corrupção e transformação em um mundo onde tecnologia e humanidade colidem. Akira é um clássico que definiu o gênero cyberpunk e continua influenciando a ficção científica até hoje com sua arte revolucionária e visão futurista."
            }
        };
    }
}