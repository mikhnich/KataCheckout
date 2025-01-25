namespace CheckoutProcessor.Tests
{
    [TestFixture]
    public class Tests
    {
        private PricingRule[] _rulesByDefault = {
           new PricingRule('A', 50, 130, 3),
           new PricingRule('B', 30, 45, 2),
           new PricingRule('C', 20),
           new PricingRule('D', 15)
        };

        [TestCase("", 0)]
        [TestCase("A", 50)]
        [TestCase("AB", 80)]
        [TestCase("CDBA", 115)]

        [TestCase("AA", 100)]
        [TestCase("AAA", 130)]
        [TestCase("AAAA", 180)]
        [TestCase("AAAAA", 230)]
        [TestCase("AAAAAA", 260)]

        [TestCase("AAAB", 160)]
        [TestCase("AAABB", 175)]
        [TestCase("AAABBD", 190)]
        [TestCase("DABABA", 190)]
        public void GetTotalPriceTest(string input, int expectedAmount)
        {
            var checkout = new Checkout(_rulesByDefault);
            checkout.Scan(input);
            var actualResult = checkout.GetTotalPrice();

            Assert.That(actualResult, Is.EqualTo(expectedAmount));
        }


        [TestCase(new[] { "A", "B" }, new[] { 50, 80 })]
        [TestCase(new[] { "C", "D", "B", "A" }, new[] { 20, 35, 65, 115 })]
        [TestCase(new[] { "A", "A" }, new[] { 50, 100 })]
        [TestCase(new[] { "A", "A", "A" }, new[] { 50, 100, 130 })]
        [TestCase(new[] { "A", "A", "A", "A" }, new[] { 50, 100, 130, 180 })]
        [TestCase(new[] { "A", "A", "A", "A", "A" }, new[] { 50, 100, 130, 180, 230 })]
        [TestCase(new[] { "A", "A", "A", "A", "A", "A" }, new[] { 50, 100, 130, 180, 230, 260 })]
        [TestCase(new[] { "A", "A", "A", "B" }, new[] { 50, 100, 130, 160 })]
        [TestCase(new[] { "A", "A", "A", "B", "B" }, new[] { 50, 100, 130, 160, 175 })]
        [TestCase(new[] { "A", "A", "A", "B", "B", "D" }, new[] { 50, 100, 130, 160, 175, 190 })]
        [TestCase(new[] { "D", "A", "B", "A", "B", "A" }, new[] { 15, 65, 95, 145, 160, 190 })]
        public void GetTotalPriceIncrementalTest(string[] input, int[] expectedAmounts)
        {
            var checkout = new Checkout(_rulesByDefault);

            for (var i = 0; i < input.Length; i++)
            {
                checkout.Scan(input[i]);
                var actualResult = checkout.GetTotalPrice();
                var expectedAmount = expectedAmounts[i];
                Assert.That(actualResult, Is.EqualTo(expectedAmount));
            }
        }

        [TestCase]
        public void ErrorSkuTest()
        {
            var expectedMessage = "Unknown SKU: T";
            var checkout = new Checkout(_rulesByDefault);
            var exception = Assert.Throws<KeyNotFoundException>(() => checkout.Scan("ATROLOLO"));
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}