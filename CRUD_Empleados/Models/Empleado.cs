namespace CRUD_Empleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Corre { get; set; }
        public DateOnly FechaAdmision { get; set; }
        public bool Activo { get; set; }
    }
}
