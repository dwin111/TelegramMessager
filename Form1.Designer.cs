namespace TelegramMessager
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
            this.userBox = new System.Windows.Forms.ListBox();
            this.MessageBox = new System.Windows.Forms.ListBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.textToSend = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.textChatIdBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.textMessageId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userBox
            // 
            this.userBox.FormattingEnabled = true;
            this.userBox.ItemHeight = 15;
            this.userBox.Location = new System.Drawing.Point(10, 16);
            this.userBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(196, 589);
            this.userBox.TabIndex = 0;
            // 
            // MessageBox
            // 
            this.MessageBox.FormattingEnabled = true;
            this.MessageBox.ItemHeight = 15;
            this.MessageBox.Location = new System.Drawing.Point(212, 16);
            this.MessageBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(689, 199);
            this.MessageBox.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sendButton.Location = new System.Drawing.Point(666, 360);
            this.sendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(235, 45);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // textToSend
            // 
            this.textToSend.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textToSend.Location = new System.Drawing.Point(212, 257);
            this.textToSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textToSend.Multiline = true;
            this.textToSend.Name = "textToSend";
            this.textToSend.Size = new System.Drawing.Size(689, 99);
            this.textToSend.TabIndex = 3;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(212, 409);
            this.LogBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(689, 196);
            this.LogBox.TabIndex = 5;
            // 
            // textChatIdBox
            // 
            this.textChatIdBox.Location = new System.Drawing.Point(212, 230);
            this.textChatIdBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textChatIdBox.Name = "textChatIdBox";
            this.textChatIdBox.Size = new System.Drawing.Size(196, 23);
            this.textChatIdBox.TabIndex = 6;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteButton.Location = new System.Drawing.Point(212, 359);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(102, 46);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // textMessageId
            // 
            this.textMessageId.Location = new System.Drawing.Point(705, 230);
            this.textMessageId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textMessageId.Name = "textMessageId";
            this.textMessageId.Size = new System.Drawing.Size(196, 23);
            this.textMessageId.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 616);
            this.Controls.Add(this.textMessageId);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.textChatIdBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.textToSend);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.userBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox userBox;
        private ListBox MessageBox;
        private Button sendButton;
        private TextBox textToSend;
        private TextBox LogBox;
        private TextBox textBox2;
        private Button deleteButton;
        private TextBox textBox3;
        private TextBox messageId;
        private TextBox chatId;
        private TextBox chatIdBox;
        private TextBox textMessageId;
        private TextBox textChatIdBox;
    }
}