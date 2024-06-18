using argo.BL;
using argo.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argo.UI.UIContent
{
    public partial class CreateLogin : Form
    {
        private string v;
        private string proc;
        private User user;

        public CreateLogin()
        {
            InitializeComponent();
            if (proc.Equals("new")) {
                button2.Visible = false;
            }
        }

        public CreateLogin(string v, string proc)
        {
            InitializeComponent();
            this.v = v;
            this.proc = proc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = new User();
            user.UserName = UserName.Text;
            user.Password = Paswrd.Text;

            if (proc.Equals("new"))
            {
                new CreateUser().SetLogin(user, v);
            }
            else
            {
                new CreateUser().checkAvailable(user, v);
            }

            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
