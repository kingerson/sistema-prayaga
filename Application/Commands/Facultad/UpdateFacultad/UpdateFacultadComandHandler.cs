using MediatR;
using SistemaPrayaga.Domain;
using SistemaPrayaga.Infraestructure;

namespace SistemaPrayaga.Application
{
    public class UpdateFacultadComandHandler : IRequestHandler<UpdateFacultadComand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateFacultadComandHandler(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> Handle(UpdateFacultadComand request, CancellationToken cancellationToken)
        {
            var factultadEntity = await _unitOfWork.Repository<Facultad>().GetById(request.Id);
            if (factultadEntity is null)
                throw new SistemaPrayagaException("La facultad no existe");

            factultadEntity.Update(request.Nombre,request.Codigo);

            _unitOfWork.Repository<Facultad>().Update(factultadEntity);

            await _unitOfWork.SaveEntitiesAsync();

            return factultadEntity.id;
        }
    }
}