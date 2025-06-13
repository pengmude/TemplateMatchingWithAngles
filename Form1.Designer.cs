namespace Test_软包电池定位极耳中心
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageROIEditControl1 = new TDJS_Vision.Forms.ShapeDraw.ImageROIEditControl();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonIsOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageROIEditControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonIsOK, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 509);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(655, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "选择图像";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(655, 389);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "执行";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageROIEditControl1
            // 
            this.imageROIEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageROIEditControl1.Location = new System.Drawing.Point(3, 2);
            this.imageROIEditControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageROIEditControl1.Name = "imageROIEditControl1";
            this.tableLayoutPanel1.SetRowSpan(this.imageROIEditControl1, 5);
            this.imageROIEditControl1.Size = new System.Drawing.Size(627, 456);
            this.imageROIEditControl1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(655, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 50);
            this.button3.TabIndex = 1;
            this.button3.Text = "清除ROI";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(655, 205);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 50);
            this.button4.TabIndex = 1;
            this.button4.Text = "选用模版";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.Location = new System.Drawing.Point(655, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 50);
            this.button5.TabIndex = 1;
            this.button5.Text = "创建模版";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonIsOK
            // 
            this.buttonIsOK.BackColor = System.Drawing.SystemColors.Control;
            this.buttonIsOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIsOK.Location = new System.Drawing.Point(636, 463);
            this.buttonIsOK.Name = "buttonIsOK";
            this.buttonIsOK.Size = new System.Drawing.Size(154, 43);
            this.buttonIsOK.TabIndex = 1;
            this.buttonIsOK.UseVisualStyleBackColor = false;
            this.buttonIsOK.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelTime, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelRes, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 463);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(627, 43);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "算法耗时";
            // 
            // labelTime
            // 
            this.labelTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(234, 14);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 15);
            this.labelTime.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "最佳匹配角度";
            // 
            // labelRes
            // 
            this.labelRes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRes.AutoSize = true;
            this.labelRes.Location = new System.Drawing.Point(547, 14);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(0, 15);
            this.labelRes.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 509);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软包电池极耳中心检测";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private TDJS_Vision.Forms.ShapeDraw.ImageROIEditControl imageROIEditControl1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonIsOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRes;
    }
}

