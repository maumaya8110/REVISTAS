using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using ControlVehicularBL = CASCO.BL.SICAS;
namespace ControlVehicularF4.Controllers
{
    public class ConsultasGeneralController : Controller
    {
        CASCO.BL.ControlVehicular.RevistaGeneral RevistaGeneralBL = new CASCO.BL.ControlVehicular.RevistaGeneral();
        // GET: ConsultasGeneral

        public ActionResult Revistas()
        {
            return View();

        }


        [HttpPost]
        public JsonResult obtieneInformacionRevistaUnidad(int unidad_id, int revistaUnidades_id)
        {
            String jsonData = JsonConvert.SerializeObject(RevistaGeneralBL.obtieneInformacionRevistaUnidad(unidad_id, revistaUnidades_id));
            var result = new JsonResult { Data = jsonData };
            return result;
        }

        [HttpPost]
        public JsonResult obtieneListaEstaciones(int unidad_id)
        {
            //CASCO.BL.SICAS.Estaciones blEstaciones = new CASCO.BL.SICAS.Estaciones();
            List<CASCO.EN.SICAS.Estacion> ls = ControlVehicularBL.Estaciones.ObtieneListadoEstaciones(Session["Usuario_ID"].ToString());
            JsonResult j = new JsonResult();
            j.Data = ls;
            return j;
        }



    }
}
