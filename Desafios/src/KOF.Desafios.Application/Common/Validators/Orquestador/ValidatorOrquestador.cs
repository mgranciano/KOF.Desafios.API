using System;
using FluentValidation;
using KOF.Desafios.Application.Common.Validators.Interfaces;
using KOF.Desafios.Domain.Common.Enums;

namespace KOF.Desafios.Application.Common.Validators.Orquestador;

public class ValidatorOrquestador : IValidatorOrquestador
{
    private readonly IServiceProvider _serviceProvider;
    public ValidatorOrquestador(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ValidateAsync<T>(T entity, Operacion operation)
    {
        var validatorType = GetValidatorType<T>(operation);
        var validator =  _serviceProvider.GetService(validatorType) as IValidator<T>;

        if (validator == null)
            throw new InvalidOperationException($"No validator registered for type {typeof(T).Name} and operation {operation}");

        var result = await validator.ValidateAsync(entity);
        if (!result.IsValid)
        {
            var errors = string.Join(" | ", result.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Validation failed: {errors}");
        }
    }
    private Type GetValidatorType<T>(Operacion operacion)
    {
        var validatorName = $"{typeof(T).Name}{operacion}Validator";
        var validatorType = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .FirstOrDefault(p =>
                typeof(IValidator<T>).IsAssignableFrom(p) &&
                p.Name.Equals(validatorName, StringComparison.OrdinalIgnoreCase));

        return validatorType ?? throw new InvalidOperationException($"Validator not found for {typeof(T).Name} + {operacion}");

    }
}
