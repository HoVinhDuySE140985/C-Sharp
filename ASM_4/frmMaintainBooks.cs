using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Controllers;
using DTO;
using Model;

namespace ASM_4
{
    public partial class frmMaintainBooks : Form
    {
        private Controller ctrl = new Controller();
        
        public frmMaintainBooks()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            //LoadDataBook();
        }
        public void LoadDataBook()
        {
            List<Book> data = new BooksModel().GetListBook();
            dgvBooks.Rows.Clear();
            for (int i = 0; i < new BooksModel().GetListBook().Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgvBooks.Rows[0].Clone();
                row.Cells[0].Value = data.ElementAt(i).bookID;
                row.Cells[1].Value = data.ElementAt(i).bookName;
                row.Cells[2].Value = data.ElementAt(i).price;
                dgvBooks.Rows.Add(row);
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            Book b = new Book();
            b.bookName = txtName.Text;
            b.price = float.Parse(txtPrice.Text);
            ctrl.AddCtl(b);
            LoadDataBook();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.bookID = int.Parse(txtID.Text);
            b.bookName = txtName.Text;
            b.price = float.Parse(txtPrice.Text);
            ctrl.UpdateCtl(b);
            LoadDataBook();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int bookID = int.Parse(txtID.Text);
            ctrl.DeleteCtl(bookID);
            LoadDataBook();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            string name = txtName.Text;
            frmBookReport search = new frmBookReport();
            search.searchbook = ctrl.SearchCtl(name);
            search.LoadDataBooksearch();
            search.ShowDialog();
            Application.Exit();
        }


        private void dgvBooks_Click(object sender, EventArgs e)
    {
        DataGridViewSelectedRowCollection datarow = dgvBooks.SelectedRows;
        txtID.Text = datarow[0].Cells[0].Value.ToString();
        txtName.Text = datarow[0].Cells[1].Value.ToString();
        txtPrice.Text = datarow[0].Cells[2].Value.ToString();
    }

        private void dgvBooks_CurrentCellChanged(object sender, EventArgs e)
        {
            if(this.dgvBooks.CurrentRow != null)
            {
                txtID.Text = dgvBooks.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgvBooks.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = dgvBooks.CurrentRow.Cells[2].Value.ToString();
                btnPrevious.Enabled = dgvBooks.CurrentRow.Index > 0;
                btnNext.Enabled = dgvBooks.CurrentRow.Index < dgvBooks.Rows.Count-2;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            int i = 0;
            dgvBooks.CurrentCell = dgvBooks.Rows[i].Cells[dgvBooks.CurrentCell.ColumnIndex];
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int next = dgvBooks.CurrentRow.Index + 1;
            if(next < dgvBooks.Rows.Count)
            {
                dgvBooks.CurrentCell = dgvBooks.Rows[next].Cells[dgvBooks.CurrentCell.ColumnIndex];
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int prev = dgvBooks.CurrentRow.Index - 1;
            dgvBooks.CurrentCell = dgvBooks.Rows[prev].Cells[dgvBooks.CurrentCell.ColumnIndex];
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int i = dgvBooks.Rows.Count-2;
            dgvBooks.CurrentCell = dgvBooks.Rows[i].Cells[dgvBooks.CurrentCell.ColumnIndex];
        }

        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            Dictionary<string, Int32> card = new Dictionary<string, int>();
            card.Add("1", 2);
            EmployeesModel m = new EmployeesModel();
            m.checkout(card);
        }

        private void frmMaintainBooks_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 232, 232);
        }
    }
}
