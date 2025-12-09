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
                this.Hide();

                if (shopForm.ShowDialog() == DialogResult.OK)
                {
                    var finalOrder = shopForm.CreatedOrder;

                    DeliveryManager.Instance.AddOrder(finalOrder.ToString());

                    MessageBox.Show(
                        $"تم استلام طلبك بنجاح! ✅\n" +
                        $"رقم الطلب: {finalOrder.OrderNumber}\n" +
                        $"الإجمالي: {finalOrder.CalculateTotal():C}\n\n" +
                        $"حالة الطلب:\n{finalOrder.ProcessOrder()}",
                        "نجاح العملية");
                }

                this.Show(); // إظهار الفورم مجدداً  
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
    }
}
