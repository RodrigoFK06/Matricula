using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class MatriculasLogica
    {
        private MatriculasDatos matriculasDatos;

        public MatriculasLogica()
        {
            matriculasDatos = new MatriculasDatos();
        }

        public List<Matriculas> ObtenerMatriculas()
        {
            return matriculasDatos.ObtenerMatriculas();
        }

        public void InsertarMatricula(Matriculas Matricula)
        {
            matriculasDatos.InsertarMatriculas(Matricula);
        }

        
    }
}
