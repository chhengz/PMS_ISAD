

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PMS_ISAD
{
    public class A6PMS
    {
        public SqlConnection con;
        // Try these alternative connection strings if needed:
        // string str = "Data Source=localhost;Initial Catalog=A6Y32025;Integrated Security=True";
        // string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=A6Y32025;Integrated Security=True";
        //string str = "Data Source=.\\MSSQLSERVER2022;Initial Catalog=A6Y32025;Integrated Security=True;Connection Timeout=30";
        string str = "Data Source=.\\MSSQLSERVER2022;Initial Catalog=PMS;Integrated Security=True;";

        public void Connection()
        {
            try
            {
                SqlDependency.Stop(str);
                SqlDependency.Start(str);

                con = new SqlConnection(str);
                con.Open();
                //Console.WriteLine("Connection successful!");
            }
            catch (SqlException ex)
            {
                //Console.WriteLine($"SQL Error: {ex.Message}");
                MessageBox.Show($"SQL Error: {ex.Message}");
                throw; // Re-throw the exception after logging
            }
        }
    }
}
