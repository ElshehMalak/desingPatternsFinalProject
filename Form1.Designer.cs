namespace desingPatternsFinalProject
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabControlMain = new System.Windows.Forms.TabPage();
            this.groupbOrderInfo = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnOpenStore = new System.Windows.Forms.Button();
            this.groupbStoreInfo = new System.Windows.Forms.GroupBox();
            this.lstStores = new System.Windows.Forms.ListBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefreshAdmin = new System.Windows.Forms.Button();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.btnShipOrder = new System.Windows.Forms.Button();
            this.btnStartCooking = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.groupbOrderInfo.SuspendLayout();
            this.groupbStoreInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabControlMain);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 384);
            this.tabControl1.TabIndex = 5;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.groupbOrderInfo);
            this.tabControlMain.Controls.Add(this.groupbStoreInfo);
            this.tabControlMain.Controls.Add(this.groupBox1);
            this.tabControlMain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(4, 25);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlMain.Size = new System.Drawing.Size(889, 355);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.Text = "customerTab";
            this.tabControlMain.UseVisualStyleBackColor = true;
            this.tabControlMain.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupbOrderInfo
            // 
            this.groupbOrderInfo.Controls.Add(this.lblType);
            this.groupbOrderInfo.Controls.Add(this.cmbType);
            this.groupbOrderInfo.Controls.Add(this.btnOpenStore);
            this.groupbOrderInfo.Location = new System.Drawing.Point(17, 188);
            this.groupbOrderInfo.Name = "groupbOrderInfo";
            this.groupbOrderInfo.Size = new System.Drawing.Size(508, 173);
            this.groupbOrderInfo.TabIndex = 9;
            this.groupbOrderInfo.TabStop = false;
            this.groupbOrderInfo.Text = "Order Info";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(24, 44);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(123, 24);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Order Type";
            this.lblType.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(211, 44);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(222, 32);
            this.cmbType.TabIndex = 5;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // btnOpenStore
            // 
            this.btnOpenStore.Location = new System.Drawing.Point(276, 102);
            this.btnOpenStore.Name = "btnOpenStore";
            this.btnOpenStore.Size = new System.Drawing.Size(211, 37);
            this.btnOpenStore.TabIndex = 6;
            this.btnOpenStore.Text = "Open Store";
            this.btnOpenStore.UseVisualStyleBackColor = true;
            this.btnOpenStore.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // groupbStoreInfo
            // 
            this.groupbStoreInfo.Controls.Add(this.lstStores);
            this.groupbStoreInfo.Controls.Add(this.lblSearch);
            this.groupbStoreInfo.Controls.Add(this.txtSearch);
            this.groupbStoreInfo.Location = new System.Drawing.Point(541, 19);
            this.groupbStoreInfo.Name = "groupbStoreInfo";
            this.groupbStoreInfo.Size = new System.Drawing.Size(340, 342);
            this.groupbStoreInfo.TabIndex = 8;
            this.groupbStoreInfo.TabStop = false;
            this.groupbStoreInfo.Text = "Store Info";
            // 
            // lstStores
            // 
            this.lstStores.FormattingEnabled = true;
            this.lstStores.ItemHeight = 24;
            this.lstStores.Location = new System.Drawing.Point(19, 97);
            this.lstStores.Name = "lstStores";
            this.lstStores.Size = new System.Drawing.Size(306, 172);
            this.lstStores.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(15, 52);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(80, 24);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(101, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(208, 32);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Location = new System.Drawing.Point(17, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 163);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Info";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(211, 45);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(276, 32);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name ";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(24, 105);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(160, 24);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "Phone Number";
            this.lblNumber.Click += new System.EventHandler(this.lblNumber_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(211, 97);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(211, 32);
            this.txtPhone.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.dgvOrders);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefreshAdmin);
            this.panel1.Controls.Add(this.btnCompleteOrder);
            this.panel1.Controls.Add(this.btnShipOrder);
            this.panel1.Controls.Add(this.btnStartCooking);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 103);
            this.panel1.TabIndex = 1;
            // 
            // btnRefreshAdmin
            // 
            this.btnRefreshAdmin.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshAdmin.Location = new System.Drawing.Point(544, 33);
            this.btnRefreshAdmin.Name = "btnRefreshAdmin";
            this.btnRefreshAdmin.Size = new System.Drawing.Size(157, 43);
            this.btnRefreshAdmin.TabIndex = 3;
            this.btnRefreshAdmin.Text = "Refresh";
            this.btnRefreshAdmin.UseVisualStyleBackColor = true;
            this.btnRefreshAdmin.Click += new System.EventHandler(this.btnRefreshAdmin_Click);
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteOrder.Location = new System.Drawing.Point(339, 33);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(157, 43);
            this.btnCompleteOrder.TabIndex = 2;
            this.btnCompleteOrder.Text = "Complete";
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            this.btnCompleteOrder.Click += new System.EventHandler(this.btnCompleteOrder_Click);
            // 
            // btnShipOrder
            // 
            this.btnShipOrder.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShipOrder.Location = new System.Drawing.Point(153, 33);
            this.btnShipOrder.Name = "btnShipOrder";
            this.btnShipOrder.Size = new System.Drawing.Size(131, 43);
            this.btnShipOrder.TabIndex = 1;
            this.btnShipOrder.Text = "Ship Order";
            this.btnShipOrder.UseVisualStyleBackColor = true;
            this.btnShipOrder.Click += new System.EventHandler(this.btnShipOrder_Click);
            // 
            // btnStartCooking
            // 
            this.btnStartCooking.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartCooking.Location = new System.Drawing.Point(16, 33);
            this.btnStartCooking.Name = "btnStartCooking";
            this.btnStartCooking.Size = new System.Drawing.Size(102, 43);
            this.btnStartCooking.TabIndex = 0;
            this.btnStartCooking.Text = "Start";
            this.btnStartCooking.UseVisualStyleBackColor = true;
            this.btnStartCooking.Click += new System.EventHandler(this.btnStartCooking_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(3, 3);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 26;
            this.dgvOrders.Size = new System.Drawing.Size(883, 349);
            this.dgvOrders.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 408);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.groupbOrderInfo.ResumeLayout(false);
            this.groupbOrderInfo.PerformLayout();
            this.groupbStoreInfo.ResumeLayout(false);
            this.groupbStoreInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabControlMain;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnOpenStore;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox groupbOrderInfo;
        private System.Windows.Forms.GroupBox groupbStoreInfo;
        private System.Windows.Forms.ListBox lstStores;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.Button btnShipOrder;
        private System.Windows.Forms.Button btnStartCooking;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnRefreshAdmin;
    }
}

