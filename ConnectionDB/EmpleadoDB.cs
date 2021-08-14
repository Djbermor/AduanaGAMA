using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDB
{
    class EmpleadoDB: Connection
    {
        public void ConsultarEmpleado()
        {
            //using lo usamos para que la variable connection solo exista dentro de el (de using)
            using (SqlConnection connection = base.GetConnection())
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
    }
}
