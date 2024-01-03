using MediatR;
using SistemaPrayaga.Domain;
using SistemaPrayaga.Infraestructure;

namespace SistemaPrayaga.Application
{
    public class CreateFacultadComandHandler : IRequestHandler<CreateFacultadComand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateFacultadComandHandler(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> Handle(CreateFacultadComand request, CancellationToken cancellationToken)
        {
            var factultadEntity = new Facultad();
            factultadEntity.Create(request.Nombre,request.Codigo);

            await _unitOfWork.Repository<Facultad>().Add(factultadEntity);

            await _unitOfWork.SaveEntitiesAsync();

            return factultadEntity.id;
        }
    }
}