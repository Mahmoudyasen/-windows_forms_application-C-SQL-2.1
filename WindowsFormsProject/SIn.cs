using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    public partial class SIn : Form
    {
        public SIn()
        {
            InitializeComponent();
        }
        static string myconnstring = ConfigurationManager.ConnectionStrings["WindowsFormsProject.Properties.Settings.GYMConnectionString"].ConnectionString;
        private DataTable Select1()
        {
            //DB connection
            SqlConnection con = new SqlConnection(myconnstring);

            //Create an Object for DataTable
            DataTable dataTable = new DataTable();

            try
            {
                // write sql query (your tables name)
                string sqlCode = "SELECT * FROM Auth";

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

        private bool isExistInTable(DataTable table, String UserName, String Password)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                if (row[0].Equals(UserName))
                    if (row[1].Equals(Password))
                        return true;
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = Select1();

            string UserName = textBox1.Text;
            string Password = textBox2.Text;

            bool isExist = isExistInTable(table, UserName, Password);
            if (isExist)
            {
                this.Hide();
                CRUD f2 = new CRUD();
                f2.ShowDialog();
                f2 = null;
                this.Show();
            }
            else
            {
                MessageBox.Show("Acess Denied!!!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
