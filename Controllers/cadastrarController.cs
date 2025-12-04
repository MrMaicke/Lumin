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
    public IActionResult ValidarSenha(string senha, string confiSenha)
    {
    if (string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confiSenha))
        {
            TempData["ErrorMessage"] = "Preencha todos os campos.";
            return RedirectToAction("Index"); // volta para a página do formulário
        }

        if (senha != confiSenha)
        {
            TempData["ErrorMessage"] = "As senhas não coincidem.";
            return RedirectToAction("Index"); // bloqueia o acesso
        }

    // Senhas batem → pode continuar
    TempData["SuccessMessage"] = "Senha confirmada!";
    return RedirectToAction("Feed", "Index"); // ou qualquer próxima página
}
}