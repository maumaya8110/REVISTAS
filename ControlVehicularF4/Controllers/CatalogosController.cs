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


namespace ControlVehicularF4.Controllers
{
    public class CatalogosController : Controller
    {
        //CASCO.BL.ControlVehicular.RevistaGeneral RevistaGeneralBL = new CASCO.BL.ControlVehicular.RevistaGeneral();
        //
        // GET: /Catalogos/

        public ActionResult ModeloAtributos()
        {
            List<CASCO.EN.SICAS.ModeloUnidad> lsModelos = ControlVehicularBL.ModelosUnidades.ObtieneModeloUnidades();
            SelectList slModelos = new SelectList(lsModelos, "ModeloUnidad_ID", "Descripcion");
            ViewBag.Modelos = slModelos;

            return View();
        }

        [HttpPost]
        public JsonResult obtieneDetalleAtributosRevista(int modeloUnidad_ID)
        {
            String jsonData = JsonConvert.SerializeObject(CASCO.BL.ControlVehicular.RevistaGeneral.obtieneAtributosModelo(modeloUnidad_ID));
            var result = new JsonResult { Data = jsonData };
            return result;
        }

        [HttpPost]
        public JsonResult actualizaAtributoModeloUnidad(int RevistaAtributo_ID, int valor, int accion, string usuario_ID)
        {
            bool bActualiza = CASCO.BL.ControlVehicular.RevistaGeneral.actualizaAtributoModeloUnidad(RevistaAtributo_ID, valor, accion, usuario_ID);

            JsonResult j = new JsonResult();
            j.Data = bActualiza;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }

    }
}
