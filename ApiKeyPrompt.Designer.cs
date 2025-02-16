namespace cstmpricebot
{
    partial class ApiKeyPrompt
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
            apikeytb = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // apikeytb
            // 
            apikeytb.Location = new Point(24, 35);
            apikeytb.Name = "apikeytb";
            apikeytb.PlaceholderText = "апи ключ";
            apikeytb.Size = new Size(266, 23);
            apikeytb.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(24, 6);
            button1.Name = "button1";
            button1.Size = new Size(266, 23);
            button1.TabIndex = 1;
            button1.Text = "открыть страницу для создания";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(24, 64);
            button2.Name = "button2";
            button2.Size = new Size(266, 23);
            button2.TabIndex = 1;
            button2.Text = "сохранить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ApiKeyPrompt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 103);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(apikeytb);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ApiKeyPrompt";
            Text = "ключ невалид или не указан";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox apikeytb;
        private Button button1;
        private Button button2;
    }
}