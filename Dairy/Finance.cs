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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            Incpopulate();
        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
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


        private void Exppopulate()
        {
            con.Open();
            string Query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void clearExp()
        {
            Purpose.SelectedIndex = -1;
            Amount.Text = "";
        }

        private void Incpopulate()
        {
            con.Open();
            string Query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void clearInc()
        {
            TypeCb.SelectedIndex = -1;
           AmountTb.Text = "";
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (Purpose.SelectedIndex == -1 || Amount.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into ExpenditureTbl values('" + dateTb.Value.Date + "','" + Purpose.SelectedItem.ToString() + "'," + Amount.Text + "," + EmpID.Text + ")";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expenditure Saved");
                    con.Close();
                    Exppopulate();
                    clearExp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }


   
}
