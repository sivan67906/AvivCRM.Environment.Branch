#region

using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Common.Behaviors;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        // Perform validation
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        // If validation fails, return a TResponse (in this case, ServerResponse)
        if (failures.Any())
        {
            var errorMessage = string.Join("; ", failures.Select(f => f.ErrorMessage));
            return (TResponse)Activator.CreateInstance(typeof(TResponse), false, $"Validation failed: {errorMessage}",
                null!)!;
        }

        // Proceed to the next behavior or handler
        return await next();
    }
}