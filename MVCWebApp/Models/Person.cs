using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models
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

        public Person(int id, string firstName, string lastName, string email, string phoneNum)
        {
            if (id < 0)
            {
                throw new ArgumentException("Person Id cannot be a negative value.");
            }
            else if (firstName == "" || lastName == "")
            {
                throw new ArgumentException("Must input person first and last names.");
            } 
            else if (email == null || phoneNum == null)
            {
                throw new ArgumentException("Must input at least one form of contact information.");
            }
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNum = phoneNum;
        }

        public Person()
        {
            ID = -1;
            FirstName = "John";
            LastName = "Doe";
            Email = "example@email.com";
            PhoneNum = "999-999-999";
        }

        public ICollection<Person> Persons { get; set; }
    }
}
