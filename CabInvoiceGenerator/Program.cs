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
                Console.WriteLine("choose 1.CalculateFare");
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
                    default:
                        Console.WriteLine("Choose valid options");
                        break;
                }
            }
        }
    }
}
