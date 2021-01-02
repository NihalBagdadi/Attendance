using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace EmployeeAttendance
{
    
    class CommonMethods
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Daily Attendence;Integrated Security=True");
        public string dbconnectiom()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Daily Attendence;Integrated Security=True";
        }
        public void iud(string q)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(q,connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void populatedt(string q, DataTable dt)
        {
            connection.Open();
            SqlDataAdapter ad = new SqlDataAdapter(q,connection);
            ad.Fill(dt);

            connection.Close();
        }
        public string populatestring(string q, string s)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(q,connection);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
                s = dr[0].ToString();
            dr.Close();
           
                connection.Close();
            return s;
        }
    }
}
