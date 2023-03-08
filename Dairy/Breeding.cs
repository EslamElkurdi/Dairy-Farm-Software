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
    public partial class Breeding : Form
    {
        public Breeding()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
