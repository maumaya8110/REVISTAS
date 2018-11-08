using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlVehicularF4.NoAprobadas
{
    public partial class NoAprobadas : System.Web.UI.Page
    {

        public DataSet DSConsulta(string query)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SGC"].ConnectionString);
            //SqlConnection con = new SqlConnection(@"Data Source=csco-cosw\sqlsistemas;Initial Catalog=Inventario2018;Persist Security Info=True;User ID=sa;Password=Xmaya1981");

            con.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = query;
            cm.CommandType = CommandType.Text;
            cm.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cm);

            DataSet ds = new DataSet();
            da.Fill(ds);


            return ds;

        }


        private void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {




            GrabaVehiculoNP();
        }


        protected void GrabaVehiculoNP()
        {
            string unidad = cmbUnidades.Value;


            DataSet dsx = DSConsulta("exec spAddRevistaUnidad " + unidad + ",'" + dtp.Value + "'");


            if (dsx.Tables[0].Rows.Count > 0)
            {
                //Response.Redirect("../Revistas/Ejecutor/EjecucionRevista");
                Response.Redirect("../Ejecutor/EjecucionRevista");
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario_ID"] == null)
            { Response.Redirect("~/Account/Login"); }

            dtp.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00");



            btlogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);


            if (!IsPostBack)
            {
                LLenaCombos();
            }
            else
            {

            }
        }


        protected void LLenaCombos()
        {
            try
            {
                DataSet ds = DSConsulta("exec ControlVehicular.usp_web_Obtiene_UnidadesActivas '" + Session["Usuario_ID"].ToString() + "',1");

                cmbUnidades.DataSource = ds.Tables[0];
                cmbUnidades.DataValueField = "unidad_id";
                cmbUnidades.DataTextField = "unidad";
                cmbUnidades.DataBind();




            }
            catch (Exception ex)
            {

                //lblmsg.Text = ex.ToString();
                //lblmsg.Visible = true;
            }

        }
    }
}