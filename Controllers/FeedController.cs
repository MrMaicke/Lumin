

using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class FeedController : Controller
{
    private readonly LuminContext _context;

    public FeedController()
    {
        _context = new LuminContext();
    }

    // GET: /Feed
    [HttpGet]
    public IActionResult Index()
    {
        var posts = _context.Postagems
            .OrderByDescending(p => p.Id)
            .ToList();

        return View(posts);
    }

    // POST: /Feed/Create
    [HttpPost]
    [Route("Create")]
    public IActionResult Create(Postagem postagem)
    {
        if (string.IsNullOrEmpty(postagem.Descricao))
            return RedirectToAction("Index");

        postagem.Descricao = postagem.Descricao;

        _context.Postagems.Add(postagem);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}