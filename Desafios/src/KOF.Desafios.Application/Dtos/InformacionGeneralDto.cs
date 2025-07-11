using System;

namespace KOF.Desafios.Application.Dtos.Desafios;

public class InformacionGeneralDto
{
    public int? IdDesafio { get; set; }  // Solo requerido en Update y Read
    public int IdSegmentacion { get; set; }
    public string TituloDesafio { get; set; } = string.Empty;
    public string DescripcionDesafio { get; set; } = string.Empty;
    public string LogotipoDesafio { get; set; } = string.Empty;
    public string Promocion { get; set; } = string.Empty;
    public int? PuntosExtra { get; set; }
    public string Estatus { get; set; } = string.Empty;
    public string? JsonMateriales { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinalizacion { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime? FechaPublicacion { get; set; }
    public string? UsuarioPublicacion { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string? UsuarioCierre { get; set; }
    public DateTime? FechaCancela { get; set; }
    public string? UsuarioCancela { get; set; }
}
