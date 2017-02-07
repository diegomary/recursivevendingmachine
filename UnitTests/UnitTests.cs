using Core;
using NUnit.Framework;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class Test
    {
        public VendingMachine cs;
        public FoodStore fd;

        [OneTimeSetUp]
        public void Init()
        {
            cs = new VendingMachine(10, 3, 2, 3, 2, 2);
            fd = new FoodStore();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            cs = null;
            fd = null;
        }       
       

        [Test]
        public void CalculateTotalMoneyInTheVendorMAchine()
        {          
            Assert.AreEqual(4.05F, cs.GrandTotal);     

        }

        [Test]
        public void A()
        {              
            cs.Purchase(1, "Drink", new string[] { "OnePound" });
            Assert.AreEqual(cs.OnePounds, 3);           
            Assert.AreEqual(FoodStore.foodStorage.FirstOrDefault(m => m.Name.Equals("Drink")).Quantity, 4);
           // Assert.AreEqual(1, 7);
        }

        [Test]
        public void B()
        {
            cs.Purchase(1, "Chocolate", new string[] { "OnePound" });
            Assert.AreEqual(cs.OnePounds, 4);
            Assert.AreEqual(FoodStore.foodStorage.FirstOrDefault(m => m.Name.Equals("Chocolate")).Quantity, 0);
            // Assert.AreEqual(1, 7);
        }

        [Test]
        public void C()
        {
            cs.Purchase(1, "Chocolate", new string[] { "OnePound" });
            // the money has not been accepted because the quantity was 0 bso the vending machine gave back the money
            Assert.AreEqual(cs.OnePounds, 4);
           
        }






        //[Test]
        //public void E()
        //{                         
        //    cs.Purchase(1, "Banana", new string[] { "FiftyPens", "TwentyPens", "TenPens"});            
        //    Assert.AreEqual(cs.FiftyPens, 3);
        //    Assert.AreEqual(FoodStore.foodStorage.FirstOrDefault(m => m.Name.Equals("Banana")).Quantity, 2);

        //}









    }
}
