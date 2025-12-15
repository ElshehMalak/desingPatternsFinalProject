using System;
using System.Linq; // أضيف لاستخدام Find
using System.Windows.Forms;
using desingPatternsFinalProject.Patterns.Creational; // لـ DeliveryManager
// 🚨 نغير الواجهة إلى IOrderObserver التي سنعدلها لتقبل رقم الطلب
using desingPatternsFinalProject.Behavioral;
using DeliverySystem.Patterns.Creational;

namespace desingPatternsFinalProject
{
    // 🚨 1. تغيير الواجهة إلى IOrderObserver (يجب عليكِ تعديلها في الملف الأصلي)
    public partial class OrderTrackingForm : Form, IOrderObserver
    {
        // متغيرات لتخزين رقم الطلب الحالي والاسم
        private int _orderIdToTrack;

        // 🚨🚨 2. إضافة المُنشئ الذي يقبل رقم الطلب (لحماية من خطأ CS1729)
        public OrderTrackingForm(int orderId)
        {
            InitializeComponent();
            _orderIdToTrack = orderId;
            this.Text = $"تتبع الطلب رقم: {_orderIdToTrack}";

            // 💡 عرض الحالة الأولية (اختياري)
            this.Load += OrderTrackingForm_Load;
        }

        // 💡 إبقاء المنشئ الافتراضي إذا كان ضرورياً لـ InitializeComponent
        public OrderTrackingForm() : this(0) { }


        private void OrderTrackingForm_Load(object sender, EventArgs e)
        {
            // 🚨 3. ربط المراقب بالـ DeliveryManager، وتمرير رقم الطلب
            // (يفترض أن دالة Attach في DeliveryManager أصبحت تقبل رقم الطلب)
            DeliveryManager.Instance.Attach(this, _orderIdToTrack);

            // محاولة إيجاد Label باسم lblCurrentStatus لعرض الحالة الأولية
            var statusLabel = this.Controls.Find("lblCurrentStatus", true).FirstOrDefault() as Label;
            if (statusLabel != null)
            {
                statusLabel.Text = $"بدء تتبع الطلب {_orderIdToTrack}...";
            }
        }

        // ===============================================
        // تنفيذ واجهة IOrderObserver (المعدلة)
        // ===============================================
        // 🚨 4. تعديل دالة Update لتتلقى رقم الطلب ورسالة الحالة
        public void Update(int updatedOrderId, string statusMessage)
        {
            // 🔑 الخطوة الحاسمة: التأكد من أن التحديث يخص الطلب الذي نراقبه فقط
            if (updatedOrderId != _orderIdToTrack)
            {
                return; // تجاهل أي تحديث لا يخص هذا الطلب
            }

            // يجب استخدام Invoke إذا كان التحديث يحدث من ثريد مختلف
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int, string>(Update), updatedOrderId, statusMessage);
            }
            else
            {
                // البحث عن Label باسم lblCurrentStatus لعرض الرسالة
                var statusLabel = this.Controls.Find("lblCurrentStatus", true).FirstOrDefault() as Label;

                if (statusLabel != null)
                {
                    statusLabel.Text = statusMessage;
                }
                else
                {
                    // حل احتياطي: استخدام MessageBox
                    MessageBox.Show(statusMessage, $"تحديث الطلب {_orderIdToTrack}");
                }
            }
        }

        private void OrderTrackingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 🚨 5. فصل المراقب عند الإغلاق وتمرير رقم الطلب
            DeliveryManager.Instance.Detach(this, _orderIdToTrack);
        }
    }
}