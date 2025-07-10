using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOF.Desafios.Domain.Entities.Desafios;

[Table("InformacionParticipante", Schema = "desafio")]
public class InformacionParticipante
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int")]
    public int Id { get; set; }

    [Column(TypeName = "int")]
    public int IdDesafio { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string IdCliente { get; set; } = string.Empty;

    [Column(TypeName = "int")]
    public int IdEstatusDesafio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaInicio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaFinalizacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaUltimaActualizacion { get; set; }
}
