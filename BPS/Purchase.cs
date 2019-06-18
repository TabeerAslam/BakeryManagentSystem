using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace BPS
{
    public partial class Purchase : MetroFramework.Forms.MetroForm
    {
        string task = "";
        double totalQty = 0;
        double totalAmt = 0;
        DBClass db = new DBClass();
        public Purchase()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            timer.Start();
            ID_Box.Text = db.autoID("Select MAX(PurchaseID) from Purchase", "Purchase").ToString();
            db.fillCombo(Category_CBox, "Select CategoryName From Category where MainCategory= 'Raw Materials' OR MainCategory= 'Company Products'");
        }

        private void ODate_DTP_ValueChanged(object sender, EventArgs e)
        {
            DDate_DTP.MinDate = ODate_DTP.Value;
        }

        private void Category_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vendor_CBox.Text = null;
            VendorPic_Box.Image = null;
            db.fillCombo(Vendor_CBox, "Select Name from Vendor where Category='" + Category_CBox.Text + "'");
            string Category = db.ReturnValueFromDB("Select MainCategory from Category where CategoryName='" + Category_CBox.Text + "'");
            if (Category == "Raw Materials")
            {
                //itemFill(Item_Grid, "Select Name from RawMaterial");
                db.search(SearchBar, "Select Name from RawMaterial");
            }
            else if (Category == "Company Products")
            {
                //itemFill(Item_Grid, "Select Name from CompanyProducts where CategoryID=(Select CategoryID from Category where CategoryName='" + Category_CBox.Text + "')");
                db.search(SearchBar, "Select Name from CompanyProducts where CategoryID=(Select CategoryID from Category where CategoryName='" + Category_CBox.Text + "')");
            }
        }

        public void itemFill(DataGridView dgw, string q)
        {
            try
            {
                for (int i = 0; i < dgw.Rows.Count; i++)
                {
                    if (Item_Grid.Rows[i].Cells[0].Value != null)
                    {
                        continue;
                    }
                    DataGridViewComboBoxCell c = (DataGridViewComboBoxCell)dgw.Rows[i].Cells[0];
                    db.datagridcombox(c, q);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Failed to Update Data in ComboBox of Gridview", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Vendor_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Vendor_CBox.Text == null || Vendor_CBox.Text == "")
            {
                VendorPic_Box.Image = null;                
            }
            else 
            {
                string Name = Vendor_CBox.Text;
                VendorPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Image from Vendor where Name='" + Name + "'"));
            }
        }

        private void SearchBar_Leave(object sender, EventArgs e)
        {
            if (SearchBar.Text != null && SearchBar.Text != "")
            {
                string ItemName = SearchBar.Text;
                string Category = db.ReturnValueFromDB("Select MainCategory from Category where CategoryName='" + Category_CBox.Text + "'");
                if (Category == "Raw Materials")
                {
                    if (db.checkValue("select Name from RawMaterial", ItemName) == true)
                    {
                        WrongItem_Label.Visible = false;
                        Consume_Button.Enabled = true;
                        ItemPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from RawMaterial where Name='" + ItemName + "'"));
                    }
                    else
                    {
                        WrongItem_Label.Visible = true;
                        Consume_Button.Enabled = false;
                        ItemPic_Box.Image = null;
                    }
                }
                else if (Category == "Company Products")
                {
                    if (db.checkValue("select Name from CompanyProducts", ItemName) == true)
                    {
                        WrongItem_Label.Visible = false;
                        Consume_Button.Enabled = true;
                        Price_Box.Enabled = true;
                        Qty_Box.Enabled = true;
                        ItemPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from CompanyProducts where Name='" + ItemName + "'"));
                    }
                    else
                    {
                        WrongItem_Label.Visible = true;
                        Consume_Button.Enabled = false;
                        Price_Box.Enabled = false;
                        Qty_Box.Enabled = false;
                        ItemPic_Box.Image = null;
                    }
                }
            }
            else
            {
                ItemPic_Box.Image = null;
            }
        }

        private void Item_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (Item_Grid.CurrentRow.Cells[1].Value != null && Item_Grid.CurrentRow.Cells[0].Value != null)
            //{
            //    string Category = db.ReturnValueFromDB("Select MainCategory from Category where CategoryName='" + Category_CBox.Text + "'");
            //    string ItemName = Item_Grid.CurrentRow.Cells[0].Value.ToString();
            //    double Qty = Convert.ToDouble(Item_Grid.CurrentRow.Cells[1].Value.ToString());
            //    string UOMM = "";
            //    double price = 0;
            //    if (Category == "Raw Materials")
            //    {
            //        UOMM = db.ReturnValueFromDB("Select UOM from RawMaterials where Name='" + ItemName + "'");
            //        price = Convert.ToDouble(db.ReturnValueFromDB("Select Price from RawMaterials where Name='" + ItemName + "'"));
            //    }
            //    else if (Category == "Company Products")
            //    {
            //        UOMM = db.ReturnValueFromDB("Select UOM from CompanyProducts where Name='" + ItemName + "'");
            //        price = Convert.ToDouble(db.ReturnValueFromDB("Select Price from CompanyProducts where Name='" + ItemName + "'"));
            //    }
            //    if (Category == "Raw Materials")
            //    {
            //        itemFill(Item_Grid, "Select Name from RawMaterial");
            //        db.search(SearchBar, "Select Name from RawMaterial");
            //    }
            //    else if (Category == "Company Products")
            //    {
            //        itemFill(Item_Grid, "Select Name from CompanyProducts where Category='" + Category_CBox.Text + "'");
            //        db.search(SearchBar, "Select Name from CompanyProducts where Category='" + Category_CBox.Text + "'");
            //    }
            //    Item_Grid.CurrentRow.Cells[2].Value = UOMM;
            //    Item_Grid.CurrentRow.Cells[4].Value = Category_CBox.Text;
            //}
            //if (Item_Grid.CurrentRow.Cells[3].Value != null && Item_Grid.CurrentRow.Cells[3].Value.ToString() != "")
            //{
            //    double amount = 0;
            //    amount = Convert.ToDouble(Item_Grid.CurrentRow.Cells[1].Value.ToString()) * Convert.ToDouble(Item_Grid.CurrentRow.Cells[3].Value.ToString());
            //    Item_Grid.CurrentRow.Cells[5].Value = amount.ToString();
            //}
        }

        private void totalCalculator()
        {
            totalAmt = 0;
            totalQty = 0;
            foreach (DataGridViewRow rows in Item_Grid.Rows)
            {
                if (rows.Cells[0].Value != null)
                {

                    totalQty += Convert.ToDouble(rows.Cells[1].Value.ToString());
                    totalAmt += Convert.ToDouble(rows.Cells[5].Value.ToString());
                }
            }
            TQty_Label.Text = totalQty.ToString();
            TAmount_Label.Text = totalAmt.ToString();
        }

        private void Item_Grid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            totalCalculator();
        }

        private void PAmount_Textbox_TextChanged(object sender, EventArgs e)
        {
            double PaidAmt = 0;
            double RetAmt = 0;
            double Balance = 0;
            double totAmt = Convert.ToDouble(TAmount_Label.Text);
            if (PAmount_Textbox.Text != null && PAmount_Textbox.Text != "")
            {
                PaidAmt += Convert.ToDouble(PAmount_Textbox.Text.ToString());
                if (PaidAmt > totAmt)
                {
                    RetAmt = PaidAmt - totAmt;
                    Balance = 0;
                }
                else
                {
                    Balance = totAmt - PaidAmt;
                    RetAmt = 0;
                }
                Return_Textbox.Text = RetAmt.ToString();
                Balance_Label.Text = Balance.ToString();
            }
        }

        private void Consume_Button_Click(object sender, EventArgs e)
        {
            string ItemName = SearchBar.Text;
            if (ItemName != null && ItemName!="")
            {
                string Category = db.ReturnValueFromDB("Select MainCategory from Category where CategoryName='" + Category_CBox.Text + "'");
                int Qty = Convert.ToInt32(Qty_Box.Text);
                string UOMM = "";
                double price = Convert.ToDouble(Price_Box.Text);
                double amount = 0;
                if (Category == "Raw Materials")
                {
                    UOMM = db.ReturnValueFromDB("Select UOM from RawMaterial where Name='" + ItemName + "'");
                }
                else if (Category == "Company Products")
                {
                    UOMM = db.ReturnValueFromDB("Select [UnitName] from UOM where UnitID=(Select UOMID from [dbo].[CompanyProducts] where Name='" + ItemName + "')");
                }
                if (task == "Edit")
                {
                    Item_Grid.CurrentRow.Cells[0].Value = ItemName;
                    Item_Grid.CurrentRow.Cells[1].Value = Qty.ToString();
                    Item_Grid.CurrentRow.Cells[2].Value = UOMM;
                    Item_Grid.CurrentRow.Cells[3].Value = price;
                    Item_Grid.CurrentRow.Cells[4].Value = Category_CBox.Text;
                    amount = Qty * price;
                    Item_Grid.CurrentRow.Cells[5].Value = amount.ToString();
                    task = "Add";
                }
                else
                {
                    Item_Grid.Rows.Add();
                    for (int i = 0; i < Item_Grid.RowCount; i++)
                    {
                        if (Item_Grid.Rows[i].Cells[0].Value == null)
                        {
                            Item_Grid.Rows[i].Cells[0].Value = ItemName;
                            Item_Grid.Rows[i].Cells[1].Value = Qty.ToString();
                            Item_Grid.Rows[i].Cells[2].Value = UOMM;
                            Item_Grid.Rows[i].Cells[3].Value = price;
                            Item_Grid.Rows[i].Cells[4].Value = Category_CBox.Text;
                            amount = Qty * price;
                            Item_Grid.Rows[i].Cells[5].Value = amount.ToString();
                        }
                    }
                }
                totalCalculator();
                SearchBar.Text = null;
                Qty_Box.Text = null;
                Price_Box.Text = null;
                ItemPic_Box.Image = null;
            }
        }

        private void CPUpdate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                if (PAmount_Textbox.Text == "0")
                {
                    status = "Unpaid";
                }
                else if (Convert.ToDouble(Balance_Label.Text) == 0)
                {
                    status = "Paid";
                }
                else if (Convert.ToDouble(Balance_Label.Text) > 0 && Convert.ToDouble(PAmount_Textbox.Text) > 0)
                {
                    status = "Partially Paid";
                }
                int venID = 0;
                venID = Convert.ToInt32(db.ReturnValueFromDB("select VendorID from Vendor where Name ='" + Vendor_CBox.Text + "' AND Category='" + Category_CBox.Text + "'"));
                if (Convert.ToDouble(Balance_Label.Text) > 0)
                {
                    db.DataManupulationOperation("Update Vendor set Balance+='" + Convert.ToDouble(Balance_Label.Text) + "' Where VendorID='" + venID + "'");
                }
                else if (Convert.ToDouble(Dues_Label.Text) > 0)
                {
                    db.DataManupulationOperation("Update Vendor set Dues+='" + Convert.ToDouble(Dues_Label.Text) + "' Where VendorID='" + venID + "'");
                }
                db.DataManupulationOperation("insert into Purchase(PurchaseID,VendorID,Status,OrderDate,DeliveryDate,TotalAmount,Remarks) values('" + Convert.ToInt32(ID_Box.Text) + "','" + venID + "','" + status + "','" + Convert.ToDateTime(ODate_DTP.Text) + "','" + Convert.ToDateTime(DDate_DTP.Text) + "','" + TAmount_Label.Text + "','" + Remarks_Box.Text + "')");
                for (int i = 0; i < Item_Grid.RowCount; i++)
                {
                    string Name = Item_Grid.Rows[i].Cells[0].Value.ToString();
                    double qty = Convert.ToDouble(Item_Grid.Rows[i].Cells[1].Value.ToString());
                    double price = Convert.ToDouble(Item_Grid.Rows[i].Cells[3].Value.ToString());
                    string category = Item_Grid.Rows[i].Cells[4].Value.ToString();
                    string mainCategory = db.ReturnValueFromDB("Select MainCategory from Category where CategoryName='" + category + "'");
                    double amt = Convert.ToDouble(Item_Grid.Rows[i].Cells[5].Value.ToString());
                    int itemID = 0;
                    if (mainCategory == "Raw Materials")
                    {
                        itemID = Convert.ToInt32(db.ReturnValueFromDB("Select RawMaterialID from RawMaterial where Name='" + Name + "'"));
                        db.DataManupulationOperation("Update RawMaterial set Price='" + price + "',Qty+='" + qty + "' where RawMaterialID='" + itemID + "'");
                        db.DataManupulationOperation("insert into PurchaseLineItems(PurchaseID,RawMaterialID,Qty,Price,Amount,Category) values('" + Convert.ToInt32(ID_Box.Text) + "','" + itemID + "','" + qty + "','" + price + "','" + amt + "','" + category + "')");
                    }
                    else if (mainCategory == "Company Products")
                    {
                        itemID = Convert.ToInt32(db.ReturnValueFromDB("Select ID from CompanyProducts where Name='" + Name + "'"));
                        db.DataManupulationOperation("Update CompanyProducts set Price='" + price + "',Qty+='" + qty + "' where ID='" + itemID + "'");
                        db.DataManupulationOperation("insert into PurchaseLineItems(PurchaseID,CompanyProductID,Qty,Price,Amount,Category) values('" + Convert.ToInt32(ID_Box.Text) + "','" + itemID + "','" + qty + "','" + price + "','" + amt + "','" + category + "')");
                    }

                }
                MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Production Done...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Failed to Update Data...!!!", "Insertion Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refresh();
        }
        public void refresh()
        {
            Category_CBox.Text = null;
            Vendor_CBox.Text = null;
            VendorPic_Box.Image = null;
            for (int i = 0; i < Item_Grid.RowCount; )
			{
                Item_Grid.Rows.RemoveAt(i);
			}
            ItemPic_Box.Image = null;
            SearchBar.Text = null;
            Qty_Box.Text = null;
            Price_Box.Text = null;
            TQty_Label.Text = "0";
            TAmount_Label.Text = "0";
            PAmount_Textbox.Text = null;
            Balance_Label.Text = "0";
            Return_Textbox.Text = "0";
            Remarks_Box.Text = null;
            ID_Box.Text = db.autoID("Select MAX(PurchaseID) from Purchase", "Purchase").ToString();
            db.fillCombo(Category_CBox, "Select CategoryName From Category where MainCategory= 'Raw Materials' OR MainCategory= 'Company Products'");
        }

        private void CPBack_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Return_Textbox_Validating(object sender, CancelEventArgs e)
        {
            int returnamt = Convert.ToInt32(PAmount_Textbox.Text) - Convert.ToInt32(TAmount_Label.Text);
            if (Return_Textbox.Text == "")
            {

            }
            else if (Convert.ToInt32(Return_Textbox.Text) < returnamt)
            {
                int dues = returnamt - Convert.ToInt32(Return_Textbox.Text);
                Balance_Label.Text = "0";
                Dues_Label.Text = dues.ToString();
            }
            else if (Convert.ToInt32(Return_Textbox.Text) > returnamt)
            {
                int bal = Convert.ToInt32(Return_Textbox.Text) - returnamt;
                Balance_Label.Text = bal.ToString();
                Dues_Label.Text = "0";
            }
            else if (Convert.ToInt32(Return_Textbox.Text) == returnamt)
            {
                Dues_Label.Text = "0";
            }
        }

        private void AddNewItem_Click(object sender, EventArgs e)
        {
            if (Category_CBox.Text == null || Category_CBox.Text == "")
            {
                MetroMessageBox.Show(this, "Kindly Select The Category First...!!!", "Category Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string tab = db.ReturnValueFromDB("Select MainCategory From Category where CategoryName = '" + Category_CBox.Text + "'");
                Entry en = new Entry(tab, "Add");
                en.ShowDialog();
            }
        }

        private void AddNewItem_MouseHover(object sender, EventArgs e)
        {
            AddNewItem.Size = new System.Drawing.Size(111, 68);
            AddNewItem.Style = MetroFramework.MetroColorStyle.Lime;
        }

        private void AddNewItem_MouseLeave(object sender, EventArgs e)
        {
            AddNewItem.Size = new System.Drawing.Size(101, 58);
            AddNewItem.Style = MetroFramework.MetroColorStyle.Default;
        }

        private void Cancel_Order_MouseHover(object sender, EventArgs e)
        {
            Cancel_Order.Size = new System.Drawing.Size(119, 91);
            Cancel_Order.Style = MetroFramework.MetroColorStyle.Lime;
        }

        private void Cancel_Order_MouseLeave(object sender, EventArgs e)
        {
            Cancel_Order.Size = new System.Drawing.Size(109, 81);
            Cancel_Order.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void Cancel_Order_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "Are You sure you Want to Cancel Current Order...???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Vendor_CBox.Text == null || Vendor_CBox.Text == "")
            {
                MetroMessageBox.Show(this, "Kindly Select The Vendor First...!!!", "Vendor Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int VendorID = Convert.ToInt32(db.ReturnValueFromDB("Select VendorID from Vendor where Name='" + Vendor_CBox.Text + "'"));
                Entry en = new Entry(VendorID, "Vendor", "Show");
                en.ShowDialog();
            }
        }

        private void Item_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Item_Grid.CurrentRow.Cells[6].Selected == true && Item_Grid.CurrentRow.Cells[7].Selected == false)//Edit
            {
                this.task = "Edit";
                if (Item_Grid.RowCount > 0)
                {
                    if (Item_Grid.Rows[0].Cells[0].Value != null)
                    {
                        string ItemName = Item_Grid.CurrentRow.Cells[0].Value.ToString();
                        string Price = Item_Grid.CurrentRow.Cells[3].Value.ToString();
                        string Category = Item_Grid.CurrentRow.Cells[4].Value.ToString();
                        string qty = Item_Grid.CurrentRow.Cells[1].Value.ToString();
                        SearchBar.Text = ItemName;
                        Qty_Box.Text = qty;
                        Price_Box.Text = Price;
                        if (Category == "Raw Materials")
                        {
                            ItemPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from RawMaterial where Name='" + ItemName + "'"));
                        }
                        else
                        {
                            ItemPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from CompanyProducts where Name='" + ItemName + "'"));
                        }
                    }
                }
            }
            else if (Item_Grid.CurrentRow.Cells[6].Selected == false && Item_Grid.CurrentRow.Cells[7].Selected == true)//Delete
            {
                if (Item_Grid.RowCount > 0)
                {
                    if (MetroMessageBox.Show(this, "Are You sure you Want to Delete Current Row...???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int index = Item_Grid.CurrentCell.RowIndex;
                        Item_Grid.Rows.RemoveAt(index);
                        totalCalculator();
                    }
                }
            }
        }
    }
}
