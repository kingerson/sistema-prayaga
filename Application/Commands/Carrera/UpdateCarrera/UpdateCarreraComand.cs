using MediatR;

namespace SistemaPrayaga.Application
{
    public class UpdateCarreraComand: IRequest<int>
    {
        public int Id { get; set; }
        public int IdFacultad { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}