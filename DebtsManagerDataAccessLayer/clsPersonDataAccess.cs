using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerDataAccessLayer
{
    public class clsPersonDataAccess
    {
        public static int AddNewPerson(string fullName, string phone, string email)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ContactID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO persons (FullName, Phone, Email)
                             VALUES (@FullName, @Phone, @Email);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", fullName);
            command.Parameters.AddWithValue("@Phone", phone);

            // Handle Null Values
            if (string.IsNullOrEmpty(email))
            {
                command.Parameters.AddWithValue("@email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", email);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ContactID = insertedID;
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

            return ContactID;
        }

        public static bool DeletePerson(int accountID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"Delete Persons 
                                where PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", accountID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllPersons()
        {

            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string Query = "select * from Persons";
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

        public static bool GetPersonByID(int personID, ref string fullName, ref string phone, ref string email, ref decimal balance, ref bool isArchived, ref DateTime createdAt, ref DateTime updatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM persons WHERE personId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", personID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    fullName = (string)reader["FullName"];
                    balance = (decimal)reader["Balance"];
                    isArchived = (bool)reader["IsArchived"];

                    // Values that allow null
                    phone = reader["Phone"] != DBNull.Value ? (string)reader["Phone"] : string.Empty;
                    email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty;
                    createdAt = reader["CreatedAt"] != DBNull.Value ? (DateTime)reader["CreatedAt"] : DateTime.MinValue;
                    updatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime)reader["UpdatedAt"] : DateTime.MinValue;
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsPersonExists(int accountID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Persons WHERE PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", accountID);

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

        public static bool UpdatePerson(int id, string fullName, string phone, string email, decimal balance, bool isArchived, DateTime updatedAt)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"Update  Persons  
                            set FullName = @FullName, 
                                Phone = @Phone, 
                                Email = @Email, 
                                Balance = @Balance, 
                                IsArchived = @IsArchived,
                                UpdatedAt = @UpdatedAt
                                where PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", id);
            command.Parameters.AddWithValue("@FullName", fullName);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Balance", balance);
            command.Parameters.AddWithValue("@IsArchived", isArchived);
            command.Parameters.AddWithValue("@UpdatedAt", updatedAt);

            // Handle Null Values
            if (string.IsNullOrEmpty(email))
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", email);
            }

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
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
    }

}
