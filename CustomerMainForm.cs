using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliverySystem.Patterns.Creational;
using static DeliverySystem.Patterns.Creational.Order;

using desingPatternsFinalProject.Behavioral;
using static desingPatternsFinalProject.Program;
using StoreCategory = DeliverySystem.Patterns.Creational.StoreCategory;
using desingPatternsFinalProject.Patterns.Creational;
using desingPatternsFinalProject.Patterns ; // مطلوب لدوال المدير المعلقة
using desingPatternsFinalProject.Patterns;


namespace desingPatternsFinalProject
{
    public partial class CustomerMainForm : Form, IOrderObserver
    {
        // 🔑 1. إضافة متغيرات لتخزين الطلب النشط الذي يتم تتبعه (int)
        private int _lastOrderId = 0;
        private Order _activeOrder = null;

        public CustomerMainForm()
        {
            InitializeComponent();
            // تم إزالة الربط الخاطئ من هنا.
        }

        // =========================================================
        // تنفيذ واجهة IOrderObserver (التوقيع المصحح)
        // =========================================================

        public void Update(int updatedOrderId, string statusMessage)
        {
            // 🔑 التحقق من أن التحديث يخص الطلب الذي يراقبه هذا العميل
            if (updatedOrderId != _lastOrderId || _lastOrderId == 0)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int, string>(Update), updatedOrderId, statusMessage);
            }
            else
            {
                MessageBox.Show(statusMessage, $"تحديث حالة طلبك رقم {_lastOrderId}");
            }
        }

        private void CustomerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 🚨 تصحيح: يجب استخدام Detach الذي يتطلب رقم الطلب
            if (_lastOrderId != 0)
            {
                DeliveryManager.Instance.Detach(this, _lastOrderId);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // نفترض أن UserSession كائن موجود
            // lblWelcome.Text = "Welcome, " + UserSession.CurrentUserName + " 👋";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        // =========================================================
        // دالة إنشاء الطلب (تم تصحيح خطأ التحويل)
        // =========================================================

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            // ⚠️ لغرض التشغيل المؤقت بدون الواجهة، نفترض وجود بيانات:
            Customer customer = new Customer { FullName = "Test Customer", Phone = "0000000000" };
            Store selectedStore = DeliveryManager.Instance.StoresDB.FirstOrDefault();

            if (selectedStore == null)
            {
                MessageBox.Show("لم يتم تهيئة أي متجر في النظام!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var shopForm = new OrderSelectionForm(customer, selectedStore))
            {
                if (shopForm.ShowDialog() == DialogResult.OK)
                {
                    var finalOrder = shopForm.CreatedOrder;
                    DeliveryManager.Instance.AddOrder(finalOrder);

                    // 🚨🚨 منطق المراقب: الفصل والربط برقم الطلب
                    if (_activeOrder != null && _lastOrderId != 0)
                    {
                        DeliveryManager.Instance.Detach(this, _lastOrderId);
                    }

                    // 🔑 تصحيح خطأ CS0029: التحويل من string إلى int
                    if (int.TryParse(finalOrder.OrderNumber, out int orderNum))
                    {
                        _lastOrderId = orderNum;
                    }
                    else
                    {
                        // إذا فشل التحويل (وهو أمر غير مرجح إذا كان OrderNumber تم إنشاؤه بشكل صحيح)، نستخدم قيمة افتراضية أو نخرج.
                        MessageBox.Show("خطأ في قراءة رقم الطلب. لن يتم تتبع الطلب.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _activeOrder = finalOrder;

                    // 3. ربط المراقب بالطلب الجديد فقط
                    DeliveryManager.Instance.Attach(this, _lastOrderId);
                    // ----------------------------------------------------

                    MessageBox.Show(
                        $"تم استلام طلبك بنجاح! ✅\n" +
                        $"رقم الطلب: {finalOrder.OrderNumber}\n" +
                        $"الإجمالي: {finalOrder.CalculateTotal():C}\n\n" +
                        $"حالة الطلب:\n{finalOrder.ProcessOrder()}",
                        "نجاح العملية");
                }

                this.Show();
            }
        }

        // =========================================================
        // دوال شاشة المدير (معلقة)
        // =========================================================

        /*
        private void RefreshAdminGrid()
        {
            dgvOrders.DataSource = null;
            var allOrders = DeliveryManager.Instance.OrdersDB;

            // Assuming 'o.OrderNumber' and 'o.StoreName' exist on the Order object
            dgvOrders.DataSource = allOrders.Select(o => new
            {
                ID = o.OrderNumber,
                Store = o.StoreName,
                Customer = o.OrderNumber, 
                Status = o.GetStatusString(),
                Total = o.CalculateTotal()
            }).ToList();

            // Update column headers
            dgvOrders.Columns["ID"].HeaderText = "رقم الطلب";
            dgvOrders.Columns["Store"].HeaderText = "المتجر";
            dgvOrders.Columns["Customer"].HeaderText = "العميل";
            dgvOrders.Columns["Status"].HeaderText = "حالة الطلب";
            dgvOrders.Columns["Total"].HeaderText = "الإجمالي";
        }

        private void btnStartCooking_Click(object sender, EventArgs e)
        {
            ChangeOrderStatus<PendingState>();
        }
        private void ChangeOrderStatus<T>() where T : IOrderState
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("الرجاء اختيار طلب من الجدول!");
                return;
            }

            // يجب أن يكون رقم الطلب في الخلية 0 من الصف الحالي
            string orderNumString = dgvOrders.CurrentRow.Cells[0].Value.ToString();
            
            if (!int.TryParse(orderNumString, out int orderNum)) return; // التحقق من التحويل
            
            // البحث عن الطلب
            var order = DeliveryManager.Instance.OrdersDB.FirstOrDefault(o => o.OrderNumber == orderNumString); 

            if (order != null)
            {
                if (order.CurrentState is T)
                {
                    order.NextState();
                    RefreshAdminGrid();
                }
                else
                {
                    MessageBox.Show($"خطأ في التسلسل!\nحالة الطلب الحالية هي: {order.GetStatusString()} \nلا يمكن تنفيذ هذا الزر الآن.");
                }
            }
        }

        private void btnShipOrder_Click(object sender, EventArgs e)
        {
            ChangeOrderStatus<CookingState>();
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            ChangeOrderStatus<OnTheWayState>();
        }

        private void btnRefreshAdmin_Click(object sender, EventArgs e)
        {
            RefreshAdminGrid();
        }
        */

        // =========================================================
        // دوال التصفح واختبار المراقب
        // =========================================================

        private void btnRestaurants_Click(object sender, EventArgs e)
        {
              RestaurantListForm foodForm = new RestaurantListForm(); 
             foodForm.Show();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {

        }

        private void btnSupermarket_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Supermarket section is coming soon! 🛒");
        }

        private void btnCourierService_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // UserSession.ClearSession(); 
            // LoginForm login = new LoginForm(); 
            // login.Show();
            this.Close();
        }

        private void btnTestObserver_Click(object sender, EventArgs e)
        {
            if (_lastOrderId == 0)
            {
                MessageBox.Show("الرجاء إنشاء طلب أولاً ليتم تتبعه!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DeliveryManager.Instance.UpdateOrderStatus(
                orderId: _lastOrderId,
                newStatus: $"تم استلام إشعار تجريبي: حالة طلبك {_lastOrderId} هي الآن قيد التسليم! 🛵"
            );

            MessageBox.Show($"تم إطلاق إشعار التحديث للطلب رقم {_lastOrderId}.", "تأكيد الإطلاق", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}