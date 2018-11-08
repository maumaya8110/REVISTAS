using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using Newtonsoft.Json;
using ControlVehicularEN = CASCO.EN.SICAS;
using ControlVehicularBL = CASCO.BL.SICAS;
using BL = CASCO.BL.ControlVehicular;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;

//using Microsoft.Web.WebPages.OAuth;
//using System.Web.Security;
namespace ControlVehicularF4.Controllers
{
    //[Authorize]
    public class ConsultasController : Controller
    {
        CASCO.BL.ControlVehicular.RevistaGeneral RevistaGeneralBL = new CASCO.BL.ControlVehicular.RevistaGeneral();
        //
        // GET: /Consultas/
        //[AllowAnonymous]


        //public ActionResult ExportExcel()
        //{
        //    DataTable dt = new DataTable();

        //    //  FILL DataTable

        //    try
        //    {
        //        FileExcel(dt);
        //        return Json(new { successCode = "1" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { successCode = "0" });
        //    }
        //}

        //public void FileExcel(DataTable dt)
        //{
            
        //    GridView gv = new GridView();
        //    gv.DataSource = dt;
        //    gv.DataBind();

        //    HttpContext context = System.Web.HttpContext.Current;
        //    context.Response.ClearContent();
        //    context.Response.Buffer = true;
        //    context.Response.AddHeader("content-disposition", "attachment; filename=Ricerca.xls");
        //    context.Response.ContentType = "application/ms-excel";
        //    context.Response.Charset = "";
        //   System.IO.StringWriter sw = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        //    gv.RenderControl(htw);
        //    context.Response.Output.Write(sw.ToString());
        //    context.Response.Flush();
        //    htw.Close();
        //    sw.Close();
        //    context.Response.End();
        //}










        public ActionResult ConsultaRevistas()
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            List<CASCO.EN.SICAS.Mercado> lsMercados = ControlVehicularBL.Mercados.ObtieneListadoEmpresasContratos(Session["Usuario_ID"].ToString());
            SelectList slMercados = new SelectList(lsMercados, "Mercado_ID", "Nombre");
            ViewBag.Mercados = slMercados;

            List<CASCO.EN.SICAS.Empresa> lsEmpresas = ControlVehicularBL.Empresas.ObtieneListadoEmpresasContratos(Session["Usuario_ID"].ToString());
            SelectList slEmpresas = new SelectList(lsEmpresas, "Empresa_ID", "Nombre");
            ViewBag.Empresas = slEmpresas;

            List<CASCO.EN.SICAS.Estacion> lsEstaciones = ControlVehicularBL.Estaciones.ObtieneListadoEstacionesContrato(Session["Usuario_ID"].ToString());
            SelectList slEstaciones = new SelectList(lsEstaciones, "Estacion_ID", "Nombre");
            ViewBag.Estaciones = slEstaciones;

            ControlVehicularF4.Functions.FunctionsGeneral funciones = new ControlVehicularF4.Functions.FunctionsGeneral();
            ViewBag.Unidades = funciones.DataTableToSelectList(RevistaGeneralBL.obtieneUnidadesActivas(Session["Usuario_ID"].ToString(), 0), "Unidad_ID", "Unidad");

            List<CASCO.EN.SICAS.ModeloUnidad> lsModelos = ControlVehicularBL.ModelosUnidades.ObtieneModeloUnidades();
            SelectList slModelos = new SelectList(lsModelos, "ModeloUnidad_ID", "Descripcion");
            ViewBag.ModelosUnidades = slModelos;

            List<CASCO.EN.ControlVehicular.RevistaEstatus> lsEstatus = BL.RevistasEstatus.obtieneEstatusRevistas();
            SelectList slEstatus = new SelectList(lsEstatus, "Estatus_ID", "Descripcion");
            ViewBag.EstatusRevistas = slEstatus;

            List<CASCO.EN.ControlVehicular.RevistaUsuario> lsUsuariosRevista = BL.RevistaUsuarios.obtieneUsuariosRevista();
            SelectList slUsuariosRevista = new SelectList(lsUsuariosRevista, "Usuario_ID", "Nombre");
            ViewBag.UsuariosRevista = slUsuariosRevista;

            return View();
        }


        public ActionResult ConsultaResumen()
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            List<CASCO.EN.SICAS.Mercado> lsMercados = ControlVehicularBL.Mercados.ObtieneListadoEmpresasContratos(Session["Usuario_ID"].ToString());
            SelectList slMercados = new SelectList(lsMercados, "Mercado_ID", "Nombre");
            ViewBag.Mercados = slMercados;

            List<CASCO.EN.SICAS.Empresa> lsEmpresas = ControlVehicularBL.Empresas.ObtieneListadoEmpresasContratos(Session["Usuario_ID"].ToString());
            SelectList slEmpresas = new SelectList(lsEmpresas, "Empresa_ID", "Nombre");
            ViewBag.Empresas = slEmpresas;

