namespace tcpClientUpdate
{
    partial class Form1
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
            this.startButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipTextbox = new System.Windows.Forms.TextBox();
            this.msgCountLabel = new System.Windows.Forms.Label();
            this.msgCountTextbox = new System.Windows.Forms.TextBox();
            this.paceLabel = new System.Windows.Forms.Label();
            this.paceTextbox = new System.Windows.Forms.TextBox();
            this.logNameLabel = new System.Windows.Forms.Label();
            this.logNameTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(5, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(204, 4);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 1;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(5, 33);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(58, 13);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "IP Address";
            // 
            // ipTextbox
            // 
            this.ipTextbox.Location = new System.Drawing.Point(5, 50);
            this.ipTextbox.Name = "ipTextbox";
            this.ipTextbox.Size = new System.Drawing.Size(100, 20);
            this.ipTextbox.TabIndex = 3;
            // 
            // msgCountLabel
            // 
            this.msgCountLabel.AutoSize = true;
            this.msgCountLabel.Location = new System.Drawing.Point(121, 33);
            this.msgCountLabel.Name = "msgCountLabel";
            this.msgCountLabel.Size = new System.Drawing.Size(81, 13);
            this.msgCountLabel.TabIndex = 4;
            this.msgCountLabel.Text = "Message Count";
            // 
            // msgCountTextbox
            // 
            this.msgCountTextbox.Location = new System.Drawing.Point(121, 50);
            this.msgCountTextbox.Name = "msgCountTextbox";
            this.msgCountTextbox.Size = new System.Drawing.Size(78, 20);
            this.msgCountTextbox.TabIndex = 5;
            // 
            // paceLabel
            // 
            this.paceLabel.AutoSize = true;
            this.paceLabel.Location = new System.Drawing.Point(215, 33);
            this.paceLabel.Name = "paceLabel";
            this.paceLabel.Size = new System.Drawing.Size(32, 13);
            this.paceLabel.TabIndex = 6;
            this.paceLabel.Text = "Pace";
            // 
            // paceTextbox
            // 
            this.paceTextbox.Location = new System.Drawing.Point(215, 49);
            this.paceTextbox.Name = "paceTextbox";
            this.paceTextbox.Size = new System.Drawing.Size(46, 20);
            this.paceTextbox.TabIndex = 7;
            // 
            // logNameLabel
            // 
            this.logNameLabel.AutoSize = true;
            this.logNameLabel.Location = new System.Drawing.Point(5, 87);
            this.logNameLabel.Name = "logNameLabel";
            this.logNameLabel.Size = new System.Drawing.Size(56, 13);
            this.logNameLabel.TabIndex = 8;
            this.logNameLabel.Text = "Log Name";
            // 
            // logNameTextbox
            // 
            this.logNameTextbox.Location = new System.Drawing.Point(5, 104);
            this.logNameTextbox.Name = "logNameTextbox";
            this.logNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.logNameTextbox.TabIndex = 9;
            this.logNameTextbox.Text = "ClientLog.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.logNameTextbox);
            this.Controls.Add(this.logNameLabel);
            this.Controls.Add(this.paceTextbox);
            this.Controls.Add(this.paceLabel);
            this.Controls.Add(this.msgCountTextbox);
            this.Controls.Add(this.msgCountLabel);
            this.Controls.Add(this.ipTextbox);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipTextbox;
        private System.Windows.Forms.Label msgCountLabel;
        private System.Windows.Forms.TextBox msgCountTextbox;
        private System.Windows.Forms.Label paceLabel;
        private System.Windows.Forms.TextBox paceTextbox;
        private System.Windows.Forms.Label logNameLabel;
        private System.Windows.Forms.TextBox logNameTextbox;
    }
}

