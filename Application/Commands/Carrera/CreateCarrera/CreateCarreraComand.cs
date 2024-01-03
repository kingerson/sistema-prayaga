using MediatR;

namespace SistemaPrayaga.Application
{
    public class CreateCarreraComand: IRequest<int>
    {
        public int IdFacultad { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}