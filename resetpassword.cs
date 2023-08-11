using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace login_page
{
    public partial class resetpassword : Form
    {
        string user = forgetpassword.to;

        public resetpassword()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txtpassword.Clear();
            txtpassverify.Clear();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == txtpassverify.Text)
            {
               SqlConnection con = new SqlConnection("Data Source=Gaurav\\SQLEXPRESS;Initial Catalog=bca;Integrated Security=True");
               SqlCommand cmd = new SqlCommand("UPDATE signup_details SET pass= '" + txtpassverify.Text + "' WHERE email='" + user + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password Reset Successfully");
                this.Hide();
                new Login().Show();

            }
            else
            {
                MessageBox.Show("Something went wrong! OR Password doesn't match ");

            }
        }

        private void check_show_CheckedChanged(object sender, EventArgs e)
        {
            if(check_show.Checked==true)
            {
                
                txtpassword.UseSystemPasswordChar = false;
                txtpassverify.UseSystemPasswordChar = false;
            }
            else
            {
                txtpassword.UseSystemPasswordChar=true;
                txtpassverify.UseSystemPasswordChar = true; 
            }
         
        }

        private void resetpassword_Load(object sender, EventArgs e)
        {

        }
    }

    
}
