namespace desingPatternsFinalProject
{
    partial class OrderTrackingForm
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
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.labelStaticOrderNumber = new System.Windows.Forms.Label();
            this.labelStaticStore = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.labelStaticTotal = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDeliveryType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEstimateTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.txtLiveUpdates = new System.Windows.Forms.TextBox();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBoxDetails.Controls.Add(this.lblTotalAmount);
            this.groupBoxDetails.Controls.Add(this.labelStaticTotal);
            this.groupBoxDetails.Controls.Add(this.lblStoreName);
            this.groupBoxDetails.Controls.Add(this.labelStaticStore);
            this.groupBoxDetails.Controls.Add(this.labelStaticOrderNumber);
            this.groupBoxDetails.Controls.Add(this.lblOrderNumber);
            this.groupBoxDetails.Location = new System.Drawing.Point(713, 126);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(257, 216);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Order Detials";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.lblEstimateTime);
            this.groupBoxStatus.Controls.Add(this.lblCurrentStatus);
            this.groupBoxStatus.Controls.Add(this.lblDeliveryType);
            this.groupBoxStatus.Controls.Add(this.label5);
            this.groupBoxStatus.Controls.Add(this.label1);
            this.groupBoxStatus.Controls.Add(this.label3);
            this.groupBoxStatus.Location = new System.Drawing.Point(375, 136);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(308, 206);
            this.groupBoxStatus.TabIndex = 1;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Order Status";
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.txtLiveUpdates);
            this.groupBoxLog.Location = new System.Drawing.Point(118, 136);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(237, 206);
            this.groupBoxLog.TabIndex = 2;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Update Log";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(178, 49);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(57, 17);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Number";
            // 
            // labelStaticOrderNumber
            // 
            this.labelStaticOrderNumber.AutoSize = true;
            this.labelStaticOrderNumber.Location = new System.Drawing.Point(17, 49);
            this.labelStaticOrderNumber.Name = "labelStaticOrderNumber";
            this.labelStaticOrderNumber.Size = new System.Drawing.Size(96, 17);
            this.labelStaticOrderNumber.TabIndex = 1;
            this.labelStaticOrderNumber.Text = "Order Number";
            // 
            // labelStaticStore
            // 
            this.labelStaticStore.AutoSize = true;
            this.labelStaticStore.Location = new System.Drawing.Point(40, 108);
            this.labelStaticStore.Name = "labelStaticStore";
            this.labelStaticStore.Size = new System.Drawing.Size(41, 17);
            this.labelStaticStore.TabIndex = 2;
            this.labelStaticStore.Text = "Store";
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Location = new System.Drawing.Point(155, 108);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(80, 17);
            this.lblStoreName.TabIndex = 3;
            this.lblStoreName.Text = "Store Name";
            // 
            // labelStaticTotal
            // 
            this.labelStaticTotal.AutoSize = true;
            this.labelStaticTotal.Location = new System.Drawing.Point(40, 174);
            this.labelStaticTotal.Name = "labelStaticTotal";
            this.labelStaticTotal.Size = new System.Drawing.Size(38, 17);
            this.labelStaticTotal.TabIndex = 4;
            this.labelStaticTotal.Text = "Total";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(178, 174);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(44, 17);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "0.00$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Delivery Type";
            // 
            // lblDeliveryType
            // 
            this.lblDeliveryType.AutoSize = true;
            this.lblDeliveryType.Location = new System.Drawing.Point(125, 49);
            this.lblDeliveryType.Name = "lblDeliveryType";
            this.lblDeliveryType.Size = new System.Drawing.Size(43, 17);
            this.lblDeliveryType.TabIndex = 3;
            this.lblDeliveryType.Text = "N/E/P";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estemited Time";
            // 
            // lblEstimateTime
            // 
            this.lblEstimateTime.AutoSize = true;
            this.lblEstimateTime.Location = new System.Drawing.Point(125, 93);
            this.lblEstimateTime.Name = "lblEstimateTime";
            this.lblEstimateTime.Size = new System.Drawing.Size(49, 17);
            this.lblEstimateTime.TabIndex = 4;
            this.lblEstimateTime.Text = "mm:ss";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Current State";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Location = new System.Drawing.Point(125, 145);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(28, 17);
            this.lblCurrentStatus.TabIndex = 6;
            this.lblCurrentStatus.Text = ".....";
            // 
            // txtLiveUpdates
            // 
            this.txtLiveUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLiveUpdates.Location = new System.Drawing.Point(3, 20);
            this.txtLiveUpdates.Multiline = true;
            this.txtLiveUpdates.Name = "txtLiveUpdates";
            this.txtLiveUpdates.ReadOnly = true;
            this.txtLiveUpdates.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLiveUpdates.Size = new System.Drawing.Size(231, 183);
            this.txtLiveUpdates.TabIndex = 0;
            // 
            // OrderTrackingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 512);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxDetails);
            this.Name = "OrderTrackingForm";
            this.Text = "OrderTrackingForm";
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label labelStaticTotal;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label labelStaticStore;
        private System.Windows.Forms.Label labelStaticOrderNumber;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblEstimateTime;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblDeliveryType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLiveUpdates;
    }
}