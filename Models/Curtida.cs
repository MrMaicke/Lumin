using System;
using System.Collections.Generic;

namespace Lumin.Models;

public partial class Curtida
{
    public int Id { get; set; }

    public DateTime? Horario { get; set; }

    public int? UsuarioId { get; set; }

    public int? PostagemId { get; set; }

    public virtual Postagem? Postagem { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
