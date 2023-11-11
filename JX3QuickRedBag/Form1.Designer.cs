namespace JX3QuickRedBag
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_X2 = new System.Windows.Forms.TextBox();
            this.textBox_Y2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox_UserY = new System.Windows.Forms.TextBox();
            this.textBox_UserX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "X末";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y末";
            // 
            // textBox_X2
            // 
            this.textBox_X2.Location = new System.Drawing.Point(41, 32);
            this.textBox_X2.Name = "textBox_X2";
            this.textBox_X2.Size = new System.Drawing.Size(100, 21);
            this.textBox_X2.TabIndex = 6;
            // 
            // textBox_Y2
            // 
            this.textBox_Y2.Location = new System.Drawing.Point(41, 82);
            this.textBox_Y2.Name = "textBox_Y2";
            this.textBox_Y2.Size = new System.Drawing.Size(100, 21);
            this.textBox_Y2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "点击时，保存屏幕图片路径";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(14, 133);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(292, 21);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "Path/抢红包截图";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 25);
            this.button1.TabIndex = 11;
            this.button1.Text = "保存配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(23, 191);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(228, 16);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "是否自动换角色（只点击第三个角色）";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox_UserY
            // 
            this.textBox_UserY.Location = new System.Drawing.Point(206, 85);
            this.textBox_UserY.Name = "textBox_UserY";
            this.textBox_UserY.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserY.TabIndex = 16;
            // 
            // textBox_UserX
            // 
            this.textBox_UserX.Location = new System.Drawing.Point(206, 35);
            this.textBox_UserX.Name = "textBox_UserX";
            this.textBox_UserX.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserX.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "角色Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "角色X";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 231);
            this.Controls.Add(this.textBox_UserY);
            this.Controls.Add(this.textBox_UserX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Y2);
            this.Controls.Add(this.textBox_X2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "阿信抢红包_DD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_X2;
        private System.Windows.Forms.TextBox textBox_Y2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox_UserY;
        private System.Windows.Forms.TextBox textBox_UserX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}

