namespace 期中專題
{
    partial class FrmRPgenerate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRPgenerate));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rpBtn = new System.Windows.Forms.Button();
            this.rpTbx = new System.Windows.Forms.TextBox();
            this.rpLbl1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rbtReserved = new System.Windows.Forms.RadioButton();
            this.rbtReserveSub = new System.Windows.Forms.RadioButton();
            this.rbtHealthReport = new System.Windows.Forms.RadioButton();
            this.rbtHealthReportDetail = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.rpComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rpLblSchma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(338, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(738, 496);
            this.dataGridView1.TabIndex = 0;
            // 
            // rpBtn
            // 
            this.rpBtn.Font = new System.Drawing.Font("新細明體", 9F);
            this.rpBtn.Location = new System.Drawing.Point(305, 117);
            this.rpBtn.Name = "rpBtn";
            this.rpBtn.Size = new System.Drawing.Size(75, 23);
            this.rpBtn.TabIndex = 1;
            this.rpBtn.Text = "搜尋";
            this.rpBtn.UseVisualStyleBackColor = true;
            this.rpBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // rpTbx
            // 
            this.rpTbx.Font = new System.Drawing.Font("新細明體", 9F);
            this.rpTbx.Location = new System.Drawing.Point(194, 117);
            this.rpTbx.Name = "rpTbx";
            this.rpTbx.Size = new System.Drawing.Size(100, 22);
            this.rpTbx.TabIndex = 2;
            // 
            // rpLbl1
            // 
            this.rpLbl1.AutoSize = true;
            this.rpLbl1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rpLbl1.Location = new System.Drawing.Point(7, 95);
            this.rpLbl1.Name = "rpLbl1";
            this.rpLbl1.Size = new System.Drawing.Size(42, 21);
            this.rpLbl1.TabIndex = 3;
            this.rpLbl1.Text = "欄位";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(829, 198);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(247, 25);
            this.bindingNavigator1.TabIndex = 4;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "刪除";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // rbtReserved
            // 
            this.rbtReserved.AutoSize = true;
            this.rbtReserved.Font = new System.Drawing.Font("新細明體", 9F);
            this.rbtReserved.Location = new System.Drawing.Point(44, 56);
            this.rbtReserved.Name = "rbtReserved";
            this.rbtReserved.Size = new System.Drawing.Size(47, 16);
            this.rbtReserved.TabIndex = 5;
            this.rbtReserved.TabStop = true;
            this.rbtReserved.Text = "預約";
            this.rbtReserved.UseVisualStyleBackColor = true;
            this.rbtReserved.CheckedChanged += new System.EventHandler(this.rbtReserved_CheckedChanged);
            // 
            // rbtReserveSub
            // 
            this.rbtReserveSub.AutoSize = true;
            this.rbtReserveSub.Font = new System.Drawing.Font("新細明體", 9F);
            this.rbtReserveSub.Location = new System.Drawing.Point(117, 56);
            this.rbtReserveSub.Name = "rbtReserveSub";
            this.rbtReserveSub.Size = new System.Drawing.Size(71, 16);
            this.rbtReserveSub.TabIndex = 5;
            this.rbtReserveSub.TabStop = true;
            this.rbtReserveSub.Text = "預約詳細";
            this.rbtReserveSub.UseVisualStyleBackColor = true;
            this.rbtReserveSub.CheckedChanged += new System.EventHandler(this.rbtReservedSub_CheckedChanged);
            // 
            // rbtHealthReport
            // 
            this.rbtHealthReport.AutoSize = true;
            this.rbtHealthReport.Font = new System.Drawing.Font("新細明體", 9F);
            this.rbtHealthReport.Location = new System.Drawing.Point(213, 56);
            this.rbtHealthReport.Name = "rbtHealthReport";
            this.rbtHealthReport.Size = new System.Drawing.Size(71, 16);
            this.rbtHealthReport.TabIndex = 5;
            this.rbtHealthReport.TabStop = true;
            this.rbtHealthReport.Text = "健檢報告";
            this.rbtHealthReport.UseVisualStyleBackColor = true;
            this.rbtHealthReport.CheckedChanged += new System.EventHandler(this.rbtHealthReport_CheckedChanged);
            // 
            // rbtHealthReportDetail
            // 
            this.rbtHealthReportDetail.AutoSize = true;
            this.rbtHealthReportDetail.Font = new System.Drawing.Font("新細明體", 9F);
            this.rbtHealthReportDetail.Location = new System.Drawing.Point(305, 56);
            this.rbtHealthReportDetail.Name = "rbtHealthReportDetail";
            this.rbtHealthReportDetail.Size = new System.Drawing.Size(71, 16);
            this.rbtHealthReportDetail.TabIndex = 5;
            this.rbtHealthReportDetail.TabStop = true;
            this.rbtHealthReportDetail.Text = "健檢詳細";
            this.rbtHealthReportDetail.UseVisualStyleBackColor = true;
            this.rbtHealthReportDetail.CheckedChanged += new System.EventHandler(this.rbtHealthReportDetail_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1172, 699);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Saved";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(-2, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(136, 128);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // rpComboBox
            // 
            this.rpComboBox.Font = new System.Drawing.Font("新細明體", 9F);
            this.rpComboBox.FormattingEnabled = true;
            this.rpComboBox.Location = new System.Drawing.Point(44, 119);
            this.rpComboBox.Name = "rpComboBox";
            this.rpComboBox.Size = new System.Drawing.Size(121, 20);
            this.rpComboBox.TabIndex = 8;
            this.rpComboBox.SelectedIndexChanged += new System.EventHandler(this.rpComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtReserveSub);
            this.groupBox1.Controls.Add(this.rpComboBox);
            this.groupBox1.Controls.Add(this.rpBtn);
            this.groupBox1.Controls.Add(this.rpTbx);
            this.groupBox1.Controls.Add(this.rpLblSchma);
            this.groupBox1.Controls.Add(this.rpLbl1);
            this.groupBox1.Controls.Add(this.rbtHealthReportDetail);
            this.groupBox1.Controls.Add(this.rbtReserved);
            this.groupBox1.Controls.Add(this.rbtHealthReport);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(364, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 153);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // rpLblSchma
            // 
            this.rpLblSchma.AutoSize = true;
            this.rpLblSchma.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rpLblSchma.Location = new System.Drawing.Point(7, 27);
            this.rpLblSchma.Name = "rpLblSchma";
            this.rpLblSchma.Size = new System.Drawing.Size(58, 21);
            this.rpLblSchma.TabIndex = 3;
            this.rpLblSchma.Text = "資料表";
            // 
            // FrmRPgenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1364, 757);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRPgenerate";
            this.Text = "FrmRPgenerate";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button rpBtn;
        private System.Windows.Forms.TextBox rpTbx;
        private System.Windows.Forms.Label rpLbl1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.RadioButton rbtReserved;
        private System.Windows.Forms.RadioButton rbtReserveSub;
        private System.Windows.Forms.RadioButton rbtHealthReport;
        private System.Windows.Forms.RadioButton rbtHealthReportDetail;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox rpComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label rpLblSchma;
    }
}