using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

public interface ICadastrarController
{
    IActionResult CadastrarUsuario(Usuario usuario);
    IActionResult Index();
}

[Route("[controller]")]

public class CadastrarController : Controller, ICadastrarController
{
    // Criar uma referência (instância) sobre a comunicação do meu banco de dados
    LuminContext _context = new LuminContext();

    public IActionResult CadastrarUsuario(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public IActionResult Index()
    {
        // include();//- trago os dados das tabelas relacionadas;
        var listaUsuario = _context.Usuarios.ToList();

        ViewBag.listaUsuario = listaUsuario;

        return View();
    }
}
