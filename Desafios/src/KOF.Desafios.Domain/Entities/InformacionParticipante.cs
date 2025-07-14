using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOF.Desafios.Domain.Entities.Desafios;

public class InformacionParticipante
{
    public int Id { get; set; }
    public int IdDesafio { get; set; }
    public string IdCliente { get; set; } = string.Empty;
    public int IdEstatusDesafio { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinalizacion { get; set; }
    public DateTime FechaUltimaActualizacion { get; set; }
}
