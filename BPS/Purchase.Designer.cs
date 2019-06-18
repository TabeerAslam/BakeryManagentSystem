namespace BPS
{
    partial class Purchase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase));
            this.ID_Box = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ODate_DTP = new System.Windows.Forms.DateTimePicker();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.DDate_DTP = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.Category_CBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.Vendor_CBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.Item_Grid = new System.Windows.Forms.DataGridView();
            this.PAmount_Textbox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.Remarks_Box = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.CPButton_Box = new System.Windows.Forms.GroupBox();
            this.CPUpdate_Button = new System.Windows.Forms.Button();
            this.CPBack_Button = new System.Windows.Forms.Button();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.Qty_Box = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.TQty_Label = new MetroFramework.Controls.MetroLabel();
            this.TAmount_Label = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.Balance_Label = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.Price_Box = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.VendorPic_Box = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AddNewItem = new MetroFramework.Controls.MetroTile();
            this.WrongItem_Label = new System.Windows.Forms.Label();
            this.ItemPic_Box = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Stock_Button = new System.Windows.Forms.Button();
            this.Consume_Button = new System.Windows.Forms.Button();
            this.Dues_Label = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.Return_Textbox = new MetroFramework.Controls.MetroTextBox();
            this.Cancel_Order = new MetroFramework.Controls.MetroTile();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Item_Grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.CPButton_Box.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VendorPic_Box)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPic_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_Box
            // 
            // 
            // 
            // 
            this.ID_Box.CustomButton.Image = null;
            this.ID_Box.CustomButton.Location = new System.Drawing.Point(223, 1);
            this.ID_Box.CustomButton.Name = "";
            this.ID_Box.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.ID_Box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ID_Box.CustomButton.TabIndex = 1;
            this.ID_Box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ID_Box.CustomButton.UseSelectable = true;
            this.ID_Box.CustomButton.Visible = false;
            this.ID_Box.Enabled = false;
            this.ID_Box.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.ID_Box.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.ID_Box.Lines = new string[0];
            this.ID_Box.Location = new System.Drawing.Point(118, 17);
            this.ID_Box.MaxLength = 32767;
            this.ID_Box.Name = "ID_Box";
            this.ID_Box.PasswordChar = '\0';
            this.ID_Box.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ID_Box.SelectedText = "";
            this.ID_Box.SelectionLength = 0;
            this.ID_Box.SelectionStart = 0;
            this.ID_Box.ShortcutsEnabled = true;
            this.ID_Box.Size = new System.Drawing.Size(251, 29);
            this.ID_Box.TabIndex = 0;
            this.ID_Box.UseSelectable = true;
            this.ID_Box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ID_Box.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(32, 21);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(64, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Order ID:";
            // 
            // ODate_DTP
            // 
            this.ODate_DTP.Location = new System.Drawing.Point(128, 58);
            this.ODate_DTP.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.ODate_DTP.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.ODate_DTP.Name = "ODate_DTP";
            this.ODate_DTP.Size = new System.Drawing.Size(240, 20);
            this.ODate_DTP.TabIndex = 1;
            this.ODate_DTP.ValueChanged += new System.EventHandler(this.ODate_DTP_ValueChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(32, 58);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(79, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Order Date:";
            // 
            // DDate_DTP
            // 
            this.DDate_DTP.Location = new System.Drawing.Point(128, 84);
            this.DDate_DTP.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.DDate_DTP.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DDate_DTP.Name = "DDate_DTP";
            this.DDate_DTP.Size = new System.Drawing.Size(240, 20);
            this.DDate_DTP.TabIndex = 2;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(32, 84);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(90, 19);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Delivery Date:";
            // 
            // Category_CBox
            // 
            this.Category_CBox.AllowDrop = true;
            this.Category_CBox.FormattingEnabled = true;
            this.Category_CBox.ItemHeight = 23;
            this.Category_CBox.Location = new System.Drawing.Point(118, 118);
            this.Category_CBox.Name = "Category_CBox";
            this.Category_CBox.Size = new System.Drawing.Size(251, 29);
            this.Category_CBox.TabIndex = 3;
            this.Category_CBox.UseSelectable = true;
            this.Category_CBox.SelectedIndexChanged += new System.EventHandler(this.Category_CBox_SelectedIndexChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(32, 121);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(67, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Category:";
            // 
            // Vendor_CBox
            // 
            this.Vendor_CBox.FormattingEnabled = true;
            this.Vendor_CBox.ItemHeight = 23;
            this.Vendor_CBox.Location = new System.Drawing.Point(118, 161);
            this.Vendor_CBox.Name = "Vendor_CBox";
            this.Vendor_CBox.Size = new System.Drawing.Size(251, 29);
            this.Vendor_CBox.TabIndex = 4;
            this.Vendor_CBox.UseSelectable = true;
            this.Vendor_CBox.SelectedIndexChanged += new System.EventHandler(this.Vendor_CBox_SelectedIndexChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(32, 167);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(55, 19);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "Vendor:";
            // 
            // Item_Grid
            // 
            this.Item_Grid.AllowUserToAddRows = false;
            this.Item_Grid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Item_Grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Item_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Item_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Qty,
            this.UOM,
            this.Price,
            this.Category,
            this.Amount,
            this.Edit,
            this.Delete});
            this.Item_Grid.Location = new System.Drawing.Point(29, 302);
            this.Item_Grid.Name = "Item_Grid";
            this.Item_Grid.Size = new System.Drawing.Size(674, 171);
            this.Item_Grid.TabIndex = 2;
            this.Item_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Item_Grid_CellClick);
            this.Item_Grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Item_Grid_CellEndEdit);
            this.Item_Grid.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Item_Grid_RowLeave);
            // 
            // PAmount_Textbox
            // 
            this.PAmount_Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.PAmount_Textbox.CustomButton.Image = null;
            this.PAmount_Textbox.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.PAmount_Textbox.CustomButton.Name = "";
            this.PAmount_Textbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PAmount_Textbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PAmount_Textbox.CustomButton.TabIndex = 1;
            this.PAmount_Textbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PAmount_Textbox.CustomButton.UseSelectable = true;
            this.PAmount_Textbox.CustomButton.Visible = false;
            this.PAmount_Textbox.Lines = new string[0];
            this.PAmount_Textbox.Location = new System.Drawing.Point(796, 516);
            this.PAmount_Textbox.MaxLength = 32767;
            this.PAmount_Textbox.Name = "PAmount_Textbox";
            this.PAmount_Textbox.PasswordChar = '\0';
            this.PAmount_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PAmount_Textbox.SelectedText = "";
            this.PAmount_Textbox.SelectionLength = 0;
            this.PAmount_Textbox.SelectionStart = 0;
            this.PAmount_Textbox.ShortcutsEnabled = true;
            this.PAmount_Textbox.Size = new System.Drawing.Size(204, 23);
            this.PAmount_Textbox.TabIndex = 3;
            this.PAmount_Textbox.UseSelectable = true;
            this.PAmount_Textbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PAmount_Textbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.PAmount_Textbox.TextChanged += new System.EventHandler(this.PAmount_Textbox_TextChanged);
            // 
            // metroLabel10
            // 
            this.metroLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.Location = new System.Drawing.Point(676, 514);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(114, 25);
            this.metroLabel10.TabIndex = 30;
            this.metroLabel10.Text = "Paid Amount:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.Location = new System.Drawing.Point(676, 485);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(90, 25);
            this.metroLabel8.TabIndex = 26;
            this.metroLabel8.Text = "Total Qty=";
            // 
            // metroLabel6
            // 
            this.metroLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(29, 544);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(84, 25);
            this.metroLabel6.TabIndex = 38;
            this.metroLabel6.Text = "Remarks:";
            // 
            // Remarks_Box
            // 
            this.Remarks_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Remarks_Box.CustomButton.Image = null;
            this.Remarks_Box.CustomButton.Location = new System.Drawing.Point(543, 1);
            this.Remarks_Box.CustomButton.Name = "";
            this.Remarks_Box.CustomButton.Size = new System.Drawing.Size(77, 77);
            this.Remarks_Box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Remarks_Box.CustomButton.TabIndex = 1;
            this.Remarks_Box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Remarks_Box.CustomButton.UseSelectable = true;
            this.Remarks_Box.CustomButton.Visible = false;
            this.Remarks_Box.Lines = new string[0];
            this.Remarks_Box.Location = new System.Drawing.Point(29, 572);
            this.Remarks_Box.MaxLength = 32767;
            this.Remarks_Box.Multiline = true;
            this.Remarks_Box.Name = "Remarks_Box";
            this.Remarks_Box.PasswordChar = '\0';
            this.Remarks_Box.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Remarks_Box.SelectedText = "";
            this.Remarks_Box.SelectionLength = 0;
            this.Remarks_Box.SelectionStart = 0;
            this.Remarks_Box.ShortcutsEnabled = true;
            this.Remarks_Box.Size = new System.Drawing.Size(621, 79);
            this.Remarks_Box.TabIndex = 4;
            this.Remarks_Box.UseSelectable = true;
            this.Remarks_Box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Remarks_Box.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblDay);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Location = new System.Drawing.Point(769, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 64);
            this.panel1.TabIndex = 53;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("DS-Digital", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate.Location = new System.Drawing.Point(5, 34);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(109, 21);
            this.lblDate.TabIndex = 53;
            this.lblDate.Text = "JAN 01 2015";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("DS-Digital", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDay.Location = new System.Drawing.Point(236, 34);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(98, 21);
            this.lblDay.TabIndex = 52;
            this.lblDay.Text = "SATURDAY";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("DS-Digital", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTime.Location = new System.Drawing.Point(110, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(139, 35);
            this.lblTime.TabIndex = 51;
            this.lblTime.Text = "22:22:22";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CPButton_Box
            // 
            this.CPButton_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CPButton_Box.BackColor = System.Drawing.Color.Transparent;
            this.CPButton_Box.Controls.Add(this.CPUpdate_Button);
            this.CPButton_Box.Controls.Add(this.CPBack_Button);
            this.CPButton_Box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CPButton_Box.Location = new System.Drawing.Point(848, 599);
            this.CPButton_Box.Name = "CPButton_Box";
            this.CPButton_Box.Size = new System.Drawing.Size(204, 62);
            this.CPButton_Box.TabIndex = 5;
            this.CPButton_Box.TabStop = false;
            // 
            // CPUpdate_Button
            // 
            this.CPUpdate_Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CPUpdate_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CPUpdate_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPUpdate_Button.Image = ((System.Drawing.Image)(resources.GetObject("CPUpdate_Button.Image")));
            this.CPUpdate_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CPUpdate_Button.Location = new System.Drawing.Point(109, 17);
            this.CPUpdate_Button.Name = "CPUpdate_Button";
            this.CPUpdate_Button.Size = new System.Drawing.Size(82, 35);
            this.CPUpdate_Button.TabIndex = 0;
            this.CPUpdate_Button.Text = "Update";
            this.CPUpdate_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPUpdate_Button.UseVisualStyleBackColor = true;
            this.CPUpdate_Button.Click += new System.EventHandler(this.CPUpdate_Button_Click);
            // 
            // CPBack_Button
            // 
            this.CPBack_Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CPBack_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CPBack_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPBack_Button.Image = ((System.Drawing.Image)(resources.GetObject("CPBack_Button.Image")));
            this.CPBack_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CPBack_Button.Location = new System.Drawing.Point(12, 17);
            this.CPBack_Button.Name = "CPBack_Button";
            this.CPBack_Button.Size = new System.Drawing.Size(82, 35);
            this.CPBack_Button.TabIndex = 1;
            this.CPBack_Button.Text = "Back";
            this.CPBack_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPBack_Button.UseVisualStyleBackColor = true;
            this.CPBack_Button.Click += new System.EventHandler(this.CPBack_Button_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.BackColor = System.Drawing.SystemColors.Window;
            this.SearchBar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBar.Location = new System.Drawing.Point(100, 148);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(211, 31);
            this.SearchBar.TabIndex = 0;
            this.SearchBar.Leave += new System.EventHandler(this.SearchBar_Leave);
            // 
            // Qty_Box
            // 
            // 
            // 
            // 
            this.Qty_Box.CustomButton.Image = null;
            this.Qty_Box.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.Qty_Box.CustomButton.Name = "";
            this.Qty_Box.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.Qty_Box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Qty_Box.CustomButton.TabIndex = 1;
            this.Qty_Box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Qty_Box.CustomButton.UseSelectable = true;
            this.Qty_Box.CustomButton.Visible = false;
            this.Qty_Box.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.Qty_Box.Lines = new string[0];
            this.Qty_Box.Location = new System.Drawing.Point(101, 234);
            this.Qty_Box.MaxLength = 32767;
            this.Qty_Box.Name = "Qty_Box";
            this.Qty_Box.PasswordChar = '\0';
            this.Qty_Box.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Qty_Box.SelectedText = "";
            this.Qty_Box.SelectionLength = 0;
            this.Qty_Box.SelectionStart = 0;
            this.Qty_Box.ShortcutsEnabled = true;
            this.Qty_Box.Size = new System.Drawing.Size(139, 29);
            this.Qty_Box.TabIndex = 2;
            this.Qty_Box.UseSelectable = true;
            this.Qty_Box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Qty_Box.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(14, 244);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(61, 19);
            this.metroLabel7.TabIndex = 13;
            this.metroLabel7.Text = "Quantity:";
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(16, 160);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(78, 19);
            this.metroLabel15.TabIndex = 13;
            this.metroLabel15.Text = "Item Name:";
            // 
            // TQty_Label
            // 
            this.TQty_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TQty_Label.AutoSize = true;
            this.TQty_Label.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.TQty_Label.Location = new System.Drawing.Point(772, 491);
            this.TQty_Label.Name = "TQty_Label";
            this.TQty_Label.Size = new System.Drawing.Size(17, 19);
            this.TQty_Label.TabIndex = 56;
            this.TQty_Label.Text = "0";
            // 
            // TAmount_Label
            // 
            this.TAmount_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TAmount_Label.AutoSize = true;
            this.TAmount_Label.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.TAmount_Label.Location = new System.Drawing.Point(983, 491);
            this.TAmount_Label.Name = "TAmount_Label";
            this.TAmount_Label.Size = new System.Drawing.Size(17, 19);
            this.TAmount_Label.TabIndex = 58;
            this.TAmount_Label.Text = "0";
            // 
            // metroLabel17
            // 
            this.metroLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel17.Location = new System.Drawing.Point(853, 485);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(124, 25);
            this.metroLabel17.TabIndex = 57;
            this.metroLabel17.Text = "Total Amount=";
            // 
            // metroLabel16
            // 
            this.metroLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel16.Location = new System.Drawing.Point(676, 545);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(66, 25);
            this.metroLabel16.TabIndex = 59;
            this.metroLabel16.Text = "Return:";
            // 
            // Balance_Label
            // 
            this.Balance_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Balance_Label.AutoSize = true;
            this.Balance_Label.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.Balance_Label.Location = new System.Drawing.Point(764, 582);
            this.Balance_Label.Name = "Balance_Label";
            this.Balance_Label.Size = new System.Drawing.Size(17, 19);
            this.Balance_Label.TabIndex = 62;
            this.Balance_Label.Text = "0";
            // 
            // metroLabel11
            // 
            this.metroLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel11.Location = new System.Drawing.Point(676, 576);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(83, 25);
            this.metroLabel11.TabIndex = 61;
            this.metroLabel11.Text = "Balance=";
            // 
            // Price_Box
            // 
            // 
            // 
            // 
            this.Price_Box.CustomButton.Image = null;
            this.Price_Box.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.Price_Box.CustomButton.Name = "";
            this.Price_Box.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.Price_Box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Price_Box.CustomButton.TabIndex = 1;
            this.Price_Box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Price_Box.CustomButton.UseSelectable = true;
            this.Price_Box.CustomButton.Visible = false;
            this.Price_Box.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.Price_Box.Lines = new string[0];
            this.Price_Box.Location = new System.Drawing.Point(101, 199);
            this.Price_Box.MaxLength = 32767;
            this.Price_Box.Name = "Price_Box";
            this.Price_Box.PasswordChar = '\0';
            this.Price_Box.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Price_Box.SelectedText = "";
            this.Price_Box.SelectionLength = 0;
            this.Price_Box.SelectionStart = 0;
            this.Price_Box.ShortcutsEnabled = true;
            this.Price_Box.Size = new System.Drawing.Size(139, 29);
            this.Price_Box.TabIndex = 1;
            this.Price_Box.UseSelectable = true;
            this.Price_Box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Price_Box.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(14, 209);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(41, 19);
            this.metroLabel9.TabIndex = 22;
            this.metroLabel9.Text = "Price:";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ID_Box);
            this.panel2.Controls.Add(this.metroLabel1);
            this.panel2.Controls.Add(this.metroLabel3);
            this.panel2.Controls.Add(this.ODate_DTP);
            this.panel2.Controls.Add(this.metroLabel2);
            this.panel2.Controls.Add(this.DDate_DTP);
            this.panel2.Controls.Add(this.metroLabel5);
            this.panel2.Controls.Add(this.Category_CBox);
            this.panel2.Controls.Add(this.metroLabel4);
            this.panel2.Controls.Add(this.Vendor_CBox);
            this.panel2.Controls.Add(this.VendorPic_Box);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(40, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(642, 212);
            this.panel2.TabIndex = 0;
            // 
            // VendorPic_Box
            // 
            this.VendorPic_Box.Location = new System.Drawing.Point(420, 12);
            this.VendorPic_Box.Name = "VendorPic_Box";
            this.VendorPic_Box.Size = new System.Drawing.Size(181, 150);
            this.VendorPic_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VendorPic_Box.TabIndex = 16;
            this.VendorPic_Box.TabStop = false;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(427, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Show Vendor Details";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.AddNewItem);
            this.panel3.Controls.Add(this.WrongItem_Label);
            this.panel3.Controls.Add(this.Price_Box);
            this.panel3.Controls.Add(this.ItemPic_Box);
            this.panel3.Controls.Add(this.metroLabel9);
            this.panel3.Controls.Add(this.metroLabel15);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.metroLabel7);
            this.panel3.Controls.Add(this.SearchBar);
            this.panel3.Controls.Add(this.Qty_Box);
            this.panel3.Controls.Add(this.Stock_Button);
            this.panel3.Controls.Add(this.Consume_Button);
            this.panel3.Location = new System.Drawing.Point(735, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 319);
            this.panel3.TabIndex = 1;
            // 
            // AddNewItem
            // 
            this.AddNewItem.ActiveControl = null;
            this.AddNewItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddNewItem.Location = new System.Drawing.Point(41, 73);
            this.AddNewItem.Name = "AddNewItem";
            this.AddNewItem.Size = new System.Drawing.Size(101, 58);
            this.AddNewItem.TabIndex = 173;
            this.AddNewItem.Text = "New\r\nItem";
            this.AddNewItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddNewItem.TileImage = global::BPS.Properties.Resources.add1;
            this.AddNewItem.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddNewItem.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.AddNewItem.UseSelectable = true;
            this.AddNewItem.UseTileImage = true;
            this.AddNewItem.Click += new System.EventHandler(this.AddNewItem_Click);
            this.AddNewItem.MouseLeave += new System.EventHandler(this.AddNewItem_MouseLeave);
            this.AddNewItem.MouseHover += new System.EventHandler(this.AddNewItem_MouseHover);
            // 
            // WrongItem_Label
            // 
            this.WrongItem_Label.AutoSize = true;
            this.WrongItem_Label.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WrongItem_Label.ForeColor = System.Drawing.Color.Red;
            this.WrongItem_Label.Location = new System.Drawing.Point(98, 182);
            this.WrongItem_Label.Name = "WrongItem_Label";
            this.WrongItem_Label.Size = new System.Drawing.Size(126, 14);
            this.WrongItem_Label.TabIndex = 23;
            this.WrongItem_Label.Text = "*Wrong Item Name...!!!";
            this.WrongItem_Label.Visible = false;
            // 
            // ItemPic_Box
            // 
            this.ItemPic_Box.Location = new System.Drawing.Point(155, 7);
            this.ItemPic_Box.Name = "ItemPic_Box";
            this.ItemPic_Box.Size = new System.Drawing.Size(154, 135);
            this.ItemPic_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ItemPic_Box.TabIndex = 15;
            this.ItemPic_Box.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BPS.Properties.Resources.Very_Basic_Search_icon;
            this.pictureBox2.Location = new System.Drawing.Point(281, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // Stock_Button
            // 
            this.Stock_Button.BackColor = System.Drawing.Color.Transparent;
            this.Stock_Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Stock_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stock_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stock_Button.Image = ((System.Drawing.Image)(resources.GetObject("Stock_Button.Image")));
            this.Stock_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Stock_Button.Location = new System.Drawing.Point(131, 271);
            this.Stock_Button.Name = "Stock_Button";
            this.Stock_Button.Size = new System.Drawing.Size(117, 35);
            this.Stock_Button.TabIndex = 4;
            this.Stock_Button.Text = " View Stock";
            this.Stock_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Stock_Button.UseVisualStyleBackColor = false;
            // 
            // Consume_Button
            // 
            this.Consume_Button.BackColor = System.Drawing.Color.Transparent;
            this.Consume_Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Consume_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Consume_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consume_Button.Image = ((System.Drawing.Image)(resources.GetObject("Consume_Button.Image")));
            this.Consume_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Consume_Button.Location = new System.Drawing.Point(246, 216);
            this.Consume_Button.Name = "Consume_Button";
            this.Consume_Button.Size = new System.Drawing.Size(66, 35);
            this.Consume_Button.TabIndex = 3;
            this.Consume_Button.Text = "Add";
            this.Consume_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Consume_Button.UseVisualStyleBackColor = false;
            this.Consume_Button.Click += new System.EventHandler(this.Consume_Button_Click);
            // 
            // Dues_Label
            // 
            this.Dues_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Dues_Label.AutoSize = true;
            this.Dues_Label.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.Dues_Label.Location = new System.Drawing.Point(950, 582);
            this.Dues_Label.Name = "Dues_Label";
            this.Dues_Label.Size = new System.Drawing.Size(17, 19);
            this.Dues_Label.TabIndex = 64;
            this.Dues_Label.Text = "0";
            // 
            // metroLabel13
            // 
            this.metroLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel13.Location = new System.Drawing.Point(882, 576);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(62, 25);
            this.metroLabel13.TabIndex = 63;
            this.metroLabel13.Text = "Dues=";
            // 
            // Return_Textbox
            // 
            this.Return_Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Return_Textbox.CustomButton.Image = null;
            this.Return_Textbox.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.Return_Textbox.CustomButton.Name = "";
            this.Return_Textbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Return_Textbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Return_Textbox.CustomButton.TabIndex = 1;
            this.Return_Textbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Return_Textbox.CustomButton.UseSelectable = true;
            this.Return_Textbox.CustomButton.Visible = false;
            this.Return_Textbox.Lines = new string[0];
            this.Return_Textbox.Location = new System.Drawing.Point(796, 545);
            this.Return_Textbox.MaxLength = 32767;
            this.Return_Textbox.Name = "Return_Textbox";
            this.Return_Textbox.PasswordChar = '\0';
            this.Return_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Return_Textbox.SelectedText = "";
            this.Return_Textbox.SelectionLength = 0;
            this.Return_Textbox.SelectionStart = 0;
            this.Return_Textbox.ShortcutsEnabled = true;
            this.Return_Textbox.Size = new System.Drawing.Size(204, 23);
            this.Return_Textbox.TabIndex = 65;
            this.Return_Textbox.UseSelectable = true;
            this.Return_Textbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Return_Textbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Return_Textbox.Validating += new System.ComponentModel.CancelEventHandler(this.Return_Textbox_Validating);
            // 
            // Cancel_Order
            // 
            this.Cancel_Order.ActiveControl = null;
            this.Cancel_Order.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Cancel_Order.Location = new System.Drawing.Point(290, 484);
            this.Cancel_Order.Name = "Cancel_Order";
            this.Cancel_Order.Size = new System.Drawing.Size(109, 81);
            this.Cancel_Order.Style = MetroFramework.MetroColorStyle.Red;
            this.Cancel_Order.TabIndex = 174;
            this.Cancel_Order.Text = "Cancel Order";
            this.Cancel_Order.TileImage = global::BPS.Properties.Resources.cancel_128;
            this.Cancel_Order.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Cancel_Order.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.Cancel_Order.UseSelectable = true;
            this.Cancel_Order.UseTileImage = true;
            this.Cancel_Order.Click += new System.EventHandler(this.Cancel_Order_Click);
            this.Cancel_Order.MouseLeave += new System.EventHandler(this.Cancel_Order_MouseLeave);
            this.Cancel_Order.MouseHover += new System.EventHandler(this.Cancel_Order_MouseHover);
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item";
            this.ItemName.Name = "ItemName";
            this.ItemName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemName.Width = 200;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Quantity";
            this.Qty.Name = "Qty";
            this.Qty.Width = 50;
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.ReadOnly = true;
            this.UOM.Width = 80;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.Width = 80;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 80;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 80;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Image = global::BPS.Properties.Resources.datagridEdit;
            this.Edit.Name = "Edit";
            this.Edit.Width = 30;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::BPS.Properties.Resources.datagrid_delete1;
            this.Delete.Name = "Delete";
            this.Delete.Width = 30;
            // 
            // Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 674);
            this.Controls.Add(this.Cancel_Order);
            this.Controls.Add(this.Return_Textbox);
            this.Controls.Add(this.Dues_Label);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Balance_Label);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel16);
            this.Controls.Add(this.TAmount_Label);
            this.Controls.Add(this.metroLabel17);
            this.Controls.Add(this.TQty_Label);
            this.Controls.Add(this.CPButton_Box);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Remarks_Box);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.PAmount_Textbox);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.Item_Grid);
            this.Name = "Purchase";
            this.Text = "PURCHASE";
            this.Load += new System.EventHandler(this.Purchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Item_Grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CPButton_Box.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VendorPic_Box)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPic_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox ID_Box;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DateTimePicker ODate_DTP;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DateTimePicker DDate_DTP;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox Category_CBox;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox Vendor_CBox;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.PictureBox VendorPic_Box;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView Item_Grid;
        private MetroFramework.Controls.MetroTextBox PAmount_Textbox;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox Remarks_Box;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox CPButton_Box;
        private System.Windows.Forms.Button CPUpdate_Button;
        public System.Windows.Forms.Button CPBack_Button;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox SearchBar;
        public System.Windows.Forms.Button Stock_Button;
        public System.Windows.Forms.Button Consume_Button;
        private MetroFramework.Controls.MetroTextBox Qty_Box;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.PictureBox ItemPic_Box;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel TQty_Label;
        private MetroFramework.Controls.MetroLabel TAmount_Label;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel Balance_Label;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox Price_Box;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label WrongItem_Label;
        private MetroFramework.Controls.MetroLabel Dues_Label;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox Return_Textbox;
        private MetroFramework.Controls.MetroTile AddNewItem;
        private MetroFramework.Controls.MetroTile Cancel_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}