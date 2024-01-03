using MediatR;
using SistemaPrayaga.Domain;
using SistemaPrayaga.Infraestructure;

namespace SistemaPrayaga.Application
{
    public class CreateCarreraComandHandler : IRequestHandler<CreateCarreraComand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCarreraComandHandler(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> Handle(CreateCarreraComand request, CancellationToken cancellationToken)
        {
            var carreraEntity = new Carrera();
            carreraEntity.Create(request.IdFacultad,request.Nombre,request.Codigo);

            await _unitOfWork.Repository<Carrera>().Add(carreraEntity);

            await _unitOfWork.SaveEntitiesAsync();

            return carreraEntity.id;
        }
    }
}