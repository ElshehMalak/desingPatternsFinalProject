using DeliverySystem.Patterns.Creational;
using desingPatternsFinalProject.Patterns.Creational;

namespace desingPatternsFinalProject.Behavioral.Strategy // 🔑 النطاق الصحيح
{
    // استراتيجية الاستلام من المتجر
    public class PickupDelivery : IDeliveryStrategy
    {
        public string DeliveryType => "استلام من المتجر (Pickup)";

        public decimal CalculateDeliveryCost(Order order)
        {
            // التكلفة صفر دائماً
            return 0.0m;
        }

        public string GetDeliveryTimeEstimate(Order order)
        {
            // جاهز للاستلام الفوري
            return "جاهز للاستلام الآن.";
        }
    }
}