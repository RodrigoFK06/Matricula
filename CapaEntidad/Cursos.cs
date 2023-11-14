namespace CapaEntidad
{
    public class Cursos
    {
        public int ID_curso { get; set; }
        public string nombre_curso { get; set; }
        public string descripcion { get; set; }
        public int creditos { get; set; }
        public int ID_Profesor { get; set; }
    }
}
