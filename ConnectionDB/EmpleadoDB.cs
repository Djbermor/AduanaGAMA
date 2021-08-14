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
    public class EmpleadoDB
    {
        //public static DataTable ConsultarEmpleado(int i)
        //{
        //    DataTable resultado = new DataTable();
        //    //using lo usamos para que la variable connection solo exista dentro de el (de using)
        //    using (SqlConnection connection = new Connection().GetConnection())
        //    {
        //        //connection.Open();
        //        using (SqlCommand sqlCommand = new SqlCommand("GestionEmpleado", connection) { CommandType = CommandType.StoredProcedure })
        //        {
        //            var parametro = new SqlParameter("@Activor", "Consultar")
        //            {
        //                SqlDbType = SqlDbType.Int,
        //                Size = 0,
        //                Direction = ParameterDirection.Input
        //            };

        //            sqlCommand.Parameters.Add(parametro);
        //        }

        //        connection.Close();
        //        return resultado;
        //    }
        //}

        public static DataTable RegistrarEmpleado(string activar, Empleado empleado)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("GestionEmpleado", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", activar) {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@nombre", empleado.Nombre) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@apellido", empleado.Apellido) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@direccion", empleado.Direccion) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@telefono", empleado.Telefono) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@salario", empleado.Salario) {  SqlDbType = SqlDbType.Money, Direction = ParameterDirection.Input },
                        new SqlParameter("@departamento", empleado.Departamento) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                        new SqlParameter("@rol", empleado.Rol) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                        new SqlParameter("@fecha", empleado.Fecha) {  SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input },
                        new SqlParameter("@sexo", empleado.Sexo) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@codigo", empleado.CodigoEmpresa) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
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

        //Metodo generico para el cargue de los datos Rol, Departameto y Sexo y el empleado.
        public static DataTable ConsultarOpcionEmpleado(string activar, int id = 0)
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
