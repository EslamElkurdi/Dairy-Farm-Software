﻿using System;
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
    public partial class MilkProduction : Form
    {
        public MilkProduction()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        private void Clear()
        {
            CowNameTb.Text = "";
            AmMilkTb.Text = "";
            pmMilkTb.Text = "";
            TotalMilkTb.Text = "";
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
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
            CowIdCB.ValueMember = "CowId";
            CowIdCB.DataSource = dt;
            con.Close();
        }

        private void populate()
        {
            con.Open();
            string Query = "select * from CowTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowDG.DataSource = ds.Tables[0];
            con.Close();
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (CowIdCB.SelectedIndex == -1 || CowNameTb.Text == "" || AmMilkTb.Text == "" || pmMilkTb.Text == "" || NoonMilkTb.Text == "" || TotalMilkTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into MilkTbl values(" + CowIdCB.SelectedValue.ToString() + ",'" + CowNameTb.Text + "'," + AmMilkTb.Text + "," + NoonMilkTb.Text + "," + pmMilkTb.Text + "," + TotalMilkTb.Text + ", '" + dateTb.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Saved");
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

        int key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCB.SelectedValue = CowDG.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = CowDG.SelectedRows[0].Cells[2].Value.ToString();
            AmMilkTb.Text = CowDG.SelectedRows[0].Cells[3].Value.ToString();
            NoonMilkTb.Text = CowDG.SelectedRows[0].Cells[4].Value.ToString();
            pmMilkTb.Text = CowDG.SelectedRows[0].Cells[5].Value.ToString();
            TotalMilkTb.Text = CowDG.SelectedRows[0].Cells[6].Value.ToString();
            dateTb.Text = CowDG.SelectedRows[0].Cells[7].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(CowDG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }


        private void GetCowName() 
        {
            con.Open();
            String query = "select * from CowTbl where CowId="+CowIdCB.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows) {
                CowNameTb.Text = dr["CowName"].ToString();
            }

            con.Close();
        }

        private void CowIdCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void pmMilkTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pmMilkTb_MouseUp(object sender, MouseEventArgs e)
        {


        }

        private void pmMilkTb_MouseLeave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(AmMilkTb.Text) + Convert.ToInt32(pmMilkTb.Text) + Convert.ToInt32(NoonMilkTb.Text);
            TotalMilkTb.Text = "" + total;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete from MilkTbl where MId= " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producet Deleted");
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CowIdCB.SelectedIndex == -1 || CowNameTb.Text == "" || AmMilkTb.Text == "" || pmMilkTb.Text == "" || NoonMilkTb.Text == "" || TotalMilkTb.Text == "")
            {
                MessageBox.Show("Select Product");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "update MilkTbl set CowName='" + CowNameTb.Text + "', AmMilk= " + AmMilkTb.Text + ",NoonMilk=" + NoonMilkTb.Text + ",PmMilk=" + pmMilkTb.Text + ",TotalMilk=" + TotalMilkTb.Text + ",DateProd='" + dateTb.Value.Date + "' where MId=" + key + " ;";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated");
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

        private void CowIdCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
