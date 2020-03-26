using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToysManufacture.Models
{
    public class vOrderDetail
    {
       
        [Key]
        public int OrderId { get; set; }
        public string ToyName { get; set; }
        public int Price { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressType { get; set; }
        public string AddressDetail { get; set; }
        public DateTime OrderDateTime { get; set; }

        public int CustomerId { get; set; }

    }
}
