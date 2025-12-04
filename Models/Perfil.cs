namespace SeuProjeto.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; } // cada usuário tem seu perfil
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string Avatar { get; set; }
    }
}
