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
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Eslam\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

    }

















}
