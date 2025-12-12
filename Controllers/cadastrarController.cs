using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class CadastrarController : Controller
{
    LuminContext _context = new LuminContext();

    public IActionResult Index()
    {
        var listaUsuario = _context.Usuarios.ToList();

        ViewBag.listaUsuario = listaUsuario;

        return View(); // carrega Views/Login/Index.cshtml
    }

    [HttpPost]
    [Route("Login")]
    public IActionResult LoginUsuario(Usuario usuario)
    {
        _context.Add(usuario);
        _context.SaveChanges();

        return RedirectToAction("Index");  // <--- Correto
    }

    [HttpPost]
    [Route("Cadastrar")]
    public IActionResult Cadastrar(Usuario usuario, string ConfSenha)
    {
        if (usuario.Senha != ConfSenha)
        {
            TempData["ErrorMessage"] = "As senhas não coincidem.";
            return RedirectToAction("Index"); // bloqueia o acesso
        }

        // Cadastrando um usuairo
        _context.Add(usuario);

        _context.SaveChanges();

        // Senhas batem → pode continuar
        TempData["SuccessMessage"] = "Senha confirmada!";
        return RedirectToAction("Index", "Feed"); // ou qualquer próxima página
    }
}