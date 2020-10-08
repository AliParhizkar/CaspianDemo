using System;
using System.Diagnostics.CodeAnalysis;

namespace Caspian.Common
{
    public class CS
    {
        public static string Con
        {
            get
            {
                Test(null);
                return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ali\\Documents\\Test.mdf;Integrated Security=True;Connect Timeout=30";
                //return "Server=.;database=Test;integrated security=true";
                //return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        public static void Test([NotNullAttribute] MyContext a)
        {

        }
    }
}
