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

namespace Dairy
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Eslam\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillCowId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowsTbl");
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            Gender.ValueMember = "CowId";
            Gender.DataSource = dt;
            con.Close();
        }

        private void populate()
        {
            con.Open();
            string Query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HealthDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void GetCowName()
        {
            con.Open();
            String query = "select * from CowTbl where CowId=" + Gender.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                NameTb.Text = dr["CowName"].ToString();
            }

            con.Close();
        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            Gender.SelectedIndex = -1;
            Address.Text = "";
            Phone.Text = "";
            key = 0;
        }


        private void clear() 
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || Gender.SelectedIndex == -1 || Address.Text == "" || Phone.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into EmployeeTbl values('" + NameTb.Text + "','" + dateTb.Value.Date + "','" + Gender.SelectedValue.ToString() + "','" + Phone.Text + "','" +Address.Text +"')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved");
                    con.Close();
                    populate();
                    clear();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int key = 0;
        private void HealthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = HealthDGV.SelectedRows[0].Cells[1].Value.ToString();
            dateTb.Text = HealthDGV.SelectedRows[0].Cells[2].Value.ToString();
            Gender.Text = HealthDGV.SelectedRows[0].Cells[3].Value.ToString();
            Phone.Text = HealthDGV.SelectedRows[0].Cells[4].Value.ToString();
            Address.Text = HealthDGV.SelectedRows[0].Cells[5].Value.ToString();
            
            if (NameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(HealthDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
