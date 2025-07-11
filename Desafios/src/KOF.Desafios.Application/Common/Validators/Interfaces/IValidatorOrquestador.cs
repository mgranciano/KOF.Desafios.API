using System;
using KOF.Desafios.Domain.Common.Enums;

namespace KOF.Desafios.Application.Common.Validators.Interfaces;

public interface IValidatorOrquestador
{
    Task ValidateAsync<T>(T entity, Operacion operation);
}
