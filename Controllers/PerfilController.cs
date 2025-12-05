using Microsoft.AspNetCore.Mvc;
using Lumin.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lumin.Controllers
{
    public class PerfilController : Controller
    {
        // Simula banco de dados em memória
        private static List<Perfil> perfis = new List<Perfil>()
        {
            new Perfil
            {
                Id = 1,
                UsuarioId = 1,
                Nome = "Usuário Exemplo",
                Bio = "Bio inicial...",
                Avatar = "/img/avatar.png"
            }
        };

        private int usuarioLogadoId = 1; // simula usuário logado

        [HttpGet]
        public IActionResult Visualizar()
        {
            var perfil = perfis.FirstOrDefault(p => p.UsuarioId == usuarioLogadoId);
            return View(perfil);
        }

        [HttpGet]
        public IActionResult Editar()
        {
            var perfil = perfis.FirstOrDefault(p => p.UsuarioId == usuarioLogadoId);
            return View(perfil);
        }

        [HttpPost]
        public IActionResult Editar(Perfil modelo)
        {
            var perfil = perfis.FirstOrDefault(p => p.UsuarioId == usuarioLogadoId);

            perfil.Nome = modelo.Nome;
            perfil.Bio = modelo.Bio;

            return RedirectToAction("Visualizar");
        }

        [HttpGet]
        public IActionResult Publico(int id)
        {
            var perfil = perfis.FirstOrDefault(p => p.Id == id);
            return View(perfil);
        }
    }
}
