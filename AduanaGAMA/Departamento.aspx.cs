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
    public partial class Departamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && int.TryParse(Request.QueryString["id"], out id) && id > 0)
            {
                DataTable empleado = DepartamentoDB.ConsultarOpcionDepartamento("CDeparta", id);
                //editar
                if (empleado.Rows.Count > 0)
                {
                    var fila = empleado.Rows[0];
                    departa.Text = fila["Nombre"].ToString();
                }
            }
        }

        [WebMethod]
        public static string RegistrarDeparta(Entidad.Departamento departamento, string id = "")
        {
            //NameValueCollection Query = HttpContext.Current.Request.QueryString;

            try
            {
                if (!string.IsNullOrEmpty(id) /*&& int.TryParse(Query["id"], out int id) && id > 0*/)
                {
                    departamento.Id = id.ToString();
                    DepartamentoDB.RegistrarDepartamento("ADeparta", departamento);
                }
                else
                {
                    DepartamentoDB.RegistrarDepartamento("IDeparta", departamento);
                }

                return "okDepar";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}