using System;
using System.Collections.Generic;

namespace Lumin.Models;

public partial class Postagem
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public int? UsuarioId { get; set; }

    public int? Likes { get; set; }

    public int? DataPostagem { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
