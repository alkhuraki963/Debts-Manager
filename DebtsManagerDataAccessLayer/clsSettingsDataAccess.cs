using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerDataAccessLayer
{
    public class clsSettingsDataAccess
    {
        public static string GetLvAccountViewType()
        {
            string lvAccountsViewType = string.Empty;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"select value from settings where setting = 'ListViewAccountsViewType';";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    lvAccountsViewType = result.ToString();
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return lvAccountsViewType;
        }

        public static bool UpdateLvAccountViewType(string value)
        {
            int rowsAffected = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"update settings set value = @Value where setting = 'ListViewAccountsViewType';";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Value", value);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

    }
}
