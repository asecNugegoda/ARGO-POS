using argo.BL;
using argo.DL;
using argo.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArgoPOS.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            logText.Text = "";
        }
        loginCheck login;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            loginData();
        }

        private void loginData()
        {
            login = new loginCheck();
            User usr = login.loginValidation(new User(userTxt.Text, paswrdTxt.Text, null, null, null, null, DateTime.Now, 1, false));
            //User usr = login.loginCheck("tt", "tt");
            if (usr.Flag)
            {
                login hom = new login(this, usr);
                hom.Show();
                userTxt.Text = "";
                paswrdTxt.Text = "";
                this.Hide();
            }
            else
            {
                logText.Text = "Please check User Name and Password.";
            }
        }

    }
}
