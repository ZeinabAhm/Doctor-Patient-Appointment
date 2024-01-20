using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web;

namespace Visual_Project
{

    public partial class Login : Form
    {
        public string name;
        SqlConnection conn = new SqlConnection(@"Data Source = MOHAMAD_AMRO; Initial Catalog = DoctorAppointmentsDB; Integrated Security = True");
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = this.textBox1.Text;
            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select in the Represent comboBox if you are a Patient, Doctor or an Admin");
            }
            else if (comboBox1.SelectedItem.ToString() == "Patient")
            {
                try
                {
                    string querry = "SELECT * FROM Patient WHERE name = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(querry, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        username = textBox1.Text;
                        password = textBox2.Text;
                        Appointment appointment = new Appointment();
                        this.Hide();
                        appointment.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Admin")
            {
                try
                {
                    string querry = "SELECT * FROM Admin WHERE name = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(querry, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        username = textBox1.Text;
                        password = textBox2.Text;
                        Admin admin = new Admin();
                        this.Hide();
                        admin.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Doctor")
            {
                try
                {
                    string querry = "SELECT * FROM Doctor WHERE name = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(querry, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        username = textBox1.Text;
                        password = textBox2.Text;
                        Doctor doctor = new Doctor();
                        this.Hide();
                        doctor.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else 
            {
                this.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            if (!checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            label4.Text = comboBox1.SelectedItem.ToString();
        }
    }
}
