using MediatR;
using SistemaPrayaga.Domain;
using SistemaPrayaga.Infraestructure;

namespace SistemaPrayaga.Application
{
    public class UpdateCarreraComandHandler : IRequestHandler<UpdateCarreraComand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCarreraComandHandler(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> Handle(UpdateCarreraComand request, CancellationToken cancellationToken)
        {
            var factultadEntity = await _unitOfWork.Repository<Carrera>().GetById(request.Id);
            if (factultadEntity is null)
                throw new SistemaPrayagaException("La carrera no existe");

            factultadEntity.Update(request.IdFacultad,request.Nombre,request.Codigo);

            _unitOfWork.Repository<Carrera>().Update(factultadEntity);

            await _unitOfWork.SaveEntitiesAsync();

            return factultadEntity.id;
        }
    }
}