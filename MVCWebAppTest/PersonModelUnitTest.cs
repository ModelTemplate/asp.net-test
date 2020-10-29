using System;
using Xunit;
using MVCWebApp.Models;

namespace MVCWebAppTest
{
    public class PersonModelUnitTest
    {
        [Fact]
        public void NoParamTest()
        {
            Person person = new Person();
            Assert.Equal(-1, person.ID);
            Assert.Equal("John", person.FirstName);
            Assert.Equal("Doe", person.LastName);
            Assert.Equal("example@email.com", person.Email);
            Assert.Equal("999-999-999", person.PhoneNum);
        }

        [Theory]
        [InlineData(0, "Jack", "Sparrow", null, "206-000-000")]
        [InlineData(1, "Jane", "Austen", "janeAusten@gmail.com", null)]
        [InlineData(2, "Tom", "Clancy", "tomC@hotmail.com", "206-111-111")]
        public void ParamTest(int id, string firstName, string lastName, string email, string phoneNum)
        {
            Person person = new Person(id, firstName, lastName, email, phoneNum);
            Assert.Equal(id, person.ID);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
            Assert.Equal(email, person.Email);
            Assert.Equal(phoneNum, person.PhoneNum);
        }
    }
}
