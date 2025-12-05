using System.Linq;
using System.Web.Mvc;
using SeuProjeto.Data;
using SeuProjeto.Models;

namespace SeuProjeto.Controllers
{
    public class PerfilController : Controller
    {
        // Simula o usuário logado (ex: usuárioId = 1)
        private int usuarioLogadoId = 1;

        public ActionResult Visualizar()
        {
            var perfil = BancoFake.Perfis
                .FirstOrDefault(p => p.UsuarioId == usuarioLogadoId);

            return View(perfil);
        }

        public ActionResult Editar()
        {
            var perfil = BancoFake.Perfis
                .FirstOrDefault(p => p.UsuarioId == usuarioLogadoId);

            return View(perfil);
        }

        [HttpPost]
        public ActionResult Editar(Perfil dados)
        {
            var perfil = BancoFake.Perfis
                .FirstOrDefault(p => p.UsuarioId == usuarioLogadoId);

            perfil.Nome = dados.Nome;
            perfil.Bio = dados.Bio;

            return RedirectToAction("Visualizar");
        }

        public ActionResult Publico(int id)
        {
            var perfil = BancoFake.Perfis
                .FirstOrDefault(p => p.Id == id);

            return View(perfil);
        }
    }
}
