using System;

namespace KOF.Desafios.Application.Dtos.Desafios.Request;

public class DesafioRequestDto : RequestBaseDto
{
    public string? IdPais { get; set; }
    public int IdSegmentacion { get; set; }
    public string? Estatus { get; set; }
}
