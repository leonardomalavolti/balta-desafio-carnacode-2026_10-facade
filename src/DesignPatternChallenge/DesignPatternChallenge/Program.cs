using DesignPatternChallenge.DTOs;
using DesignPatternChallenge.Facades;

var order = new OrderDTO
{
    ProductId = "PROD001",
    Quantity = 2,
    CustomerEmail = "cliente@email.com",
    CreditCard = "1234567890123456",
    Cvv = "123",
    ShippingAddress = "Rua Exemplo, 123",
    ZipCode = "12345-678",
    CouponCode = "PROMO10",
    ProductPrice = 100.00m
};

var facade = new OrderFacade();
facade.ProcessOrder(order);

Console.WriteLine("\n=== BENEFÍCIOS DO FACADE ===");
Console.WriteLine("✔ Cliente conhece apenas uma classe");
Console.WriteLine("✔ Complexidade encapsulada");
Console.WriteLine("✔ Redução de acoplamento");
Console.WriteLine("✔ Código mais limpo");
Console.WriteLine("✔ Interface simples e unificada");