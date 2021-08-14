using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDB
{
    public class EmpleadoDB
    {
        public void ConsultarEmpleado()
        {
            //using lo usamos para que la variable connection solo exista dentro de el (de using)
            using (SqlConnection connection = new Connection().GetConnection())
            {
                //connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("nombre sp", connection))
                {
                    var parametro = new SqlParameter("@nombre", "valor")
                    {
                        SqlDbType = SqlDbType.Int,
                        Size = 0,
                        Direction = ParameterDirection.Input
                    };

                    sqlCommand.Parameters.Add(parametro);
                }

                connection.Close();
            }
        }

        //Metodo generico para el cargue de los datos Rol, Departameto y Sexo.
        public static DataTable ConsultarOpcion(string activar)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("GestionEmpleado", connection) { CommandType = CommandType.StoredProcedure })
                {
                    var parametro = new SqlParameter("@Activar", activar)
                    {
                        SqlDbType = SqlDbType.VarChar,
                        Size = 20,
                        Direction = ParameterDirection.Input
                    };

                    sqlCommand.Parameters.Add(parametro);

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
