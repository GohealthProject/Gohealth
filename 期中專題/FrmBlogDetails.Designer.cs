namespace 期中專題
{
    partial class FrmBlogDetails
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
            this.txtBlogDetailTitle = new System.Windows.Forms.TextBox();
            this.lblBlogDetailTitle = new System.Windows.Forms.Label();
            this.btnBrowseChangePic = new System.Windows.Forms.Button();
            this.pbDetailImage = new System.Windows.Forms.PictureBox();
            this.cbBlogDetailCategory = new System.Windows.Forms.ComboBox();
            this.rtbBlogDetailContent = new System.Windows.Forms.RichTextBox();
            this.btnUpDateBlog = new System.Windows.Forms.Button();
            this.btnDeleteBlog = new System.Windows.Forms.Button();
            this.txtBlogDetailID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBlogClassID = new System.Windows.Forms.Label();
            this.lblBlogID = new System.Windows.Forms.Label();
            this.listiD = new System.Windows.Forms.ListBox();
            this.btnReplyDel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listReply = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetailImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBlogDetailTitle
            // 
            this.txtBlogDetailTitle.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtBlogDetailTitle.Location = new System.Drawing.Point(116, 67);
            this.txtBlogDetailTitle.Name = "txtBlogDetailTitle";
            this.txtBlogDetailTitle.Size = new System.Drawing.Size(164, 29);
            this.txtBlogDetailTitle.TabIndex = 23;
            // 
            // lblBlogDetailTitle
            // 
            this.lblBlogDetailTitle.AutoSize = true;
            this.lblBlogDetailTitle.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.lblBlogDetailTitle.Location = new System.Drawing.Point(35, 66);
            this.lblBlogDetailTitle.Name = "lblBlogDetailTitle";
            this.lblBlogDetailTitle.Size = new System.Drawing.Size(52, 24);
            this.lblBlogDetailTitle.TabIndex = 22;
            this.lblBlogDetailTitle.Text = "標題:";
            // 
            // btnBrowseChangePic
            // 
            this.btnBrowseChangePic.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnBrowseChangePic.Location = new System.Drawing.Point(802, 439);
            this.btnBrowseChangePic.Name = "btnBrowseChangePic";
            this.btnBrowseChangePic.Size = new System.Drawing.Size(125, 38);
            this.btnBrowseChangePic.TabIndex = 21;
            this.btnBrowseChangePic.Text = "Browse...";
            this.btnBrowseChangePic.UseVisualStyleBackColor = true;
            this.btnBrowseChangePic.Click += new System.EventHandler(this.btnBrowseChangePic_Click);
            // 
            // pbDetailImage
            // 
            this.pbDetailImage.Location = new System.Drawing.Point(802, 154);
            this.pbDetailImage.Name = "pbDetailImage";
            this.pbDetailImage.Size = new System.Drawing.Size(345, 275);
            this.pbDetailImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDetailImage.TabIndex = 20;
            this.pbDetailImage.TabStop = false;
            // 
            // cbBlogDetailCategory
            // 
            this.cbBlogDetailCategory.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbBlogDetailCategory.FormattingEnabled = true;
            this.cbBlogDetailCategory.Location = new System.Drawing.Point(116, 105);
            this.cbBlogDetailCategory.Name = "cbBlogDetailCategory";
            this.cbBlogDetailCategory.Size = new System.Drawing.Size(199, 28);
            this.cbBlogDetailCategory.TabIndex = 19;
            // 
            // rtbBlogDetailContent
            // 
            this.rtbBlogDetailContent.Location = new System.Drawing.Point(116, 154);
            this.rtbBlogDetailContent.Name = "rtbBlogDetailContent";
            this.rtbBlogDetailContent.Size = new System.Drawing.Size(676, 408);
            this.rtbBlogDetailContent.TabIndex = 18;
            this.rtbBlogDetailContent.Text = "";
            // 
            // btnUpDateBlog
            // 
            this.btnUpDateBlog.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnUpDateBlog.Location = new System.Drawing.Point(802, 524);
            this.btnUpDateBlog.Name = "btnUpDateBlog";
            this.btnUpDateBlog.Size = new System.Drawing.Size(125, 38);
            this.btnUpDateBlog.TabIndex = 17;
            this.btnUpDateBlog.Text = "修改";
            this.btnUpDateBlog.UseVisualStyleBackColor = true;
            this.btnUpDateBlog.Click += new System.EventHandler(this.btnUpDateBlog_Click);
            // 
            // btnDeleteBlog
            // 
            this.btnDeleteBlog.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnDeleteBlog.Location = new System.Drawing.Point(937, 524);
            this.btnDeleteBlog.Name = "btnDeleteBlog";
            this.btnDeleteBlog.Size = new System.Drawing.Size(125, 38);
            this.btnDeleteBlog.TabIndex = 16;
            this.btnDeleteBlog.Text = "刪除";
            this.btnDeleteBlog.UseVisualStyleBackColor = true;
            this.btnDeleteBlog.Click += new System.EventHandler(this.btnDeleteBlog_Click);
            // 
            // txtBlogDetailID
            // 
            this.txtBlogDetailID.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtBlogDetailID.Location = new System.Drawing.Point(116, 27);
            this.txtBlogDetailID.Name = "txtBlogDetailID";
            this.txtBlogDetailID.Size = new System.Drawing.Size(164, 29);
            this.txtBlogDetailID.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.label1.Location = new System.Drawing.Point(16, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "文章內容:";
            // 
            // lblBlogClassID
            // 
            this.lblBlogClassID.AutoSize = true;
            this.lblBlogClassID.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.lblBlogClassID.Location = new System.Drawing.Point(16, 105);
            this.lblBlogClassID.Name = "lblBlogClassID";
            this.lblBlogClassID.Size = new System.Drawing.Size(90, 24);
            this.lblBlogClassID.TabIndex = 13;
            this.lblBlogClassID.Text = "文章類別:";
            // 
            // lblBlogID
            // 
            this.lblBlogID.AutoSize = true;
            this.lblBlogID.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.lblBlogID.Location = new System.Drawing.Point(35, 32);
            this.lblBlogID.Name = "lblBlogID";
            this.lblBlogID.Size = new System.Drawing.Size(71, 24);
            this.lblBlogID.TabIndex = 12;
            this.lblBlogID.Text = "文章ID:";
            // 
            // listiD
            // 
            this.listiD.FormattingEnabled = true;
            this.listiD.ItemHeight = 12;
            this.listiD.Location = new System.Drawing.Point(730, 577);
            this.listiD.Name = "listiD";
            this.listiD.Size = new System.Drawing.Size(63, 220);
            this.listiD.TabIndex = 38;
            this.listiD.Visible = false;
            this.listiD.SelectedIndexChanged += new System.EventHandler(this.listiD_SelectedIndexChanged);
            // 
            // btnReplyDel
            // 
            this.btnReplyDel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnReplyDel.Location = new System.Drawing.Point(1059, 682);
            this.btnReplyDel.Name = "btnReplyDel";
            this.btnReplyDel.Size = new System.Drawing.Size(99, 42);
            this.btnReplyDel.TabIndex = 37;
            this.btnReplyDel.Text = "刪除";
            this.btnReplyDel.UseVisualStyleBackColor = true;
            this.btnReplyDel.Click += new System.EventHandler(this.btnReplyDel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.textBox1.Location = new System.Drawing.Point(937, 597);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 29);
            this.textBox1.TabIndex = 36;
            // 
            // listReply
            // 
            this.listReply.FormattingEnabled = true;
            this.listReply.ItemHeight = 12;
            this.listReply.Location = new System.Drawing.Point(116, 577);
            this.listReply.Name = "listReply";
            this.listReply.Size = new System.Drawing.Size(677, 220);
            this.listReply.TabIndex = 35;
            this.listReply.SelectedIndexChanged += new System.EventHandler(this.listReply_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(12, 567);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1146, 2);
            this.label3.TabIndex = 34;
            // 
            // btnReply
            // 
            this.btnReply.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnReply.Location = new System.Drawing.Point(1059, 634);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(99, 42);
            this.btnReply.TabIndex = 33;
            this.btnReply.Text = "回覆";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(837, 602);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 31;
            this.label4.Text = "回覆評論:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(18, 577);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 32;
            this.label2.Text = "用戶評論:";
            // 
            // FrmBlogDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 813);
            this.Controls.Add(this.listiD);
            this.Controls.Add(this.btnReplyDel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listReply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBlogDetailTitle);
            this.Controls.Add(this.lblBlogDetailTitle);
            this.Controls.Add(this.btnBrowseChangePic);
            this.Controls.Add(this.pbDetailImage);
            this.Controls.Add(this.cbBlogDetailCategory);
            this.Controls.Add(this.rtbBlogDetailContent);
            this.Controls.Add(this.btnUpDateBlog);
            this.Controls.Add(this.btnDeleteBlog);
            this.Controls.Add(this.txtBlogDetailID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBlogClassID);
            this.Controls.Add(this.lblBlogID);
            this.Name = "FrmBlogDetails";
            this.Text = "FrmBlogDetails";
            this.Load += new System.EventHandler(this.FrmBlogDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDetailImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBlogDetailTitle;
        private System.Windows.Forms.Label lblBlogDetailTitle;
        private System.Windows.Forms.Button btnBrowseChangePic;
        private System.Windows.Forms.PictureBox pbDetailImage;
        private System.Windows.Forms.ComboBox cbBlogDetailCategory;
        private System.Windows.Forms.RichTextBox rtbBlogDetailContent;
        private System.Windows.Forms.Button btnUpDateBlog;
        private System.Windows.Forms.Button btnDeleteBlog;
        private System.Windows.Forms.TextBox txtBlogDetailID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBlogClassID;
        private System.Windows.Forms.Label lblBlogID;
        private System.Windows.Forms.ListBox listiD;
        private System.Windows.Forms.Button btnReplyDel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listReply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}