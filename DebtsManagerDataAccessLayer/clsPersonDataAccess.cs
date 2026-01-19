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
        public static int AddNewPerson(string fullName, string phone, string email, int classificationId)
        {
            //this function will return the new Person id if succeeded and -1 if not.
            int PersonId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO persons (FullName, Phone, Email,ClassificationId)
                             VALUES (@FullName, @Phone, @Email,@classificationId);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", fullName);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@ClassificationId", classificationId);

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
                    PersonId = insertedID;
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

            return PersonId;
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

        public static bool GetPersonByID(int personID, ref string fullName, ref string phone, ref string email,
            ref int classificationId, ref DateTime createdAt, ref DateTime updatedAt)
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
                    phone = (string)reader["Phone"];
                    // email value allows null
                    email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty;
                    classificationId = (int)reader["ClassificationId"];
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

        public static DataTable SearchForPerson(string text)
        {

            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string Query = "select * from Persons where fullname like @Text";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
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
                //
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }

        public static bool UpdatePerson(int id, string fullName, string phone, string email,
            int classificationId, DateTime updatedAt)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"Update  Persons  
                            set FullName = @FullName, 
                                Phone = @Phone, 
                                Email = @Email, 
                                ClassificationId = @ClassificationId,
                                UpdatedAt = @UpdatedAt
                                where PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", id);
            command.Parameters.AddWithValue("@FullName", fullName);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@ClassificationId", classificationId);
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
