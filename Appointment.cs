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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Visual_Project
{
    public partial class Appointment : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = MOHAMAD_AMRO; Initial Catalog = DoctorAppointmentsDB; Integrated Security = True");
        public Appointment()
        {
            InitializeComponent();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.Doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.dataSet2.Doctor);
            // TODO: This line of code loads data into the 'dataSet2.tbl_regions' table. You can move, or remove it, as needed.
            //this.tbl_regionsTableAdapter.Fill(this.dataSet2.tbl_regions);
            // TODO: This line of code loads data into the 'dataSet1.Doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.dataSet1.Doctor);
            // TODO: This line of code loads data into the 'dataSet.Appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.dataSet.Appointment);
            // TODO: This line of code loads data into the 'dataSet.Doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.dataSet.Doctor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue == comboBox2.SelectedValue)
            {
                listBox1.Items.Add(comboBox2.SelectedValue.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int appointmentID = 1;
            //int doctorID;
            conn.Open();
            //SqlCommand cmd0 = new SqlCommand("SELECT doctor_id from Doctor WHERE name=@Name", conn);
            //cmd0.Parameters.AddWithValue("@Name",listBox1.SelectedItem.ToString());
            //cmd0.Connection = conn;
            //cmd0.ExecuteNonQuery();
            //DataSet ds0 = new DataSet();
            //DataSetTableAdapters.DoctorTableAdapter da0 = new DataSetTableAdapters.DoctorTableAdapter();
            //da0.Fill(ds0.Doctor);
            //var res = ds0.Doctor.Where(x => x.name == listBox1.SelectedItem.ToString())
            //    .Select(x => x.doctor_id);
            //foreach(int item in res)
            //{
            //    doctorID = int.Parse(item.ToString());
            //}
            //doctorID = ds0.Doctor.Count;
            SqlCommand cmd = new SqlCommand("INSERT INTO Appointment VALUES(@app_id,@name,@patient_id,@app_date,@app_time)",conn);
            cmd.Parameters.AddWithValue("@app_id",appointmentID);
            cmd.Parameters.AddWithValue("@name",listBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@patient_id",int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@app_date",dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@app_time",maskedTextBox1.Text);
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                DataSetTableAdapters.AppointmentTableAdapter da = new DataSetTableAdapters.AppointmentTableAdapter();
                BindingSource bs = new BindingSource();
                da.Fill(ds.Appointment);
                dataGridView1.DataSource = ds.Appointment;
                bs.DataSource = ds.Appointment;
                MessageBox.Show("Appointment Scheduled");
                appointmentID++;
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
        private void Clearing()
        {
            textBox2.Text = "";
            textBox1.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            maskedTextBox1.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            listBox1.Items.Clear();
            textBox2.Focus();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.doctorTableAdapter.Fill(this.dataSet.Doctor);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentBindingSource.EndEdit();
            this.appointmentTableAdapter.Update(this.dataSet);
            this.appointmentTableAdapter.Fill(this.dataSet.Appointment);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE Appointment WHERE appointment_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                DataSetTableAdapters.AppointmentTableAdapter da = new DataSetTableAdapters.AppointmentTableAdapter();
                BindingSource bs = new BindingSource();
                da.Fill(ds.Appointment);
                dataGridView1.DataSource = ds.Appointment;
                bs.DataSource = ds.Appointment;
                MessageBox.Show("Appointment Deleted");
                Clearing();
            }
            catch
            {
                MessageBox.Show("There is no such an Appointment with this ID");
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
