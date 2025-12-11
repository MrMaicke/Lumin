using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lumin.Controllers
{
    public class EditarUsuarioController : Controller
    {
        private readonly LuminContext _context;

        public EditarUsuarioController(LuminContext context)
        {
            _context = context;
        }

        // GET: /Perfil/Editar/1
        public IActionResult Editar(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        // POST: /Perfil/Editar
        [HttpPost]
        public IActionResult Editar(EditarUsuario usuarioEditado)
        {
            if (!ModelState.IsValid)
                return View(usuarioEditado);

            var find = _context.Usuarios.FirstOrDefault(x => x.Id == usuarioEditado.Id);

            if (find == null)
                return NotFound();

            EditarUsuario usuario = new EditarUsuario()
            {
                Nome = usuarioEditado.Nome,
                Cidade = usuarioEditado.Cidade,
                Estado = usuarioEditado.Estado,
                FotoPerfil = usuarioEditado.Avatar
            };

            _context.Update(usuario);
            _context.SaveChanges();

            TempData["Sucesso"] = "Perfil atualizado com sucesso!";
            return RedirectToAction("Editar", new { id = usuario.Id });
        }
    }
}