using MESModule.DB;
using MESModule.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace InnerQueue
{
    public static class Global
    {
        #region *** Properties
        public static string SQL;
        public static string _cname { get { return MyCom.GetMachineName(); } }
        public static string Line = ConfigurationManager.AppSettings["Line"];
        #endregion

        #region *** Method
        public static string GetTitle()
        {            
            string ipaddress = MyCom.GetMachineAddress();
            SQL = "select VERSION " +
                    "from CONTROLLINE " +
                    "where CNAME= '" + _cname + "' " +
                    "and IPADD='" + ipaddress + "' " +
                    "and PNAME='" + MyApp.GetAppName(MyApp.AppNameOption.WithExtension) + "'";
            using(MyDB _db = new MyDB(ConfigurationManager.ConnectionStrings["ConnectionLN"].ConnectionString))
            using (DbObject VS = _db.ExecQuery(SQL))
            {
                return "Computer: " + _cname +
                     "  IP address: " + ipaddress +
                     "  Com Version: " + MyApp.GetAppVersion(MyApp.GetAppName(MyApp.AppNameOption.FullPath)) +
                     "  Request Version: " + ((VS.EOF) ? "Not Found!!!" : VS["VERSION"]);
            }
        }     
        #endregion
    }   
}
