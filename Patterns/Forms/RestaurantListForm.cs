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



namespace desingPatternsFinalProject.Patterns
{
    public partial class RestaurantListForm : Form
    {
        StoreRepository _repo;
        string _categoryToShow;
        public RestaurantListForm(string category)
        {
            InitializeComponent();
            _repo = new StoreRepository();
            _categoryToShow = category;
        }

        private void RestaurantListForm_Load(object sender, EventArgs e)
        {
            LoadRestaurants();
        }
        private void LoadRestaurants()
        {
            List<Store> stores = _repo.GetStoresByCategory(_categoryToShow);

            // 2. نمسحوا أي أزرار قديمة (لو اللوحة اسمها flowLayoutPanel1)
            if (flowPanelRestaurants.Controls.Count > 0)
                flowPanelRestaurants.Controls.Clear();

            // 3. نصنعوا زر لكل متجر
            foreach (Store store in stores)
            {
                Button btn = new Button();

                // التنسيق (الشكل)
                btn.Text = $"{store.Name}\n⭐ {store.Rating}\n🛵 {store.DeliveryFee} LYD";
                btn.Size = new System.Drawing.Size(180, 100);
                btn.BackColor = System.Drawing.Color.WhiteSmoke;
                btn.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

                // ⚠️ حركة ذكية: نخزنوا كائن المتجر كامل داخل الزر
                btn.Tag = store;

                // إضافة الحدث (لما ينضغط الزر)
                btn.Click += Btn_Click;

                // إضافة الزر للشاشة
                flowPanelRestaurants.Controls.Add(btn);
            }
            /*
            // 1. نظفي اللوحة قبل ما تعبيها
            flowPanelRestaurants.Controls.Clear();

            // 2. لفي على كل مطعم في الـ MockData
            foreach (var store in MockData.AllStores)
            {
                // نصنع زر جديد لكل مطعم (كأنه كرت)
                Button btnStore = new Button();

                // --- تنسيق الزر (الشكل) ---
                btnStore.Text = store.Name + "\n" + store.Category; // الاسم والنوع
                btnStore.Size = new Size(150, 150); // حجم مربع
                btnStore.BackColor = Color.White;
                btnStore.FlatStyle = FlatStyle.Flat;

                // (اختياري) لو تبي تحطي صورة، لازم تكون مخزنة في الـ Store Object
                // btnStore.Image = ... 
                btnStore.TextAlign = ContentAlignment.BottomCenter;
                btnStore.Font = new Font("Arial", 10, FontStyle.Bold);

                // --- التفاعل (الحدث) ---
                // هنا السحر: نخزنوا المطعم داخل خاصية Tag في الزر عشان نعرفوه بعدين
                btnStore.Tag = store;

                // لما يضغط الزر، تنادى الدالة btnStore_Click
                btnStore.Click += BtnStore_Click;

                // 3. نضيف الزر للوحة
                flowPanelRestaurants.Controls.Add(btnStore);
            }
            */
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            Store selectedStore = (Store)clickedBtn.Tag;

            Customer dummyCustomer = new Customer
            {
                FullName = UserSession.CurrentUserName,
                Phone = UserSession.CurrentPhone,
                Email = UserSession.CurrentEmail,
                UserType = UserSession.CurrentRole
            };

            OrderSelectionForm orderForm = new OrderSelectionForm(dummyCustomer, selectedStore);

            // 🔑 نستخدم ShowDialog() للانتظار حتى يغلق العميل نموذج الطلب (بـ DialogResult.OK)
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                Order newOrder = orderForm.CreatedOrder;

                if (newOrder != null && newOrder.Items.Count > 0)
                {
                    // 1. إضافة الطلب إلى قاعدة البيانات المركزية (Singleton)
                    DeliveryManager.Instance.AddOrder(newOrder);

                    if (int.TryParse(newOrder.OrderNumber, out int orderId))
                    {
                        // 🔑 2. فتح نافذة تتبع العميل (المراقب)
                        OrderTrackingForm trackingForm = new OrderTrackingForm(orderId);
                        trackingForm.Show(); // Non-modal

                        // 🔑🔑 3. فتح نافذة إدارة الدليفري الجديدة
                        DeliveryManagementForm deliveryForm = new DeliveryManagementForm();
                        deliveryForm.Show(); // Non-modal

                        MessageBox.Show($"تم إرسال طلبك رقم {orderId} بنجاح! \nتم فتح نافذتي التتبع والإدارة للاختبار.", "تأكيد الطلب وبدء الاختبار");
                    }
                    else
                    {
                        MessageBox.Show("خطأ في تحديد رقم الطلب.", "خطأ داخلي");
                    }
                }
                else
                {
                    MessageBox.Show("لم يتم إنشاء الطلب أو السلة فارغة.", "إلغاء الطلب");
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
