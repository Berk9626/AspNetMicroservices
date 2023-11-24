using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Ordering.Application.Exceptions.ValidationException;

//Basically running all the validation classes if exist and collect the results.

namespace Ordering.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators; //bütün validatonları topluyor. update, checkouttakileri gibi

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                //bütü validationları seçip alıyor
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                //null eror varsa alıp aşağıda bizim oluşturduğumuz exceptiona yolluyor bu eşşekleri

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
