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
    public partial class Cows_Health : Form
    {
        public Cows_Health()
        {
            InitializeComponent();
            populate();
            FillCowId();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Cows obj = new Cows();
            obj.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            MilkProduction obj = new MilkProduction();
            obj.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Cows_Health obj = new Cows_Health();
            obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Breeding obj = new Breeding();
            obj.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            MilkSales obj = new MilkSales();
            obj.Show();
            this.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Finance obj = new Finance();
            obj.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            Cows obj = new Cows();
            obj.Show();
            this.Hide();
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            MilkProduction obj = new MilkProduction();
            obj.Show();
            this.Hide();
        }

        private void guna2HtmlLabel14_Click(object sender, EventArgs e)
        {
            Cows_Health obj = new Cows_Health();
            obj.Show();
            this.Hide();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {
            Breeding obj = new Breeding();
            obj.Show();
            this.Hide();
        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {
            MilkSales obj = new MilkSales();
            obj.Show();
            this.Hide();
        }

        private void guna2HtmlLabel15_Click(object sender, EventArgs e)
        {
            Finance obj = new Finance();
            obj.Show();
            this.Hide();
        }

        private void guna2HtmlLabel16_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cows_Health_Load(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            CowNameTb.Text = "";
            CostTb.Text = "";
            DiagTb.Text = "";
            EventTb.Text = "";
            TreatmentTb.Text = "";
            VelTb.Text = "";
            key = 0;
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
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;
            con.Close();
        }

        private void populate()
        {
            con.Open();
            string Query = "select * from HealthTbl";
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
            String query = "select * from CowTbl where CowId=" + CowIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CowNameTb.Text = dr["CowName"].ToString();
            }

            con.Close();
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || VelTb.Text == "" || TreatmentTb.Text == "" || EventTb.Text == "" || DiagTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into HealthTbl values('" + CowIdCb.SelectedValue.ToString() + "','" + CowNameTb.Text + "','" + dateTb.Value.Date + "','" + EventTb.Text + "','" + DiagTb.Text + "','" + TreatmentTb.Text + "', '" + CostTb.Text + "', '" + VelTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Health issue saved");
                    con.Close();
                    populate();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        int key = 0;
        private void HealthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue =HealthDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = HealthDGV.SelectedRows[0].Cells[2].Value.ToString();
            dateTb.Text = HealthDGV.SelectedRows[0].Cells[3].Value.ToString();
            EventTb.Text = HealthDGV.SelectedRows[0].Cells[4].Value.ToString();
            DiagTb.Text = HealthDGV.SelectedRows[0].Cells[5].Value.ToString();
            TreatmentTb.Text = HealthDGV.SelectedRows[0].Cells[6].Value.ToString();
            CostTb.Text = HealthDGV.SelectedRows[0].Cells[7].Value.ToString();
            VelTb.Text = HealthDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(HealthDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }

















}
