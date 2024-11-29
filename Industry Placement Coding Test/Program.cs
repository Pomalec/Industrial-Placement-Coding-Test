using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Industry_Placement_Coding_Test
{
    internal class Program
    {

        static void Main(string[] args)
        {

            while (true) //constant loop until the user types exit
            {
                Console.WriteLine("Welcome to Coffee Snobs!\n"
                    + "We offer the following coffees:\n" +
                    "regular ($2.11)\n" +
                    "decaf ($1.51)\n" +
                    "With the following extras:\n" +
                    "milk ($0.53)\n" +
                    "sugar ($0.17)\n" +
                    "cream ($0.73)\n" +
                    "sprinkles ($0.29)\n" +
                    "As well as the following cakes\n" +
                    "muffins ($2.03)\n" +
                    "flapjacks ($2.59)\n" +
                    "pannetone ($2.88)\n" +

                    "Please type your order or type 'exit' to quit");
                string order = Console.ReadLine()?.Trim();
                if (string.Equals(order, "exit", StringComparison.OrdinalIgnoreCase))//case when the user types exit the while loop will stop using the break
                {
                    Console.WriteLine("Exiting the program. Thanks for ordering at Coffee Snobs. Have a good day");
                    Console.ReadKey();
                    break;
                }
                if (string.IsNullOrEmpty(order))//case when the user does not type anything giving an error and restarting the loop using continue
                {
                    Console.WriteLine("Error: The order is empty please provide a valid order.");
                    continue;
                }
                float totalCost = 0.0f;
                string[] items = order.Split(',');//each part of the order is separated by ' , '
                foreach (string item in items)
                {
                    string[] parts = item.Trim().Split('+');//each extra of the order is separated by ' , '
                    if (string.IsNullOrEmpty(parts[0]))
                    {
                        Console.WriteLine("Error: Skipping empty or incorrect order");
                        continue;
                    }
                    string mainOrder = parts[0].Trim();

                    // Process main order (e.g., "1 x regular")
                    string[] orderDetails = mainOrder.Split('x');// each part of the order is separated by the quantity 'x' and then the order
                    if (orderDetails.Length < 2)// case when the user does not input the quantity or the order or neither of them
                    {
                        Console.WriteLine($"Warning: Skipping malformed order '{mainOrder}'.");
                        continue;
                    }
                    int quantity;
                    if (!int.TryParse(orderDetails[0].Trim(), out quantity))// case when the user does not input the quantity correctly which will default to 1
                    {
                        Console.WriteLine("Error: Invalid quantity defaulting to 1");
                        quantity = 1;
                    }
                    string type = orderDetails[1].Trim().ToLower();

                    Beverage beverage = null;
                    if (type == "regular")
                        beverage = new RegularCoffee();
                    else if (type == "decaf")
                        beverage = new DecafCoffee();

                    if (beverage != null)//case when the item is a coffee
                    {
                        float coffeeCost = beverage.getCost() * quantity;//cost of the coffee multiplied by the quantity given
                        totalCost += coffeeCost;//cost of the coffee is added

                        // Processing extras
                        HashSet<string> extrasprocessed = new HashSet<string>();
                        Extra extraorder;
                        for (int i = 1; i < parts.Length; i++)
                        {
                            string extra = parts[i].Trim();
                            if (string.IsNullOrEmpty(extra))
                            {
                                Console.WriteLine("Error: Empty extra skipping");
                                continue;
                            }
                            if (!extrasprocessed.Add(extra.ToLower()))
                            {
                                Console.WriteLine($"Error: duplicated extra '{extra}' skipping");//error when the extra is duplicated
                                continue;
                            }

                            extraorder = new Extra(extra);
                            if (extraorder.getCost() > 0)//case when the extra is part of the menu since it has a price
                            {
                                totalCost += extraorder.getCost() * quantity;//cost of the extra is added
                            }
                            else
                            {
                                Console.WriteLine($"Error: unrecognized extra '{extra}' skipping");//error when the extra is not on the menu
                            }

                        }
                    }
                    else
                    {
                        // Process cakes
                        Cakes cake = new Cakes(type);
                        if (cake.getCost() > 0)//case when the cake is part of the menu since it has a price
                        {
                            totalCost += cake.getCost() * quantity;//cost of the cake is added
                        }
                        else
                        {
                            Console.WriteLine($"Error: unrecognized cake '{cake}' skipping");//error when the cake is not on the menu
                        }
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine($"Final bill is ${totalCost:F2}");// total cost of the bill is displayed
                Console.WriteLine("\n");

            }

        }
    }
}
