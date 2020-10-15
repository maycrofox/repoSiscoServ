using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Datos
{
   public class Conexion
    {

       public string GetConex()
       {
           string strConex = ConfigurationManager.ConnectionStrings["configMsqlConexion"].ConnectionString;
           if (object.ReferenceEquals(strConex, string.Empty))
           {
               return string.Empty;
           }
           else
           {
               return strConex;
           }
       }
    }               

}
