using System.Data.SqlClient;

namespace login_page
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myconnect.connect();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new signup().Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string user, password, sql;
            user=txt_user.Text;
            password=txt_pass.Text;
            sql = "select * from signup_details where email='" + user + "'";
            try
            {
                myconnect.cmd = new SqlCommand(sql, myconnect.con);
                myconnect.rs = myconnect.cmd.ExecuteReader();
                if (myconnect.rs.Read())
                {
                    if (myconnect.rs.GetString(3).Equals(password))
                        MessageBox.Show("Great!Login Success");
                    else
                        MessageBox.Show("OOPs!User Does not Exist");


                }
                else
                    MessageBox.Show("Username does anot exist!!");

            }
            catch (Exception exp)
            {

                MessageBox.Show("Error" + exp.Message);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            forgetpassword fp = new forgetpassword();
            this.Hide();
            fp.Show();


        }

        private void check_show_CheckedChanged(object sender, EventArgs e)
        {
            if(check_show.Checked==true)
            {
                txt_pass.UseSystemPasswordChar= false;

            }
            else
            {
                txt_pass.UseSystemPasswordChar = true;
            }
        }
    }
}