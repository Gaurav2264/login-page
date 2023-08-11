using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace login_page
{
    public partial class forgetpassword : Form
        
    {
        string randomCode;
        public static string to;
        public forgetpassword()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();


        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string from, pass, messagebody;
            Random r=new Random();
            randomCode = (r.Next(999999)).ToString();
            MailMessage message =new MailMessage();
            to = (txtemail.Text).ToString();
            from = "";//your email id from which your want to send verification mail.
            pass = "";//your email password
            messagebody = "Your code for reset your password is " + randomCode+"Thank You ❤️ ©️Gaurav  ";
            message.To.Add(to);
            message.From=new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Password Reseting Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            //app password:-obkwjjnxqbonqcyh
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code sent Successfully");

            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }


        }

        private void btn_verify_Click(object sender, EventArgs e)
        {
            if (randomCode == (txtcode.Text).ToString())
            {
                to = txtemail.Text;
                resetpassword rp = new resetpassword();
                this.Hide();
                rp.Show();
            }
            else
            {
                MessageBox.Show("wrong Code");
            }
        }
    }
}
