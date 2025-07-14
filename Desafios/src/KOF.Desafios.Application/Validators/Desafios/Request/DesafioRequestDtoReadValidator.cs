using System;
using FluentValidation;
using KOF.Desafios.Application.Dtos.Desafios.Request;

namespace KOF.Desafios.Application.Validators.Desafios.Request;

public class DesafioRequestDtoReadValidator : AbstractValidator<DesafioRequestDto>
{
    public DesafioRequestDtoReadValidator()
    {
        RuleFor(x => x.IdSegmentacion)
            .GreaterThan(0).WithMessage("El identificador de segmentación debe ser mayor a cero.");

        RuleFor(x => x.IdPais)
            .MaximumLength(5).WithMessage("El país no debe exceder 5 caracteres.")
            .When(x => !string.IsNullOrWhiteSpace(x.IdPais));

        RuleFor(x => x.Estatus)
            .MaximumLength(15).WithMessage("El estatus no debe exceder 15 caracteres.")
            .When(x => !string.IsNullOrWhiteSpace(x.Estatus));
    }

}
