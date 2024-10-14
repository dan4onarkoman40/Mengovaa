using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mengova.Data;
using mengova.Models;
using System.Linq;
using System.Threading.Tasks;

public class CategoriesController : BaseController
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    // GET: Categories
    public async Task<IActionResult> Index()
    {
        return View(await _context.mengova.ToListAsync());
    }

    // GET: Categories/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Categories/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,DisplayOrder")] Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public IActionResult Details(int id)
    {
        var category = _context.mengova.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
}
