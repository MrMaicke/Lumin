using Microsoft.AspNetCore.Mvc;
using Lumin.Models;
using System;
using System.Collections.Generic;

namespace Lumin.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Visualizar()
        {
            // Exemplo de perfil
            var perfil = new Perfil
            {
                Nome = "Kathy Davis",
                Profissao = "Front-end Developer",
                Cidade = "San Francisco",
                Estado = "SA",
                Empresa = "GitHub",
                Avatar = "https://bootdey.com/img/Content/avatar/avatar3.png"
            };

            // Posts de exemplo
            perfil.Posts.Add(new Post
            {
                Autor = "Kathy Davis",
                Conteudo = "Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus...",
                Imagem = "https://bootdey.com/img/Content/avatar/avatar2.png",
                Data = DateTime.Now.AddMinutes(-5)
            });

            perfil.Posts.Add(new Post
            {
                Autor = "Andrew Jones",
                Conteudo = "Nullam quis ante. Etiam rhoncus. Maecenas tempus...",
                Imagem = "https://bootdey.com/img/Content/avatar/avatar4.png",
                Data = DateTime.Now.AddMinutes(-30)
            });

            // Amigos de exemplo
            perfil.Amigos.Add(new Perfil { Nome = "Carlos", Avatar = "https://bootdey.com/img/Content/avatar/avatar5.png" });
            perfil.Amigos.Add(new Perfil { Nome = "Rogerio", Avatar = "https://bootdey.com/img/Content/avatar/avatar4.png" });
            perfil.Amigos.Add(new Perfil { Nome = "Cleiton", Avatar = "https://bootdey.com/img/Content/avatar/avatar2.png" });

            // Pedidos de amizade
            perfil.PedidosAmizade.Add(new Perfil { Nome = "Marie Salter", Avatar = "https://bootdey.com/img/Content/avatar/avatar3.png" });

            return View(perfil);
        }
    }
}
