using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee
    {
        private string EmpID  ;
        private string EmpPassword ; 
        private Boolean EmpRole;

        public Employee()
        {
        }

        public Employee(string empID, string empPassword, bool empRole)
        {
            EmpID = empID;
            EmpPassword = empPassword;
            EmpRole = empRole;
        }

        public string empID { get => EmpID; set => EmpID = value; }
        public string empPassword { get => EmpPassword; set => EmpPassword = value; }
        public bool empRole { get => EmpRole; set => EmpRole = value; }
    }

    public class Book
    {
        private int BookID;
        private string BookName;
        private float Price;

        public Book()
        {
        }

        public Book(int bookID, string bookName, float price)
        {
            BookID = bookID;
            BookName = bookName;
            Price = price;
        }

        public int bookID { get => BookID; set => BookID = value; }
        public string bookName { get => BookName; set => BookName = value; }
        public float price { get => Price; set => Price = value; }
    }

    public class CardDto
    {
        Dictionary<string, System.Int32> card;
        public void AddCart(string id ,int value)
        {
            if (card == null)
            {
                card = new Dictionary<string, int>();
            }
            card.Add(id, value);
        }
    }
}
