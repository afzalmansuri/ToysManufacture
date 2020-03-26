using System;
using ToysManufacture.Controller;

namespace ToysManufacture
{
    class Program
    {
        public void Menu()
        {
            ToysManufactureController toysManufactureController = new ToysManufactureController();
            CustomerController customerController = new CustomerController();


            Console.WriteLine("******      Welcome Toy Manufactures Limited     ************* ");
            Console.WriteLine("1. Manufacturer Site");
            Console.WriteLine("2. Customer Site");


            Console.Write("Enter Your Choice    :   ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("***********      Welcome To Manufacturer Site        *************");
                    Console.Write(" Enter Pin To Perform Something  :   ");
                    int pin=Convert.ToInt32(Console.ReadLine());
                    if(pin==123)
                    {
                        Console.WriteLine("1. Add Plant");
                        Console.WriteLine("2. Add Toys");
                        Console.Write("Enter Your Choice : ");
                        int plantchoice = Convert.ToInt32(Console.ReadLine());
                        switch(plantchoice)
                        {
                            case 1:
                                toysManufactureController.AddPlant();
                                break;

                            case 2:
                                toysManufactureController.AddToy();
                                break;
                            default:
                                Console.WriteLine("Invalid Choice Enter...!");
                                break;
                        }
                       

                    }
                    else
                    {
                        Console.WriteLine("Invalid Pin.....!");
                        Menu();
                    }
                    break;

                case 2:
                    Console.WriteLine("Welcome To Toys Manufacture Customer Site");
                    Console.WriteLine("1. Dont'Have Account Register ?");
                    Console.WriteLine("2. Already Have Account Login ? ");
                    Console.Write("Enter Your Choice    :   ");
                    int customerchoice = Convert.ToInt32(Console.ReadLine());
                    switch(customerchoice)
                    {
                        case 1:
                            customerController.RegisterCustomer();
                            break;
                        case 2:
                            customerController.CustomerLogin();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice Enter ...!");
                            Menu();
                            break;
                    }
                    customerController.RegisterCustomer();

                    break;
                default:
                    Console.WriteLine("Invalid CHoice Enter....");
                    break;
            }

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Menu();
        }
    }
}
