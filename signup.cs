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
using System.IO;


namespace login_page
{
    public partial class signup : Form
    {
        private string sql;

        public signup()
        {
            InitializeComponent();
        }
        string imgLocation = "";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

            new Login().Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name, email, contact, password, city;
            name = txtname.Text;
            email = txtemail.Text;
            contact = txtcontact.Text;
            password = txtpassword.Text;
            city = txtcity.Text;

            sql = "insert into signup_details values('"+name+ "','" +email + "','" + contact + "','" + password + "','" + city + "',@images)";
            txtname.Clear();
            txtemail.Clear();
            txtcontact.Clear();
            txtpassword.Clear();
            txtcity.Clear();
            txtname.Focus();
            try
            {
                byte[] images = null;
                FileStream steem=new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(steem);
                images = br.ReadBytes((int)steem.Length);
                myconnect.cmd = new SqlCommand(sql, myconnect.con);
                myconnect.cmd.Parameters.Add(new SqlParameter("@images",images));
                myconnect.cmd.ExecuteNonQuery();
                MessageBox.Show("Signed Up Succesfully!");
                

            }
            catch (Exception exp)
            {

                MessageBox.Show("Error!"+exp.Message);
            }


        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog=new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation=dialog.FileName.ToString();
                pictureBox2.ImageLocation = imgLocation;
            }
        }
    }
}
