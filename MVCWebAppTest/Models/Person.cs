using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppTest.Models
{
    /// <summary>
    /// Representing a person that uses loaning service to track loaned items.
    /// </summary>
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }

        public Person(int id = 0, string firstName = "Mary", string lastName = "Sue", 
                string email = "example@email.com", string phoneNum = "999-999-999")
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNum = phoneNum;
        }
        public ICollection<Person> Persons { get; set; }
    }
}
