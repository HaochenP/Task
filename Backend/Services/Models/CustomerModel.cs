﻿using Backend.Data.Entities;

namespace Backend.Services.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public CustomerModel() { }

        public CustomerModel(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Phone = customer.Phone;
        }
    }
}
