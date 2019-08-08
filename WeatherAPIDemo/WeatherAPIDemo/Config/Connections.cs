using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherAPIDemo.Config
{
    class Connections
    {
        private SqlConnection conn;
        public Connections()
        {
            conn = new SqlConnection("Server=tcp:uservoicedb.database.windows.net,1433;Database=UserVoiceDB;User ID=kunalmighty@uservoicedb;Password=Sagar123;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; Initial Catalog = WeatherAPIDB");
        }

        public bool ExeCmd(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query,conn);
            conn.Open();
            int Res = cmd.ExecuteNonQuery();
            conn.Close();
            return Res==1;
        }

        public DataSet GetAllData(DateTime Dt, string type)
        {
            SqlCommand cmd = new SqlCommand("Get_All_Data", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@date", Dt);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}
