using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToysManufacture.Models
{
   public  class Toy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ToyId { get; set; }
        public string ToyName { get; set; }

        public int Price { get; set; }

        [ForeignKey(nameof(Plant))]
        public int PlantId { get; set; }
        
        public Toy(string toyname,int price,int plantid)
        {
            this.ToyName = toyname;
            this.Price = price;
            this.PlantId = plantid;
        }
        public Toy()
        {

        }
    }
}
