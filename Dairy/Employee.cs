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
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Eslam\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }
    }
}
