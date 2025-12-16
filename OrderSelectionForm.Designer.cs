namespace desingPatternsFinalProject
{
    partial class OrderSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupbShoppingCart = new System.Windows.Forms.GroupBox();
            this.lblDeliveryCost = new System.Windows.Forms.Label();
            this.groupBoxDelivery = new System.Windows.Forms.GroupBox();
            this.rdbExpressDelivery = new System.Windows.Forms.RadioButton();
            this.rdbPickupDelivery = new System.Windows.Forms.RadioButton();
            this.rdbNormalDelivery = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.ListBox();
            this.btnTrackOrder = new System.Windows.Forms.Button();
            this.groupbShoppingCart.SuspendLayout();
            this.groupBoxDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.SuspendLayout();
            // 
            // groupbShoppingCart
            // 
            this.groupbShoppingCart.Controls.Add(this.lblDeliveryCost);
            this.groupbShoppingCart.Controls.Add(this.groupBoxDelivery);
            this.groupbShoppingCart.Controls.Add(this.btnSubmit);
            this.groupbShoppingCart.Controls.Add(this.lblTotal);
            this.groupbShoppingCart.Controls.Add(this.dgvCart);
            this.groupbShoppingCart.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbShoppingCart.Location = new System.Drawing.Point(416, 12);
            this.groupbShoppingCart.Name = "groupbShoppingCart";
            this.groupbShoppingCart.Size = new System.Drawing.Size(441, 369);
            this.groupbShoppingCart.TabIndex = 0;
            this.groupbShoppingCart.TabStop = false;
            this.groupbShoppingCart.Text = "Shopping Cart";
            this.groupbShoppingCart.Enter += new System.EventHandler(this.groupbShoppingCart_Enter);
            // 
            // lblDeliveryCost
            // 
            this.lblDeliveryCost.AutoSize = true;
            this.lblDeliveryCost.Location = new System.Drawing.Point(18, 211);
            this.lblDeliveryCost.Name = "lblDeliveryCost";
            this.lblDeliveryCost.Size = new System.Drawing.Size(123, 21);
            this.lblDeliveryCost.TabIndex = 5;
            this.lblDeliveryCost.Text = "Delivery Cost";
            // 
            // groupBoxDelivery
            // 
            this.groupBoxDelivery.Controls.Add(this.rdbExpressDelivery);
            this.groupBoxDelivery.Controls.Add(this.rdbPickupDelivery);
            this.groupBoxDelivery.Controls.Add(this.rdbNormalDelivery);
            this.groupBoxDelivery.Location = new System.Drawing.Point(244, 265);
            this.groupBoxDelivery.Name = "groupBoxDelivery";
            this.groupBoxDelivery.Size = new System.Drawing.Size(168, 104);
            this.groupBoxDelivery.TabIndex = 4;
            this.groupBoxDelivery.TabStop = false;
            this.groupBoxDelivery.Text = "Delivery Option";
            // 
            // rdbExpressDelivery
            // 
            this.rdbExpressDelivery.AutoSize = true;
            this.rdbExpressDelivery.Location = new System.Drawing.Point(6, 48);
            this.rdbExpressDelivery.Name = "rdbExpressDelivery";
            this.rdbExpressDelivery.Size = new System.Drawing.Size(97, 25);
            this.rdbExpressDelivery.TabIndex = 2;
            this.rdbExpressDelivery.Text = "Express";
            this.rdbExpressDelivery.UseVisualStyleBackColor = true;
            this.rdbExpressDelivery.CheckedChanged += new System.EventHandler(this.rdbNormalDelivery_CheckedChanged);
            // 
            // rdbPickupDelivery
            // 
            this.rdbPickupDelivery.AutoSize = true;
            this.rdbPickupDelivery.Location = new System.Drawing.Point(6, 73);
            this.rdbPickupDelivery.Name = "rdbPickupDelivery";
            this.rdbPickupDelivery.Size = new System.Drawing.Size(90, 25);
            this.rdbPickupDelivery.TabIndex = 1;
            this.rdbPickupDelivery.Text = "PickUp";
            this.rdbPickupDelivery.UseVisualStyleBackColor = true;
            this.rdbPickupDelivery.CheckedChanged += new System.EventHandler(this.rdbNormalDelivery_CheckedChanged);
            // 
            // rdbNormalDelivery
            // 
            this.rdbNormalDelivery.AutoSize = true;
            this.rdbNormalDelivery.Checked = true;
            this.rdbNormalDelivery.Location = new System.Drawing.Point(6, 27);
            this.rdbNormalDelivery.Name = "rdbNormalDelivery";
            this.rdbNormalDelivery.Size = new System.Drawing.Size(93, 25);
            this.rdbNormalDelivery.TabIndex = 0;
            this.rdbNormalDelivery.TabStop = true;
            this.rdbNormalDelivery.Text = "Normal";
            this.rdbNormalDelivery.UseVisualStyleBackColor = true;
            this.rdbNormalDelivery.CheckedChanged += new System.EventHandler(this.rdbNormalDelivery_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(22, 284);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(134, 44);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(18, 180);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 21);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total";
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Price,
            this.Quantity});
            this.dgvCart.Location = new System.Drawing.Point(7, 23);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 26;
            this.dgvCart.Size = new System.Drawing.Size(427, 144);
            this.dgvCart.TabIndex = 1;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.MinimumWidth = 6;
            this.Product.Name = "Product";
            this.Product.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numQty);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.Menu);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 424);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(129, 313);
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(93, 28);
            this.numQty.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(276, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 44);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 28);
            this.textBox1.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(224, 256);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 44);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(63, 254);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(105, 44);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Menu
            // 
            this.Menu.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu.FormattingEnabled = true;
            this.Menu.ItemHeight = 21;
            this.Menu.Location = new System.Drawing.Point(19, 81);
            this.Menu.Name = "Menu";
            this.Menu.ScrollAlwaysVisible = true;
            this.Menu.Size = new System.Drawing.Size(344, 151);
            this.Menu.TabIndex = 0;
            this.Menu.SelectedIndexChanged += new System.EventHandler(this.lstMenu_SelectedIndexChanged);
            // 
            // btnTrackOrder
            // 
            this.btnTrackOrder.Location = new System.Drawing.Point(592, 393);
            this.btnTrackOrder.Name = "btnTrackOrder";
            this.btnTrackOrder.Size = new System.Drawing.Size(236, 34);
            this.btnTrackOrder.TabIndex = 2;
            this.btnTrackOrder.Text = "تتبع حالة الطلب 📦";
            this.btnTrackOrder.UseVisualStyleBackColor = true;
            this.btnTrackOrder.Click += new System.EventHandler(this.btnTrackOrder_Click);
            // 
            // OrderSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 442);
            this.Controls.Add(this.btnTrackOrder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupbShoppingCart);
            this.Name = "OrderSelectionForm";
            this.Text = "OrderSelectionForm";
            this.Load += new System.EventHandler(this.OrderSelectionForm_Load);
            this.groupbShoppingCart.ResumeLayout(false);
            this.groupbShoppingCart.PerformLayout();
            this.groupBoxDelivery.ResumeLayout(false);
            this.groupBoxDelivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbShoppingCart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox Menu;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnTrackOrder;
        private System.Windows.Forms.GroupBox groupBoxDelivery;
        private System.Windows.Forms.RadioButton rdbExpressDelivery;
        private System.Windows.Forms.RadioButton rdbPickupDelivery;
        private System.Windows.Forms.RadioButton rdbNormalDelivery;
        private System.Windows.Forms.Label lblDeliveryCost;
    }
}