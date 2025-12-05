using System;
using System.Collections.Generic;

namespace Lumin.Models
{
    public class Perfil
    {
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Empresa { get; set; }
        public string Avatar { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Perfil> Amigos { get; set; } = new List<Perfil>();
        public List<Perfil> PedidosAmizade { get; set; } = new List<Perfil>();
    }

    public class Post
    {
        public string Conteudo { get; set; }
        public string Imagem { get; set; }
        public string Autor { get; set; }
        public DateTime Data { get; set; }
    }
}
