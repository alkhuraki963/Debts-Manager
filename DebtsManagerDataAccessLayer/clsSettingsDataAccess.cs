using DebtsManagerUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DebtsManagerDataAccessLayer
{
    public class clsSettingsDataAccess
    {
        public static string GetSetting(string settingName)
        {
            string SettingValue = string.Empty;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = $"select value from settings where setting = '{settingName}';";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    SettingValue = result.ToString();
                }
            }

            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return SettingValue;
        }

        public static bool UpdateSetting(string settingName, string newValue)
        {
            int rowsAffected = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = $"update settings set value = @Value where setting = '{settingName}';";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Value", newValue);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }

            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool SaveBackup(string destinationFolder)
        {
          
            if (!Directory.Exists(destinationFolder))
            {
                throw new DirectoryNotFoundException("المجلد المحدد غير موجود.");
            }

            string backupFileDestination = clsUtility.CreateBackupName(destinationFolder);



            string query = $"BACKUP DATABASE [{clsDataAccessLayerSettings.DatabaseName}] TO DISK = @BackupFileDestination";


            using (SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BackupFileDestination", backupFileDestination);
                command.CommandTimeout = 300;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"خطأ في النسخ الاحتياطي: {ex.Message}");
                    return false;
                }
            }
        }

        public static bool RestoreDatabase(string backupPath)
        {
            bool success = false;
            string connectionString = clsDataAccessLayerSettings.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Query to kill existing connections to the database
                string killConnectionsQuery = $@"
            USE master;
            ALTER DATABASE [{clsDataAccessLayerSettings.DatabaseName}] 
            SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

                // Query to restore the database
                string restoreQuery = $@"
            RESTORE DATABASE [{clsDataAccessLayerSettings.DatabaseName}] 
            FROM DISK = @BackupFileDestination
            WITH REPLACE, RECOVERY;";

                // Query to set database back to multi-user mode
                string setMultiUserQuery = $@"
            ALTER DATABASE [{clsDataAccessLayerSettings.DatabaseName}] 
            SET MULTI_USER;";

                using (SqlCommand restoreCommand = new SqlCommand(restoreQuery, connection))
                {
                    restoreCommand.Parameters.AddWithValue("@BackupFileDestination", backupPath);
                    restoreCommand.CommandTimeout = 300; // 5 minutes timeout

                    try
                    {
                        connection.Open();

                        // Step 1: Terminate existing connections
                        using (SqlCommand killConnectionsCommand = new SqlCommand(killConnectionsQuery, connection))
                        {
                            killConnectionsCommand.ExecuteNonQuery();
                        }

                        // Step 2: Execute the database restore
                        restoreCommand.ExecuteNonQuery();

                        // Step 3: Set database back to multi-user mode
                        using (SqlCommand setMultiUserCommand = new SqlCommand(setMultiUserQuery, connection))
                        {
                            setMultiUserCommand.ExecuteNonQuery();
                        }

                        success = true;
                    }
                    catch (SqlException ex)
                    {
                        // Log the error for debugging
                        Console.WriteLine($"SQL Error during restore: {ex.Message}");
                        success = false;
                    }
                    finally
                    {
                        // Ensure database is set back to multi-user mode even if an error occurred
                        try
                        {
                            if (connection.State == System.Data.ConnectionState.Open)
                            {
                                using (SqlCommand setMultiUserCommand = new SqlCommand(setMultiUserQuery, connection))
                                {
                                    setMultiUserCommand.ExecuteNonQuery();
                                }
                            }
                        }
                        catch
                        {
                            
                        }
                    }
                }
            }

            return success;
        }
    }
}
