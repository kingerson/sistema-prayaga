using MediatR;

namespace SistemaPrayaga.Application
{
    public class CreateFacultadComand: IRequest<int>
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}