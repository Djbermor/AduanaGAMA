using ConnectionDB;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AduanaGAMA
{
    public partial class Empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadControlDropDown(rol, EmpleadoDB.ConsultarOpcionEmpleado("CRoles"), "Id", "Nombre");
            LoadControlDropDown(departamento, EmpleadoDB.ConsultarOpcionEmpleado("CDepa"), "Id", "Nombre");
            LoadControlDropDown(sexo, EmpleadoDB.ConsultarOpcionEmpleado("CSexo"), "Nombre", "Nombre");

            int id = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && int.TryParse(Request.QueryString["id"], out id) && id > 0)
            {
                DataTable empleado = EmpleadoDB.ConsultarOpcionEmpleado("consultar", id);
                //editar
                if (empleado.Rows.Count > 0)
                {
                    var fila = empleado.Rows[0];
                    nombre.Text = fila["Nombre"].ToString();
                    apellido.Text = fila["Apellido"].ToString();
                    direccion.Text = fila["Direccion"].ToString();
                    telefono.Text = fila["Telefono"].ToString();
                    salario.Text = fila["Salario"].ToString();
                    departamento.SelectedValue = fila["IdDepartamento"].ToString();
                    rol.SelectedValue = fila["Rol"].ToString();
                    fecha.Text = fila["FechaIngreso"].ToString();
                    sexo.SelectedValue = fila["Sexo"].ToString();
                    codigoCompania.Text = fila["CodigoCompania"].ToString();
                }
            }
            else
            {
                fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void LoadControlDropDown(DropDownList dropDownList, DataTable datos, string value, string text)
        {
            dropDownList.DataSource = datos;
            dropDownList.DataValueField = value;
            dropDownList.DataTextField = text;
            dropDownList.DataBind();
        }

        [WebMethod]
        public static string Registrar(Entidad.Empleado empleado, string id = "", string vista = "")
        {
            //NameValueCollection Query = HttpContext.Current.Request.QueryString;

            try
            {
                if(!string.IsNullOrEmpty(id) /*&& int.TryParse(Query["id"], out int id) && id > 0*/)
                {
                    empleado.Id = id.ToString();
                    EmpleadoDB.RegistrarEmpleado("Actualizar", empleado);
                }
                else
                {
                    EmpleadoDB.RegistrarEmpleado("Insertar", empleado);
                }

                if (vista == "Jefe") {
                    return "okJefe";
                }
                else {
                    return "ok";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}