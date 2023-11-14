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
    public class ProfesoresDatos : Conexion
    {
        public List<Profesores> ObtenerProfesores()
        {
            List<Profesores> profesores = new List<Profesores>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_MostrarProfesores";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Profesores profesor = new Profesores
                            {
                                ID_profesor = Convert.ToInt32(reader["ID_profesor"]),
                                nombres = Convert.ToString(reader["nombres"]),
                                apellidos = Convert.ToString(reader["apellidos"]),
                                correo = Convert.ToString(reader["correo"]),
                                direccion = Convert.ToString(reader["direccion"]),
                            };

                            profesores.Add(profesor);
                        }
                    }
                }
            }

            return profesores;
        }

        public void InsertarProfesores(Profesores profesor)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_RegistrarProfesor";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombres", profesor.nombres);
                    cmd.Parameters.AddWithValue("@apellidos", profesor.apellidos);
                    cmd.Parameters.AddWithValue("@correo", profesor.correo);
                    cmd.Parameters.AddWithValue("@direccion", profesor.direccion);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditarProfesores(Profesores profesor)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_EditarProfesor";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_profesor", profesor.ID_profesor);
                    cmd.Parameters.AddWithValue("@nombres", profesor.nombres);
                    cmd.Parameters.AddWithValue("@apellidos", profesor.apellidos);
                    cmd.Parameters.AddWithValue("@correo", profesor.correo);
                    cmd.Parameters.AddWithValue("@direccion", profesor.direccion);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProfesores(int ID_profesor)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_EliminarProfesor";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_profesor", ID_profesor);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
