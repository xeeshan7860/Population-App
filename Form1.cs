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

namespace population
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cm2 = new SqlCommand("delete from papula where ID=@ID", conn);
                cm2.Parameters.AddWithValue("ID", comboBox1.Text);
                cm2.Parameters.AddWithValue("Name", textBox1.Text);
                cm2.Parameters.AddWithValue("F_name", textBox2.Text);
                cm2.Parameters.AddWithValue("Cnic", textBox3.Text);
                cm2.Parameters.AddWithValue("Gendar", textBox4.Text);
                cm2.Parameters.AddWithValue("Marital", textBox5.Text);
                cm2.Parameters.AddWithValue("Current_adress", textBox6.Text);
                cm2.Parameters.AddWithValue("permenant_adress", textBox7.Text);
                cm2.Parameters.AddWithValue("Contact_no", textBox8.Text);
                cm2.Parameters.AddWithValue("DOB", textBox9.Text);
                cm2.Parameters.AddWithValue("POB", textBox10.Text);
                cm2.Parameters.AddWithValue("Mother_tongue", textBox11.Text);
                cm2.Parameters.AddWithValue("T_Famly_members", textBox12.Text);
                cm2.ExecuteNonQuery();
                
                MessageBox.Show("Data has been Deleted", "Command Succesfull", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                this.comboBox1.Items.Clear();
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                this.textBox5.Clear();
                this.textBox6.Clear();
                this.textBox7.Clear();
                this.textBox8.Clear();
                this.textBox9.Clear();
                this.textBox10.Clear();
                this.textBox11.Clear();
                this.textBox12.Clear();
                
                cm2 = new SqlCommand("select * from papula", conn);
                SqlDataReader dr = cm2.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["ID"].ToString());

                }

                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Your Cannot Assigned Same Id Your Records Please give Another id");
            }
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated security=SSPI;database=population");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("select ID from papula", conn);
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Id"].ToString());
                }
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("error" + ex);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();


                SqlCommand cm = new SqlCommand("select * from papula where Id='" + this.comboBox1.Text + "'", conn);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.textBox1.Text = dr["Name"].ToString();
                    this.textBox2.Text = dr["F_name"].ToString();
                    this.textBox3.Text = dr["Cnic"].ToString();
                    this.textBox4.Text = dr["Gendar"].ToString();

                    this.textBox5.Text = dr["Marital"].ToString();

                    this.textBox6.Text = dr["Current_adress"].ToString();

                    this.textBox7.Text = dr["permenant_adress"].ToString();
                    this.textBox8.Text = dr["Contact_no"].ToString();

                    this.textBox9.Text = dr["DOB"].ToString();

                    this.textBox10.Text = dr["POB"].ToString();

                    this.textBox11.Text = dr["Mother_tongue"].ToString();
                    this.textBox12.Text = dr["T_famly_members"].ToString();


                } conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                SqlCommand cm2 = new SqlCommand("insert into papula(ID,Name,F_name,Cnic,Gendar,Marital,Current_adress,permenant_adress,Contact_no,DOB,POB,Mother_tongue,T_Famly_members) values (@ID,@Name,@F_name,@Cnic,@Gendar,@Marital,@Current_adress,@permenant_adress,@Contact_no,@DOB,@POB,@Mother_tongue,@T_Famly_members)", conn);
                cm2.Parameters.AddWithValue("ID", comboBox1.Text);
                cm2.Parameters.AddWithValue("Name", textBox1.Text);
                cm2.Parameters.AddWithValue("F_name", textBox2.Text);
                cm2.Parameters.AddWithValue("Cnic", textBox3.Text);
                cm2.Parameters.AddWithValue("Gendar", textBox4.Text);
                cm2.Parameters.AddWithValue("Marital", textBox5.Text);
                cm2.Parameters.AddWithValue("Current_adress", textBox6.Text);
                cm2.Parameters.AddWithValue("permenant_adress", textBox7.Text);
                cm2.Parameters.AddWithValue("Contact_no", textBox8.Text);
                cm2.Parameters.AddWithValue("DOB", textBox9.Text);
                cm2.Parameters.AddWithValue("POB", textBox10.Text);
                cm2.Parameters.AddWithValue("Mother_tongue", textBox11.Text);
                cm2.Parameters.AddWithValue("T_Famly_members", textBox12.Text);
                cm2.ExecuteNonQuery();
                MessageBox.Show("Data Has Been Inserted", "Data Inserted", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.comboBox1.Items.Clear();
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                this.textBox5.Clear();
                this.textBox6.Clear();
                this.textBox7.Clear();
                this.textBox8.Clear();
                this.textBox9.Clear();
                this.textBox10.Clear();
                this.textBox11.Clear();
                this.textBox12.Clear();
            


               
                cm2 = new SqlCommand("select * from papula", conn);
                SqlDataReader dr = cm2.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["ID"].ToString());
                }

            }   
            catch (Exception)
            {
                MessageBox.Show("You Cannot Input Same ID Becouse Its Primary Key", "Alert");
                this.comboBox1.Items.Clear();
            }
            conn.Close();
        }
          
        private void button2_Click(object sender, EventArgs e)
        {
           

                conn.Open();
                SqlCommand cm3 = new SqlCommand("update papula set ID=@ID,Name=@Name,F_name=@F_name,Cnic=@Cnic,Gendar=@Gendar,Marital=@Marital,Current_adress=@Current_adress,permenant_adress=@permenant_adress,Contact_no=@Contact_no,DOB=@DOB,POB=@POB,Mother_tongue=@Mother_tongue,T_famly_members=@T_famly_members where ID = '" + comboBox1.Text + "'", conn);
                cm3.Parameters.AddWithValue("ID", comboBox1.Text);
                cm3.Parameters.AddWithValue("Name", textBox1.Text);
                cm3.Parameters.AddWithValue("F_name", textBox2.Text);
                cm3.Parameters.AddWithValue("Cnic", textBox3.Text);
                cm3.Parameters.AddWithValue("Gendar", textBox4.Text);
                cm3.Parameters.AddWithValue("Marital", textBox5.Text);
                cm3.Parameters.AddWithValue("Current_adress", textBox6.Text);
                cm3.Parameters.AddWithValue("permenant_adress", textBox7.Text);
                cm3.Parameters.AddWithValue("Contact_no", textBox8.Text);
                cm3.Parameters.AddWithValue("DOB", textBox9.Text);
                cm3.Parameters.AddWithValue("POB", textBox10.Text);
                cm3.Parameters.AddWithValue("Mother_tongue", textBox11.Text);
                cm3.Parameters.AddWithValue("T_famly_members", textBox12.Text);
                cm3.ExecuteNonQuery();
                MessageBox.Show("Data has Updated", "Command Succesfull", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                this.comboBox1.Items.Clear();
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                this.textBox5.Clear();
                this.textBox6.Clear();
                this.textBox7.Clear();
                this.textBox8.Clear();
                this.textBox9.Clear();
                this.textBox10.Clear();
                this.textBox11.Clear();
                this.textBox12.Clear();

                cm3 = new SqlCommand("select * from papula", conn);
                SqlDataReader dr = cm3.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["ID"].ToString());
                }
                conn.Close();
            }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dat = new SqlDataAdapter("select *from papula", conn);
            DataTable dt = new DataTable();
            dat.Fill(dt);
            dataGridView1.DataSource = dt;
        }









        }
    }


