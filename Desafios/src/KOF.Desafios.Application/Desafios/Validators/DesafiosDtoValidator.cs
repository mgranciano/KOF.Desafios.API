using FluentValidation;
using KOF.Desafios.Application.Desafios.Dto;

namespace KOF.Desafios.Application.Desafios.Validators
{
    public class DesafioDtoValidator : AbstractValidator<DesafioDto>
    {
        public DesafioDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(100).WithMessage("El título no debe exceder los 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no debe exceder los 500 caracteres.");

            RuleFor(x => x.FechaInicio)
                .NotEmpty().WithMessage("La fecha de inicio es obligatoria.");

            RuleFor(x => x.FechaFin)
                .GreaterThanOrEqualTo(x => x.FechaInicio)
                .When(x => x.FechaFin.HasValue)
                .WithMessage("La fecha de fin debe ser mayor o igual a la fecha de inicio.");
        }
    }
}