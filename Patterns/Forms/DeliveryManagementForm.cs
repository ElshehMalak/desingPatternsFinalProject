using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using desingPatternsFinalProject.Patterns.Creational; // لـ DeliveryManager و Order
// 🚨 يجب أن تكون النطاقات التالية صحيحة لنظام State Pattern لديك
using DeliverySystem.Patterns.Creational;
using desingPatternsFinalProject.Behavioral;
// ... أضيفي أي using أخرى تحتاجينها

namespace desingPatternsFinalProject
{
    // 🚨 تأكدي من أن اسم الكلاس هنا هو اسم ملف الفورم لديك (مثلاً DeliveryManagementForm)
    public partial class DeliveryManagementForm : Form
    {
        public DeliveryManagementForm()
        {
            InitializeComponent();
        }

        private void DeliveryManagementForm_Load(object sender, EventArgs e)
        {
            RefreshAdminGrid();
        }

        // =================================================================
        // دالة تحديث شاشة العرض
        // =================================================================
        private void RefreshAdminGrid()
        {
            // نفترض أن dgvOrders هو اسم DataGridView في التصميم
            dgvOrders.DataSource = null;
            var allOrders = DeliveryManager.Instance.OrdersDB;

            //🔑 1.تعديل الـ LINQ لإضافة خاصيتي DeliveryType و DeliveryEstimate
            dgvOrders.DataSource = allOrders.Select(o => new
            {
                ID = o.OrderNumber,
                Store = o.StoreName,
                Customer = o.Customer?.FullName ?? o.OrderNumber.ToString(),
                // 💡 إضافة خاصية نوع التوصيل
                DeliveryType = o.GetDeliveryType(),
                // 💡 إضافة خاصية الوقت المقدر
                Estimate = o.GetDeliveryEstimate(),
                Status = o.GetStatusString(),
                Total = o.CalculateTotal()
            }).ToList();

            // 🔑 2. تحديث رؤوس الأعمدة
            if (dgvOrders.Columns["ID"] != null) dgvOrders.Columns["ID"].HeaderText = "رقم الطلب";
            if (dgvOrders.Columns["Store"] != null) dgvOrders.Columns["Store"].HeaderText = "المتجر";
            if (dgvOrders.Columns["Customer"] != null) dgvOrders.Columns["Customer"].HeaderText = "العميل";
            // 🔑 إضافة رأس العمود الجديد لنوع التوصيل
            if (dgvOrders.Columns["DeliveryType"] != null) dgvOrders.Columns["DeliveryType"].HeaderText = "نوع التوصيل";
            // 🔑 إضافة رأس العمود الجديد للوقت المقدر
            if (dgvOrders.Columns["Estimate"] != null) dgvOrders.Columns["Estimate"].HeaderText = "وقت مقدر";
            if (dgvOrders.Columns["Status"] != null) dgvOrders.Columns["Status"].HeaderText = "حالة الطلب";
            if (dgvOrders.Columns["Total"] != null) dgvOrders.Columns["Total"].HeaderText = "الإجمالي";

            // 💡 ملاحظة: التأكد من أن عمود الإجمالي (Total) يعرض التكلفة النهائية التي تحسبها الاستراتيجية
            if (dgvOrders.Columns["Total"] != null)
            {
                dgvOrders.Columns["Total"].DefaultCellStyle.Format = "C"; // لعرض العملة
            }
        }


        // =================================================================
        // دالة تغيير الحالة مع إطلاق إشعار المراقب (Observer Notify)
        // =================================================================
        private void ChangeOrderStatus<T>() where T : IOrderState
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("الرجاء اختيار طلب من الجدول!");
                return;
            }

            // يتم الحصول على رقم الطلب هنا كـ String من العمود الأول (Cells[0] = ID)
            string orderNumStr = dgvOrders.CurrentRow.Cells[0].Value.ToString();
            
            // نحتاج التحويل الآمن لضمان أننا نبحث برقم صحيح
            if (!int.TryParse(orderNumStr, out int orderId))
            {
                 MessageBox.Show("خطأ: لم يتم العثور على رقم الطلب!");
                 return;
            }

