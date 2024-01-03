namespace SistemaPrayaga.Domain
{
    public abstract class Entity
    {
        public int id { get; set; }
        public DateTime creado_tmstp { get; set; }
        public DateTime actualizado_tmstp { get; set; } 
        public bool es_activo { get; set; }
    }
}