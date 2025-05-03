using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Exceptions;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Bookify.Application.Abstractions.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate
        <TResponse> next, CancellationToken cancellationToken
        )
    {
        if (!_validators.Any())
        {
            return await next();
        }
        var context = new ValidationContext<TRequest>(request);
        var validationError = _validators
            .Select(v => v.Validate(context))
            .Where(ValidationResult => ValidationResult.Errors.Any())
            .SelectMany(ValidationResult => ValidationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.ErrorMessage, 
                validationFailure.PropertyName))
            .ToList();
        if (validationError.Any())
        {
            throw new Exceptions.ValidationException(validationError);
        }
        return await next();
    }
}
