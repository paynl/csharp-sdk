namespace PAYNLFormsApp
{
    partial class ApproveDecline
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
            this.label1 = new System.Windows.Forms.Label();
            this.btApprove = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbTransactionID = new System.Windows.Forms.TextBox();
            this.btDecline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TransactionID";
            // 
            // btApprove
            // 
            this.btApprove.Location = new System.Drawing.Point(203, 146);
            this.btApprove.Name = "btApprove";
            this.btApprove.Size = new System.Drawing.Size(75, 23);
            this.btApprove.TabIndex = 1;
            this.btApprove.Text = "Approve";
            this.btApprove.UseVisualStyleBackColor = true;
            this.btApprove.Click += new System.EventHandler(this.btApprove_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbTransactionID
            // 
            this.tbTransactionID.Location = new System.Drawing.Point(203, 28);
            this.tbTransactionID.Name = "tbTransactionID";
            this.tbTransactionID.Size = new System.Drawing.Size(246, 20);
            this.tbTransactionID.TabIndex = 3;
            // 
            // btDecline
            // 
            this.btDecline.Location = new System.Drawing.Point(317, 146);
            this.btDecline.Name = "btDecline";
            this.btDecline.Size = new System.Drawing.Size(75, 23);
            this.btDecline.TabIndex = 4;
            this.btDecline.Text = "Decline";
            this.btDecline.UseVisualStyleBackColor = true;
            this.btDecline.Click += new System.EventHandler(this.btDecline_Click);
            // 
            // ApproveDecline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 278);
            this.Controls.Add(this.btDecline);
            this.Controls.Add(this.tbTransactionID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btApprove);
            this.Controls.Add(this.label1);
            this.Name = "ApproveDecline";
            this.Text = "ApproveDecline";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btApprove;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbTransactionID;
        private System.Windows.Forms.Button btDecline;
    }
}