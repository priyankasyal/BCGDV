using System;
using System.Runtime.InteropServices;
using BCGDV.Product;
namespace BCGDV.Models
    {

    /**
    * Class for implementing the shopping cart with functionalities to create cart
    * add items and get quantity for an item by its product ID. Can be extended for other
    * functionalities like removing item etc.
    */      
    public class Cart
        {
        private Dictionary<IProduct, int> itemCount;

            public Cart()
            {
                this.itemCount = new Dictionary<IProduct, int>();
            }

            public Cart(IProduct product, int quantity)
            {
                this.itemCount = new Dictionary<IProduct, int>();
                itemCount.Add(product, quantity);
            }

            public void addItem(IProduct product)
            {
                int count = itemCount.GetValueOrDefault(product, 0);
                itemCount[product] = count+1;
            }

            public void addItemWithQuantity(IProduct product, int quantity)
            {
                int count = itemCount.GetValueOrDefault(product, 0);
                itemCount[product] = count + quantity;
            }

            public List<IProduct> getItems()
            {
                return itemCount.Keys.ToList();  
            }

            public int getQuantity(IProduct product)
            {
                return itemCount.GetValueOrDefault(product, 0);
            }
     
        }
    }


