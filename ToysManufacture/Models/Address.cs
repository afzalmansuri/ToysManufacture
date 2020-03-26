using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToysManufacture.Models
{
   public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AddressId { get; set; }

        public string AddressDetail { get; set; }

        public string AddressType { get; set; }


        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; } 

        public Address(string addresstype,string addressdetail, int customerid)
        {
            this.AddressDetail = addressdetail;
            this.AddressType = addresstype;
            this.CustomerId = customerid;
        }
        public Address()
        {

        }
    }
}
