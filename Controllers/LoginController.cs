using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

public interface iLoginController
{
    IActionResult LoginUsuario(Usuario usuario);
    IActionResult index();
}


[Route("[controller]")]



#pragma warning disable CA1050 // Declarar tipos em namespaces
public class LoginController : Controller
#pragma warning restore CA1050 // Declarar tipos em namespaces

{
    // Criar uma referência (instância) sobre a comunicação do meu banco de dados
    LuminContext _context = new LuminContext();

    public IActionResult Index()
    {
        // include();//- trago os dados das tabelas relacionadas;
        var listaUsuario = _context.Usuarios.ToList();

        ViewBag.listaUsuario = listaUsuario;

        return View();
    }

    [Route("Login")]
    public IActionResult LoginUsuario(Usuario usuario)
    {

        // Armazenar a equipe no banco de dados
        _context.Add(usuario);

        // Registrar as alterações no banco de dados
        _context.SaveChanges();

        return RedirectToAction("Login");
    }
}
