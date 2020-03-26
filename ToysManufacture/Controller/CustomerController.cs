using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysManufacture.Context;
using ToysManufacture.Models;

namespace ToysManufacture.Controller
{
    class CustomerController
    {
        string useremail;
        string userpass;
        int userid;
        int addresid;
        int toyid;
        ToyManufactureContext db = new ToyManufactureContext();

        Program program = new Program();
        public void RegisterCustomer()
        {
            Console.WriteLine("**********       Register  Customer      **************");
            Console.Write("Enter Name    :   ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone Number : ");
            string number = Console.ReadLine();
            Console.Write("Enter Email  :   ");
            string email = Console.ReadLine();

            Console.Write("Enter Password  :   ");
            string password = Console.ReadLine();
            Console.Write("Enter Gender   :     ");
            string gender = Console.ReadLine();

            var cusobj = db.Customers.Where(t => t.Email == email);
           
                try
                {
                    Customer customer = new Customer(name,number,email,password,gender);
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    Console.WriteLine("Customer Registerd Successfully");
                    program.Menu();
                }
                catch
                {
                    Console.WriteLine("Something Went Wrong");
                    program.Menu();
                }
          

            
        }

        public void CustomerLogin()

        {

            Console.WriteLine("************     Customer Login      **************");
            Console.Write("Enter Email :    ");
            string loginemail = Console.ReadLine();
            Console.Write("ENter Password   :   ");
            string loginpass = Console.ReadLine();

            var loginobj = db.Customers.Where(t => t.Email == loginemail);
            foreach(var single in loginobj)
            {
                useremail = single.Email;
                userpass = single.Password;
                userid = single.CustomerId;
            }

            if(loginobj.Count()==0)
            {
                Console.WriteLine("User Not Found");
                CustomerLogin();
            }
            else if(useremail==loginemail && userpass==loginpass)
            {
                Console.WriteLine("Welcome" + useremail);

                var toysdataobj = db.Toys;
                Console.WriteLine("Available Toys Are......");
                foreach (var single in toysdataobj)
                {
                    Console.WriteLine("Toys Name :  " + single.ToyName + "  Toy Price   :   " + single.Price);
                }

                Console.WriteLine("*******************************");
                Console.WriteLine("1. View My Order");
                Console.WriteLine("2. View My Address");
                Console.WriteLine("3. Add Order");
                Console.WriteLine("4. Add Address");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Choice :   ");
                int usercoice = Convert.ToInt32(Console.ReadLine());

                switch(usercoice)
                {
                    case 1:
                        var customerorderobj = db.vOrderDetails.Where(t=>t.CustomerId==userid);
                        foreach(var singleorder in customerorderobj)
                        {
                            Console.WriteLine("Order Id :"+ singleorder.OrderId + "Toy Name : "+singleorder.ToyName+"  Toy Price : "+singleorder.Price+" Name : "+singleorder.CustomerName+"  Mobile Number : "+singleorder.PhoneNumber+"Shipping Address Type : "+singleorder.AddressType+"Shiping Address : "+singleorder.AddressDetail+"Order Date-Time : "+singleorder.OrderDateTime);
                        }
                        CustomerLogin();
                        break;

                    case 2:
                        Console.WriteLine("Your Addresse are......");
                        var useraddresses = db.Addresses.Where(t => t.CustomerId == userid);
                        if(useraddresses.Count()>=1)
                        {
                            foreach(var single in useraddresses)
                            {
                                Console.WriteLine("Address Type : "+single.AddressType +" Address : "+ single.AddressDetail);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Address Found");
                            program.Menu();
                        }
                        break;
                    case 3:
                        Console.Write("Enter Toy Name   :   ");
                        string toynm = Console.ReadLine();
                        Console.Write("Enter Address type : ");
                        string addtype = Console.ReadLine();

                        var addgetobj = db.Addresses.Where(t => t.CustomerId == userid && t.AddressType == addtype);

                        foreach(var singleadd in addgetobj)
                        {
                            addresid=singleadd.AddressId;
                        }



                        var toyfindobj = db.Toys.Where(t => t.ToyName == toynm);

                        

                        if(toyfindobj.Count()==0)
                        {
                            Console.WriteLine("Toy Not Found Try Again");
                            CustomerLogin();
                        }
                        else
                        {
                            try
                            {
                                foreach(var singletoy in toyfindobj)
                                {
                                    toyid = singletoy.ToyId;
                                }

                                DateTime now = DateTime.Now;
                                Order order = new Order(addresid,toyid,userid,now);

                                db.Orders.Add(order);
                                db.SaveChanges();
                                Console.WriteLine("Order Added Successfully");

                                program.Menu();
                                    
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                                Console.WriteLine("Something Went Wrong OrderNot Placed...Try Again...");
                                CustomerLogin();
                            }
                        }
                        break;
                    case 4:
                        Console.Write("Enter Address Type : ");
                        string addresstypes = Console.ReadLine();
                        Console.Write("Enter Address : ");
                        string addressdet = Console.ReadLine();

                        try
                        {
                            Address addres = new Address(addresstypes,addressdet,userid);
                            db.Addresses.Add(addres);
                            db.SaveChanges();
                            Console.WriteLine("Address Added Successfully");
                            CustomerLogin();

                        }catch
                        {
                            Console.WriteLine("SOmething WentWrong");

                            program.Menu();
                        }

                        break;

                    case 5:
                        program.Menu();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice Entered");

                        break;

                }

            }
            else
            {
                Console.WriteLine("Invalid Email or Password");
            }
                
            
        }
    }
}
