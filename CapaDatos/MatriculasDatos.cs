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
    public class MatriculasDatos : Conexion
    {
        public List<Matriculas> ObtenerMatriculas()
        {
            List<Matriculas> matriculas = new List<Matriculas>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_MostrarMatriculas";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Matriculas matricula = new Matriculas
                            {
                                ID_matricula = Convert.ToInt32(reader["ID_matricula"]),
                                ID_estudiante = Convert.ToInt32(reader["ID_estudiante"]),
                                ID_curso = Convert.ToInt32(reader["ID_curso"]),
                                fecha_matricula = Convert.ToDateTime(reader["fecha_matricula"]),
                                estado = Convert.ToString(reader["estado"]),
                                
                            };

                            matriculas.Add(matricula);
                        }
                    }
                }
            }

            return matriculas;
        }

        public void InsertarMatriculas(Matriculas matricula)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_RegistrarMatricula";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_estudiante", matricula.ID_estudiante);
                    cmd.Parameters.AddWithValue("@ID_curso", matricula.ID_curso);
                    cmd.Parameters.AddWithValue("@fecha_matricula", matricula.fecha_matricula);
                    cmd.Parameters.AddWithValue("@estado", matricula.estado);
                   


                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
