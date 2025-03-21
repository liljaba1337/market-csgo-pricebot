namespace cstmpricebot
{
    partial class AdditionPrompt
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdditionPrompt));
            namelbl = new Label();
            pricelbl = new Label();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            minpricetb = new TextBox();
            label1 = new Label();
            maxpricetb = new TextBox();
            label8 = new Label();
            button1 = new Button();
            toolTip1 = new ToolTip(components);
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // namelbl
            // 
            namelbl.Anchor = AnchorStyles.Top;
            namelbl.AutoSize = true;
            namelbl.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namelbl.Location = new Point(10, 13);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(49, 18);
            namelbl.TabIndex = 0;
            namelbl.Text = "name";
            // 
            // pricelbl
            // 
            pricelbl.AutoSize = true;
            pricelbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            pricelbl.Location = new Point(183, 63);
            pricelbl.Name = "pricelbl";
            pricelbl.Size = new Size(56, 25);
            pricelbl.TabIndex = 1;
            pricelbl.Text = "price";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(10, 91);
            trackBar1.Maximum = 0;
            trackBar1.Minimum = -10;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(200, 45);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(210, 91);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(200, 45);
            trackBar2.TabIndex = 3;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 5;
            label2.Text = "Min price";
            toolTip1.SetToolTip(label2, "The lowest price allowed.");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 73);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 6;
            label3.Text = "Max price (?)";
            toolTip1.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 121);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 7;
            label4.Text = "-10%";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(373, 121);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 8;
            label5.Text = "+10%";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(198, 121);
            label7.Name = "label7";
            label7.Size = new Size(23, 15);
            label7.TabIndex = 10;
            label7.Text = "0%";
            // 
            // minpricetb
            // 
            minpricetb.Location = new Point(19, 143);
            minpricetb.Name = "minpricetb";
            minpricetb.Size = new Size(62, 23);
            minpricetb.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 146);
            label1.Name = "label1";
            label1.Size = new Size(17, 20);
            label1.TabIndex = 12;
            label1.Text = "$";
            // 
            // maxpricetb
            // 
            maxpricetb.Location = new Point(340, 139);
            maxpricetb.Name = "maxpricetb";
            maxpricetb.Size = new Size(62, 23);
            maxpricetb.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(326, 142);
            label8.Name = "label8";
            label8.Size = new Size(17, 20);
            label8.TabIndex = 14;
            label8.Text = "$";
            // 
            // button1
            // 
            button1.Location = new Point(147, 173);
            button1.Name = "button1";
            button1.Size = new Size(120, 35);
            button1.TabIndex = 15;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 100;
            // 
            // button2
            // 
            button2.Location = new Point(2, 210);
            button2.Name = "button2";
            button2.Size = new Size(159, 23);
            button2.TabIndex = 17;
            button2.Text = "Price displayed incorrectly?";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AdditionPrompt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 234);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(maxpricetb);
            Controls.Add(label8);
            Controls.Add(minpricetb);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(pricelbl);
            Controls.Add(namelbl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AdditionPrompt";
            Text = "Add an item";
            Load += AdditionPrompt_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label namelbl;
        private Label pricelbl;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private TextBox minpricetb;
        private Label label1;
        private TextBox maxpricetb;
        private Label label8;
        private Button button1;
        private ToolTip toolTip1;
        private Button button2;
    }
}