namespace DistributedCacheWinform
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtVal = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dmpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCacheLimit = new System.Windows.Forms.ComboBox();
            this.lbReadVal = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtDelKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDateType = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbExpire = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "写入cache";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "键（key）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "值（value）";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(90, 17);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(234, 28);
            this.txtKey.TabIndex = 3;
            // 
            // txtVal
            // 
            this.txtVal.Location = new System.Drawing.Point(90, 51);
            this.txtVal.Multiline = true;
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(234, 29);
            this.txtVal.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "读取cache";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "批量删除cache";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(267, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "读取缓存列表";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dmpExpireDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbCacheLimit);
            this.groupBox1.Controls.Add(this.lbReadVal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtVal);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 217);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "写入缓存";
            // 
            // dmpExpireDate
            // 
            this.dmpExpireDate.Location = new System.Drawing.Point(90, 119);
            this.dmpExpireDate.Name = "dmpExpireDate";
            this.dmpExpireDate.Size = new System.Drawing.Size(200, 21);
            this.dmpExpireDate.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "过期时间:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "缓存限制";
            // 
            // cbCacheLimit
            // 
            this.cbCacheLimit.FormattingEnabled = true;
            this.cbCacheLimit.Items.AddRange(new object[] {
            "CurrentDay ",
            "Forever",
            "ByExpireDate",
            ""});
            this.cbCacheLimit.Location = new System.Drawing.Point(90, 93);
            this.cbCacheLimit.Name = "cbCacheLimit";
            this.cbCacheLimit.Size = new System.Drawing.Size(234, 20);
            this.cbCacheLimit.TabIndex = 7;
            this.cbCacheLimit.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbReadVal
            // 
            this.lbReadVal.AutoSize = true;
            this.lbReadVal.Location = new System.Drawing.Point(235, 173);
            this.lbReadVal.Name = "lbReadVal";
            this.lbReadVal.Size = new System.Drawing.Size(77, 12);
            this.lbReadVal.TabIndex = 6;
            this.lbReadVal.Text = "放置读取的值";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.txtDelKey);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbDateType);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbExpire);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtEnd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.dtStart);
            this.groupBox2.Location = new System.Drawing.Point(430, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 217);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "删除缓存";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(211, 117);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(175, 23);
            this.button8.TabIndex = 18;
            this.button8.Text = "删除永久数据";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(13, 117);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(175, 23);
            this.button7.TabIndex = 17;
            this.button7.Text = "删除头一天的数据";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(274, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "删除";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtDelKey
            // 
            this.txtDelKey.Location = new System.Drawing.Point(65, 159);
            this.txtDelKey.Name = "txtDelKey";
            this.txtDelKey.Size = new System.Drawing.Size(176, 21);
            this.txtDelKey.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "键(key):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "时间类型:";
            // 
            // cbDateType
            // 
            this.cbDateType.FormattingEnabled = true;
            this.cbDateType.Items.AddRange(new object[] {
            "CreateTime",
            "ExpireTime"});
            this.cbDateType.Location = new System.Drawing.Point(79, 53);
            this.cbDateType.Name = "cbDateType";
            this.cbDateType.Size = new System.Drawing.Size(121, 20);
            this.cbDateType.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(211, 80);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(180, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "只按是否过期条件删除";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "是否过期:";
            // 
            // cbExpire
            // 
            this.cbExpire.FormattingEnabled = true;
            this.cbExpire.Items.AddRange(new object[] {
            "ALL",
            "Expired",
            "NoExpired"});
            this.cbExpire.Location = new System.Drawing.Point(274, 54);
            this.cbExpire.Name = "cbExpire";
            this.cbExpire.Size = new System.Drawing.Size(121, 20);
            this.cbExpire.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "结束时间:";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(275, 21);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(120, 21);
            this.dtEnd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "开始时间:";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(79, 21);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(120, 21);
            this.dtStart.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(807, 246);
            this.dataGridView1.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(14, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(829, 301);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "读取缓存";
            // 
            // lstLog
            // 
            this.lstLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.lstLog.ForeColor = System.Drawing.Color.Green;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(12, 588);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(823, 172);
            this.lstLog.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 559);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "日志输出:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 772);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbReadVal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDateType;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbExpire;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtDelKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbCacheLimit;
        private System.Windows.Forms.DateTimePicker dmpExpireDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}

