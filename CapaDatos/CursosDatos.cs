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
    public class CursosDatos : Conexion
    {
        public List<Cursos> ObtenerCursos()
        {
            List<Cursos> cursos = new List<Cursos>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_MostrarCursos";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cursos curso = new Cursos
                            {
                                ID_curso = Convert.ToInt32(reader["ID_curso"]),
                                nombre_curso = Convert.ToString(reader["nombre_curso"]),
                                descripcion = Convert.ToString(reader["descripcion"]),
                                creditos = Convert.ToInt32(reader["creditos"]),
                                ID_Profesor = Convert.ToInt32(reader["ID_Profesor"]),
                                
                            };

                            cursos.Add(curso);
                        }
                    }
                }
            }

            return cursos;
        }

        public void InsertarCursos(Cursos curso)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_Registrarcurso";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre_curso", curso.nombre_curso);
                    cmd.Parameters.AddWithValue("@descripcion", curso.descripcion);
                    cmd.Parameters.AddWithValue("@creditos", curso.creditos);
                    cmd.Parameters.AddWithValue("@ID_Profesor", curso.ID_Profesor);
                    


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditarCursos(Cursos curso)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_Editarcurso";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_curso", curso.ID_curso);
                    cmd.Parameters.AddWithValue("@nombre_curso", curso.nombre_curso);
                    cmd.Parameters.AddWithValue("@descripcion", curso.descripcion);
                    cmd.Parameters.AddWithValue("@creditos", curso.creditos);
                    cmd.Parameters.AddWithValue("@ID_Profesor", curso.ID_Profesor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCursos(int ID_curso)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string procedimiento = "sp_Eliminarcurso";

                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_curso", ID_curso);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
