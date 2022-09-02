using System;
namespace BCGDV.Product
{
    /**
    * Class Implementing Casio Watch Product
    */
    public class CasioWatch : IProduct
    {
        private string watchName;
        private string watchId;
        private int unitPrice;
        public CasioWatch()
        {
            watchName = "Casio";
            watchId = "004";
            unitPrice = 30;
        }
        public override int getUnitPrice()
        {
            return this.unitPrice;
        }

        public override string getId()
        {
            return this.watchId;
        }

        public override string getName()
        {
            return this.watchName;
        }
    }
}

