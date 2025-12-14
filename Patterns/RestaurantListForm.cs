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
        public RestaurantListForm()
        {
            InitializeComponent();
        }

        private void RestaurantListForm_Load(object sender, EventArgs e)
        {
            LoadRestaurants();
        }
        private void LoadRestaurants()
        {
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

        }
        private void BtnStore_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;

            Store selectedStore = (Store)clickedBtn.Tag;

            Customer customer = new Customer();
             
            OrderSelectionForm orderForm = new OrderSelectionForm(customer, selectedStore);
            orderForm.Show();

            // this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
