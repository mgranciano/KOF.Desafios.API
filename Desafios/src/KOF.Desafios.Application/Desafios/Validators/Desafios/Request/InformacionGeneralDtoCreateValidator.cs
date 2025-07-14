using System;
using FluentValidation;
using KOF.Desafios.Application.Dtos.Desafios;

namespace KOF.Desafios.Application.Desafios.Validators.Desafios.Request;

public class InformacionGeneralDtoCreateValidator : AbstractValidator<InformacionGeneralDto>
{
    public InformacionGeneralDtoCreateValidator()
    {
        // 1. Validación para campos REQUERIDOS
        RuleFor(x => x.IdSegmentacion)
            .NotEmpty().WithMessage("La segmentación es requerida");

        RuleFor(x => x.TituloDesafio)
            .NotEmpty().WithMessage("El título es requerido")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres");

        RuleFor(x => x.DescripcionDesafio)
            .NotEmpty().WithMessage("La descripción es requerida")
            .MaximumLength(500).WithMessage("Máximo 500 caracteres");

        RuleFor(x => x.LogotipoDesafio)
            .NotEmpty().WithMessage("El logotipo es requerido")
            .MaximumLength(250).WithMessage("Máximo 250 caracteres");

        RuleFor(x => x.Promocion)
            .NotEmpty().WithMessage("La promoción es requerida")
            .MaximumLength(50).WithMessage("Máximo 50 caracteres");

        RuleFor(x => x.Estatus)
            .NotEmpty().WithMessage("El estatus es requerido")
            .MaximumLength(15).WithMessage("Máximo 15 caracteres");

        // 2. Validación para FECHAS
        RuleFor(x => x.FechaInicio)
            .NotEmpty().WithMessage("La fecha de inicio es requerida")
            .LessThan(x => x.FechaFinalizacion).WithMessage("La fecha de inicio debe ser anterior a la finalización");

        RuleFor(x => x.FechaFinalizacion)
            .NotEmpty().WithMessage("La fecha de finalización es requerida");




    }

}


