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

namespace Dairy
{
    public partial class Cows : Form
    {
        public Cows()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Eslam\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
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

        private void populate()
        {
            Con.Open();
            string Query = "select * from CowTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowDG.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            cowNameTb.Text = "";
            earTagTb.Text = "";
            colorTb.Text = "";
            AgeTb.Text = "";
            WeightAtBirthTb.Text = "";
            pastureTb.Text = "";
            key = 0;
        }

        int age = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (cowNameTb.Text == "" || earTagTb.Text == "" || colorTb.Text == "" || breedTb.Text == "" || WeightAtBirthTb.Text == "" || AgeTb.Text == "" || pastureTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Insert into CowTbl values('" + cowNameTb.Text + "', '" + earTagTb.Text + "', '" + colorTb.Text + "', '" + breedTb.Text + "', " + Convert.ToInt32(AgeTb.Text)  + ", " + Convert.ToInt32(WeightAtBirthTb.Text)+ ", '" + pastureTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Saved Successfully");
                    Con.Close();
                    populate();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days)/365;
           // MessageBox.Show("" + age);
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DOBDate.Value.Date - DateTime.Today.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void CowDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cowNameTb.Text = CowDG.SelectedRows[0].Cells[1].Value.ToString();
            earTagTb.Text = CowDG.SelectedRows[0].Cells[2].Value.ToString();
            colorTb.Text = CowDG.SelectedRows[0].Cells[3].Value.ToString();
            breedTb.Text = CowDG.SelectedRows[0].Cells[4].Value.ToString();
            WeightAtBirthTb.Text = CowDG.SelectedRows[0].Cells[6].Value.ToString();
            pastureTb.Text = CowDG.SelectedRows[0].Cells[7].Value.ToString();
            if (cowNameTb.Text == "")
            {
                key = 0;
                age = 0;
            }
            else
            {
                key = Convert.ToInt32(CowDG.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowDG.SelectedRows[0].Cells[5].Value.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select item");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "delete from CowTbl where CowId=" + key +";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");
                    Con.Close();
                    populate();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            } 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cowNameTb.Text == "" || earTagTb.Text == "" || colorTb.Text == "" || breedTb.Text == "" || WeightAtBirthTb.Text == "" || AgeTb.Text == "" || pastureTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update CowTbl set CowName='" + cowNameTb.Text + "', EarTag= '" + earTagTb.Text + "',Color='" + colorTb.Text + "',Breed='" + breedTb.Text + "',Age=" + age + ",WeifhtAtBirth=" + WeightAtBirthTb.Text + ",Posture='" + pastureTb.Text+ "' where CowId=" + key + " ;";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Updated");
                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
     
    }
}
