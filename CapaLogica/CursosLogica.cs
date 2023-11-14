using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CursosLogica
    {
        private CursosDatos cursosDatos;

        public CursosLogica()
        {
            cursosDatos = new CursosDatos();
        }

        public List<Cursos> ObtenerCursos()
        {
            return cursosDatos.ObtenerCursos();
        }

        public void InsertarCursos(Cursos Estudiante)
        {
            cursosDatos.InsertarCursos(Estudiante);
        }

        public void EditarCursos(Cursos Estudiante)
        {
            cursosDatos.EditarCursos(Estudiante);
        }

        public void EliminarCursos(int idEstudiante)
        {
            cursosDatos.EliminarCursos(idEstudiante);
        }
    }
}
