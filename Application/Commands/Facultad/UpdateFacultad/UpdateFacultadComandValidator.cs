using FluentValidation;

namespace SistemaPrayaga.Application
{
    public class UpdateFacultadComandValidator : AbstractValidator<UpdateFacultadComand>
    {
        public UpdateFacultadComandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
            RuleFor(x => x.Nombre).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
            RuleFor(x => x.Codigo).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        }
    }
}