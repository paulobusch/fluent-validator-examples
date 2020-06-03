using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class Person
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool HasDiscount { get; private set; }
        public decimal Discount { get; private set; }

        public Person() { }

        public Person(
            string fullName,
            int age,
            string email,
            DateTime birthDate,
            bool hasDiscount,
            decimal discount
        ) : this()
        {
            this.FullName = fullName;
            this.Age = age;
            this.Email = email;
            this.BirthDate = birthDate;
            this.HasDiscount = hasDiscount;
            this.Discount = discount;
        }
    }
}
