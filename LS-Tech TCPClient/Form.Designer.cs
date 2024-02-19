namespace LS_Tech_TCPClient
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.hostLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.helloMessageTextBox = new System.Windows.Forms.TextBox();
            this.helloMessageLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.logsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.hostMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(20, 23);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(53, 13);
            this.hostLabel.TabIndex = 1;
            this.hostLabel.Text = "IP-адрес:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(269, 23);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(35, 13);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "Порт:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(310, 20);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 2;
            // 
            // helloMessageTextBox
            // 
            this.helloMessageTextBox.Location = new System.Drawing.Point(105, 57);
            this.helloMessageTextBox.Name = "helloMessageTextBox";
            this.helloMessageTextBox.Size = new System.Drawing.Size(199, 20);
            this.helloMessageTextBox.TabIndex = 4;
            // 
            // helloMessageLabel
            // 
            this.helloMessageLabel.AutoSize = true;
            this.helloMessageLabel.Location = new System.Drawing.Point(20, 60);
            this.helloMessageLabel.Name = "helloMessageLabel";
            this.helloMessageLabel.Size = new System.Drawing.Size(79, 13);
            this.helloMessageLabel.TabIndex = 5;
            this.helloMessageLabel.Text = "Hello message:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(319, 55);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(91, 23);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Подключить";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // logsRichTextBox
            // 
            this.logsRichTextBox.Location = new System.Drawing.Point(23, 99);
            this.logsRichTextBox.Name = "logsRichTextBox";
            this.logsRichTextBox.ReadOnly = true;
            this.logsRichTextBox.Size = new System.Drawing.Size(387, 131);
            this.logsRichTextBox.TabIndex = 7;
            this.logsRichTextBox.Text = "";
            // 
            // hostMaskedTextBox
            // 
            this.hostMaskedTextBox.Location = new System.Drawing.Point(79, 20);
            this.hostMaskedTextBox.Name = "hostMaskedTextBox";
            this.hostMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.hostMaskedTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 253);
            this.Controls.Add(this.hostMaskedTextBox);
            this.Controls.Add(this.logsRichTextBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.helloMessageLabel);
            this.Controls.Add(this.helloMessageTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.hostLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox helloMessageTextBox;
        private System.Windows.Forms.Label helloMessageLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.RichTextBox logsRichTextBox;
        private System.Windows.Forms.MaskedTextBox hostMaskedTextBox;
    }
}

