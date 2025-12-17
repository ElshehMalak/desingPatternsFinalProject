using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliverySystem.Patterns.Creational;
using desingPatternsFinalProject.Patterns.Creational;
using desingPatternsFinalProject.Behavioral.Strategy;
using desingPatternsFinalProject.Patterns;
using static DeliverySystem.Patterns.Creational.ShopOrder;
namespace desingPatternsFinalProject
{
    public partial class OrderSelectionForm : Form
    {
        //private Customer _customer;
        private User _currentUser;
        private Store _currentStore;
        private StoreRepository _repo;
        private List<Product> _allProducts;
        private BindingList<OrderItem> _cartItems;
        public Order CreatedOrder { get; private set; }

        // 🔑 خاصية لمتابعة الإجمالي الحالي (يحتوي على سعر التوصيل)
        private decimal _currentTotalWithDelivery = 0.0m;
        public OrderSelectionForm(Customer customer, Store store)
        {
            InitializeComponent();
            _currentUser = customer ;
            _currentStore = store;
            _repo = new StoreRepository();
            _cartItems = new BindingList<OrderItem>();

            dgvCart.DataSource = _cartItems;
        }

        // 🔑 3. دوال نمط Strategy
        // =========================================================

        // هذه الدالة تقرر أي Concrete Strategy يجب استخدامها بناءً على الـ Radio Buttons
        private IDeliveryStrategy GetSelectedDeliveryStrategy()
        {
            if (rdbExpressDelivery.Checked)
            {
                return new ExpressDelivery();
            }
            else if (rdbPickupDelivery.Checked)
            {
                return new PickupDelivery();
            }
            else // Default هو NormalDelivery
            {
                return new NormalDelivery();
            }
        }
        private void OrderSelectionForm_Load(object sender, EventArgs e)
        {
            this.Text = $"التسوق من: {_currentStore.Name}";

            Menu.DataSource = _repo.GetProductsByStore(_currentStore.ID);
            Menu.DisplayMember = "Name";
            dgvCart.AutoGenerateColumns = true;
            /*
            try
            {
                // نخفوا الكائن الأساسي لأنه ما ينعرضش كنص
                dgvCart.Columns["Product"].Visible = false;

                // نعدلوا أسماء الأعمدة الظاهرة (نربطوها بالخصائص اللي درناها في الكلاس)
                dgvCart.Columns["ShowName"].HeaderText = "Product";
                dgvCart.Columns["ShowPrice"].HeaderText = "Price";
                dgvCart.Columns["ShowQuantity"].HeaderText = "Quantity";

                // ترتيبهم (اختياري)
                dgvCart.Columns["ShowName"].DisplayIndex = 0;
                dgvCart.Columns["ShowPrice"].DisplayIndex = 1;
                dgvCart.Columns["ShowQuantity"].DisplayIndex = 2;
            }
            catch { }
            */
            lblTotal.Text = "0.00 DLY";

            //lblTotal.Text = "0.00 $"; // تحديث الإجمالي عند التحميل
        }
        private void lstMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var product = Menu.SelectedItem as Product;
            if (product == null) return;

            int qty = (int)numQty.Value;

            // إضافة للسلة
            _cartItems.Add(new OrderItem(product, qty));

            UpdateTotal();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("السلة فارغة!");
                return;
            }
            // 1. إنشاء الطلب
            CreatedOrder = OrderFactory.CreateOrder( _currentUser, _currentStore );

            // 🔑 2. تعيين الاستراتيجية النهائية للطلب بناءً على اختيار العميل
            IDeliveryStrategy finalStrategy = GetSelectedDeliveryStrategy();
            CreatedOrder.SetDeliveryStrategy(finalStrategy);

            // 3. نضيف المنتجات من السلة للطلب
            foreach (var item in _cartItems)
            {
                CreatedOrder.AddItem(item.Product, item.Quantity);
            }

            // يتم إرسال الطلب (CreatedOrder) إلى DeliveryManager في الكود الرئيسي (Program.cs)

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                var item = (OrderItem)dgvCart.CurrentRow.DataBoundItem;
                _cartItems.Remove(item);
                UpdateTotal();
            }
        }
        private void UpdateTotal()
        {
            decimal total = _cartItems.Sum(x => x.GetTotal());
            lblTotal.Text = $"{total:C}";
            if (_cartItems.Count == 0)
            {
                _currentTotalWithDelivery = 0.0m;
                lblTotal.Text = "0.00 $";
                // 🔑 تفريغ Label تكلفة التوصيل
                lblDeliveryCost.Text = "";
                return;
            }

            // 1. إنشاء طلب وهمي مؤقت لحساب التكاليف
            Order tempOrder = OrderFactory.CreateOrder( _currentUser, _currentStore);

            // 2. إضافة العناصر إلى الطلب المؤقت
            foreach (var item in _cartItems)
            {
                tempOrder.AddItem(item.Product, item.Quantity);
            }

            // 3. تعيين الاستراتيجية المختارة وحساب الإجمالي الكلي (يشمل التوصيل)
            IDeliveryStrategy selectedStrategy = GetSelectedDeliveryStrategy();
            tempOrder.SetDeliveryStrategy(selectedStrategy);

            _currentTotalWithDelivery = tempOrder.CalculateTotal();
            decimal itemsTotal = tempOrder.CalculateItemsTotal();
            decimal deliveryCost = _currentTotalWithDelivery - itemsTotal;

            // 4. تحديث واجهة المستخدم
            lblTotal.Text = $"{_currentTotalWithDelivery:C}";
            // 🔑 عرض تفاصيل التوصيل والوقت المقدر
            lblDeliveryCost.Text = $"تكلفة التوصيل: {deliveryCost:C} | ({tempOrder.GetDeliveryEstimate()})";
        }

        private void groupbShoppingCart_Enter(object sender, EventArgs e)
        {

        }

         private void btnTrackOrder_Click(object sender, EventArgs e)
        {
            // 1. إنشاء نموذج التتبع الجديد
            /*
             * OrderTrackingForm trackingForm = new OrderTrackingForm();

            // 2. فتحه. (نستخدم Show() ليبقى نموذج العميل الرئيسي فعالاً)
            trackingForm.Show();

             // 💡 يمكن هنا إضافة رسالة تنبيه للعميل (اختياري)
            */
            MessageBox.Show("تم فتح شاشة التتبع. ستصلك الإشعارات فور تحديث الطلب من قبل الإدارة.", "بدء التتبع");
        } 
        // 🔑 4. دالة معالجة حدث تغيير خيارات التوصيل (مربوطة بـ 3 أزرار راديو)
        private void rdbNormalDelivery_CheckedChanged(object sender, EventArgs e)
        {
            // نتأكد أن الحدث تم إطلاقه بسبب اختيار زر (وليس إلغاء اختيار)
            if (sender is RadioButton rb && rb.Checked)
            {
                UpdateTotal();
            }
        }
    }
}
