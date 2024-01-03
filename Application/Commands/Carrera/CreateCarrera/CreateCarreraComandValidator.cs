using FluentValidation;

namespace SistemaPrayaga.Application
{
    public class CreateCarreraComandValidator : AbstractValidator<CreateCarreraComand>
    {
        public CreateCarreraComandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
            RuleFor(x => x.Codigo).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        }
    }
}