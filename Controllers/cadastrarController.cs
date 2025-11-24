using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]

public class CadastrarController : Controller
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

    [Route("cadastrar")]
    public IActionResult CadastrarUsuario(Usuario usuario)
    {

        // Registrar as alterações no banco de dados
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}





    
