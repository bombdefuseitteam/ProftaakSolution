using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatabaseTester
{
    class SQLConnect : Common
    {
        SqlConnection db = new SqlConnection();

        internal SQLConnect()
        {
            Initialize();
        }
        
        void Initialize()
        {
            db.ConnectionString =
                "Data Source=studmysql01.fhict.local;" +
                "Initial Catalog=defuseit;" +
                "User id=dbi387895" +
                "Password=Hoihoi1995;";

            try
            {
                db.Open();
            }
            catch (Exception e)
            {

                Print(e.ToString());
                Console.Read();
            }
        }


        
    }
}
