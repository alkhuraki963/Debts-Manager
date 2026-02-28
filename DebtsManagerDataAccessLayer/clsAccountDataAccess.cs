using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerDataAccessLayer
{
    public class clsAccountDataAccess
    {
        public static DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string Query = "select * from Accounts";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }

        public static bool GetAccountById(int accountID, ref decimal balance, ref bool isDefault, ref int personId, ref int currencyId, ref DateTime createdAt, ref DateTime updatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Accounts WHERE AccountId = @AccountId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountId", accountID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    balance = (decimal)reader["Balance"];
                    isDefault = (bool)reader["IsDefault"];
                    personId = (int)reader["PersonId"];
                    currencyId = (int)reader["CurrencyId"];
                    createdAt = (DateTime)reader["CreatedAt"];
                    updatedAt = (DateTime)reader["UpdatedAt"];
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
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewAccount(int personId, int currencyId)
        {
            //this function will return the new Person id if succeeded and -1 if not.
            int AccountId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO Accounts (PersonId,CurrencyId)
                             VALUES (@PersonId,@CurrencyId);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", personId);
            command.Parameters.AddWithValue("@CurrencyId", currencyId);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AccountId = insertedID;
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

            return AccountId;
        }

        public static bool UpdateAccount(int accountId, decimal balance, bool isDefault, DateTime updatedAt)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"Update  Accounts  
                            set Balance = @Balance, 
                                IsDefault = @IsDefault, 
                                UpdatedAt = @UpdatedAt
                                where AccountId = @AccountId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountId", accountId);
            command.Parameters.AddWithValue("@Balance", balance);
            command.Parameters.AddWithValue("@IsDefault", isDefault);
            command.Parameters.AddWithValue("@UpdatedAt", updatedAt);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool IsAccountExists(int accountID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Accounts WHERE AccountId = @AccountId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountId", accountID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool DeleteAccount(int accountID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"Delete Accounts 
                                where AccountId = @AccountId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountId", accountID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);
        }

        public static int GetAccountId(int personId, int currencyId)
        {
            int AccountId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"select AccountId from Accounts where PersonId = @PersonId AND CurrencyId = @CurrencyId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", personId);
            command.Parameters.AddWithValue("@CurrencyId", currencyId);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AccountId = insertedID;
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

            return AccountId;
        }

        public static bool SetDefaultAccount(int accountId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"UPDATE Accounts SET IsDefault = 0;
                             UPDATE Accounts SET IsDefault = 1 WHERE AccountId = @AccountId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountId", accountId);
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
