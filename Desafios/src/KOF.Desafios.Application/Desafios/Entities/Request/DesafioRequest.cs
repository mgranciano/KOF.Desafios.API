using System;

namespace KOF.Desafios.Application.Entities.Desafios.Request;

public class DesafioRequest: RequestBase
{
    public string? IdPais { get; set; }
    public int IdSegmentacion { get; set; }
    public string? Estatus { get; set; }
}
