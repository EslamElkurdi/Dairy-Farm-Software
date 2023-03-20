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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            Finance();
        }

        
        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            MilkProduction obj = new MilkProduction();
            obj.Show();
            this.Hide();
        }

       

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            Cows obj = new Cows();
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
         
        private void Finance() 
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(IncAmt) from IncomeTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int inc, exp;
            double bal;
            inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(ExpAmount) from ExpenditureTbl", con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            IncLabel.Text = dt.Rows[0][0].ToString();
            
            exp = Convert.ToInt32(dt.Rows[0][0].ToString());
            bal = inc - exp;
            Explabel.Text = dt1.Rows[0][0].ToString();
            Balancelabel.Text = "" + bal; 
            con.Close();
        
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
