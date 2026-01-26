using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DebtsManagerDataAccessLayer
{
    public class clsCurrencyDataAccess
    {
        public static int AddNewCurrency(string name, string country, string suffix,decimal toDefaultRate)
        {
            //this function will return the new Currency id if succeeded and -1 if not.
            int CurrencyId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO Currencies (CurrencyName, CurrencyCountry, CurrencySuffix, ToDefaultRate)
                             VALUES (@Name, @Country, @Suffix,@ToDefaultRate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Country", country);
            command.Parameters.AddWithValue("@Suffix", suffix);
            command.Parameters.AddWithValue("@ToDefaultRate", toDefaultRate);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CurrencyId = insertedID;
                }
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return CurrencyId;
        }

        public static bool DeleteCurrency(int currencyId)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"DELETE FROM Currencies 
                             WHERE CurrencyId = @CurrencyId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyId", currencyId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllCurrencies()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Currencies";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetCurrencyById(int currencyId, ref string name, ref string country, ref string suffix,ref bool isUsed, ref bool isDefault,ref decimal toDefaultRate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Currencies WHERE CurrencyId = @CurrencyId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyId", currencyId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    name = (string)reader["CurrencyName"];
                    country = (string)reader["CurrencyCountry"];
                    suffix = (string)reader["CurrencySuffix"];
                    isUsed = (bool)reader["IsUsed"];
                    isDefault = (bool)reader["IsDefault"];
                    toDefaultRate = (decimal)reader["ToDefaultRate"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch
            {
                isFound = false;
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int GetCurrencyId(string currencyName)
        {
            int CurrencyId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"select CurrencyId From Currencies where CurrencyName = @CurrencyName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyName", currencyName);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int currencyID))
                {
                    CurrencyId = currencyID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return CurrencyId;
        }

        public static bool IsCurrencyExists(int currencyId)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Currencies WHERE CurrencyId = @CurrencyId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyId", currencyId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsCurrencyUsedInAccounts(int currencyId)
        {
            bool isUsed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Accounts WHERE CurrencyId = @CurrencyId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyId", currencyId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isUsed = reader.HasRows;

                reader.Close();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                isUsed = false;
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return isUsed;
        }

        public static DataTable SearchForCurrency(string text)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM Currencies 
                            WHERE Name LIKE @Text 
                            OR Country LIKE @Text 
                            OR Suffix LIKE @Text";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Text", "%" + text + "%");

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool SetDefaultCurrency(int CurrencyId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"UPDATE Currencies SET IsDefault = 0;
                             UPDATE Currencies SET IsDefault = 1 WHERE CurrencyId = @CurrencyId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CurrencyId", CurrencyId);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool UpdateCurrency(int id, string name, string country, string suffix,bool IsUsed,decimal toDefaultRate)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"UPDATE Currencies  
                            SET CurrencyName = @CurrencyName, 
                                CurrencyCountry = @CurrencyCountry, 
                                CurrencySuffix = @CurrencySuffix,
                                IsUsed = @IsUsed,
                                ToDefaultRate = @ToDefaultRate
                            WHERE CurrencyId = @CurrencyId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyId", id);
            command.Parameters.AddWithValue("@CurrencyName", name);
            command.Parameters.AddWithValue("@CurrencyCountry", country);
            command.Parameters.AddWithValue("@CurrencySuffix", suffix);
            command.Parameters.AddWithValue("@IsUsed", IsUsed);
            command.Parameters.AddWithValue("@ToDefaultRate", toDefaultRate);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}