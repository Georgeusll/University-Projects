using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Banking
{
    class Program
    {
        static void Main(string[] args)
        {
            var AccountList = new List<CDAccount>();

          
            Console.WriteLine("---------------------------------------------------------");
            var choice = 'a';
            int i = 0;
            do
            {
                String Username; double interest; //Prompt user to create its own id and give him freedom to choose the interest rate as well
                Console.Write("Welcome To our Bank Registry.\nRegister The account\nPlease Enter your Account Number or Name:");
                Username = Console.ReadLine();
                Console.Write("\n\n Interest rate in %.(10% recommended).\nInterest rate: ");
                interest = Convert.ToDouble(Console.ReadLine());
                AccountList.Add(new CDAccount(Username, interest));
                var CHOICE = 'a';
                Console.WriteLine("Welcome to our services.\n\n Since your account was just created you currently no money on deposit.\n\n Would you like to:\n\n" +
                        "1. Check your Balance.\n2. Make a Deposit.\n3. Withdraw the deposit.\n4. Simulate the compound interest with your current savings?\nq. Log out");
                do
                { //create a do while loop and then another one to create and interactive menu so the user can navigate at its will
                    CHOICE = Console.ReadLine()[0];

                    switch (CHOICE)
                    {

                        case '1':  //self explanatory: 1.Show Balance. 2. Deposit.  3. Withdraw. 4. Calculate compound interest and add to the deposit.  q - quit.
                            Console.WriteLine(AccountList[i].ToString()+"\n\n");
                            break;
                        case '2':
                            Console.WriteLine("Please provide us the amount you would want to Deposit?");
                            Console.Write("Amount: ");
                            var amount = Convert.ToDecimal(Console.ReadLine());

                            AccountList[i].Deposit(amount);
                            Console.WriteLine(amount + "$ has been successfully deposited to your account.");
                            Console.WriteLine("\n");

                            break;
                        case '3':
                            Console.Write("Withdraw\nHow much would you like to withdraw?\nAmount:");
                            AccountList[i].Withdraw(Convert.ToDecimal(Console.ReadLine()));
                            Console.WriteLine("The amount was successfully withdrawed");
                            break;
                        case '4':
                            Console.Write("Welcome to the Compound Interest Simulator.\n your interest rate is " + interest +"\nand " );
                            Console.WriteLine(AccountList[i].ToString() + "\n\n\n");
                            Console.Write("Please enter years after which you expect to check on account again?\nYears to pass: ");
                            int years = Convert.ToInt32(Console.ReadLine());
                            for (int j = 0; j < years; j++)
                            {
                                AccountList[i].AddInterests();
                            }
                            Console.WriteLine(years + " years have passed and");
                            Console.WriteLine(AccountList[i].ToString());

                            break;

                        case 'q':
                            Console.WriteLine("Logging out...\n\n");

                            break;
                        default:
                            Console.WriteLine("Wrong input bruh");
                            break;
                    }

                  

                   
                } while (CHOICE != 'q'); //then this loop ends the user is asked if he wants to create another account or leave



                        
                          
                


                Console.WriteLine("Would you like to shut the system down and Quit?\n(Press q to quit) (Press any other key to sign up as a new user)");
                i++;

                choice = Console.ReadLine()[0];
            } while (choice != 'q'); //every time this loop starts again it creates another object, in our case the account

           

            var order = from account in AccountList                            //select and order objects
                        orderby account.Balance descending
                        select account;

            Console.WriteLine("Accounts ordered by Balance:\n\n");
            foreach (var a in order)
                Console.WriteLine(a.ToString());
        }
        
    }
    
    
}
