using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class LoginController : Controller
{
    LuminContext _context = new LuminContext();

    public IActionResult Index()
    {
        var ListaUsuario = _context.Usuarios.ToList();

        ViewBag.listaUsuario = ListaUsuario;

        return View(); // carrega Views/Login/Index.cshtml
    }
    [HttpPost]
    [Route("Login")]
    public IActionResult LoginUsuario(Usuario usuario)
    {
        _context.Add(usuario);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}