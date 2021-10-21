using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private static double COST_PER_KILOMETER = 10.0;
        private static double COST_PER_MINUTE = 1.0;
        private static double MINIMUM_FARE = 5.0;
        private double cabFare = 0.0;
        public double CalculateFare(double distance,double time)
        {
            try
            {
                this.cabFare = (distance * COST_PER_KILOMETER) + (time * COST_PER_MINUTE);
                if (this.cabFare < MINIMUM_FARE)
                    throw new CabInvoiceGeneratorCustomException(CabInvoiceGeneratorCustomException.ExceptionType.INVALID_COST, "Cost Could not LessThan Minimum Cost");
                Console.WriteLine("cost of cab journey is:Rs." + Math.Max(this.cabFare, MINIMUM_FARE));
            }
            catch(CabInvoiceGeneratorCustomException e)
            {
                Console.WriteLine(e.Message);
            }
            return Math.Max(this.cabFare, MINIMUM_FARE);
        }
        public double CalMultipleRidesFare(Ride[] rides)
        {
            double totalRideFare = 0.0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalRideFare += CalculateFare(ride.distance, ride.time);
                }
                if (totalRideFare < MINIMUM_FARE)
                    throw new CabInvoiceGeneratorCustomException(CabInvoiceGeneratorCustomException.ExceptionType.INVALID_COST, "Cost Could not LessThan Minimum Cost");
                //total cost of multiple rides
                Console.WriteLine("total cost of multiple rides is:" + totalRideFare);
                //Average cost of multiple rides
                Console.WriteLine("Average cost are:" + totalRideFare / rides.Length);
            }
            catch(CabInvoiceGeneratorCustomException e)
            {
                Console.WriteLine(e.Message);
            }
            return totalRideFare / rides.Length;
        }
        public InvoiceSummary GetMultipleRideFare(Ride[] rides)
        {
            double totalRideFare = 0.0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalRideFare += CalculateFare(ride.distance, ride.time);
                }
                if (totalRideFare < MINIMUM_FARE)
                    throw new CabInvoiceGeneratorCustomException(CabInvoiceGeneratorCustomException.ExceptionType.INVALID_COST, "Cost Could not LessThan Minimum Cost");
                //total cost of multiple rides
                Console.WriteLine("total cost of multiple rides is:" + totalRideFare);
                //Average cost of multiple rides
                Console.WriteLine("Average cost are:" + totalRideFare / rides.Length);
            }
            catch (CabInvoiceGeneratorCustomException e)
            {
                Console.WriteLine(e.Message);
            }
            return new InvoiceSummary(totalRideFare, rides.Length);
        }
    }
}
