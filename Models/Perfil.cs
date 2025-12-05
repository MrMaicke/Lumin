namespace Lumin.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; } // identifica cada usuário
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string Avatar { get; set; } // caminho da imagem
    }
}