namespace BPS
{
    partial class MyMessageBox
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
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ID_Box = new System.Windows.Forms.TextBox();
            this.Data_Box = new System.Windows.Forms.TextBox();
            this.Descp_Box = new System.Windows.Forms.TextBox();
            this.Descp = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel10
            // 
            this.metroLabel10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.ForeColor = System.Drawing.Color.Gainsboro;
            this.metroLabel10.Location = new System.Drawing.Point(136, 74);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(32, 25);
            this.metroLabel10.TabIndex = 176;
            this.metroLabel10.Text = "ID:";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.ForeColor = System.Drawing.Color.Gainsboro;
            this.metroLabel1.Location = new System.Drawing.Point(386, 74);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 25);
            this.metroLabel1.TabIndex = 178;
            this.metroLabel1.Text = "Data:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(595, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 31);
            this.button1.TabIndex = 180;
            this.button1.Text = "&Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(477, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 31);
            this.button2.TabIndex = 181;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ID_Box
            // 
            this.ID_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ID_Box.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Box.Enabled = false;
            this.ID_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_Box.Location = new System.Drawing.Point(174, 72);
            this.ID_Box.Name = "ID_Box";
            this.ID_Box.Size = new System.Drawing.Size(182, 29);
            this.ID_Box.TabIndex = 182;
            // 
            // Data_Box
            // 
            this.Data_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Data_Box.BackColor = System.Drawing.Color.Gainsboro;
            this.Data_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Data_Box.Location = new System.Drawing.Point(443, 73);
            this.Data_Box.Name = "Data_Box";
            this.Data_Box.Size = new System.Drawing.Size(182, 26);
            this.Data_Box.TabIndex = 183;
            // 
            // Descp_Box
            // 
            this.Descp_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Descp_Box.BackColor = System.Drawing.Color.Gainsboro;
            this.Descp_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descp_Box.Location = new System.Drawing.Point(174, 107);
            this.Descp_Box.Name = "Descp_Box";
            this.Descp_Box.Size = new System.Drawing.Size(451, 26);
            this.Descp_Box.TabIndex = 185;
            // 
            // Descp
            // 
            this.Descp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Descp.AutoSize = true;
            this.Descp.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Descp.ForeColor = System.Drawing.Color.Gainsboro;
            this.Descp.Location = new System.Drawing.Point(67, 108);
            this.Descp.Name = "Descp";
            this.Descp.Size = new System.Drawing.Size(101, 25);
            this.Descp.TabIndex = 184;
            this.Descp.Text = "Description:";
            this.Descp.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BPS.Properties.Resources.Capture;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(737, 210);
            this.Controls.Add(this.Descp_Box);
            this.Controls.Add(this.Descp);
            this.Controls.Add(this.Data_Box);
            this.Controls.Add(this.ID_Box);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel10);
            this.Name = "MyMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "MyMessageBox";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.MyMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ID_Box;
        private System.Windows.Forms.TextBox Data_Box;
        private System.Windows.Forms.TextBox Descp_Box;
        private MetroFramework.Controls.MetroLabel Descp;

    }
}