using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace Model
{
    public class BooksModel
    {
        string ConnectionString = @"server=DESKTOP-NBNVM4Q;database=BookStore;uid=sa;pwd=1";

        public List<Book> GetListBook()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            List<Book> list = new List<Book>();
            string sql = "select BookID, BookName, BookPrice from Books";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    float price = (float)(double)reader["BookPrice"];
                    Book b = new Book(id, name, price);
                    list.Add(b);
                }
            }
            return list;

        }
        public void AddNewBook(Book b)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "insert Books values( @name, @price )";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", b.bookName);
            command.Parameters.AddWithValue("@price", b.price);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Add Successful");
        }

        public void UpdateBook(Book b)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "update Books set BookName = @name, BookPrice = @price where BookID = @id ";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", b.bookName);
            command.Parameters.AddWithValue("@price", b.price);
            command.Parameters.AddWithValue("@id", b.bookID);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Update Successful");
        }

        public void DeleteBook(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "delete Books where BookID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Delete Successful");
        }

        public List<Book> SearchBook(string name)
        {
            List<Book> listsearch = new List<Book>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "select BookID,BookName, BookPrice from Books where BookName like '%'+@name+'%' ";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string bname = reader.GetString(1);
                    float price = (float)(double)reader["BookPrice"];
                    Book b = new Book(id, bname, price);
                    listsearch.Add(b);
                }
            }
            return listsearch;
        }

        public void SortBookDescending(List<Book> listsearch)
        {

            Book tmp;
            for (int i = 0; i < listsearch.Count; i++)
            {
                for (int j = i + 1; j < listsearch.Count; j++)
                {
                    if (listsearch[i].price < listsearch[j].price)
                    {
                        tmp = listsearch[i];
                        listsearch[i] = listsearch[j];
                        listsearch[j] = tmp;
                    }
                }
            }
        }
    }

    public class EmployeesModel
    {
        string ConnectionString = @"server=DESKTOP-NBNVM4Q;database=BookStore;uid=sa;pwd=1";
        public Employee CheckLogin(string userName, string password)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "Select EmpID, EmpPassword, EmpRole from Employee where EmpID = @id and EmpPassword = @password";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", userName);
            command.Parameters.AddWithValue("@password", password);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string username = reader.GetString(0);
                    string pword = reader.GetString(1);
                    Boolean role = (Boolean)reader["EmpRole"];
                    Employee emp = new Employee(username, password, role);
                    return emp;
                }
            }
            return null;
        }

        public void ChangePassWord(Employee emp)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "Update Employee set EmpPassword = @password where EmpID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@password", emp.empPassword);
            command.Parameters.AddWithValue("@id", emp.empID);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Change Successful");
        }


        public void checkout(Dictionary<string, Int32> card)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "select Price from Book where BookID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            float sumPrice = 0;
            foreach (var item in card)
            {
                command.Parameters.AddWithValue("@id", item.Key);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        float price = (float)(double)reader["Price"];
                        sumPrice += price;
                    }
                }
                connection.Close();
            }
           
            DateTime checkoutTime = DateTime.Now;
            string sqlinsertorder = "INSERT INTO [dbo].[Order]([OrderID],[TotalPrice])VALUES(@id, @tPrice)";
            command = new SqlCommand(sqlinsertorder, connection);
            command.Parameters.AddWithValue("@id", checkoutTime);
            command.Parameters.AddWithValue("@tPrice", sumPrice);
            connection.Open();
            SqlTransaction transaction;
            transaction = connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.ExecuteNonQuery();
                foreach (var item in card)
                {
                    command.CommandText = "insert into OrderDetail (BookID, Price, Quantity, orderID) " +
                                          "values(@bID, @price, @Quan, @oID)";
                    command.Parameters.AddWithValue("@bID", item.Key);
                    command.Parameters.AddWithValue("@price", 10);
                    command.Parameters.AddWithValue("@Quan", item.Value);
                    command.Parameters.AddWithValue("@oID", checkoutTime);
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                    
                }
                MessageBox.Show(errorMessages.ToString());
                transaction.Rollback();
            }
            connection.Close();
        }
    }
}
