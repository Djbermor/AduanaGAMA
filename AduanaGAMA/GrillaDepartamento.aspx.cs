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
    public partial class GrillaDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridViewDepartamento.DataSource = DepartamentoDB.ConsultarOpcionDepartamento("CDeparta");
            gridViewDepartamento.DataBind();
        }

        [WebMethod]
        public static string Eliminar(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    DepartamentoDB.EliminarDepartamento(id);
                }
                else
                {
                    return "no se pudo eliminar";
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