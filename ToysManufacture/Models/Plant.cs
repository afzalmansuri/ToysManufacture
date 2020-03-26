using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToysManufacture.Models
{
    public class Plant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        
        public Plant(string plantname)
        {
            this.PlantName = plantname;
        }
        public Plant()
        {

        }
    }
}
