using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class EstudiantesDatos : Conexion
    {
        public List<Estudiantes> ObtenerEstudiantes()
        {
            List<Estudiantes> estudiantes = new List<Estudiantes>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_MostrarEstudiantes";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Estudiantes estudiante = new Estudiantes
                            {
                                ID_estudiante = Convert.ToInt32(reader["ID_estudiante"]),
                                nombres = Convert.ToString(reader["nombres"]),
                                apellidos = Convert.ToString(reader["apellidos"]),
                                fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                                correo = Convert.ToString(reader["correo"]),
                                direccion = Convert.ToString(reader["direccion"]),
                            };

                            estudiantes.Add(estudiante);
                        }
                    }
                }
            }

            return estudiantes;
        }

        public void InsertarEstudiantes(Estudiantes estudiante)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_RegistrarEstudiante";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombres", estudiante.nombres);
                    cmd.Parameters.AddWithValue("@apellidos", estudiante.apellidos);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", estudiante.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@correo", estudiante.correo);
                    cmd.Parameters.AddWithValue("@direccion", estudiante.direccion);
                    

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditarEstudiantes(Estudiantes estudiante)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_EditarEstudiante";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_estudiante", estudiante.ID_estudiante);
                    cmd.Parameters.AddWithValue("@nombres", estudiante.nombres);
                    cmd.Parameters.AddWithValue("@apellidos", estudiante.apellidos);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", estudiante.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@correo", estudiante.correo);
                    cmd.Parameters.AddWithValue("@direccion", estudiante.direccion);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarEstudiantes(int ID_estudiante)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_EliminarEstudiante";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_estudiante", ID_estudiante);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
