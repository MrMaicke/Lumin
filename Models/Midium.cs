using System;
using System.Collections.Generic;

namespace Lumin.Models;

public partial class Midium
{
    public int Id { get; set; }

    public string? Imagem { get; set; }

    public int? PostagemId { get; set; }

    public virtual Postagem? Postagem { get; set; }
}
