using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlVehicularF4.NoProgramada
{
    public partial class npall : System.Web.UI.Page
    {
        protected void LLenaCombos()
        {
            try
            {
                DataSet ds = DSConsulta("exec spDameEstatusUnidad");

                cmbEstatus.DataSource = ds.Tables[0];
                cmbEstatus.DataValueField = "id";
                cmbEstatus.DataTextField = "desc";
                cmbEstatus.DataBind();




            }
            catch (Exception ex)
            {

                //lblmsg.Text = ex.ToString();
                //lblmsg.Visible = true;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["Usuario_ID"] == null)
            //{ Response.Redirect("~/Account/Login"); }

            // dtp.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00");



            //btlogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);


            if (!IsPostBack)
            {
                LLenaCombos();
            }
            else
            {

            }
        }
        protected void GrabaVehiculoNP()
        {


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("unidad") });
            foreach (GridViewRow row in gvUnidades.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string unidad = row.Cells[1].Text;
                        //string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                        dt.Rows.Add(unidad);
                    }
                }
            }

            string fecha = dtp.Value;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                // do something with dr
                string unidad = dr[0].ToString();
                DSConsulta("exec spAddRevistaUnidad " + unidad + ",'" + dtp.Value + "'");
            }

            Response.Redirect("../Ejecutor/EjecucionRevista");




            //  string unidad = cmbUnidades.Value;


            //DataSet dsx = DSConsulta("exec spAddRevistaUnidad " + unidad + ",'" + dtp.Value + "'");


            //if (dsx.Tables[0].Rows.Count > 0)
            //{
            //    //Response.Redirect("../Revistas/Ejecutor/EjecucionRevista");
            //    Response.Redirect("../Ejecutor/EjecucionRevista");
            //}


        }
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

        protected void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = DSConsulta("exec spDameEstacionXEstatus " + cmbEstatus.SelectedValue);

            cmbEstacion.DataSource = ds.Tables[0];
            cmbEstacion.DataValueField = "id";
            cmbEstacion.DataTextField = "desc";
            cmbEstacion.DataBind();


        }

        protected void cmbEstacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = DSConsulta("exec spDameUnidadesXEstacionXEstatus " + cmbEstatus.SelectedValue + "," + cmbEstacion.SelectedValue);

            gvUnidades.DataSource = ds.Tables[0];
            gvUnidades.DataBind();
        }
        protected void GetSelectedRecords(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("unidad") });
            foreach (GridViewRow row in gvUnidades.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string unidad = row.Cells[1].Text;
                        //string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                        dt.Rows.Add(unidad);
                    }
                }
            }
            //gvSelected.DataSource = dt;
            //gvSelected.DataBind();
        }



    }
}