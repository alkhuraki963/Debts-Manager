using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerDataAccessLayer
{
    public class clsClassificationDataAccess
    {
        public static int AddNewClassification(string classificationName)
        {
            // This function will return the new Classification id if succeeded and -1 if not.
            int ClassificationId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO Classifications (ClassificationName)
                             VALUES (@ClassificationName);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationName", classificationName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ClassificationId = insertedID;
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

            return ClassificationId;
        }

        public static bool DeleteClassification(int classificationId)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"DELETE FROM Classifications 
                             WHERE ClassificationId = @ClassificationId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationId", classificationId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
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

            return (rowsAffected > 0);
        }

        public static DataTable GetAllClassifications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Classifications";
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
            catch
            {
                //Console.WriteLine(ex.Message);
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetClassificationById(int classificationId, ref string classificationName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Classifications WHERE ClassificationId = @ClassificationId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationId", classificationId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    classificationName = (string)reader["ClassificationName"];
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

        public static int GetClassificationId(string classificationName)
        {
            int ClassificationId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = "SELECT ClassificationId FROM Classifications WHERE ClassificationName = @ClassificationName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationName", classificationName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    ClassificationId = id;
                }
            }
            catch
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return ClassificationId;
        }

        public static string GetClassificationName(int classificationId)
        {
            string ClassificationName = string.Empty;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = "SELECT ClassificationName FROM Classifications WHERE ClassificationId = @ClassificationId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationId", classificationId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ClassificationName = result.ToString();
                }
            }
            catch
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return ClassificationName;
        }

        public static bool IsClassificationExists(int classificationId)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Classifications WHERE ClassificationId = @ClassificationId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationId", classificationId);

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

        public static bool IsClassificationExistsByName(string classificationName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Classifications WHERE ClassificationName = @ClassificationName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationName", classificationName);

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

        public static bool UpdateClassification(int id, string classificationName)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"UPDATE Classifications  
                            SET ClassificationName = @ClassificationName
                            WHERE ClassificationId = @ClassificationId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationId", id);
            command.Parameters.AddWithValue("@ClassificationName", classificationName);

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

        public static bool IsClassificationEmpty(int classificationId)
        {
            bool isEmpty = true;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Persons WHERE ClassificationId = @ClassificationId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassificationId", classificationId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isEmpty = !reader.HasRows;
                reader.Close();
            }
            catch
            {
                isEmpty = true;
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return isEmpty;
        }

    }
}