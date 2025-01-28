namespace Ordering.Infrastructure.Data.Extensions;
internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>()
        {
            Customer.Create(CustomerId.Of(new Guid("20e8daea-3f42-4c21-80f1-c6b7c7aaa542")), "john", "john@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("eec28f1d-8e6f-4b0d-bc69-aaf765db6975")), "bob", "bob@gmail.com")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>()
        {
            Product.Create(ProductId.Of(new Guid("36f383f0-8fe1-4af9-bd94-234b26ff7d04")), "IPhone X", 500),
            Product.Create(ProductId.Of(new Guid("ee38e242-1a56-4a29-9d9b-2948948015aa")), "Samsung 10", 400),
            Product.Create(ProductId.Of(new Guid("0a1cd315-116f-4ecf-8130-b5f208f98839")), "Huawei Plus", 650),
            Product.Create(ProductId.Of(new Guid("d02798cc-30cc-49ab-ae74-c0d63fce64c7")), "Xiaomi Mi", 450),
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("bob", "bobson", "bob@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("bob", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);
            order1.Add(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 2, 500);
            order1.Add(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);
            order2.Add(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), 1, 650);
            order2.Add(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }
}
