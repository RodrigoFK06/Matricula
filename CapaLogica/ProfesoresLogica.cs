using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ProfesoresLogica
    {
        private ProfesoresDatos profesoresDatos;

        public ProfesoresLogica()
        {
            profesoresDatos = new ProfesoresDatos();
        }

        public List<Profesores> ObtenerProfesores()
        {
            return profesoresDatos.ObtenerProfesores();
        }

        public void InsertarProfesores(Profesores Profesores)
        {
            profesoresDatos.InsertarProfesores(Profesores);
        }

        public void EditarProfesores(Profesores Profesores)
        {
            profesoresDatos.EditarProfesores(Profesores);
        }

        public void EliminarProfesores(int idProfesores)
        {
            profesoresDatos.EliminarProfesores(idProfesores);
        }
    }
}
