using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlClient;

namespace login_page
{
    internal class myconnect
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader rs;
         public static void connect()
        {
            try
            {
                con = new SqlConnection("Data Source=Gaurav\\SQLEXPRESS;Initial Catalog=bca;Integrated Security=True");
                con.Open();
               
            }
            catch (Exception exp)
            {

                MessageBox.Show("Connection Failed"+exp.Message);
            }
        }
    }
}
