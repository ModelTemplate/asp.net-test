using System;
using Xunit;
using MVCWebApp.Models;
using NuGet.Frameworks;

namespace MVCWebAppTest
{
    public class LoanEventModelUnitTest
    {
        [Fact]
        public void NoParamTest()
        {
            LoanEvent loan = new LoanEvent();
            Assert.Equal(-1, loan.ID);
            Assert.Equal(-1, loan.LoanerID);
            Assert.Equal("John Doe", loan.BorrowerName);
            Assert.Equal(new DateTime(), loan.LoanDate);
            Assert.Equal(new DateTime(), loan.DueDate);
            Assert.Null(loan.ReturnDate);
        }

        [Theory]
        [InlineData(0, 1, "Joe Smith", "2020-8-20", "2020-8-25", "2020-8-25")]
        [InlineData(1, 2, "Mary Jane", "2021-12-5", "2022-1-1", "2020-1-3")]
        public void AllParamTest(int id, int loanerId, string borrowerName, string loanDate,
            string dueDate, string returnDate)
        {
            LoanEvent loan = new LoanEvent(id, loanerId, borrowerName, DateTime.Parse(loanDate),
                    DateTime.Parse(dueDate), DateTime.Parse(returnDate));
            Assert.Equal(id, loan.ID);
            Assert.Equal(loanerId, loan.LoanerID);
            Assert.Equal(borrowerName, loan.BorrowerName);
            Assert.Equal(DateTime.Parse(loanDate).ToBinary(), loan.LoanDate.ToBinary());
            Assert.Equal(DateTime.Parse(dueDate).ToBinary(), loan.DueDate.ToBinary());
            Assert.Equal(DateTime.Parse(returnDate).ToString(), loan.ReturnDate.ToString());
        }
    }
}
