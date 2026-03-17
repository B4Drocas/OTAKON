using Microsoft.AspNetCore.Mvc;
using OTAKode.Data;

namespace OTAKode.Controllers
{
    public class StoreController : Controller
    {
        private readonly OtakonDbContext _context;

        public StoreController(OtakonDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mangas = _context.Mangas.Where(m => m.IsAvailable).ToList();
            return View(mangas);
        }

        public IActionResult Details(int id)
        {
            var manga = _context.Mangas.FirstOrDefault(m => m.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            manga.ViewCount++;
            _context.SaveChanges();

            return View(manga);
        }

        public IActionResult Search(string query)
        {
            var mangas = _context.Mangas
                .Where(m => m.IsAvailable && (m.Title.Contains(query) || m.Author.Contains(query) || m.Genre.Contains(query)))
                .ToList();
            
            return View("Index", mangas);
        }
    }
}
