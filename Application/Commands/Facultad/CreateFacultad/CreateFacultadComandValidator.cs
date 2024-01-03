using FluentValidation;

namespace SistemaPrayaga.Application
{
    public class CreateFacultadComandValidator : AbstractValidator<CreateFacultadComand>
    {
        public CreateFacultadComandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
            RuleFor(x => x.Codigo).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        }
    }
}