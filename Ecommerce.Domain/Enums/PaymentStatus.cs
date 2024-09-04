namespace Ecommerce.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending,
        Authorized,
        Successful,
        Declined,
        Refunded,
        PartiallyRefunded,
        Failed,
        Cancelled,
        Expired

    }
}