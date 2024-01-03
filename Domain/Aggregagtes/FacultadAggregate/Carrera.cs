namespace SistemaPrayaga.Domain
{
    public class Carrera : Entity
    {
        public int id_facultad { get; private set; }
        public string nombre_carrera { get; private set; }
        public string codigo_carrera { get; private set; }
        public Facultad Facultad { get; private set; }
        public void Create(int idFacultad, string nombre, string codigo)
        {
            id_facultad = idFacultad;
            nombre_carrera = nombre;
            codigo_carrera = codigo;
        }
    }
}