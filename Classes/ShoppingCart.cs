using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ShoppingCart
    {
        public List<Product> Products { get; set; } = [];
        

        public bool AddProduct(Product prod)
        {
            var quantityToAdd = Products.FirstOrDefault(e => e.Name == prod.Name);

            if (prod is not null && quantityToAdd == null)
            {
                Products.Add(prod);
                ProductVailalabillty();
                return true;
            }
            else if (prod is not null && quantityToAdd != null)
            {
                Products.Find(e => e.Name == prod.Name).Quantity += prod.Quantity;
                return true;
            }
            else
            {
                throw new ArgumentException("Prod doesnt exist");
            }
        }

        public bool RemoveProduct(Product prod)
        {
            if (prod is not null)
            {
                var ngt = Products.FirstOrDefault(e => e.Name == prod.Name);
                Products.Remove(ngt);
                ProductVailalabillty();
                return true;
            }
            else
            {
                throw new ArgumentException("No product Selected");
            }
            
        }

        public int CalcTotal() 
        {
            var totalprice = 0;
            if (Products.Count != 0)
            {
                foreach (Product prod in Products)
                {

                    totalprice += prod.Price * prod.Quantity; 
                }
                ProductVailalabillty();
                return totalprice;
            }
            else
            {
                throw new ArgumentException("No products");
            }
        }

        public float ApplyDiscount(float disc)
        {
            if (Products is not null && disc <= 1)
            {
                var total = CalcTotal();
                var discountedprice = total * disc;
                ProductVailalabillty();
                return discountedprice;
            }
            else
            {
                throw new ArgumentException("Given discount must be under '1'");
            }

            
        }

        public void ProductVailalabillty()
        {
            
            for (int i = Products.Count - 1; i >= 0; i--)
            {
                var item = Products[i];
                if (item.Quantity == 0)
                {
                    Products.RemoveAt(i);
                }
            }
        }



    }
}
