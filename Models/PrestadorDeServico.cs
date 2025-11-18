using System;
using System.Collections.Generic;

namespace Lumin.Models;

public partial class PrestadorDeServico
{
    public int Id { get; set; }

    public int? Identificador { get; set; }

    public string? Certificados { get; set; }

    public int? TipoId { get; set; }

    public virtual TipoPrestador? Tipo { get; set; }
}
