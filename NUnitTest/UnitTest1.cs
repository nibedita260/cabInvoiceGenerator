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
        //Test-2.1 ->Given Avg cost should matches the multiple cab rides cost
        [Test]
        public void Given_Avgcost_ShouldMatches_ToActualAvgCost()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            double actual = invoiceGenerator.CalMultipleRidesFare(rides);
            Assert.AreEqual(30, actual);
        }
        //Test-1.2 ->When ActualAvg Cost Less than MinimumCost Throw Exception
        [Test]
        public void When_ActualAvgCost_LessThanMinimumCost_ThrowException()
        {
            try
            {
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
                Ride[] rides = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
                double actual = invoiceGenerator.CalMultipleRidesFare(rides);
                Assert.AreEqual(30, actual);
            }
            catch (CabInvoiceGeneratorCustomException e)
            {
                Assert.AreEqual("Cost Could not LessThan Minimum Cost", e.Message);
            }
        }
    }
}