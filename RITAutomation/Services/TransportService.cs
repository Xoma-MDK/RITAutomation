using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RITAutomation.Models;
using System.Data;
using System.Windows.Forms;

namespace RITAutomation.Services
{
    public class TransportService
    {
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        string sql = "SELECT * FROM ";

        public List<TransportUnit> GeTransportUnits()
        {
            List<TransportUnit> units = new List<TransportUnit>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {

                    while (reader.Read()) 
                    {
                    }
                }
            }

            return units;
        }
    }
}
