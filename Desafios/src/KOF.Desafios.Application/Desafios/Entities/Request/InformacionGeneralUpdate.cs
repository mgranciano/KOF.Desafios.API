using System;

namespace KOF.Desafios.Application.Desafios.Entities.Request;

public class InformacionGeneralUpdate
{
    public int IdDesafio { get; set; }
    public string TituloDesafio { get; set; } = string.Empty;
    public string DescripcionDesafio { get; set; } = string.Empty;
    public string LogotipoDesafio { get; set; } = string.Empty;
    public string Promocion { get; set; } = string.Empty;
    public int PuntosExtra { get; set; }
}
