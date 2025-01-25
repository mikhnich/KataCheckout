using CheckoutProcessor;

var rulesByDefault = new PricingRule[] {
           new PricingRule('A', 50, 130, 3),
           new PricingRule('B', 30, 45, 2),
           new PricingRule('C', 20),
           new PricingRule('D', 15)
        };
var checkout = new Checkout(rulesByDefault);
Console.WriteLine("Available sku: {0}", string.Join(", ", rulesByDefault.Select(x => x.SKU)));
Console.Write("Start scan: ");
do
{
    var sku = Console.ReadLine();
    try
    {
        checkout.Scan(sku ?? "");
        var totalPrice = checkout.GetTotalPrice();

        Console.WriteLine("Total price: {0}", totalPrice);
    }
    catch (KeyNotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.Write("Continue scan: ");

} while (true);
