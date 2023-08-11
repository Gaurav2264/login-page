using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_page
{
    public partial class welcomescr : Form
    {
        public welcomescr()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void welcomescr_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value < 100)
            {
                progressBar1.Value += 2;
                label3.Text=progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                new Login().Show();
                this.Hide();

            }
        }
    }
}
