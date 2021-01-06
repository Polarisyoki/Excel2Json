
namespace Excel2Json
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MyTip1 = new System.Windows.Forms.Label();
            this.Url1 = new System.Windows.Forms.TextBox();
            this.Bt1 = new System.Windows.Forms.Button();
            this.Options_box = new System.Windows.Forms.GroupBox();
            this.MyTip2 = new System.Windows.Forms.Label();
            this.Option_dataformat_comboBox = new System.Windows.Forms.ComboBox();
            this.Option_dataformat_title = new System.Windows.Forms.Label();
            this.Option_header_comboBox = new System.Windows.Forms.ComboBox();
            this.Options_header_title = new System.Windows.Forms.Label();
            this.Option_encoding_comboBox = new System.Windows.Forms.ComboBox();
            this.Option_encoding_title = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.Button();
            this.Options_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyTip1
            // 
            this.MyTip1.AutoSize = true;
            this.MyTip1.Location = new System.Drawing.Point(30, 28);
            this.MyTip1.Name = "MyTip1";
            this.MyTip1.Size = new System.Drawing.Size(119, 12);
            this.MyTip1.TabIndex = 0;
            this.MyTip1.Text = "How can I use this?";
            // 
            // Url1
            // 
            this.Url1.CausesValidation = false;
            this.Url1.Location = new System.Drawing.Point(32, 43);
            this.Url1.Name = "Url1";
            this.Url1.ReadOnly = true;
            this.Url1.Size = new System.Drawing.Size(479, 21);
            this.Url1.TabIndex = 1;
            this.Url1.TabStop = false;
            // 
            // Bt1
            // 
            this.Bt1.Location = new System.Drawing.Point(517, 41);
            this.Bt1.Name = "Bt1";
            this.Bt1.Size = new System.Drawing.Size(75, 23);
            this.Bt1.TabIndex = 2;
            this.Bt1.Text = "浏览";
            this.Bt1.UseVisualStyleBackColor = true;
            this.Bt1.Click += new System.EventHandler(this.Bt1_Click);
            // 
            // Options_box
            // 
            this.Options_box.Controls.Add(this.MyTip2);
            this.Options_box.Controls.Add(this.Option_dataformat_comboBox);
            this.Options_box.Controls.Add(this.Option_dataformat_title);
            this.Options_box.Controls.Add(this.Option_header_comboBox);
            this.Options_box.Controls.Add(this.Options_header_title);
            this.Options_box.Controls.Add(this.Option_encoding_comboBox);
            this.Options_box.Controls.Add(this.Option_encoding_title);
            this.Options_box.Location = new System.Drawing.Point(32, 70);
            this.Options_box.Name = "Options_box";
            this.Options_box.Size = new System.Drawing.Size(560, 125);
            this.Options_box.TabIndex = 6;
            this.Options_box.TabStop = false;
            this.Options_box.Text = "选项";
            // 
            // MyTip2
            // 
            this.MyTip2.AutoSize = true;
            this.MyTip2.Location = new System.Drawing.Point(254, 32);
            this.MyTip2.Name = "MyTip2";
            this.MyTip2.Size = new System.Drawing.Size(275, 72);
            this.MyTip2.TabIndex = 6;
            this.MyTip2.Text = "备注：\r\n·Excel第一行固定作为列名，第二行固定为为类型\r\n·当前版本数据默认从第一列开始\r\n·Header代表Excel表头有几行\r\n·全表输出到一个Jso" +
    "n文件中\r\n·编码和日期格式？那是什么？可以次吗？";
            // 
            // Option_dataformat_comboBox
            // 
            this.Option_dataformat_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Option_dataformat_comboBox.FormattingEnabled = true;
            this.Option_dataformat_comboBox.Items.AddRange(new object[] {
            "yyyy/MM/dd"});
            this.Option_dataformat_comboBox.Location = new System.Drawing.Point(98, 86);
            this.Option_dataformat_comboBox.Name = "Option_dataformat_comboBox";
            this.Option_dataformat_comboBox.Size = new System.Drawing.Size(121, 20);
            this.Option_dataformat_comboBox.TabIndex = 5;
            // 
            // Option_dataformat_title
            // 
            this.Option_dataformat_title.AutoSize = true;
            this.Option_dataformat_title.Location = new System.Drawing.Point(27, 89);
            this.Option_dataformat_title.Name = "Option_dataformat_title";
            this.Option_dataformat_title.Size = new System.Drawing.Size(65, 12);
            this.Option_dataformat_title.TabIndex = 4;
            this.Option_dataformat_title.Text = "DateFormat";
            // 
            // Option_header_comboBox
            // 
            this.Option_header_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Option_header_comboBox.FormattingEnabled = true;
            this.Option_header_comboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.Option_header_comboBox.Location = new System.Drawing.Point(98, 56);
            this.Option_header_comboBox.Name = "Option_header_comboBox";
            this.Option_header_comboBox.Size = new System.Drawing.Size(121, 20);
            this.Option_header_comboBox.TabIndex = 3;
            // 
            // Options_header_title
            // 
            this.Options_header_title.AutoSize = true;
            this.Options_header_title.Location = new System.Drawing.Point(51, 59);
            this.Options_header_title.Name = "Options_header_title";
            this.Options_header_title.Size = new System.Drawing.Size(41, 12);
            this.Options_header_title.TabIndex = 2;
            this.Options_header_title.Text = "Header";
            this.Options_header_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Option_encoding_comboBox
            // 
            this.Option_encoding_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Option_encoding_comboBox.FormattingEnabled = true;
            this.Option_encoding_comboBox.Items.AddRange(new object[] {
            "utf8"});
            this.Option_encoding_comboBox.Location = new System.Drawing.Point(98, 26);
            this.Option_encoding_comboBox.Name = "Option_encoding_comboBox";
            this.Option_encoding_comboBox.Size = new System.Drawing.Size(121, 20);
            this.Option_encoding_comboBox.TabIndex = 1;
            // 
            // Option_encoding_title
            // 
            this.Option_encoding_title.AutoSize = true;
            this.Option_encoding_title.Location = new System.Drawing.Point(39, 29);
            this.Option_encoding_title.Name = "Option_encoding_title";
            this.Option_encoding_title.Size = new System.Drawing.Size(53, 12);
            this.Option_encoding_title.TabIndex = 0;
            this.Option_encoding_title.Text = "Encoding";
            this.Option_encoding_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(517, 210);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(75, 23);
            this.Output.TabIndex = 7;
            this.Output.Text = "输出";
            this.Output.UseVisualStyleBackColor = true;
            this.Output.Click += new System.EventHandler(this.Output_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 262);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Options_box);
            this.Controls.Add(this.Bt1);
            this.Controls.Add(this.Url1);
            this.Controls.Add(this.MyTip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Excel2Json";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Options_box.ResumeLayout(false);
            this.Options_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MyTip1;
        private System.Windows.Forms.TextBox Url1;
        private System.Windows.Forms.Button Bt1;
        private System.Windows.Forms.GroupBox Options_box;
        private System.Windows.Forms.Label Option_encoding_title;
        private System.Windows.Forms.ComboBox Option_encoding_comboBox;
        private System.Windows.Forms.ComboBox Option_dataformat_comboBox;
        private System.Windows.Forms.Label Option_dataformat_title;
        private System.Windows.Forms.ComboBox Option_header_comboBox;
        private System.Windows.Forms.Label Options_header_title;
        private System.Windows.Forms.Label MyTip2;
        private System.Windows.Forms.Button Output;
    }
}

