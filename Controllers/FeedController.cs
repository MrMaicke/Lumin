using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class FeedController : Controller
{
    LuminContext _context = new LuminContext();

    public IActionResult Index()
    {
        var listaUsuario = _context.Usuarios.ToList();

        ViewBag.listaUsuario = listaUsuario;

        return View(); // carrega Views/Login/Index.cshtml
    }

    [HttpPost]
    [Route("Feed")]
    public IActionResult LoginUsuario(Usuario usuario)
    {
        _context.Add(usuario);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}