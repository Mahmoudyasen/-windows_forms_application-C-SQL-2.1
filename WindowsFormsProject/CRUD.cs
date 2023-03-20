using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
        }

        GymClass std = new GymClass();

        private void CRUD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMDataSet.Members' table. You can move, or remove it, as needed.
            this.membersTableAdapter.Fill(this.gYMDataSet.Members);
            DataTable dt = std.Select();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the values from Input Fields
            string gen = "";
            string pro = "";
            string spo = "";
            if (rbMale.Checked)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }
            if (cbLosingWeight.Checked)
            {
                pro = "LosingWeight";
            }
            else if (cbGainingMuscle.Checked)
            {
                pro = "GainingMuscles";
            }
            else if (cbFitness.Checked)
            {
                pro = "Fitness";
            }
            else if (cbPilates.Checked)
            {
                pro = "Pilates";
            }
            if (cbSwimming.Checked)
            {
                spo = "Swimming";
            }
            else if (cbLiftingWeights.Checked)
            {
                spo = "LiftingWeights";
            }
            else if (cbBasketball.Checked)
            {
                spo = "Basketball";
            }
            else if (cbRunning.Checked)
            {
                spo = "Running";
            }
            std.FirstName = txtFirstName.Text;
            std.LastName = txtLastName.Text;
            std.PhoneNumber = txtPhoneNumber.Text;
            std.Gender = gen;
            std.DOB = dtpDOB.Text;
            std.Height = cbHeight.Text;
            std.Weight = cbWeight.Text;
            std.Program = pro;
            std.Sport = spo;

            // Insert a record to the table using the previous method
            bool success = std.Insert(std);

            if (success == true)
            {
                MessageBox.Show("A new member inserted to ");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed");
            }

            DataTable dt = std.Select();
            dataGridView1.DataSource = dt;
        }

        public void Clear()
        {
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Clear();
            txtPhoneNumber.Clear();
            dtpDOB.Text = "";
            cbHeight.Text = "";
            cbWeight.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cbLosingWeight.Checked = false;
            cbGainingMuscle.Checked = false;
            cbFitness.Checked = false;
            cbPilates.Checked = false;
            cbRunning.Checked = false;
            cbSwimming.Checked = false;
            cbLiftingWeights.Checked = false;
            cbBasketball.Checked = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the values from Input Fields
            string gen = "";
            string pro = "";
            string spo = "";
            if (rbMale.Checked)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }
            if (cbLosingWeight.Checked)
            {
                pro = "LosingWeight";
            }
            if (cbGainingMuscle.Checked)
            {
                pro = "GainingMuscles";
            }
            if (cbFitness.Checked)
            {
                pro = "Fitness";
            }
            if (cbPilates.Checked)
            {
                pro = "Pilates";
            }
            if (cbSwimming.Checked)
            {
                spo = "Swimming";
            }
            if (cbLiftingWeights.Checked)
            {
                spo = "LiftingWeights";
            }
            if (cbBasketball.Checked)
            {
                spo = "Basketball";
            }
            if (cbRunning.Checked)
            {
                spo = "Running";
            }
            // Transfer the Form values to ClassGym
            std.ID = int.Parse(txtID.Text);
            std.FirstName = txtFirstName.Text;
            std.LastName = txtLastName.Text;
            std.PhoneNumber = txtPhoneNumber.Text;
            std.Gender = gen;
            std.DOB = dtpDOB.Text;
            std.Height = cbHeight.Text;
            std.Weight = cbWeight.Text;
            std.Program = pro;
            std.Sport = spo;

            // Update the row in the table in DB
            bool success = std.Update(std);

            if (success == true)
            {
                MessageBox.Show("Record has been updated");

                // Load DGV from DB
                DataTable dt = std.Select();
                dataGridView1.DataSource = dt;

                // Call the Clear() method
                Clear();
            }
            else
            {
                MessageBox.Show("Update Failed");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Get the data from From
            std.ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            bool success = std.Delete(std);
            if (success)
            {
                // Successfully deleted
                MessageBox.Show("Record has been deleted");
                // Refresh the DGV
                DataTable dt = std.Select();
                dataGridView1.DataSource = dt;

                // Call the Clear() method
                Clear();

            }
            else
            {
                // Failed to delete
                MessageBox.Show("Record has not been deleted");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;


            txtID.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            txtPhoneNumber.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();

            string gender = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            rbMale.Checked = gender.Equals("Male");
            rbFemale.Checked = gender.Equals("Female");
            dtpDOB.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();

            cbHeight.Text = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
            cbWeight.Text = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
            string pro = dataGridView1.Rows[rowindex].Cells[8].Value.ToString();

            var proArr = pro.Split(' ');
            foreach (var prog in proArr)
            {

                if (prog.Equals("GainingMuscle"))
                {
                    cbGainingMuscle.Checked = true;
                }
                if (prog.Equals("LosingWeight"))
                {
                    cbLosingWeight.Checked = true;
                }
                if (prog.Equals("Fitness"))
                {
                    cbFitness.Checked = true;
                }
                if (prog.Equals("Pilates"))
                {
                    cbPilates.Checked = true;
                }
            }
                string spo = dataGridView1.Rows[rowindex].Cells[9].Value.ToString();
                var spoArr = spo.Split(' ');
                foreach (var sport in spoArr)
                {
                    if (sport.Equals("GainingMuscle"))
                    {
                        cbLiftingWeights.Checked = true;
                    }
                    if (sport.Equals("Swimming"))
                    {
                        cbSwimming.Checked = true;
                    }
                    if (sport.Equals("Running"))
                    {
                        cbRunning.Checked = true;
                    }
                    if (sport.Equals("Basketball"))
                    {
                        cbBasketball.Checked = true;
                    }

                }
            
        }
    }
}


