using FluentValidation;
using MediatR;
using System.Diagnostics;

namespace Order.Pipeline
{
    public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
          => _validators = validators;

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .ToArray();

            if (failures.Length > 0)
            {
                var errors = failures
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(k => k.Key, v => v.Select(x => x.ErrorMessage).ToArray());

                foreach(var error in errors)
                {
                    foreach(var errs in error.Value)
                    {
                        Debug.WriteLine(error.Key + " " + errs);
                    }
                }
                
                throw new Exception("An error occured!");
            }

            return next();
        }
    }
}
