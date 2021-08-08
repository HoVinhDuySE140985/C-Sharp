using Controllers;
using DTO;
using Model;
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
    public partial class frmBookReport : Form
    {
        public frmBookReport()
        {
            InitializeComponent();
            
        }
        public List<Book> searchbook { get; set; }

        public void LoadDataBooksearch()
        {
            List<Book> datasearch = searchbook;
            for (int i = 0; i < datasearch.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgvBooksSort.Rows[0].Clone();
                row.Cells[0].Value = datasearch.ElementAt(i).bookID;
                row.Cells[1].Value = datasearch.ElementAt(i).bookName;
                row.Cells[2].Value = datasearch.ElementAt(i).price;
                dgvBooksSort.Rows.Add(row);
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            Controller ctrl = new Controller();
            ctrl.SortBookDesendingCtl(searchbook);
            dgvBooksSort.Rows.Clear();
            LoadDataBooksearch();
        }

        private void frmBookReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmMaintainBooks mainBook = new frmMaintainBooks();
            mainBook.ShowDialog();
            Application.Exit();
        }
    }
}
