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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        int startppoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startppoint += 5;
            MyProgress.Value = startppoint;
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                Login Log = new Login();
                this.Hide();
                Log.Show();
            }
        }
    }
}
