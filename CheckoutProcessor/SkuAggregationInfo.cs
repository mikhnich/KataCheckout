namespace CheckoutProcessor
{
    public class SkuAggregationInfo
    {
        private PricingRule _rule;
        private int Count;
        public SkuAggregationInfo(PricingRule rule)
        {
            _rule = rule;
        }

        public void Increment()
        {
            Count++;
        }
        public int GetTotalAmount()
        {
            if (_rule.CountForSpecialPrice.HasValue && _rule.SpecialPriceForSet.HasValue)
            {
                int setWithSpecialPrice = Count / _rule.CountForSpecialPrice.Value;
                var remainderCount = Count % _rule.CountForSpecialPrice.Value;
                return setWithSpecialPrice * _rule.SpecialPriceForSet.Value + remainderCount * _rule.RegularPrice;
            }
            return Count * _rule.RegularPrice;
        }
    }
}
