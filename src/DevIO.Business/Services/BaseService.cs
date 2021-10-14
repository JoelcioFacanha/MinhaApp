using DevIO.Business.Models;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Business.Services
{
    public abstract class BaseService
    {
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            // propagar error para camada de apresentação...

        }

        protected bool ExecutarValidacao<TV, T>(TV validation, T entity) where TV : AbstractValidator<T> where T : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }
    }
}
