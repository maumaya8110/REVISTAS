using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Windows.Forms;
namespace ControlVehicularF4
{
    public static class Utils
    {
        private static string GetValueStringFromWebConfig(string key)
        {
            string cad = "";
            if (System.Configuration.ConfigurationManager.ConnectionStrings[key] != null &&
                System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString != null &&
                System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString.Length > 0)
                cad = System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return cad;
        }

        public static string CadenaConexionSICAS
        {
            get
            {
                return GetValueStringFromWebConfig("SICAS");
            }
        }

        public static string CadenaConexionXDS
        {
            get
            {
                return GetValueStringFromWebConfig("XDS");
            }
        }

        public static string CadenaConexionMSSQL
        {
            get
            {
                return GetValueStringFromWebConfig("sql");
            }
        }

        public static string CadenaConexionOLAP
        {
            get
            {
                return GetValueStringFromWebConfig("OLAP");
            }
        }

        public static string CadenaConexionMySQL
        {
            get
            {
                return GetValueStringFromWebConfig("mysql");
            }
        }

        public static string CadConURGI { get { return System.Configuration.ConfigurationManager.ConnectionStrings["SGC"].ConnectionString; } }
        public static string CadConMembership { get { return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; } }
        public static string CadConMenu { get { return System.Configuration.ConfigurationManager.ConnectionStrings["Menu"].ConnectionString; } }

        public static string CadConSMPP { get { return System.Configuration.ConfigurationManager.ConnectionStrings["CadConSMPP"].ConnectionString; } }

        public static int IntervalPeriod
        {
            get
            {
                string sintervalo = "15";
                if (System.Configuration.ConfigurationManager.AppSettings["interval_period"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["interval_period"].Length > 0)
                    sintervalo = System.Configuration.ConfigurationManager.AppSettings["interval_period"];
                return Convert.ToInt32(sintervalo);
            }
        }

        public static string MailFrom
        {
            get
            {
                string s = "noresponder@urgi.com.mx";
                if (System.Configuration.ConfigurationManager.AppSettings["From"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["From"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["From"];
                return s;
            }
        }

        public static string ServidorSMTP
        {
            get
            {
                string s = "mail.urgi.com.mx";
                if (System.Configuration.ConfigurationManager.AppSettings["ServidorSMTP"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["ServidorSMTP"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["ServidorSMTP"];
                return s;
            }
        }

        public static string SMTPuser
        {
            get
            {
                string s = "noresponder@urgi.com.mx";
                if (System.Configuration.ConfigurationManager.AppSettings["SMTPuser"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["SMTPuser"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["SMTPuser"];
                return s;
            }
        }

        public static int SMTPport
        {
            get
            {
                string sintervalo = "587";
                if (System.Configuration.ConfigurationManager.AppSettings["SMTPport"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["SMTPport"].Length > 0)
                    sintervalo = System.Configuration.ConfigurationManager.AppSettings["SMTPport"];
                return Convert.ToInt32(sintervalo);
            }
        }

        public static string SMTPpass
        {
            get
            {
                string s = "L4qu3se4";
                if (System.Configuration.ConfigurationManager.AppSettings["SMTPpass"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["SMTPpass"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["SMTPpass"];
                return s;
            }
        }

        public static string SMTPMailPrueba
        {
            get
            {
                string s = "nephtali.juarez@casco.com.mx";
                if (System.Configuration.ConfigurationManager.AppSettings["SMTPMailPrueba"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["SMTPMailPrueba"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["SMTPMailPrueba"];
                return s;
            }
        }

        public static string CopiaMail
        {
            get
            {
                string s = "samuel.maldonado@urgi.com.mx";
                if (System.Configuration.ConfigurationManager.AppSettings["CopiaMail"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["CopiaMail"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["CopiaMail"];
                return s;
            }
        }

        public static string URLAudio
        {
            get
            {
                string s = "https://192.168.0.56/grabaciones/reports/1/monitor/";
                if (System.Configuration.ConfigurationManager.AppSettings["Ruta_Audio"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["Ruta_Audio"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["Ruta_Audio"];
                return s;
            }
        }

        //public static List<T> GetControlByName<T>(Control controlToSearch, string startsWith, bool searchDescendants) where T : class
        //{
        //    List<T> result;
        //    result = new List<T>();
        //    foreach (Control c in controlToSearch.Controls)
        //    {
        //        if (c.Name.StartsWith(startsWith) && c.GetType() == typeof(T))
        //        {
        //            result.Add(c as T);
        //        }
        //        if (searchDescendants)
        //        {
        //            result.AddRange(GetControlByName<T>(c, startsWith, true));
        //        }
        //    }
        //    return result;
        //}

        public static int ConexionTimeOut
        {
            get
            {
                int to = 60;
                if (System.Configuration.ConfigurationManager.AppSettings["TimeOut"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["TimeOut"].Length > 0)
                    to = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TimeOut"]);

                return to;
            }
        }

        public static string ServidorSMPP
        {
            get
            {
                string s = "192.168.0.54";
                if (System.Configuration.ConfigurationManager.AppSettings["ServidorSMPP"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["ServidorSMPP"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["ServidorSMPP"];
                return s;
            }
        }

        public static string SMPPuser
        {
            get
            {
                string s = "admin";
                if (System.Configuration.ConfigurationManager.AppSettings["SMPPuser"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["SMPPuser"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["SMPPuser"];
                return s;
            }
        }

        public static int SMPPport
        {
            get
            {
                string sintervalo = "587";
                if (System.Configuration.ConfigurationManager.AppSettings["SMPPport"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["SMPPport"].Length > 0)
                    sintervalo = System.Configuration.ConfigurationManager.AppSettings["SMPPport"];
                return Convert.ToInt32(sintervalo);
            }
        }

        public static string SMPPpass
        {
            get
            {
                string s = "L4qu3se4";
                if (System.Configuration.ConfigurationManager.AppSettings["SMPPpass"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["SMPPpass"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["SMPPpass"];
                return s;
            }
        }

        public static string SMPPSMSPrueba
        {
            get
            {
                string s = "8112044667";
                if (System.Configuration.ConfigurationManager.AppSettings["SMPPSMSPrueba"] != null &&
                    System.Configuration.ConfigurationManager.AppSettings["SMPPSMSPrueba"].Length > 0)
                    s = System.Configuration.ConfigurationManager.AppSettings["SMPPSMSPrueba"];
                return s;
            }
        }
    }

}