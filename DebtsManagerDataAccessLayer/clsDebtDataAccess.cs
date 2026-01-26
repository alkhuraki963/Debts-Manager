using DebtsManagerUtility;
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


    public class clsDebtDataAccess
    {
        public static int AddNewDebt(string notes, decimal amount, enDebtType debtType, DateTime debtDate,
            decimal balanceChange, int currencyId, int AccountId)
        {
            //this function will return the new Debt debtID if succeeded and -1 if not.
            int DebtID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO Debts (Notes, Amount, DebtType,DebtDate,BalanceChange,AccountId)
                             VALUES (@Notes, @Amount, @DebtType,@DebtDate,@BalanceChange,@AccountId);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Notes", notes);
            command.Parameters.AddWithValue("@Amount", amount);
            command.Parameters.AddWithValue("@DebtDate", debtDate);
            command.Parameters.AddWithValue("@BalanceChange", balanceChange);
            command.Parameters.AddWithValue("@AccountId", AccountId);

            if (debtType == enDebtType.INCOME)
            {
                command.Parameters.AddWithValue("@DebtType", "INCOME");
            }
            else
            {
                command.Parameters.AddWithValue("@DebtType", "OUTCOME");
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DebtID = insertedID;
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

            return DebtID;
        }

        public static bool DeleteDebt(int debtID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"Delete Debts 
                                where DebtId = @DebtId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DebtId", debtID);

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

        public static DataTable GetAllDebts(int AccountId)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string Query = "select * from Debts where AccountId = @AccountId";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@AccountId", AccountId);

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

        public static bool GetDebtByID(int debtId, ref string notes, ref decimal amount, ref enDebtType debtType, ref DateTime debtDate,
            ref decimal balanceChange, ref DateTime createdAt, ref DateTime updatedAt, ref int AccountId)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM debts WHERE DebtId = @DebtId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DebtId", debtId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    notes = (string)reader["Notes"];
                    amount = (decimal)reader["Amount"];
                    debtType = _GetDebtType(reader["DebtType"].ToString());
                    debtDate = (DateTime)reader["DebtDate"];
                    balanceChange = (decimal)reader["BalanceChange"];
                    createdAt = (DateTime)reader["CreatedAt"];
                    updatedAt = (DateTime)reader["UpdatedAt"];
                    AccountId = (int)reader["AccountId"];
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

        private static enDebtType _GetDebtType(string type)
        {
            if (type.ToUpper().Equals("INCOME"))
                return enDebtType.INCOME;
            else
                return enDebtType.OUTCOME;
        }

        public static bool IsDebtExists(int debtID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Debts WHERE DebtId = @DebtId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DebtId", debtID);

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
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool UpdateDebt(int debtID, string notes, decimal amount, enDebtType debtType, DateTime debtDate,
            decimal balanceChange, int currencyId, DateTime updatedAt)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"Update  Debts  
                            set Notes = @Notes, 
                                Amount = @Amount, 
                                DebtType = @DebtType, 
                                DebtDate = @DebtDate, 
                                BalanceChange = @BalanceChange,
                                UpdatedAt = @UpdatedAt
                                where DebtId = @DebtId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DebtId", debtID);
            command.Parameters.AddWithValue("@Notes", notes);
            command.Parameters.AddWithValue("@Amount", amount);
            command.Parameters.AddWithValue("@DebtType", _GetDebtTypeString(debtType));
            command.Parameters.AddWithValue("@DebtDate", debtDate);
            command.Parameters.AddWithValue("@BalanceChange", balanceChange);
            command.Parameters.AddWithValue("@CurrencyId", currencyId);
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

        private static string _GetDebtTypeString(enDebtType debtType)
        {
            if (debtType == enDebtType.INCOME)
            {
                return "INCOME";
            }
            else
            {
                return "OUTCOME";
            }
        }

        public static DataTable SearchForDebt(string text, int accountId)
        {
            DataTable dt = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string Query = "select * from Debts where AccountId = @AccountId and Notes like @Text";

            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@AccountId", accountId);
            sqlCommand.Parameters.AddWithValue("@Text", "%" + text + "%");

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
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }
    }
}
