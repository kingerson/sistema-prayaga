using MediatR;

namespace SistemaPrayaga.Application
{
    public class UpdateFacultadComand: IRequest<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}