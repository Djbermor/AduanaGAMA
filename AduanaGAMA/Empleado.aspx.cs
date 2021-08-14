using ConnectionDB;
using System;
using System.Collections.Generic;
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
            fecha.Text = DateTime.Now.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !int.TryParse(Request.QueryString["id"], out int id) && id > 0)
            {
                //editar
                EmpleadoDB.ConsultarOpcionEmpleado("consultar", id);
            }
            else
            {
                LoadControlDropDown(rol, EmpleadoDB.ConsultarOpcionEmpleado("CRoles"), "Id", "Nombre");
                LoadControlDropDown(departamento, EmpleadoDB.ConsultarOpcionEmpleado("CDepa"), "Id", "Nombre");
                LoadControlDropDown(sexo, EmpleadoDB.ConsultarOpcionEmpleado("CSexo"), "Nombre", "Nombre");
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
        public static string Registrar(Entidad.Empleado empleado)
        {
            try
            {
                EmpleadoDB.RegistrarEmpleado("Insertar", empleado);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}