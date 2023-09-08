using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RITAutomation.Models;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RITAutomation.Services
{
    public class TransportService
    {
        private const string ConnectionString = @"Data Source=XOMIC-PC\SQLEXPRESS;Initial Catalog=Rit_Automation;Integrated Security=True";

        public static List<TransportUnit> GetTransportUnits()
        {
            List<TransportUnit> units = new List<TransportUnit>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("dbo.GetAllTransportUnits", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            units.Add(new TransportUnit(
                                id: reader.GetInt32(0),
                                name: reader.GetString(1),
                                longtitude: reader.GetDouble(2),
                                latitude: reader.GetDouble(3))
                            );
                        }
                    }
                }
                return units;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public static void UpdateTransportUnit(TransportUnit unit)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("dbo.SaveTransportUnit", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@Name", unit.Name);
                    command.Parameters.AddWithValue("@Latitude", unit.Latitude);
                    command.Parameters.AddWithValue("@Longtitude", unit.Longtitude);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
