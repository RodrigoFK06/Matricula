using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class HorariosDatos : Conexion
    {
        public List<Horarios> ObtenerHorarios()
        {
            List<Horarios> horarios = new List<Horarios>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_MostrarHorarios";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Horarios horario = new Horarios
                            {
                                ID_horario = Convert.ToInt32(reader["ID_horario"]),
                                ID_curso = Convert.ToInt32(reader["ID_curso"]),
                                dia_semana = Convert.ToString(reader["dia_semana"]),
                                hora_inicio = Convert.ToInt32(reader["hora_inicio"]),
                                hora_fin = Convert.ToInt32(reader["hora_fin"]),
                                aula = Convert.ToString(reader["aula"]),
                            };

                            horarios.Add(horario);
                        }
                    }
                }
            }

            return horarios;
        }

        public void InsertarHorarios(Horarios horario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_RegistrarHorario";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@ID_curso", horario.ID_curso);
                    cmd.Parameters.AddWithValue("@dia_semana", horario.dia_semana);
                    cmd.Parameters.AddWithValue("@hora_inicio", horario.hora_inicio);
                    cmd.Parameters.AddWithValue("@hora_fin", horario.hora_fin);
                    cmd.Parameters.AddWithValue("@aula", horario.aula);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditarHorarios(Horarios horario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_EditarHorario";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_horario", horario.ID_horario);
                    cmd.Parameters.AddWithValue("@ID_curso", horario.ID_curso);
                    cmd.Parameters.AddWithValue("@dia_semana", horario.dia_semana);
                    cmd.Parameters.AddWithValue("@hora_inicio", horario.hora_inicio);
                    cmd.Parameters.AddWithValue("@hora_fin", horario.hora_fin);
                    cmd.Parameters.AddWithValue("@aula", horario.aula);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarHorarios(int ID_horario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_EliminarHorario";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_horario", ID_horario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
