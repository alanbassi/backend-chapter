﻿namespace WebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Document { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string getFullName()
        {
            return Name + " " + LastName; 
        }
    }
}