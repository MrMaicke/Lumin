using Lumin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Lumin.Controllers
{
    public class EditarPerfilController : Controller
    {
        private readonly AppContext _context;

        public EditarPerfilController(AppContext context)
        {
            _context = context;
        }

        // GET /Perfil/Editar/1
        public IActionResult Editar(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        // POST /Perfil/Editar
        [HttpPost]
        public IActionResult Editar(Usuario usuarioEditado)
        {
            if (!ModelState.IsValid)
                return View(usuarioEditado);

            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == usuarioEditado.Id);

            if (usuario == null)
                return NotFound();

            // Atualiza campos
            usuario.Nome = usuarioEditado.Nome;
            usuario.Cidade = usuarioEditado.Cidade;
            usuario.Estado = usuarioEditado.Estado;
            usuario.FotoPerfil = usuarioEditado.Avatar;

            _context.Update(usuario);
            _context.SaveChanges();

            TempData["Sucesso"] = "Perfil atualizado com sucesso!";
            return RedirectToAction("Editar", new { id = usuario.Id });
        }
    }
}