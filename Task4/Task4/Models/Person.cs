using System;
using System.Web.Mvc;
using Task4.Infrastructure;

namespace Task4.Models
{
    [ModelBinder(typeof(PersonModelBinder))]
    public class Person
	{
		public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Role Role { get; set; }

        public Address HomeAddress { get; set; }
	}
}