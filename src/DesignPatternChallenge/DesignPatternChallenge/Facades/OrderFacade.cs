using DesignPatternChallenge.DTOs;
using DesignPatternChallenge.Subsystems;

namespace DesignPatternChallenge.Facades;

public class OrderFacade
{
    private readonly InventorySystem _inventory;
    private readonly PaymentGateway _payment;
    private readonly ShippingService _shipping;
    private readonly CouponSystem _coupon;
    private readonly NotificationService _notification;

    public OrderFacade()
    {
        _inventory = new InventorySystem();
        _payment = new PaymentGateway();
        _shipping = new ShippingService();
        _coupon = new CouponSystem();
        _notification = new NotificationService();
    }

    public void ProcessOrder(OrderDTO order)
    {
        Console.WriteLine("=== Processando Pedido via Facade ===\n");

        if (!_inventory.CheckAvailability(order.ProductId))
        {
            Console.WriteLine("❌ Produto indisponível");
            return;
        }

        _inventory.ReserveProduct(order.ProductId, order.Quantity);

        decimal discount = 0;
        if (!string.IsNullOrEmpty(order.CouponCode) &&
            _coupon.ValidateCoupon(order.CouponCode))
        {
            discount = _coupon.GetDiscount(order.CouponCode);
        }

        decimal subtotal = order.ProductPrice * order.Quantity;
        decimal discountAmount = subtotal * discount;
        decimal shippingCost =
            _shipping.CalculateShipping(order.ZipCode, order.Quantity * 0.5m);

        decimal total = subtotal - discountAmount + shippingCost;

        string transactionId = _payment.InitializeTransaction(total);

        if (!_payment.ValidateCard(order.CreditCard, order.Cvv))
        {
            _inventory.ReleaseReservation(order.ProductId, order.Quantity);
            Console.WriteLine("❌ Cartão inválido");
            return;
        }

        if (!_payment.ProcessPayment(transactionId, order.CreditCard))
        {
            _inventory.ReleaseReservation(order.ProductId, order.Quantity);
            Console.WriteLine("❌ Pagamento recusado");
            return;
        }

        string orderId = $"ORD{DateTime.Now.Ticks}";
        string labelId =
            _shipping.CreateShippingLabel(orderId, order.ShippingAddress);

        _shipping.SchedulePickup(labelId, DateTime.Now.AddDays(1));

        if (!string.IsNullOrEmpty(order.CouponCode))
            _coupon.MarkCouponAsUsed(order.CouponCode, order.CustomerEmail);

        _notification.SendOrderConfirmation(order.CustomerEmail, orderId);
        _notification.SendPaymentReceipt(order.CustomerEmail, transactionId);
        _notification.SendShippingNotification(order.CustomerEmail, labelId);

        Console.WriteLine($"\n✅ Pedido {orderId} finalizado com sucesso!");
        Console.WriteLine($"   Total: R$ {total:N2}");
    }
}