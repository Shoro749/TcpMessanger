namespace TcpMessangerServer
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
            audit = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // audit
            // 
            audit.BackColor = Color.FromArgb(179, 243, 180);
            audit.Font = new Font("Segoe UI", 12F);
            audit.ForeColor = Color.Black;
            audit.FormattingEnabled = true;
            audit.ItemHeight = 21;
            audit.Location = new Point(8, 80);
            audit.Margin = new Padding(2);
            audit.Name = "audit";
            audit.Size = new Size(845, 298);
            audit.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(179, 243, 180);
            button1.Font = new Font("Segoe UI", 14F);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(13, 10);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(215, 38);
            button1.TabIndex = 1;
            button1.Text = "Start Server";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(68, 227, 164);
            ClientSize = new Size(861, 404);
            Controls.Add(button1);
            Controls.Add(audit);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion

        private ListBox audit;
        private Button button1;
    }
}
