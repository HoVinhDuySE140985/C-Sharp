using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ASM_4;
using System.Windows.Forms;

namespace Controllers

{
    public class Controller
    {
        BooksModel bModel = new BooksModel();
        EmployeesModel empModel = new EmployeesModel();
        public void LoginCtl(string userName, string password)
        {
            Employee employee = empModel.CheckLogin(userName, password);
            if (employee != null)
            {
                if (employee.empRole == true)
                {
                    MessageBox.Show("Login With Role Admin Successfull !");
                    frmMaintainBooks admin = new frmMaintainBooks();
                    admin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Login With Role Guest Successfull !");
                    frmChangeAccount guest = new frmChangeAccount(employee);
                    guest.ShowDialog();
                }
            }
        }

        public void ChangePasswordCtl(Employee emp)
        {
            empModel.ChangePassWord(emp);
        }
        public void AddCtl(Book b)
        {
            bModel.AddNewBook(b);
        }

        public void UpdateCtl(Book b)
        {
            bModel.UpdateBook(b);
        }

        public void DeleteCtl(int id)
        {
            bModel.DeleteBook(id);
        }

        public List<Book> SearchCtl(string name)
        {
            return bModel.SearchBook(name);

        }

        public void SortBookDesendingCtl(List<Book> listsearch)
        {
            bModel.SortBookDescending(listsearch);
        }
    }
}
