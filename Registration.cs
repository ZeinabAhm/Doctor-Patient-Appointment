using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Visual_Project
{
    public partial class Registration : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = MOHAMAD_AMRO; Initial Catalog = DoctorAppointmentsDB; Integrated Security = True");
        public Registration()
        {
            InitializeComponent();
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.dataSet.Patient);
            conn.Open();
            textBox1.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != string.Empty || textBox3.Text != string.Empty || textBox2.Text != string.Empty)
            {
                if (textBox3.Text == textBox4.Text)
                {
                    SqlCommand cmd = new SqlCommand("select * from Patient where name='" + textBox2.Text + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into Patient values(@id,@name,@dob,@number,@gender,@age,@password)", conn);
                        cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@number", maskedTextBox1.Text);
                        cmd.Parameters.AddWithValue("@gender", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@age", (int)numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@password", textBox3.Text);
                        cmd.ExecuteNonQuery();
                        DialogResult res;
                        res = MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            this.Hide();
                            Login login = new Login();
                            login.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            if (!checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
            }
            if (!checkBox2.Checked)
            {
                textBox4.UseSystemPasswordChar = true;
            }
        }
    }
}