            // البحث عن كائن الطلب في قاعدة البيانات (الذاكرة)
            // 💡 ملاحظة: يجب أن تكون خاصية OrderNumber في كائن الطلب من نوع int للبحث بـ orderId
            var order = DeliveryManager.Instance.OrdersDB.FirstOrDefault(o => o.OrderNumber.ToString() == orderNumStr);
            if (order != null)
            {
                // التحقق من أن الحالة الحالية للكائن من نفس نوع الحالة المتوقعة (T)
                if (order.CurrentState.GetType() == typeof(T))
                {
                    // ✅ 1. انتقال الطلب إلى الحالة التالية (State Pattern)
                    order.NextState();

                    // 🔑 إضافة معلومات التوصيل الناتجة عن Strategy إلى رسالة الإشعار
                    string newStatus = order.GetStatusString();
                    string deliveryType = order.GetDeliveryType();
                    string deliveryEstimate = order.GetDeliveryEstimate();

                    string notificationMessage = $"تحديث: حالة طلبك رقم {orderId} هي الآن: {newStatus}. \nنوع التوصيل: {deliveryType}. الوقت المقدر: {deliveryEstimate}";

                    // نرسل الإشعار لجميع المراقبين المربوطين (مثل OrderTrackingForm)
                    DeliveryManager.Instance.UpdateOrderStatus(
                        orderId: orderId,
                        newStatus: notificationMessage
                    );
                    // ----------------------------------------------------

                    // 3. تحديث الجدول لنرى الحالة الجديدة
                    RefreshAdminGrid();
                    MessageBox.Show($"تم تحديث حالة الطلب {orderId} بنجاح إلى: {newStatus}");
                }
                else
                {
                    // ❌ خطأ في التسلسل
                    MessageBox.Show($"خطأ في التسلسل!\nحالة الطلب الحالية هي: {order.GetStatusString()} \nلا يمكن تنفيذ هذا الزر الآن.");
                }
            }
        }

        // =================================================================
        // الدوال المرتبطة بالأزرار
        // =================================================================
        private void btnStartCooking_Click(object sender, EventArgs e)
        {
            // يفترض الانتقال من PendingState أو NewOrderState إلى حالة الطبخ
            ChangeOrderStatus<PendingState>();
        }

        private void btnShipOrder_Click(object sender, EventArgs e)
        {
            // يفترض الانتقال من CookingState إلى حالة الشحن
            ChangeOrderStatus<CookingState>();
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            // يفترض الانتقال من OnTheWayState إلى حالة الإكمال
            ChangeOrderStatus<OnTheWayState>();
        }

        private void btnRefreshAdmin_Click(object sender, EventArgs e)
        {
            RefreshAdminGrid();
        }

        private void btnOpenTrackerTest_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("الرجاء اختيار طلب من الجدول لتتبعه!");
                return;
            }
            // 1. استخراج رقم الطلب من الصف المحدد
            string orderNumStr = dgvOrders.CurrentRow.Cells[0].Value.ToString();

            if (!int.TryParse(orderNumStr, out int orderId))
            {
                MessageBox.Show("خطأ في قراءة رقم الطلب.");
                return;
            }
            // 2. إنشاء نموذج التتبع وتمرير رقم الطلب
            // (هنا نفترض أنكِ عدلتِ OrderTrackingForm ليأخذ orderId)
            OrderTrackingForm trackingForm = new OrderTrackingForm(orderId);

            // 3. 🔑 استخدام Show() لفتح الواجهة دون حظر واجهة الدليفري
            trackingForm.Show();

            MessageBox.Show($"تم فتح نموذج التتبع للطلب رقم {orderId}. يمكنك الآن تغيير حالته في واجهة الدليفري ومراقبة التحديث الفوري.", "بدء المراقبة");
        }

        private void btnRefreshAdmin_Click_1(object sender, EventArgs e)
        {
            RefreshAdminGrid();
        }

        private void btnStartCooking_Click_1(object sender, EventArgs e)
        {
            // يفترض الانتقال من PendingState أو NewOrderState إلى حالة الطبخ
            ChangeOrderStatus<PendingState>();
        }

        private void btnCompleteOrder_Click_1(object sender, EventArgs e)
        {
            // يفترض الانتقال من OnTheWayState إلى حالة الإكمال
            ChangeOrderStatus<OnTheWayState>();

        }

        private void btnShipOrder_Click_1(object sender, EventArgs e)
        {
            // يفترض الانتقال من CookingState إلى حالة الشحن
            ChangeOrderStatus<CookingState>();
        }
    }
}