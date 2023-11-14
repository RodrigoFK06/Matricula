using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaLogica
{
    public class EstudiantesLogica 
    {
        private EstudiantesDatos estudiantesDatos;

        public EstudiantesLogica()
        {
            estudiantesDatos = new EstudiantesDatos();
        }

        public List<Estudiantes> ObtenerEstudiantes()
        {
            return estudiantesDatos.ObtenerEstudiantes();
        }

        public void InsertarEstudiante(Estudiantes Estudiante)
        {
            estudiantesDatos.InsertarEstudiantes(Estudiante);
        }

        public void EditarEstudiante(Estudiantes Estudiante)
        {
            estudiantesDatos.EditarEstudiantes(Estudiante);
        }

        public void EliminarEstudiante(int idEstudiante)
        {
            estudiantesDatos.EliminarEstudiantes(idEstudiante);
        }
    }
}
