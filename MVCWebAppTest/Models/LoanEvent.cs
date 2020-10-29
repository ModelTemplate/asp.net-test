using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppTest.Models
{
    /// <summary>
    /// Representing a loan to someone.
    /// </summary>
    public class LoanEvent
    {
        public int ID { get; set; }
        public int LoanerID { get; set; }
        public string BorrowerName{ get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public LoanEvent(int id = -1, int loanerId = 0, string borrowerName = "John Doe", 
                DateTime loanDate = new DateTime(), DateTime dueDate = new DateTime(), 
                DateTime returnDate = new DateTime())
        {
            ID = id;
            LoanerID = loanerId;
            BorrowerName = borrowerName;
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
        }

        public LoanEvent()
        {
            ID = -1;
            LoanerID = 0;
            BorrowerName = "John Doe";
            LoanDate = DateTime.Now;
            DueDate = DateTime.Now;
            ReturnDate = DateTime.Now;
        }

        public ICollection<LoanEvent> Loans { get; set; }
    }
}
