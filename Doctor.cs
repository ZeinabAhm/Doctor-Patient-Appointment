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
using Visual_Project.DataSetTableAdapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace Visual_Project
{ 
    public partial class Doctor : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = MOHAMAD_AMRO; Initial Catalog = DoctorAppointmentsDB; Integrated Security = True");
        public Doctor()
        {
            InitializeComponent();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.dataSet.Appointment);
            // TODO: This line of code loads data into the 'dataSet.Appointment' table. You can move, or remove it, as needed.
            //dataGridView1.ClearSelection();
            label1.Text = "Welcome back Doctor";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            //string strcon = ConfigurationManager.ConnectionStrings["carconstr"].ToString();
            //SqlConnection con = new SqlConnection(strcon);
            DataTable dt_appointment = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Appointment where dr_name=@name", conn);
            //  MessageBox.Show(comboBox1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@name",textBox1.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            try
            {
                conn.Open();
                da.Fill(dt_appointment);
                dataGridView1.DataSource = dt_appointment;
            }
            catch
            {
                MessageBox.Show(textBox1.Text.ToString() + " doesn't have an appointments scheduled yet");
            }
            finally { conn.Close(); }
            //conn.Open();
            //string query = "select * from Appointment where dr_name = '" + textBox1.Text + "'";
            //SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //SqlCommandBuilder bu = new SqlCommandBuilder(da);
            //var ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[1];
            //conn.Close();
            //}
            //        conn.Open();
            //            SqlCommand cmd = new SqlCommand("SELECT * from Appointment WHERE dr_name=@name", conn);
            //        cmd.Parameters.AddWithValue("@name", textBox1.Text.ToString());
            //            cmd.Connection = conn;
            //            try
            //            {
            //                cmd.ExecuteNonQuery();
            //                DataSet ds = new DataSet();
            //        DataSetTableAdapters.AppointmentTableAdapter da = new DataSetTableAdapters.AppointmentTableAdapter();
            //        BindingSource bs = new BindingSource();
            //        da.Fill(ds.Appointment); bs.DataSource = ds.Appointment;
            //                dataGridView1.DataSource = ds.Appointment;

            //                textBox1.Text = "";
            //                textBox1.Focus();
            //        }
            //            catch
            //            {
            //                MessageBox.Show("Invalid inputs");
            //            }
            //            finally
            //            {
            //    conn.Close();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = monthCalendar1.SelectionStart.ToShortDateString();
            textBox3.Text = monthCalendar1.SelectionEnd.ToShortDateString();
        }
    }
}
