using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using Newtonsoft.Json;
using ControlVehicularEN = CASCO.EN.SICAS;
using ControlVehicularBL = CASCO.BL.SICAS;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ControlVehicularF4.Controllers
{
   // [Authorize]
    public class EjecutorController : Controller
    {
        CASCO.BL.ControlVehicular.RevistaGeneral RevistaGeneralBL = new CASCO.BL.ControlVehicular.RevistaGeneral();


        // GET: Ejecutor
        public ActionResult Index()
        {
            return View();
        }






        //public JsonResult GetCountry(string countryName)
        //{
        //    var cn = new SqlConnection();
        //    var ds = new DataSet();
        //    string strCn = ConfigurationManager.ConnectionStrings["SGC"].ToString();
        //    cn.ConnectionString = strCn;
        //    var cmd = new SqlCommand
        //    {
        //        Connection = cn,
        //        CommandType = CommandType.Text,
        //        CommandText = "select CountryName from tblCountry  Where CountryName like @myParameter and CountryName != @myParameter2"
        //    };

        //    cmd.Parameters.AddWithValue("@myParameter", "%" + countryName + "%");
        //    cmd.Parameters.AddWithValue("@myParameter2", countryName);

        //    try
        //    {
        //        cn.Open();
        //        cmd.ExecuteNonQuery();
        //        var da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //    DataTable dt = ds.Tables[0];


        //    var txtItems = (from DataRow row in dt.Rows
        //                    select row["CountryName"].ToString()
        //                        into dbValues
        //                    select dbValues.ToLower()).ToList();
        //    return Json(txtItems, JsonRequestBehavior.AllowGet);
        //}














        // GET: Ejecutor
        public ActionResult EjecucionRevista()
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");

            ControlVehicularF4.Functions.FunctionsGeneral funciones = new ControlVehicularF4.Functions.FunctionsGeneral();
            CASCO.BL.ControlVehicular.RevistaGeneral RevistaGeneralBL = new CASCO.BL.ControlVehicular.RevistaGeneral();
            //CASCO.BL.SICAS.Estaciones blEstaciones = new CASCO.BL.SICAS.Estaciones();

            ViewBag.Unidades = funciones.DataTableToSelectList(RevistaGeneralBL.obtieneUnidadesActivas(Session["Usuario_ID"].ToString(), 1), "Unidad_ID", "Unidad");
            ViewBag.Conductores = funciones.DataTableToSelectList(RevistaGeneralBL.obtieneConductoresUnidades(), "Conductor_ID", "Conductor");

            List<CASCO.EN.SICAS.Estacion> ls = CASCO.BL.SICAS.Estaciones.ObtieneListadoEstaciones(Session["Usuario_ID"].ToString());
            SelectList sl = new SelectList(ls, "Estacion_ID", "Nombre");
            ViewBag.Estaciones = sl;
            
            string Usuario_ID = Session["Usuario_ID"].ToString();
            return View();
        }

        // GET: Ejecutor
        public ActionResult CapturaRevista()
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");

            ControlVehicularF4.Functions.FunctionsGeneral funciones = new ControlVehicularF4.Functions.FunctionsGeneral();
            CASCO.BL.ControlVehicular.RevistaGeneral RevistaGeneralBL = new CASCO.BL.ControlVehicular.RevistaGeneral();
            //CASCO.BL.SICAS.Estaciones blEstaciones = new CASCO.BL.SICAS.Estaciones();

            ViewBag.Unidades = funciones.DataTableToSelectList(RevistaGeneralBL.obtieneUnidadesActivas(Session["Usuario_ID"].ToString(), 1), "Unidad_ID", "Unidad");
            ViewBag.Conductores = funciones.DataTableToSelectList(RevistaGeneralBL.obtieneConductoresUnidades(), "Conductor_ID", "Conductor");

            List<CASCO.EN.SICAS.Estacion> ls = CASCO.BL.SICAS.Estaciones.ObtieneListadoEstaciones(Session["Usuario_ID"].ToString());
            SelectList sl = new SelectList(ls, "Estacion_ID", "Nombre");
            ViewBag.Estaciones = sl;

            string Usuario_ID = Session["Usuario_ID"].ToString();
            return View();
        }


        public ActionResult Programacion()
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");

            ViewBag.Usuario_ID = Session["Usuario_ID"].ToString();
            List<CASCO.EN.SICAS.Estacion> ls = CASCO.BL.SICAS.Estaciones.ObtieneListadoEstaciones(Session["Usuario_ID"].ToString());
            SelectList sl = new SelectList(ls, "Estacion_ID", "Nombre");
            ViewBag.Estaciones = sl;
            return View();
        }

        [HttpPost]
        public JsonResult ObtienePlantillaUnidad(int unidad_id, int revistaUnidades_id, string usuario_id)
        {
            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.obtienePlantillaRevistaModelo(unidad_id, revistaUnidades_id, usuario_id));
            var result = new JsonResult { Data = jsonData };
            return result;
        }



        [HttpPost]
        public JsonResult ObtieneRevistaDetalleEvidencia(int revistaUnidadesDetalle_ID)
        {
            CASCO.BL.ControlVehicular.Revista_Unidad RevistaUnidadBL = new CASCO.BL.ControlVehicular.Revista_Unidad();
            String jsonData = JsonConvert.SerializeObject(RevistaUnidadBL.ObtieneRevistaDetalleEvidencia(revistaUnidadesDetalle_ID));
            var result = new JsonResult { Data = jsonData };
            return result;
        }

        [HttpPost]
        public JsonResult actualizaDetalleEvaluacion(int RevistaUnidadesDetalle_ID, int PuntajeReal, String observaciones)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.actualizaDetalleEvaluacion(RevistaUnidadesDetalle_ID, PuntajeReal, observaciones));
            var result = new JsonResult { Data = jsonData };
            return result;
        }

        [HttpPost]
        public JsonResult InsertaActualizaRevistaParoMotor(int RevistaUnidad_ID, int RevistaUnidadesDetalle_ID, string comentario, string unidad, string Usuario_ID, int activo)
        {
            bool bActualiza = RevistaGeneralBL.InsertaActualizaRevistaParoMotor(RevistaUnidad_ID, RevistaUnidadesDetalle_ID, comentario, unidad, Usuario_ID, activo);
            JsonResult j = new JsonResult();
            j.Data = bActualiza;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }

        [HttpPost]
        public JsonResult ActualizaRevistaUnidadesMaestro(int revistaUnidades_id, int estacion_id, int kilometraje, string usuarioUltMod, string taximetro, int esConductorDiferente, string ConductorDiferente)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            CASCO.BL.ControlVehicular.Revista_Unidad RevistaUnidadBL = new CASCO.BL.ControlVehicular.Revista_Unidad();
            bool bActualiza = RevistaUnidadBL.actualizaRevistaUnidadesMaestro(revistaUnidades_id, estacion_id, kilometraje, usuarioUltMod, taximetro, esConductorDiferente, ConductorDiferente);

            JsonResult j = new JsonResult();
            j.Data = bActualiza;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }


        [HttpPost]
        public JsonResult GuardaImagenEvidencia(int revistaUnidades_ID, int revistaUnidadesDetalle_ID)
        {
            CASCO.BL.ControlVehicular.Revista_Unidad RevistaUnidadBL = new CASCO.BL.ControlVehicular.Revista_Unidad();
            bool bActualiza = false;
            bool isSaveFile = false;
            HttpFileCollectionBase files = Request.Files;
            String _Path = Server.MapPath("~/RevistaEvidencia/" + revistaUnidades_ID + "/" + revistaUnidadesDetalle_ID + "/");
            String _PathFile=""; 
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase btfile = files[i];
                    string fname;
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = btfile.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = btfile.FileName;
                    }
                    DirectoryInfo di;
                    if (!Directory.Exists(_Path))
                        di = Directory.CreateDirectory(_Path);
                    // Get the complete folder path and store the file inside it.  
                    _PathFile = Path.Combine(_Path, fname);


                    btfile.SaveAs(_PathFile);


                    isSaveFile = true;
                    bActualiza = RevistaUnidadBL.GuardaImagenEvidencia(revistaUnidadesDetalle_ID, "../RevistaEvidencia/" + revistaUnidades_ID + "/" + revistaUnidadesDetalle_ID + "/" + fname);
                }                             
            }
            catch (Exception ex) {            
                if (isSaveFile)
                    System.IO.File.Delete(_PathFile);
                bActualiza = false;    
            }
            JsonResult j = new JsonResult();
            j.Data = bActualiza;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }


        [HttpPost]
        public JsonResult GuardaFirma(int revistaUnidades_ID)
        {
            CASCO.BL.ControlVehicular.Revista_Unidad RevistaUnidadBL = new CASCO.BL.ControlVehicular.Revista_Unidad();
            bool bActualiza = false;
            bool isSaveFile = false;
            HttpFileCollectionBase files = Request.Files;
            String _Path = Server.MapPath("~/RevistaEvidencia/" + revistaUnidades_ID + "/");
            String _PathFile = "";
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase btfile = files[i];
                    string fname;
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = btfile.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = "Firma_"+ revistaUnidades_ID+".jpg";
                    }
                    DirectoryInfo di;
                    if (!Directory.Exists(_Path))
                        di = Directory.CreateDirectory(_Path);
                    // Get the complete folder path and store the file inside it.  
                    _PathFile = Path.Combine(_Path, fname);
                    btfile.SaveAs(_PathFile);
                    isSaveFile = true;
                }
            }
            catch (Exception ex)
            {
                if (isSaveFile)
                    System.IO.File.Delete(_PathFile);
                bActualiza = false;
            }
            JsonResult j = new JsonResult();
            j.Data = bActualiza;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }

        [HttpPost]
        public JsonResult actualizafinalizarEstatusRevista(int revistaUnidades_id, string usuario_id)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            CASCO.BL.ControlVehicular.Revista_Unidad RevistaUnidadBL = new CASCO.BL.ControlVehicular.Revista_Unidad();
            bool bActualiza = RevistaUnidadBL.actualizafinalizarEstatusRevista(revistaUnidades_id, usuario_id);

            JsonResult j = new JsonResult();
            j.Data = bActualiza;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }


        [HttpPost]
        public JsonResult AgregaUnidadCompromiso(int unidad_id, string compromiso, DateTime fechaCompromiso, string usuario_id, int requiereParo)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            CASCO.EN.ControlVehicular.RevistaUnidadCompromiso CompromisoUnidad = new CASCO.EN.ControlVehicular.RevistaUnidadCompromiso();
            CompromisoUnidad.Unidad_ID = unidad_id;
            CompromisoUnidad.Compromiso = compromiso;
            CompromisoUnidad.FechaCompromiso = fechaCompromiso;
            CompromisoUnidad.RequiereParo = requiereParo;
            CompromisoUnidad.Usuario_ID = usuario_id;

            bool bResult = CASCO.BL.ControlVehicular.RevistaUnidadCompromiso.AgregaUnidadCompromiso(CompromisoUnidad);

            JsonResult j = new JsonResult();
            j.Data = bResult;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }

        [HttpPost]
        public JsonResult ActualizaUnidadCompromiso(int revistaCompromiso_ID, string usuario_id, int activo)
        {
            if (Session["Usuario_ID"] == null)
                Response.Redirect("~/Account/Login");
            CASCO.EN.ControlVehicular.RevistaUnidadCompromiso CompromisoUnidad = new CASCO.EN.ControlVehicular.RevistaUnidadCompromiso();
            CompromisoUnidad.RevistaCompromiso_ID = revistaCompromiso_ID;
            CompromisoUnidad.UsuarioUltMod = usuario_id;
            CompromisoUnidad.Activo = activo;

            bool bResult = CASCO.BL.ControlVehicular.RevistaUnidadCompromiso.ActualizaUnidadCompromiso(CompromisoUnidad);

            JsonResult j = new JsonResult();
            j.Data = bResult;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }

        [HttpPost]
        public JsonResult ObtieneUnidadCompromisos(int unidad_ID)
        {
             String jsonData = JsonConvert.SerializeObject(CASCO.BL.ControlVehicular.RevistaUnidadCompromiso.ObtieneUnidadCompromisos(unidad_ID));
            var result = new JsonResult { Data = jsonData };
            return result;
        }


        [HttpPost]
        public JsonResult ObtieneRevistasPendientes(int unidad_ID, string usuario_ID)
        {
            String jsonData = JsonConvert.SerializeObject(CASCO.BL.ControlVehicular.Revista_Unidad.ObtieneRevistasPendientes(unidad_ID, usuario_ID));
            var result = new JsonResult { Data = jsonData };
            return result;
        }

        // GET: Ejecutor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejecutor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejecutor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ejecutor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejecutor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ejecutor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejecutor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
