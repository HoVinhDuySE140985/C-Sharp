using Controllers;
using DTO;
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
    public partial class frmChangeAccount : Form
    {
        public frmChangeAccount()
        {
            InitializeComponent();
        }
        public frmChangeAccount(Employee e)
        {
            InitializeComponent();
            emp = e;
            txtUserName.Text = emp.empID;
            txtPassword.Text = emp.empPassword;
            txtRole.Text = emp.empRole.ToString();
            txtUserName.Enabled = false;
            txtRole.Enabled = false;
        }


        public Employee emp { get; set; }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Text.Equals(txtPassword.Text))
            {
                Controller ctrl = new Controller();
                emp.empPassword = txtPassword.Text;
                ctrl.ChangePasswordCtl(emp);
                MessageBox.Show("Change Success");
            }
            else
            {
                MessageBox.Show("PassWord is not matching !!!");
            }
            
        }

        private void frmChangeAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmLogin flogin = new frmLogin();
            flogin.ShowDialog();
            Application.Exit();
        }
    }
}
