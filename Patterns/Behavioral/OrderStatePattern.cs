using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliverySystem.Patterns.Creational;

namespace desingPatternsFinalProject.Behavioral
{
        public interface IOrderState
        {
            void Proceed(Order order); 
            string GetStatusName();  
        }

        public class PendingState : IOrderState
        {
            public void Proceed(Order order)
            {
                order.CurrentState = new CookingState();
            }

            public string GetStatusName() => "⏳ معلق (Pending)";
        }
        public class CookingState : IOrderState
        {
            public void Proceed(Order order)
            {
                order.CurrentState = new OnTheWayState();
            }

            public string GetStatusName() => "👨‍🍳 جاري التحضير (Processing)";
        }

        public class OnTheWayState : IOrderState
        {
            public void Proceed(Order order)
            {
                order.CurrentState = new DeliveredState();
            }

            public string GetStatusName() => "🛵 في الطريق (On The Way)";
        }

        public class DeliveredState : IOrderState
        {
            public void Proceed(Order order)
            {
                throw new System.Exception("الطلب مكتمل بالفعل!");
            }

            public string GetStatusName() => "✅ تم التسليم (Delivered)";
        }
}
