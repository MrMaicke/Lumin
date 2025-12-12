using System;
using System.Collections.Generic;

namespace Lumin.Models;

public partial class Postagem
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? DataPostagem { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Curtida> Curtida { get; set; } = new List<Curtida>();

    public virtual ICollection<Midium> Midia { get; set; } = new List<Midium>();

    public virtual Usuario? Usuario { get; set; }
}
