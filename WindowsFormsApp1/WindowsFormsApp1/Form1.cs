using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String conString = "Data Source=localhost;Initial Catalog=School;Integrated Security=True";

        private DataTable Select()
        {
            //DB connection
            SqlConnection con = new SqlConnection(conString);

            //Create an Object for DataTable
            DataTable dataTable = new DataTable();

            try
            {
                // write sql query (your tables name)
                string sqlCode = "SELECT * FROM Aut" ;

                // write sql query (your tables name)
                SqlCommand cmd = new SqlCommand(sqlCode, con);

                // create sqldataadapter using cmd
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                // open connection
                con.Open();
                dataAdapter.Fill(dataTable);

            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }

            return dataTable;
        }

        private bool isExistInTable(DataTable table, String username, String password)
        {
            for(int i=0; i<table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                if (row[1].Equals(username))
                    if (row[2].Equals(password))
                        return true;
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = Select();

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isExist = isExistInTable(table, username, password);

            if (isExist)
            {
                // OPEN THE NEXT FORM
                ////
                //////
                ///////
                ////////
            }
            else
            {
                MessageBox.Show("Acess Denied!!!");
            }

        }
    }
}
