using CheckoutProcessor.Interfaces;

namespace CheckoutProcessor
{
    public class Checkout : ICheckout
    {
        private Dictionary<char, SkuAggregationInfo> _skuList;
        private int? _lastTotalPrice = null;

        public Checkout(PricingRule[] pricingRules)
        {
            _skuList = pricingRules.ToDictionary(r => r.SKU, r => new SkuAggregationInfo(r));
        }

        public void Scan(string skuList)
        {
            foreach (var sku in skuList)
            {
                if (_skuList.TryGetValue(sku, out var skuAggregationInfo))
                {
                    skuAggregationInfo.Increment();
                }
                else
                {
                    throw new KeyNotFoundException($"Unknown SKU: {sku}");
                }

                _lastTotalPrice = null;
            }
        }

        public int GetTotalPrice()
        {
            if (_lastTotalPrice == null)
            {
                _lastTotalPrice = CalcTotalPrice(_skuList.Values.ToArray());
            }
            return _lastTotalPrice.Value;
        }

        private int CalcTotalPrice(SkuAggregationInfo[] scanInfos)
        {
            return scanInfos.Sum(x => x.GetTotalAmount());
        }
    }
}
