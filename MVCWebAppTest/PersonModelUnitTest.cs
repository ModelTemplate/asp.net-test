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
            Assert.Equal(0, person.ID);
            Assert.Equal("John", person.FirstName);
            Assert.Equal("Doe", person.LastName);
            Assert.Equal("example@email.com", person.Email);
            Assert.Equal("999-999-999", person.PhoneNum);
        }

        [Theory]
        [InlineData("Jack", "Sparrow", null, "206-000-000")]
        [InlineData("Jane", "Austen", "janeAusten@gmail.com", null)]
        [InlineData("Tom", "Clancy", "tomC@hotmail.com", "206-111-111")]
        public void AllParamTest(string firstName, string lastName, string email, string phoneNum)
        {
            Person person = new Person(firstName, lastName, email, phoneNum);
            Assert.Equal(0, person.ID);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
            Assert.Equal(email, person.Email);
            Assert.Equal(phoneNum, person.PhoneNum);
        }
    }
}
