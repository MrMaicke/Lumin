using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class InicioController : Controller
{
    LuminContext _context = new LuminContext();
}