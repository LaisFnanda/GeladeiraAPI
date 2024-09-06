using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class ItemModels
{
    public int IdItem { get; set; }

    public string? DescricaoItem { get; set; }

    public int? Quantidade { get; set; }

    public string? Unidade { get; set; }

    public string? Classificacao { get; set; }

    public int? Andar { get; set; }

    public int? Container { get; set; }

    public int? Posicao { get; set; }
}
