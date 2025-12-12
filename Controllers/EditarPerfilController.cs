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

        // GET: /EditarUsuario/Editar/1
        [HttpGet]
        public IActionResult Editar(int id)
        {
            // USE _context.Usuarios (não Perfils) — ajuste conforme seu DbContext
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
                return NotFound();

            var model = new EditarUsuario
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                // Se Usuario NÃO tem Cidade/Estado/FotoPerfil, estes ficarão null até você adicionar as colunas
                Cidade = usuario.GetType().GetProperty("Cidade") != null ? (string?)usuario.GetType().GetProperty("Cidade")?.GetValue(usuario) : null,
                Estado = usuario.GetType().GetProperty("Estado") != null ? (string?)usuario.GetType().GetProperty("Estado")?.GetValue(usuario) : null,
                Avatar = usuario.GetType().GetProperty("FotoPerfil") != null ? (string?)usuario.GetType().GetProperty("FotoPerfil")?.GetValue(usuario) : null
            };

            return View(model);
        }

        // POST: /EditarUsuario/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EditarUsuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            var entidade = _context.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);
            if (entidade == null)
                return NotFound();

            entidade.Nome = usuario.Nome;

            // Atualiza apenas se a propriedade existir no model Usuario (evita exception se coluna faltar)
            var propCidade = entidade.GetType().GetProperty("Cidade");
            if (propCidade != null) propCidade.SetValue(entidade, usuario.Cidade);

            var propEstado = entidade.GetType().GetProperty("Estado");
            if (propEstado != null) propEstado.SetValue(entidade, usuario.Estado);

            var propFoto = entidade.GetType().GetProperty("FotoPerfil");
            if (propFoto != null) propFoto.SetValue(entidade, usuario.Avatar);

            _context.SaveChanges();

            TempData["Sucesso"] = "Perfil atualizado com sucesso!";
            return RedirectToAction("Editar", new { id = usuario.Id });
        }
    }
}