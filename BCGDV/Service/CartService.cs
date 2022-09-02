using System;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Service.Interfaces;

namespace BCGDV.Service
{
    /**
     * Cart service to create carts with the list of Ids, can be extended for 
     * implementing other cart related functionalities like removing an item
     */
    public class CartService : ICartService
    {
        IProductService productService; 
        public CartService(IProductService productService)
        {
            this.productService = productService;
        }

        /*
         * Creates a cart with a given productId List
         * Throws an exception if no matching product is found
         */
        public Cart createCart(List<string> productIdList)
        {
            Cart cart = new Cart();

            foreach (string product in productIdList)
            {
                try
                {
                    IProduct currentProduct = this.productService.getProductById(product);
                    cart.addItem(currentProduct);

                }
                catch (Exception)
                {
                    Console.WriteLine("Product not found");
                }
            }
            if(cart.getItems().Count==0)
            {
                throw new Exception("No Matching Product Found");
            }
            else return cart;
        }
    }
}

