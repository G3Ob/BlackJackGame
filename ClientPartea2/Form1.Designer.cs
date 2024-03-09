using System;

namespace ClientPartea2
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.DrawButton = new System.Windows.Forms.Button();
            this.DrawCardsLabel = new System.Windows.Forms.Label();
            this.totalValueLabel = new System.Windows.Forms.Label();
            this.hitButton = new System.Windows.Forms.Button();
            this.buttonStand = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.clientLogTextBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrawButton
            // 
            this.DrawButton.BackColor = System.Drawing.Color.Red;
            this.DrawButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DrawButton.Location = new System.Drawing.Point(345, 231);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(75, 23);
            this.DrawButton.TabIndex = 0;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = false;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click_1);
            // 
            // DrawCardsLabel
            // 
            this.DrawCardsLabel.AutoSize = true;
            this.DrawCardsLabel.BackColor = System.Drawing.Color.Lime;
            this.DrawCardsLabel.Location = new System.Drawing.Point(160, 72);
            this.DrawCardsLabel.Name = "DrawCardsLabel";
            this.DrawCardsLabel.Size = new System.Drawing.Size(0, 16);
            this.DrawCardsLabel.TabIndex = 1;
            // 
            // totalValueLabel
            // 
            this.totalValueLabel.AutoSize = true;
            this.totalValueLabel.BackColor = System.Drawing.Color.Lime;
            this.totalValueLabel.Location = new System.Drawing.Point(596, 72);
            this.totalValueLabel.Name = "totalValueLabel";
            this.totalValueLabel.Size = new System.Drawing.Size(0, 16);
            this.totalValueLabel.TabIndex = 2;
            // 
            // hitButton
            // 
            this.hitButton.BackColor = System.Drawing.Color.Red;
            this.hitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hitButton.Location = new System.Drawing.Point(345, 260);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(75, 23);
            this.hitButton.TabIndex = 3;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = false;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click_1);
            // 
            // buttonStand
            // 
            this.buttonStand.BackColor = System.Drawing.Color.Red;
            this.buttonStand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStand.Location = new System.Drawing.Point(345, 289);
            this.buttonStand.Name = "buttonStand";
            this.buttonStand.Size = new System.Drawing.Size(75, 23);
            this.buttonStand.TabIndex = 4;
            this.buttonStand.Text = "Stand";
            this.buttonStand.UseVisualStyleBackColor = false;
            this.buttonStand.Click += new System.EventHandler(this.buttonStand_Click_1);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Red;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReset.Location = new System.Drawing.Point(345, 318);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click_1);
            // 
            // clientLogTextBox
            // 
            this.clientLogTextBox.Location = new System.Drawing.Point(66, 350);
            this.clientLogTextBox.Name = "clientLogTextBox";
            this.clientLogTextBox.Size = new System.Drawing.Size(175, 22);
            this.clientLogTextBox.TabIndex = 7;
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.Red;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConnectButton.Location = new System.Drawing.Point(634, 349);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click_1);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.clientLogTextBox);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonStand);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.totalValueLabel);
            this.Controls.Add(this.DrawCardsLabel);
            this.Controls.Add(this.DrawButton);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SendMessageButton_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Label DrawCardsLabel;
        private System.Windows.Forms.Label totalValueLabel;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button buttonStand;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox clientLogTextBox;
        private System.Windows.Forms.Button ConnectButton;
    }
}

