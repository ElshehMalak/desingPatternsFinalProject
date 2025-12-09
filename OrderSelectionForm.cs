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

namespace desingPatternsFinalProject
{
    public partial class OrderSelectionForm : Form
    {
        private Customer _customer;
        private Store _store;
        private BindingList<OrderItem> _cartItems;
        public Order CreatedOrder { get; private set; }
        public OrderSelectionForm(Customer customer, Store store)
        {
            InitializeComponent();
            _customer = customer;
            _store = store; 

            _cartItems = new BindingList<OrderItem>();
            dgvCart.DataSource = _cartItems;
        }
        private void OrderSelectionForm_Load(object sender, EventArgs e)
        {
            this.Text = $"التسوق من: {_store.Name}";

            Menu.DataSource = _store.Menu;
            Menu.DisplayMember = "Name";

            lblTotal.Text = "0.00 $";
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
            CreatedOrder = OrderFactory.CreateOrder(_store.Category, _customer, _store.Name);

            // 2. نضيف المنتجات من السلة للطلب
            foreach (var item in _cartItems)
            {
                CreatedOrder.AddItem(item.Product, item.Quantity);
            }

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
        }
    }
}
