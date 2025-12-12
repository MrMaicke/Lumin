using Lumin.Contexts;
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
    public IActionResult Logar(string email, string senha)
    {
        // Verificar se existe um usuario com o email
        var usuarioProcurado = _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

        if (usuarioProcurado != null)
        {
            if (usuarioProcurado.Senha == senha)
            {
                HttpContext.Session.SetString("Usuario", usuarioProcurado.Id.ToString());

                return RedirectToAction("Index", "Feed");
            }

            TempData["ErrorMessage"] = "Email ou senha inválidos";
        }
        else
        {
            TempData["ErrorMessage"] = "Email não encontrado";   
        }

        return RedirectToAction("Index");
    }
}