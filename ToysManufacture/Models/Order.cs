using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToysManufacture.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int OrderId { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Toy))]
        public int ToyId { get; set; }
        public DateTime OrderDateTime{ get; set; }

        public Order(int addressid,int customerid,int toyid,DateTime orderdate)
        {
            this.AddressId = addressid;
            this.CustomerId = customerid;
            this.ToyId = toyid;
            this.OrderDateTime = orderdate;

        }
        public Order()
        {

        }
        
    }
}
