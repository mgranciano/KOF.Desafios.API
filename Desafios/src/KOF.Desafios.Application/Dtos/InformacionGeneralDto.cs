using System;

namespace KOF.Desafios.Application.Dtos.Desafios;

public class InformacionGeneralDto
{
    public string IdPais { get; set; } = "GT";
    public int IdSegmentacion { get; set; }
    public int IdDesafio { get; set; }
    public string TituloDesafio { get; set; } = string.Empty;
    public string LogotipoDesafio { get; set; } = string.Empty;
    public string DescripcionDesafio { get; set; } = string.Empty;
    public string Promocion { get; set; } = string.Empty;
    public int PuntosExtra { get; set; }
    public string FechaInicio { get; set; } = string.Empty; // yyyy-MM-dd
    public string FechaFinalizacion { get; set; } = string.Empty; // yyyy-MM-dd
    public string Estatus { get; set; } = string.Empty;
    public string JsonMateriales { get; set; } = string.Empty;
}
