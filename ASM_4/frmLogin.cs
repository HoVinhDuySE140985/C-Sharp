using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_4
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Controller ctrl = new Controller();
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            ctrl.LoginCtl(username, password);
            Application.Exit();
        }

        
    }
}
