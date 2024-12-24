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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymProject
{
    public partial class Form2 : Form
    {
        SqlConnection connection = Form1.connection;

        public Form2()
        {
            InitializeComponent();
            CustomizeUI();
        }

        private void CustomizeUI()
        {
            // Customize form appearance
            this.Text = "Member Registration";
            this.BackColor = Color.LightBlue;

            // Customize text boxes
            textBox1.Font = new Font("Arial", 10, FontStyle.Regular);
            textBox2.Font = new Font("Arial", 10, FontStyle.Regular);
            textBox3.Font = new Font("Arial", 10, FontStyle.Regular);

            // Customize buttons
            button1.Font = new Font("Arial", 10, FontStyle.Bold);
            button1.BackColor = Color.DarkBlue;
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;

            // Customize date picker
            dateTimePicker1.Font = new Font("Arial", 10, FontStyle.Regular);

            // Customize checkbox
            checkBox1.Font = new Font("Arial", 10, FontStyle.Regular);
            checkBox3.Font = new Font("Arial", 10, FontStyle.Regular);

            // Customize link label
            linkLabel1.Font = new Font("Arial", 10, FontStyle.Underline);
            linkLabel1.LinkColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            connection.Open();

            using (SqlCommand command = new SqlCommand(
                "INSERT INTO [customers] (member_name, contact_number, passwords, date_of_birth, member_gender, joining_date) " +
                "VALUES (@member_name, @contact_number, @passwords, @date_of_birth, @member_gender, @joining_date)", connection))
            {
                command.Parameters.AddWithValue("@member_name", textBox1.Text.Trim());
                command.Parameters.AddWithValue("@contact_number", textBox2.Text.Trim());
                command.Parameters.AddWithValue("@passwords", textBox3.Text.Trim());
                command.Parameters.AddWithValue("@date_of_birth", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@member_gender", checkBox1.Checked ? "Male" : "Female");
                command.Parameters.AddWithValue("@joining_date", DateTime.Now);

                command.ExecuteNonQuery();

            }

            MessageBox.Show($"Kayıt Başarılı!");

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
            {
                connection.Close();

            }

        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {

                textBox3.PasswordChar = '\0';
            }

            else
            {
                textBox3.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }
    }
}