            List<CASCO.EN.SICAS.Estacion> lsEstaciones = ControlVehicularBL.Estaciones.ObtieneListadoEstacionesContrato(Session["Usuario_ID"].ToString());
            SelectList slEstaciones = new SelectList(lsEstaciones, "Estacion_ID", "Nombre");
            ViewBag.Estaciones = slEstaciones;
            return View();
        }

        public ActionResult ConsultaResumenEjecutores()
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");


            List<CASCO.EN.SICAS.Estacion> lsEstaciones = ControlVehicularBL.Estaciones.ObtieneListadoEstacionesContrato(Session["Usuario_ID"].ToString());
            SelectList slEstaciones = new SelectList(lsEstaciones, "Estacion_ID", "Nombre");
            ViewBag.Estaciones = slEstaciones;

            List<CASCO.EN.ControlVehicular.RevistaUsuario> lsUsuariosRevista = BL.RevistaUsuarios.obtieneUsuariosRevista();
            SelectList slUsuariosRevista = new SelectList(lsUsuariosRevista, "Usuario_ID", "Nombre");
            ViewBag.UsuariosRevista = slUsuariosRevista;

            return View();
        }



        public ActionResult ConsultaRevista(int unidad_id, int revistaUnidad_id)
        {
            //if (Session["Usuario_ID"] == null)
            //    Response.Redirect("~/Account/Login");
            //string Usuario_ID = "revista.piloto";

            //DateTime expiration = DateTime.Now.AddMinutes(10);
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Usuario_ID, DateTime.Now, expiration, false, Usuario_ID);
            //string cookie = FormsAuthentication.Encrypt(ticket);
            //HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookie);
            //httpCookie.Expires = expiration;
            //httpCookie.Path = FormsAuthentication.FormsCookiePath;
            //Response.Cookies.Add(httpCookie);

            string Usuario_ID = "revista.piloto"; //Session["Usuario_ID"].ToString();
            ViewBag._RevistaUnidad_ID = revistaUnidad_id;
            ViewBag._Unidad_ID = unidad_id;
            ControlVehicularF4.Functions.FunctionsGeneral funciones = new ControlVehicularF4.Functions.FunctionsGeneral();
            CASCO.BL.ControlVehicular.RevistaGeneral RevistaGeneralBL = new CASCO.BL.ControlVehicular.RevistaGeneral();
            ViewBag.Unidades = funciones.DataTableToSelectList(RevistaGeneralBL.obtieneUnidad(unidad_id), "Unidad_ID", "Unidad");
            ViewBag.Conductores = funciones.DataTableToSelectList(RevistaGeneralBL.obtieneConductoresUnidades(), "Conductor_ID", "Conductor");


            List<CASCO.EN.SICAS.Estacion> ls = CASCO.BL.SICAS.Estaciones.ObtieneListadoEstaciones(Usuario_ID);
            SelectList sl = new SelectList(ls, "Estacion_ID", "Nombre");
            ViewBag.Estaciones = sl;

            //ViewBag.Archivo = GeneratePDF();
            return View();
        }



        [HttpPost]
        public JsonResult ObtieneConsultaRevistas(int empresa_id, int mercado_id, int estacion_id, int unidad_id, int modeloUnidad_id, int anio, int estatus_id, string usuario_id, string fechaInicio, string fechaFin, int presentaCriticos, int esConductorDiferente, int compromisos, int paroMotor)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            System.Data.DataTable dt = RevistaGeneralBL.obtieneConsultaRevistas(empresa_id, mercado_id, estacion_id, unidad_id, modeloUnidad_id, anio, estatus_id, usuario_id, fechaInicio, fechaFin, presentaCriticos, esConductorDiferente, compromisos, paroMotor);

            String jsonData = JsonConvert.SerializeObject(dt);
            JsonResult jsonResult = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = 2147483647 };
            jsonResult.Data = jsonData;
            //var result = new JsonResult { Data = jsonData };
            return jsonResult;
        }

        [HttpPost]
        public JsonResult obtieneConsultaRevistasResumen(int empresa_id, int mercado_id, int estacion_id, string fechaInicio, string fechaFin)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.obtieneConsultaRevistasResumen(empresa_id, mercado_id, estacion_id, fechaInicio, fechaFin));
            var result = new JsonResult { Data = jsonData };
            return result;
        }

        [HttpPost]
        public JsonResult obtieneConsultaEjecutoresResumen(string usuario_id, int estacion_id, string fechaInicio, string fechaFin)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.obtieneConsultaEjecutoresResumen(usuario_id, estacion_id, fechaInicio, fechaFin));
            var result = new JsonResult { Data = jsonData };
            return result;
        }

        public JsonResult obtieneConsultaEjecutoresResumenHoras(string usuario_id, int estacion_id, string fechaInicio, string fechaFin)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.obtieneConsultaEjecutoresResumenHoras(usuario_id, estacion_id, fechaInicio, fechaFin));
            var result = new JsonResult { Data = jsonData };
            return result;
        }



        [HttpPost]
        public JsonResult obtieneConsultaProgramacionUsuario(int estacion_id, string fechaInicio, string fechaFin, string usuario_ID)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");


            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.obtieneConsultaProgramacionUsuario(estacion_id, fechaInicio, fechaFin, usuario_ID));
            var result = new JsonResult { Data = jsonData };
            return result;
        }


        [HttpPost]
        public JsonResult obtieneCriticosRevistaUnidad(int revistaUnidades_ID)
        {
            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.obtieneCriticosRevistaUnidad(revistaUnidades_ID));
            var result = new JsonResult { Data = jsonData };
            return result;
        }


        [HttpPost]
        public JsonResult obtieneDetalleAtributosRevista(int unidad_id, int revistaUnidades_id)
        {
            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.obtieneDetalleAtributosRevista(unidad_id, revistaUnidades_id));
            var result = new JsonResult { Data = jsonData };
            return result;
        }


        public ActionResult FormatoRevista(int unidad_id, int revistaUnidad_id)
        {
            //if (Session["Usuario_ID"] == null)
            //    Response.Redirect("~/Account/Login");
            ViewBag._RevistaUnidad_ID = revistaUnidad_id;
            ViewBag._Unidad_ID = unidad_id;

            return View();
        }


    }
}
