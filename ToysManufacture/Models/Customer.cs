using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToysManufacture.Models
{
   public  class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }

        public Customer(string name,string number,string email,string password,string gender)
        {
            this.CustomerName = name;
            this.PhoneNumber = number;
            this.Email = email;
            this.Password = password;
            this.Gender = gender;
        }

        public Customer()
        {

        }
    }
}
