using CabInvoiceGenerator;
using NUnit.Framework;

namespace NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        //Test-1.1 ->Given cost should matches the cab invoice cost
        [Test]
        public void Given_cost_ShouldMatches_ToActualCost()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double actual=invoiceGenerator.CalculateFare(3, 5);
            Assert.AreEqual(35, actual);
        }
        //Test-1.2 ->When Actual Cost Less than MinimumCost Throw Exception
        [Test]
        public void When_ActualCost_LessThanMinimumCost_ThrowException()
        {
            try
            {
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
                double actual = invoiceGenerator.CalculateFare(0.4, 0.2);
                Assert.AreEqual(5.0, actual);
            }
            catch(CabInvoiceGeneratorCustomException e)
            {
                Assert.AreEqual("Cost Could not LessThan Minimum Cost", e.Message);
            }
        }
        //Test-2.1 ->Given Distance And Time For Multiple Rides When Not Proper Should Return Aggregate Fare
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnAggregateFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            double actual = invoiceGenerator.CalMultipleRidesFare(rides);
            Assert.AreEqual(30, actual);
        }
        //Test-2.2 ->Given Distance And Time For Multiple Rides When Not Proper Should THrow Exception
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenNotProper_ThrowException()
        {
            try
            {
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
                Ride[] rides = { new Ride(0.1, 0.1), new Ride(0.1, 0.1) };
                double actual = invoiceGenerator.CalMultipleRidesFare(rides);
                Assert.AreEqual(30, actual);
            }
            catch (CabInvoiceGeneratorCustomException e)
            {
                Assert.AreEqual("Cost Could not LessThan Minimum Cost", e.Message);
            }
        }
        //Test-3.1 ->Given Distance And Time For MultipleRides When Not Proper Should Return InvoiceSummary
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
                Ride[] rides = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
                InvoiceSummary actualInvoiceSummary = invoiceGenerator.GetMultipleRideFare(rides);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(60.0, 2);
                Assert.AreEqual(expectedInvoiceSummary, actualInvoiceSummary);
        }
        //Test-3.2 ->Given Distance And Time For MultipleRides When Not Proper Throw Exception
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenNotProper_ShouldReturnInvoiceSummary()
        {
            try
            {
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
                Ride[] rides = { new Ride(0.1, 0.1), new Ride(0.1, 0.1) };
                InvoiceSummary actualInvoiceSummary = invoiceGenerator.GetMultipleRideFare(rides);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(10.0, 2);
                //Assert.AreEqual(expectedInvoiceSummary, actualInvoiceSummary);
            }
            catch (CabInvoiceGeneratorCustomException e)
            {
                Assert.AreEqual("Cost Could not LessThan Minimum Cost", e.Message);
            }
        }
    }
}