using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int options;
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("choose 1.CalculateFare 2.MultipleRides 3.InvoiceSummary");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
                        Console.WriteLine("enter distance of cab journey");
                        double distance = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("enter time for cab journey");
                        double time = Convert.ToDouble(Console.ReadLine());
                        invoiceGenerator.CalculateFare(distance, time);
                        break;
                    case 2:
                        InvoiceGenerator invoiceGeneratorForRides = new InvoiceGenerator();
                        Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
                        invoiceGeneratorForRides.CalMultipleRidesFare(ride);
                        break;
                    case 3:
                        InvoiceGenerator invoiceGeneratorForSummary = new InvoiceGenerator();
                        Ride[] rides = { new Ride(0.1, 0.1), new Ride(0.1, 0.1) };
                        invoiceGeneratorForSummary.GetMultipleRideFare(rides);
                        break;
                    default:
                        Console.WriteLine("Choose valid options");
                        break;
                }
            }
        }
    }
}
