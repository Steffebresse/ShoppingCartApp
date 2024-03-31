using Classes;
using System.Diagnostics;
using System.Xml.Linq;
namespace ShoppingCartApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Try_To_Add_Product()
        {
            // Arrange
            var ShoppingCart = new ShoppingCart();
            var prod = new Product() { Name = "Juice", Price = 20, Quantity = 1 };

            // Act
            var success = ShoppingCart.AddProduct(prod);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]

        public void Add_Existing_Product_And_Add_To_The_Quant()
        {
            // Act
            var ShoppingCart = new ShoppingCart();
           var prod1 = new Product() { Name = "Juice", Price = 20, Quantity = 3 };
           var prod2 =  new Product() { Name = "Juice", Price = 20, Quantity = 3 };
            // Arrange
            ShoppingCart.AddProduct(prod1);
            ShoppingCart.AddProduct(prod2);
            // Assert
            Assert.AreEqual(6, ShoppingCart.Products[0].Quantity);
            Debug.WriteLine(ShoppingCart.Products[0].Quantity);

        }

        [TestMethod]
        public void Look_If_Product_Removes_The_Thng_it_should()
        {
            var ShoppingCart = new ShoppingCart();
            var prod = new Product() { Name = "Juice", Price = 20, Quantity = 1 };
            ShoppingCart.AddProduct(prod);

            var test = ShoppingCart.RemoveProduct(prod);

            Assert.IsTrue(test);
            Assert.AreEqual(0,ShoppingCart.Products.Count);
            
        }

        [TestMethod]
        public void See_If_The_Calculated_Price_Is_right()
        {
            var shoppingcart = new ShoppingCart();
                var rnd = new Random();
            int Price = 0;
                for (int i = 0; i < 10; i++)
                {
                        var name = $"Product{i.ToString()}";
                        var prod = new Product() { Name = name, Price = rnd.Next(99, 3999), Quantity = rnd.Next(1,9) };
                        Price += prod.Price * prod.Quantity;
                        shoppingcart.AddProduct(prod);
                }

            Assert.AreEqual(Price, shoppingcart.CalcTotal());




        }

        [TestMethod]

        public void Check_If_Given_Discount_Calculates_The_Expected_Price()
        {
            // Arrange
            var shoppingcart = new ShoppingCart();
            var rnd = new Random();
            float price = 0;
            // Act 
            for (int i = 0; i < 10; i++)
            {
                var name = $"Product{i.ToString()}";
                var prod = new Product() { Name = name, Price = rnd.Next(99, 3999), Quantity = rnd.Next(1, 9) };
                price += prod.Price * prod.Quantity;
                shoppingcart.AddProduct(prod);
                Debug.WriteLine($"{price - shoppingcart.CalcTotal()} : 0 is good!");
            }
            // Assert
            Assert.ThrowsException<ArgumentException>(() => shoppingcart.ApplyDiscount(2));
            Assert.AreEqual(price * 0.3f, shoppingcart.ApplyDiscount(0.3f));
            Debug.WriteLine($"Price expected: {price * 0.3f}, Price Calculated {shoppingcart.ApplyDiscount(0.3f)}");


        }

        [TestMethod]

        public void Check_If_Quantity_Of_An_Item_Removes_It()
        {
            // Arrange
            var shoppingcart = new ShoppingCart();
            var rnd = new Random();
            float price = 0;
            // Act 
            for (int i = 0; i < 10; i++)
            {
                var name = $"Product{i.ToString()}";
                var prod = new Product() { Name = name, Price = rnd.Next(99, 3999), Quantity = 0 };
               
                shoppingcart.AddProduct(prod);
                
            }
            shoppingcart.ProductVailalabillty();
            // Assert
            foreach (var prod in shoppingcart.Products)
            {
                Assert.AreEqual(0, shoppingcart.Products.Count);
            }
            
        }
    }
}