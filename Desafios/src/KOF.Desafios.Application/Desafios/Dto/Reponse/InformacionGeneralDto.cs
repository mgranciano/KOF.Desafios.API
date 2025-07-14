using System;

namespace KOF.Desafios.Application.Dtos.Desafios;

public class InformacionGeneralDto
{
    public int IdDesafio { get; set; }  // Solo requerido en Update y Read
    public int IdSegmentacion { get; set; }
    public string TituloDesafio { get; set; } = string.Empty;
    public string DescripcionDesafio { get; set; } = string.Empty;
    public string LogotipoDesafio { get; set; } = string.Empty;
    public string Promocion { get; set; } = string.Empty;
    public int PuntosExtra { get; set; }
    public string Estatus { get; set; } = string.Empty;
    public string JsonMateriales { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinalizacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string UsuarioCreacion { get; set; } = string.Empty;
    public DateTime FechaPublicacion { get; set; }
    public string UsuarioPublicacion { get; set; } = string.Empty;
    public DateTime FechaCierre { get; set; }
    public string UsuarioCierre { get; set; } = string.Empty;
    public DateTime FechaCancela { get; set; }
    public string UsuarioCancela { get; set; } = string.Empty;
}
