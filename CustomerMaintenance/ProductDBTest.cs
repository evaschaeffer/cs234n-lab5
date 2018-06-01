using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;  // used for testing nUnit

namespace CustomerMaintenance
{
    [TestFixture]
    public class ProductDBTest
    {
        //string productCode;
        //string description;
        //decimal unitPrice;
        //int onHandQuantity;
        Product p1;
        Product p2;

        [SetUp]
        public void SetupAllTests()
        {
            p1 = new Product();
            {
                p1.ProductCode = "TEST";
                p1.Description = "Test Product";
                p1.UnitPrice = 5.00m;
                p1.OnHandQuantity = 2;
            }

            p2 = new Product();
            {
                p2.ProductCode = "TEST";
                p2.Description = "Test Product";
                p2.UnitPrice = 5.00m;
                p2.OnHandQuantity = 3;
            }
        }
        [Test, Order(1)]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("VB10");
            Assert.AreEqual("Murach's Visual Basic 2010", p.Description.Trim());
        }
        [Test,Order(2)]
        public void TestAddProduct()
        {

            ProductDB.AddProduct(p1);
            Assert.AreEqual("TEST", p1.ProductCode);
        }
        [Test,Order(3)]
        public void TestUpdateProduct()
        {
            ProductDB.UpdateProduct(p1, p2);
            Assert.AreEqual(3, p2.OnHandQuantity);
        }
        [Test, Order(4)]
        public void TestDeleteProduct()
        {

            Assert.True(ProductDB.DeleteProduct(p2));

        }
    }
}
