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
    public partial class Rol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && int.TryParse(Request.QueryString["id"], out id) && id > 0)
            {
                DataTable empleado = RolDB.ConsultarOpcionRol("CRol", id);
                //editar
                if (empleado.Rows.Count > 0)
                {
                    var fila = empleado.Rows[0];
                    rol.Text = fila["Nombre"].ToString();
                }
            }
        }

        [WebMethod]
        public static string RegistrarRol(Entidad.Rol rol, string id = "")
        {
            //NameValueCollection Query = HttpContext.Current.Request.QueryString;

            try
            {
                if (!string.IsNullOrEmpty(id) /*&& int.TryParse(Query["id"], out int id) && id > 0*/)
                {
                    rol.Id = id.ToString();
                    RolDB.RegistrarRol("ARol", rol);
                }
                else
                {
                    RolDB.RegistrarRol("IRol", rol);
                }

                return "okRol";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}