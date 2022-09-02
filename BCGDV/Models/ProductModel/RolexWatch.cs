using System;

namespace BCGDV.Product
{
    /**
    * Class Implementing Rolex Watch Product
    */
    public class RolexWatch: IProduct
    {
        private string watchName;
        private string watchId;
        private int unitPrice;

        public RolexWatch()
        {
            watchName = "Rolex";
            watchId = "001";
            unitPrice = 100;
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

