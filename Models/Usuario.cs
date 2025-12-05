using System;
using System.Collections.Generic;

namespace Lumin.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public string? Telefone { get; set; }

    public virtual ICollection<Curtida> Curtida { get; set; } = new List<Curtida>();

    public virtual ICollection<Postagem> Postagems { get; set; } = new List<Postagem>();
}
