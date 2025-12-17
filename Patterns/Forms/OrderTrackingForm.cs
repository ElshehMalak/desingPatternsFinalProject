using System;
using System.Linq;
using System.Windows.Forms;
using desingPatternsFinalProject.Patterns.Creational;
using desingPatternsFinalProject.Behavioral;
using DeliverySystem.Patterns.Creational;

namespace desingPatternsFinalProject
{
    public partial class OrderTrackingForm : Form, IOrderObserver
    {
        private int _orderIdToTrack;

        public OrderTrackingForm(int orderId)
        {
            InitializeComponent();
            _orderIdToTrack = orderId;
            this.Text = $"تتبع الطلب رقم: {_orderIdToTrack}";

            this.Load += OrderTrackingForm_Load;
        }

        public OrderTrackingForm() : this(0) { }


        private void OrderTrackingForm_Load(object sender, EventArgs e)
        {
            // 1. ربط المراقب بالـ DeliveryManager
            DeliveryManager.Instance.Attach(this, _orderIdToTrack);

            // 2. عرض التفاصيل الأولية (Strategy + State)
            LoadOrderDetails();
        }

        // ===============================================================
        // 🔑 دالة: تحميل تفاصيل الطلب الثابتة والمحدثة (Strategy + State)
        // ===============================================================
        private void LoadOrderDetails()
        {
            // البحث عن كائن الطلب في قاعدة البيانات (Singleton)
            string orderNumStr = _orderIdToTrack.ToString();
            var order = DeliveryManager.Instance.OrdersDB
                .FirstOrDefault(o => o.OrderNumber == orderNumStr);

            if (order == null)
            {
                MessageBox.Show("لم يتم العثور على الطلب المطلوب تتبعه.");
                return;
            }

            // تحديث العناصر الثابتة (Strategy Pattern)
            SetLabelText("lblDeliveryType", order.GetDeliveryType());
            SetLabelText("lblEstimateTime", order.GetDeliveryEstimate());
            SetLabelText("lblTotalAmount", order.CalculateTotal().ToString("C"));

            // تحديث الحالة الحالية (State Pattern)
            SetLabelText("lblCurrentStatus", order.GetStatusString());

            // معلومات الطلب الأساسية
            SetLabelText("lblOrderNumber", order.OrderNumber);
            SetLabelText("lblStoreName", order.StoreName);
        }

        // دالة مساعدة لتحديث النصوص بناءً على الاسم البرمجي
        private void SetLabelText(string labelName, string text)
        {
            var label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
            if (label != null)
            {
                label.Text = text;
            }
        }

        // دالة مساعدة لإضافة التحديثات للسجل
        private void UpdateLog(string message)
        {
            var logTextBox = this.Controls.Find("txtLiveUpdates", true).FirstOrDefault() as TextBox;
            if (logTextBox != null)
            {
                logTextBox.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
            }
        }


        // ===============================================
        // تنفيذ واجهة IOrderObserver (يتم تحديثها بالكامل هنا)
        // ===============================================
        public void Update(int updatedOrderId, string statusMessage)
        {
            if (updatedOrderId != _orderIdToTrack)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int, string>(Update), updatedOrderId, statusMessage);
            }
            else
            {
                // 1. تحديث سجل التحديثات الحية (Observer Feed)
                UpdateLog(statusMessage);

                // 2. تحديث Label الحالة الحالية بالرسالة
                SetLabelText("lblCurrentStatus", statusMessage);

                // 3. 🔑 إعادة تحميل التفاصيل لتحديث كل شيء آخر (Strategy/State Visuals)
                LoadOrderDetails();
            }
        }

        private void OrderTrackingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // فصل المراقب عند الإغلاق
            DeliveryManager.Instance.Detach(this, _orderIdToTrack);
        }
    }
}