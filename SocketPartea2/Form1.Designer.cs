namespace SocketPartea2
{
    partial class ServerClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerClient));
            this.DrawButton = new System.Windows.Forms.Button();
            this.hitButton = new System.Windows.Forms.Button();
            this.buttonStand = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.DrawCardsLabel = new System.Windows.Forms.Label();
            this.totalValueLabel = new System.Windows.Forms.Label();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.serverLogTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DrawButton
            // 
            this.DrawButton.BackColor = System.Drawing.Color.Red;
            this.DrawButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DrawButton.Location = new System.Drawing.Point(345, 232);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(75, 23);
            this.DrawButton.TabIndex = 1;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = false;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click_1);
            // 
            // hitButton
            // 
            this.hitButton.BackColor = System.Drawing.Color.Red;
            this.hitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hitButton.Location = new System.Drawing.Point(345, 261);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(75, 23);
            this.hitButton.TabIndex = 2;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = false;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click_1);
            // 
            // buttonStand
            // 
            this.buttonStand.BackColor = System.Drawing.Color.Red;
            this.buttonStand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStand.Location = new System.Drawing.Point(345, 290);
            this.buttonStand.Name = "buttonStand";
            this.buttonStand.Size = new System.Drawing.Size(75, 23);
            this.buttonStand.TabIndex = 3;
            this.buttonStand.Text = "Stand";
            this.buttonStand.UseVisualStyleBackColor = false;
            this.buttonStand.Click += new System.EventHandler(this.buttonStand_Click_1);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Red;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReset.Location = new System.Drawing.Point(345, 319);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click_1);
            // 
            // DrawCardsLabel
            // 
            this.DrawCardsLabel.AutoSize = true;
            this.DrawCardsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.DrawCardsLabel.Location = new System.Drawing.Point(131, 68);
            this.DrawCardsLabel.Name = "DrawCardsLabel";
            this.DrawCardsLabel.Size = new System.Drawing.Size(0, 16);
            this.DrawCardsLabel.TabIndex = 5;
            // 
            // totalValueLabel
            // 
            this.totalValueLabel.AutoSize = true;
            this.totalValueLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.totalValueLabel.Location = new System.Drawing.Point(606, 68);
            this.totalValueLabel.Name = "totalValueLabel";
            this.totalValueLabel.Size = new System.Drawing.Size(0, 16);
            this.totalValueLabel.TabIndex = 6;
            // 
            // StartServerButton
            // 
            this.StartServerButton.BackColor = System.Drawing.Color.Red;
            this.StartServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartServerButton.Location = new System.Drawing.Point(618, 364);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(75, 23);
            this.StartServerButton.TabIndex = 7;
            this.StartServerButton.Text = "StartServer";
            this.StartServerButton.UseVisualStyleBackColor = false;
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click_1);
            // 
            // serverLogTextBox
            // 
            this.serverLogTextBox.Location = new System.Drawing.Point(62, 364);
            this.serverLogTextBox.Name = "serverLogTextBox";
            this.serverLogTextBox.Size = new System.Drawing.Size(136, 22);
            this.serverLogTextBox.TabIndex = 8;
            // 
            // ServerClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.serverLogTextBox);
            this.Controls.Add(this.StartServerButton);
            this.Controls.Add(this.totalValueLabel);
            this.Controls.Add(this.DrawCardsLabel);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonStand);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.DrawButton);
            this.Name = "ServerClient";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button buttonStand;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label DrawCardsLabel;
        private System.Windows.Forms.Label totalValueLabel;
        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.TextBox serverLogTextBox;
    }
}

