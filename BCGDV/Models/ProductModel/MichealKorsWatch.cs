using System;
namespace BCGDV.Product
{
    /**
    * Class Implementing Micheal Watch Product
    */
    public class MichealKorsWatch : IProduct
    {
        private string watchName;
        private string watchId;
        private int unitPrice;
        public MichealKorsWatch()
        {
            watchName = "Micheal Kors";
            watchId = "002";
            unitPrice = 80;
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

