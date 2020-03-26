
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysManufacture.Context;
using ToysManufacture.Models;

namespace ToysManufacture.Controller
{
    class ToysManufactureController
    {
        int plantid;
        ToyManufactureContext db = new ToyManufactureContext();

        Program program = new Program();
        public void AddPlant()
        {
            Console.Write("Enter Plant Name :   ");
            string plantname = Console.ReadLine();


          
                try
                {
                    Plant plant = new Plant(plantname);
                    db.Add(plant);
                    db.SaveChanges();
                    Console.WriteLine("Plan Successfully Added...!!");
                    program.Menu();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                
          

            
         }


        public void AddToy()
        {
            var plantdet=db.Plants;

            Console.WriteLine("********         Plants Are             ************");
            
            foreach(var singleplant in plantdet)
            {
                Console.WriteLine("Plan Name    :   " + singleplant.PlantName);
            }

            Console.Write("Enter Toy Name   :   ");
            string toyname=Console.ReadLine();
            Console.Write("Price    :   ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.Write("Plant Name   :   ");
            string plantname = Console.ReadLine();

            var plantobj=db.Plants.Where(t => t.PlantName == plantname);
            
            if(plantobj.Count()==0)
            {
                Console.WriteLine("Plant Not Found Try Again");
                program.Menu();
            }
            else
            {
                foreach (var single in plantobj)
                {
                    plantid = single.PlantId;
                }

                Toy toy = new Toy(toyname, price, plantid);
                db.Toys.Add(toy);
                db.SaveChanges();
                Console.WriteLine("Toys SuccessFully Added");
                program.Menu();
            }
            
           

        }
    }
}
