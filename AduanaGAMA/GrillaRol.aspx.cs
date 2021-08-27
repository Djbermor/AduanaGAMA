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
    public partial class GrillaRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridViewRol.DataSource = RolDB.ConsultarOpcionRol("CRol");
            gridViewRol.DataBind();
        }

        [WebMethod]
        public static string Eliminar(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    RolDB.EliminarRol(id);
                }
                else
                {
                    return "no se pudo eliminar";
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