using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AduanaGAMA
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtEmpleado.Text = "kk";

            gridViewEmpleado.DataSource = new DataTable();
            gridViewEmpleado.DataBind();
        }


    }
}