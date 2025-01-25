namespace CheckoutProcessor
{
    public class PricingRule
    {
        public char SKU { get; private set; }
        public int RegularPrice { get; private set; }
        public int? SpecialPriceForSet { get; private set; } = null;
        public int? CountForSpecialPrice { get; private set; } = null;

        public PricingRule(char sku, int regularPrice, int specialPrice, int countForSpecialPrice)
        {
            SKU = sku;
            CountForSpecialPrice = countForSpecialPrice;
            SpecialPriceForSet = specialPrice;
            RegularPrice = regularPrice;
        }

        public PricingRule(char sku, int regularPrice)
        {
            SKU = sku;
            RegularPrice = regularPrice;
        }
    }
}
