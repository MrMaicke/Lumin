using System;
using System.Collections.Generic;

namespace Lumin.Models;

public partial class TipoPrestador
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Curtida> Curtida { get; set; } = new List<Curtida>();

    public virtual ICollection<PrestadorDeServico> PrestadorDeServicos { get; set; } = new List<PrestadorDeServico>();
}
