using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Matriculas
    {
        public int ID_matricula {  get; set; }
        public int ID_estudiante { get; set; }
        public int ID_curso { get; set; }
        public DateTime fecha_matricula { get; set; }
        public string estado { get; set; }

    }
}
