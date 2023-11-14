using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    internal class HorariosLogica
    {
        private HorariosDatos horariosDatos;

        public HorariosLogica()
        {
            horariosDatos = new HorariosDatos();
        }

        public List<Horarios> ObtenerHorarios()
        {
            return horariosDatos.ObtenerHorarios();
        }

        public void InsertarHorario(Horarios Horario)
        {
            horariosDatos.InsertarHorarios(Horario);
        }

        public void EditarHorario(Horarios Horario)
        {
            horariosDatos.EditarHorarios(Horario);
        }

        public void EliminarHorario(int idHorario)
        {
            horariosDatos.EliminarHorarios(idHorario);
        }
    }
}
