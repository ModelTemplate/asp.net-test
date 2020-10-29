using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models
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
        public DateTime? ReturnDate { get; set; }

        public LoanEvent(int id, int loanerId, string borrowerName, DateTime loanDate, 
            DateTime dueDate, DateTime returnDate)
        {
            if (dueDate.CompareTo(loanDate) <= 0)
            {
                throw new ArgumentException("Due date cannot be less than or equal to loan date.");
            }
            else if (returnDate.CompareTo(loanDate) <= 0)
            {
                throw new ArgumentException("Return date cannot be less than or equal to loan date.");
            }
            else if (loanDate.AddDays(3).CompareTo(dueDate) > 0)
            {
                throw new ArgumentException("Loan must be for at least three days.");
            }
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
            LoanerID = -1;
            BorrowerName = "John Doe";
            LoanDate = new DateTime();
            DueDate = new DateTime();
            ReturnDate = null;
        }

        public ICollection<LoanEvent> Loans { get; set; }
    }
}
