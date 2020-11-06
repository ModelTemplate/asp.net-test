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
        public int ID { get; set; }     // auto-incremented by SQL database
        public int LoanerID { get; set; }
        public string BorrowerName{ get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ICollection<LoanEvent> Loans { get; set; }

        public LoanEvent(int loanerId, string borrowerName, DateTime loanDate, 
            DateTime dueDate, DateTime returnDate)
        {
            if (loanerId < 0)
            {
                throw new ArgumentException("Loaner Id cannot be a negative value.");
            } 
            else if (borrowerName == "")
            {
                throw new ArgumentException("Must put in borrower name.");
            }
            else if (dueDate.CompareTo(loanDate) <= 0)
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
            LoanerID = loanerId;
            BorrowerName = borrowerName;
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
        }

        public LoanEvent()
        {
            LoanerID = -1;
            BorrowerName = "John Doe";
            LoanDate = new DateTime();
            DueDate = new DateTime();
            ReturnDate = null;
        }
    }
}
