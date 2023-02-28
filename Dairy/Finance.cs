using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
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
    }


   
}
