namespace CybersecurityChatbot.GUI2
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
            panel1 = new Panel();
            lblLogo = new Label();
            rtbChat = new RichTextBox();
            txtInput = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(18, 18, 42);
            panel1.Controls.Add(lblLogo);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(805, 58);
            panel1.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.Cyan;
            lblLogo.Location = new Point(225, 17);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(373, 23);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🛡️ CYBERSECURITY AWARENESS BOT 🛡️";
            lblLogo.Click += label1_Click;
            // 
            // rtbChat
            // 
            rtbChat.BackColor = Color.FromArgb(30, 30, 46);
            rtbChat.ForeColor = Color.White;
            rtbChat.Location = new Point(83, 99);
            rtbChat.Name = "rtbChat";
            rtbChat.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChat.Size = new Size(635, 176);
            rtbChat.TabIndex = 1;
            rtbChat.Text = "";
            // 
            // txtInput
            // 
            txtInput.BackColor = Color.FromArgb(46, 46, 78);
            txtInput.Location = new Point(83, 342);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(237, 31);
            txtInput.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 180, 216);
            button1.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(594, 339);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Send 🛡️";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(txtInput);
            Controls.Add(rtbChat);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "🛡️ Cybersecurity Awareness Bot";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblLogo;
        private RichTextBox rtbChat;
        private TextBox txtInput;
        private Button button1;
    }
}
