using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsProject
{
    class GymClass
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Program { get; set; }
        public string Sport { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["WindowsFormsProject.Properties.Settings.GYMConnectionString"].ConnectionString;


        public DataTable Select()
        {
            // Step 1: Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create an Object for DataTable
            DataTable dt = new DataTable();
            try
            {
                // Step 2: Write Sql Query
                string sql = "SELECT * FROM Members";
                // Create Command using "sql" and "conn"
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Create SqlDataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                // Open connection
                conn.Open();
                // Fill our dt with our adapter.
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool Insert(GymClass std)
        {
            // Creating a default return type and setting its value to false
            bool isSuccess = false;

            // Step 1: Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                // Step 2: Write Sql Query to insert data
                string sql = "INSERT INTO Members (FirstName, LastName,PhoneNumber,Gender,DOB,Height, Weight,Program,Sport) VALUES ( @FirstName, @LastName,@PhoneNumber,@Gender,@DOB,@Height, @Weight,@Program,@Sport) ";

                // Create Command using "sql" and "conn"
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Create Parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", std.FirstName);
                cmd.Parameters.AddWithValue("@LastName", std.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", std.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender", std.Gender);
                cmd.Parameters.AddWithValue("@DOB", std.DOB);
                cmd.Parameters.AddWithValue("@Height", std.Height);
                cmd.Parameters.AddWithValue("@Weight", std.Weight);
                cmd.Parameters.AddWithValue("@Program", std.Program);
                cmd.Parameters.AddWithValue("@Sport", std.Sport);


                // Open connection
                conn.Open();

                // Run the Query
                int rows = cmd.ExecuteNonQuery();

                // If the query runs successfully then the value "rows" will be greater then zero else it will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        public bool Update(GymClass std)
        {
            // Creating a default return type and setting its value to false
            bool isSuccess = false;
            // Step 1: Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // Step 2: Write Sql Query to update data in DB
                string sql = "UPDATE Members SET FirstName=@FirstName, LastName=@LastName, PhoneNumber=@PhoneNumber, Gender=@Gender, DOB=@DOB, Height=@Height, Weight=@Weight, Program=@Program, Sport=@Sport  WHERE ID = @ID";

                // Create Command using "sql" and "conn"
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Create Parameters to update data
                cmd.Parameters.AddWithValue("@ID", std.ID);
                cmd.Parameters.AddWithValue("@FirstName", std.FirstName);
                cmd.Parameters.AddWithValue("@LastName", std.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", std.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender", std.Gender);
                cmd.Parameters.AddWithValue("@DOB", std.DOB);
                cmd.Parameters.AddWithValue("@Height", std.Height);
                cmd.Parameters.AddWithValue("@Weight", std.Weight);
                cmd.Parameters.AddWithValue("@Program", std.Program);
                cmd.Parameters.AddWithValue("@Sport", std.Sport);


                // Open connection
                conn.Open();

                // Run the Query
                int rows = cmd.ExecuteNonQuery();

                // If the query runs successfully then the value "rows" will be greater then zero else it will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        // Method to delete a record in DB
        public bool Delete(GymClass std)
        {
            // Creating a default return type and setting its value to false
            bool isSuccess = false;
            // Step 1: Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // Step 2: Write Sql Query to Delete data in DB
                string sql = "DELETE FROM Members WHERE ID = @ID ";

                // Create Command using "sql" and "conn"
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Create Parameter to delete data
                cmd.Parameters.AddWithValue("@ID", std.ID);


                // Open connection
                conn.Open();

                // Run the Query
                int rows = cmd.ExecuteNonQuery();

                // If the query runs successfully then the value "rows" will be greater then zero else it will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
    }
}
