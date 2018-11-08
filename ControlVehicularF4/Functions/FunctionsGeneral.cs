using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

using System.Text;
namespace ControlVehicularF4.Functions
{
    public class FunctionsGeneral
    {

        public SelectList DataTableToSelectList(DataTable data, String valueID, String valueText)
        {
            List<SelectListItem> litems = new List<SelectListItem>();
            SelectList sl = new SelectList(litems, "Value", "Text");
            foreach (System.Data.DataRow u in data.Rows)
            {
                litems.Add(new SelectListItem { Value = u[valueID].ToString(), Text = u[valueText].ToString() });
            }
            return sl;
        }


        public static IHtmlString ShowMenuSimple(DataTable lista)
        {

            StringBuilder output = new StringBuilder();
                DataRow[] n = lista.Select("PaginaPadre_ID = " + 0);
                if (n.Length > 0)
                {                    
                    foreach (DataRow subItem in n)
                    {
                        output.AppendFormat("<li class='dropdown'>");
                        output.AppendFormat("<a class='dropdown-toggle' data-toggle='dropdown' href='#' id='{0}'> {1} <span class='caret'></span></a>", subItem["Pagina_ID"].ToString(), subItem["NombreMenu"].ToString());
                        output.AppendFormat("<ul class='dropdown-menu' aria-labelledby='{0}'>", subItem["Pagina_ID"].ToString());

                        DataRow[] options = lista.Select("PaginaPadre_ID = " + subItem["Pagina_ID"].ToString());
                        foreach (DataRow ItemOption in options)
                        {
                            output.AppendFormat("<li> <a href='{0}'><i class='fa fa-list-ul fa-fw'></i> {1} </a> </li>", ItemOption["URL"].ToString(), ItemOption["NombreMenu"].ToString());
                        }
                        output.Append("</ul>");
                        output.Append("</li>");

                    }                    
                }
            return MvcHtmlString.Create(output.ToString());
        }

    }



}