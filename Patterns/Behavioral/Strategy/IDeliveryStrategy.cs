using DeliverySystem.Patterns.Creational;
using desingPatternsFinalProject.Patterns.Creational;

namespace desingPatternsFinalProject.Behavioral.Strategy // 🔑 النطاق الصحيح
{
    public interface IDeliveryStrategy
    {
        decimal CalculateDeliveryCost(Order order);
        string GetDeliveryTimeEstimate(Order order);
        string DeliveryType { get; }
    }
}