using CheckoutProcessor.Interfaces;

namespace CheckoutProcessor
{
    public class Checkout : ICheckout
    {
        public Checkout(PricingRule[] pricingRules)
        {

        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
