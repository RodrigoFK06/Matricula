using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Horarios
    {
        public int ID_horario { get; set; }
        public int ID_curso { get; set; }
        public string dia_semana { get; set; }
        public int hora_inicio { get; set; }
        public int hora_fin {  get; set; }
        public string aula {  get; set; }

    }
}
