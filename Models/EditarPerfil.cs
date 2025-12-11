namespace Lumin.Models;

public class EditarUsuario
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string FotoPerfil { get; set; }   // caso tenha imagem
    public string Avatar { get; set; }   // caso tenha imagem
}