namespace SistemaPrayaga.Domain
{
    public class Facultad : Entity
    {
        public string nombre_facultad { get; private set; }
        public string codigo_facultad { get; private set; }
        public ICollection<Carrera> Carreras { get; private set; } = new List<Carrera>();
        public void Create(string nombre , string codigo)
        {
            nombre_facultad = nombre;
            codigo_facultad = codigo;
        }
        
        public void Update(string nombre , string codigo)
        {
            nombre_facultad = nombre;
            codigo_facultad = codigo;
        }
    }
}