using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidad;

namespace ConnectionDB
{
    public class RolDB
    {
        public static DataTable RegistrarRol(string activar, Rol rol)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("GestionEmpleado", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", activar) {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@nombre", rol.Nombre) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@id", rol.Id) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            resultado.Load(reader);
                        }

                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                    }
                }
            }

            return resultado;
        }

        public static void EliminarRol(string id)
        {
            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("GestionEmpleado", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "ERol") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@id", id) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        //Metodo generico para el cargue de los datos Rol, Departameto y Sexo y el empleado.
        public static DataTable ConsultarOpcionRol(string activar, int id = 0)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("GestionEmpleado", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", activar) {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@id", id) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            resultado.Load(reader);
                        }

                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                    }
                }
            }

            return resultado;
        }
    }
}
