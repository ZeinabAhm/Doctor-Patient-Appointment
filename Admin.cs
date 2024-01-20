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
namespace Visual_Project
{
    public partial class Admin : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = MOHAMAD_AMRO; Initial Catalog = DoctorAppointmentsDB; Integrated Security = True");
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.dataSet.Doctor);
            // TODO: This line of code loads data into the 'dataSet.Doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.dataSet.Doctor);
            // TODO: This line of code loads data into the 'dataSet.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.dataSet.Admin);
            textBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Doctor VALUES(@id,@name,@specialty,@number,@email,@password,@region)", conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@specialty", textBox3.Text);
            cmd.Parameters.AddWithValue("@number", MaskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@password", textBox5.Text);
            cmd.Parameters.AddWithValue("@region", textBox6.Text);
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                DataSetTableAdapters.DoctorTableAdapter da = new DataSetTableAdapters.DoctorTableAdapter();
                BindingSource bs = new BindingSource();
                da.Fill(ds.Doctor);
                dataGridView2.DataSource = ds.Doctor;
                bs.DataSource = ds.Doctor;
                MessageBox.Show("Doctor Inserted");
                Clearing();
            }
            catch
            {
                MessageBox.Show("Invalid inputs");
            }
            finally
            {
                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Clearing()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            MaskedTextBox1.Text = "";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Doctor SET name=@Name,specialty=@Specialty,contact_number=@Number,email=@Email,password=@Password,region=@Region WHERE doctor_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Specialty", textBox3.Text);
            cmd.Parameters.AddWithValue("@Number", MaskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@Password", textBox5.Text);
            cmd.Parameters.AddWithValue("@Region", textBox6.Text);
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                DataSetTableAdapters.DoctorTableAdapter da = new DataSetTableAdapters.DoctorTableAdapter();
                BindingSource bs = new BindingSource();
                da.Fill(ds.Doctor);
                dataGridView2.DataSource = ds.Doctor;
                bs.DataSource = ds.Doctor;
                MessageBox.Show("Doctor Updated");
                Clearing();
            }
            catch
            {
                MessageBox.Show("Invalid inputs");
            }
            finally
            {
                conn.Close();
            }
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE Doctor WHERE doctor_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                DataSetTableAdapters.DoctorTableAdapter da = new DataSetTableAdapters.DoctorTableAdapter();
                BindingSource bs = new BindingSource();
                da.Fill(ds.Doctor);
                dataGridView2.DataSource = ds.Doctor;
                bs.DataSource = ds.Doctor;
                MessageBox.Show("Doctor Deleted");
                Clearing();
            }
            catch
            {
                MessageBox.Show("There is no such a Doctor with this ID");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}

