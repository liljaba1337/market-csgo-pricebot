namespace cstmpricebot
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label3 = new Label();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(15, 21);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(773, 126);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 329);
            label1.Name = "label1";
            label1.Size = new Size(523, 50);
            label1.TabIndex = 1;
            label1.Text = "загрузка и проверка ключа";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Location = new Point(12, 167);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(773, 126);
            flowLayoutPanel2.TabIndex = 1;
            flowLayoutPanel2.WrapContents = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 150);
            label3.Name = "label3";
            label3.Size = new Size(175, 15);
            label3.TabIndex = 4;
            label3.Text = "Предметы с автопонижением:";
            // 
            // button1
            // 
            button1.Location = new Point(3, 421);
            button1.Name = "button1";
            button1.Size = new Size(127, 26);
            button1.TabIndex = 2;
            button1.Text = "обновить предметы";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 3);
            label2.Name = "label2";
            label2.Size = new Size(134, 15);
            label2.TabIndex = 3;
            label2.Text = "Предметы на продаже:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "cstm price bot вадим соси яйца";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button1;
        internal FlowLayoutPanel flowLayoutPanel1;
        internal FlowLayoutPanel flowLayoutPanel2;
        private Label label3;
        private Label label2;
    }
}
