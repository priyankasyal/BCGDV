using System;
namespace BCGDV.Models
{
    /**
    * Class Implementing Data transfer object for response for checkout controller
    */
    public class CheckoutDto
    {
        public double price {get;} 

        public CheckoutDto(double price)
        {
            this.price = price;    
        }
    }
}

