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
using StoreCategory =  DeliverySystem.Patterns.Creational.StoreCategory;


namespace desingPatternsFinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbType.DataSource = Enum.GetValues(typeof(StoreCategory));

            cmbType.SelectedIndex = 0;

            UpdateStoreList();

        }
      
        private void UpdateStoreList()
        {
            if (cmbType.SelectedValue == null) return;

            StoreCategory category;
            Enum.TryParse(cmbType.SelectedValue.ToString(), out category);

            string searchText = txtSearch.Text;

            var results = DeliveryManager.Instance.SearchStores(category, searchText);

            lstStores.DataSource = null;      
            lstStores.DataSource = results;   
            lstStores.DisplayMember = "Name";
        }
        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("الرجاء إدخال اسمك ورقم الهاتف!", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstStores.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار متجر من القائمة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer customer = new Customer { Name = txtName.Text, Phone = txtPhone.Text };
            Store selectedStore = (Store)lstStores.SelectedItem;

            using (var shopForm = new OrderSelectionForm(customer, selectedStore))
            {
                //this.Hide();

                if (shopForm.ShowDialog() == DialogResult.OK)
                {
                    var finalOrder = shopForm.CreatedOrder;

                    DeliveryManager.Instance.AddOrder(finalOrder);

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateStoreList();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = ""; // نصفر البحث
            UpdateStoreList();
        }

        private void RefreshAdminGrid()
        {
            dgvOrders.DataSource = null;
            var allOrders = DeliveryManager.Instance.OrdersDB;

            // Assuming `o` is a string, replace `o.StoreName` with `o` directly.
            dgvOrders.DataSource = allOrders.Select(o => new
            {
                ID = o.OrderNumber,          // سميناه ID
                Store = o.StoreName ,          // Use `o` directly since `o` is a string
                Customer = o.OrderNumber,  // سميناه Customer
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

            string orderNum = dgvOrders.CurrentRow.Cells[0].Value.ToString();

            // Assuming `OrdersDB` contains objects of a class (not strings) that has a `CurrentState` property.  
            var order = DeliveryManager.Instance.OrdersDB.FirstOrDefault(o => o.OrderNumber == orderNum);

            if (order != null)
            {
                if (order.CurrentState is T)
                {
                    // ✅ نعم، هو في الحالة الصحيحة -> انتقل للحالة التالية  
                    order.NextState();

                    // تحديث الجدول لنرى الحالة الجديدة  
                    RefreshAdminGrid();
                }
                else
                {
                    // ❌ لا، المدير يحاول تخطي مرحلة (مثلاً تسليم طلب لم يطبخ بعد)  
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
    }
}
