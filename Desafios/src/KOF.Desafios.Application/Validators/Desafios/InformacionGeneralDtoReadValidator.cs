using System;
using System.Data;
using FluentValidation;
using KOF.Desafios.Application.Dtos.Desafios;

namespace KOF.Desafios.Application.Validators.Desafios;

public class InformacionGeneralDtoReadValidator : AbstractValidator<InformacionGeneralDto>
{
    public InformacionGeneralDtoReadValidator()
    {
        RuleFor(x => x.IdSegmentacion)
            .GreaterThan(0).WithMessage("La segmentación es requerida.");

        RuleFor(x => x.TituloDesafio)
            .NotEmpty().WithMessage("El título del desafío es requerido.")
            .MaximumLength(100).WithMessage("El título no puede exceder los 100 caracteres.");

        RuleFor(x => x.DescripcionDesafio)
            .NotEmpty().WithMessage("La descripción del desafío es requerida.")
            .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");

        RuleFor(x => x.LogotipoDesafio)
            .NotEmpty().WithMessage("El logotipo del desafío es requerido.")
            .MaximumLength(250).WithMessage("El logotipo no puede exceder los 250 caracteres.");

        RuleFor(x => x.Promocion)
            .NotEmpty().WithMessage("La promoción es requerida.")
            .MaximumLength(50).WithMessage("La promoción no puede exceder los 50 caracteres.");

        RuleFor(x => x.Estatus)
            .NotEmpty().WithMessage("El estatus es requerido.")
            .MaximumLength(15).WithMessage("El estatus no puede exceder los 15 caracteres.");

        RuleFor(x => x.FechaInicio)
            .NotEmpty().WithMessage("La fecha de inicio es requerida.")
            .Must(BeAValidDate).WithMessage("La fecha de inicio no es válida.");

        RuleFor(x => x.FechaFinalizacion)
            .NotEmpty().WithMessage("La fecha de finalización es requerida.")
            .Must(BeAValidDate).WithMessage("La fecha de finalización no es válida.")
            .GreaterThan(x => x.FechaInicio).WithMessage("La fecha de finalización debe ser mayor a la de inicio.");

        RuleFor(x => x.FechaCreacion)
            .Must(BeNullableValidDate).WithMessage("La fecha de creación no es válida.");

        RuleFor(x => x.UsuarioCreacion)
            .MaximumLength(250).WithMessage("El usuario de creación no puede exceder los 250 caracteres.");

        RuleFor(x => x.FechaPublicacion)
            .Must(BeNullableValidDate).WithMessage("La fecha de publicación no es válida.");

        RuleFor(x => x.UsuarioPublicacion)
            .MaximumLength(250).WithMessage("El usuario de publicación no puede exceder los 250 caracteres.");

        RuleFor(x => x.FechaCierre)
            .Must(BeNullableValidDate).WithMessage("La fecha de cierre no es válida.");

        RuleFor(x => x.UsuarioCierre)
            .MaximumLength(250).WithMessage("El usuario de cierre no puede exceder los 250 caracteres.");

        RuleFor(x => x.FechaCancela)
            .Must(BeNullableValidDate).WithMessage("La fecha de cancelación no es válida.");

        RuleFor(x => x.UsuarioCancela)
            .MaximumLength(250).WithMessage("El usuario que cancela no puede exceder los 250 caracteres.");

    }
    private static bool BeAValidDate(DateTime fecha)
    {
        return fecha != default;
    }

    private static bool BeNullableValidDate(DateTime? fecha)
    {
        return fecha == null || fecha > DateTime.MinValue;
    }
}
