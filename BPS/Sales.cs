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
    public partial class Sales : MetroFramework.Forms.MetroForm
    {
        int smanID = 0;
        string salesman = "";
        string task = "Add";
        DBClass db = new DBClass();
        double totQty = 0;
        double totAmt = 0;
        double PaidAmt = 0;
        double RetAmt = 0;
        double Balance = 0;
        public Sales(string sman, int ID)
        {
            this.smanID = ID;
            this.salesman = sman;
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            int AuthLevel = Convert.ToInt32(db.ReturnValueFromDB("Select Level from AuthorizationLevel where LevelID=(Select AuthorizationLevelID from Employees where EmployeeID='" + smanID + "')"));
            if (AuthLevel > 0 && AuthLevel <= 3)
            {
                timer.Start();
                Salesman_PicBox.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where Name='" + salesman + "'"));
                Salesman_Label.Text = salesman;
                ID_Box.Text = db.autoID("Select MAX(OrderID) from Sales", "Sales").ToString();
                db.fillCombo(Customer_CBox, "Select Name from Customer");
                db.fillCombo(Category_CBox, "Select Distinct MainCategory From Category where MainCategory!= 'Raw Materials'");
            }
            else
            {
                if (MetroMessageBox.Show(this, "You Don't have access over here...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void Current_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Current_RadioButton.Checked == true)
            {
                DDate_DTP.Enabled = false;
            }
            else
            {
                DDate_DTP.Enabled = true;
            }
        }

        private void Category_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Category_CBox.Text=="Bakery Products")
            {
                //itemFill(Item_Grid, "Select Name from BakeryItems");
                db.search(SearchBar, "Select Name from BakeryItems");
            }
            else
            {
                //itemFill(Item_Grid, "Select Name from CompanyProducts");
                db.search(SearchBar, "Select Name from CompanyProducts");
            }
        }

        //public void itemFill(DataGridView dgw,string q)
        //{
        //    try
        //    {
        //        for (int i = 0; i < dgw.Rows.Count; i++)
        //        {
        //            if (Item_Grid.Rows[i].Cells[0].Value != null)
        //            {
        //                continue;
        //            }
        //            DataGridViewComboBoxCell c = (DataGridViewComboBoxCell)dgw.Rows[i].Cells[0];
        //            db.datagridcombox(c, q);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MetroMessageBox.Show(this, "Failed to Update Data in ComboBox of Gridview", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void Consume_Button_Click(object sender, EventArgs e)
        {
            string ItemName = SearchBar.Text;
            double Qty = Convert.ToDouble(Qty_Box.Text);
            string UOMM = "";
            double price = 0;
            int avlQty = 0;
            double amount = 0;
            if (Category_CBox.Text == "Bakery Products")
            {
                UOMM = db.ReturnValueFromDB("Select UnitName from UOM where UnitID=(Select UOMID from BakeryItems where Name='" + ItemName + "')");
                price = Convert.ToDouble(db.ReturnValueFromDB("Select Price from BakeryItems where Name='" + ItemName + "'"));
                avlQty = Convert.ToInt32(db.ReturnValueFromDB("Select Qty From BakeryItems where Name='" + ItemName + "'"));
            }
            else
            {
                UOMM = db.ReturnValueFromDB("Select UnitName from UOM where UnitID=(Select UOMID from CompanyProducts where Name='" + ItemName + "')");
                price = Convert.ToDouble(db.ReturnValueFromDB("Select Price from CompanyProducts where Name='" + ItemName + "'"));
                avlQty = Convert.ToInt32(db.ReturnValueFromDB("Select Qty From CompanyProducts where Name='" + ItemName + "'"));
            }
            if (task=="Edit")
            {
                if (avlQty >= Qty)
                {
                    Item_Grid.CurrentRow.Cells[0].Value = ItemName;
                    Item_Grid.CurrentRow.Cells[1].Value = Qty.ToString();
                    Item_Grid.CurrentRow.Cells[2].Value = UOMM;
                    Item_Grid.CurrentRow.Cells[3].Value = Category_CBox.Text;
                    Item_Grid.CurrentRow.Cells[4].Value = price;
                    amount = Qty * price;
                    Item_Grid.CurrentRow.Cells[5].Value = amount.ToString();
                    totalCalculator();
                }
                else
                {
                    MetroMessageBox.Show(this, "Required Qty for " + ItemName + " is Not Available...!!!", "Less Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.task = "Add";
            }
            else
            {
                if (avlQty >= Qty)
                {
                    Item_Grid.Rows.Add();
                    for (int i = 0; i < Item_Grid.RowCount; i++)
                    {
                        if (Item_Grid.Rows[i].Cells[0].Value == null)
                        {
                            Item_Grid.Rows[i].Cells[0].Value = ItemName;
                            Item_Grid.Rows[i].Cells[1].Value = Qty.ToString();
                            Item_Grid.Rows[i].Cells[2].Value = UOMM;
                            Item_Grid.Rows[i].Cells[3].Value = Category_CBox.Text;
                            Item_Grid.Rows[i].Cells[4].Value = price;
                            amount = Qty * price;
                            Item_Grid.Rows[i].Cells[5].Value = amount.ToString();
                        }
                    }
                    totalCalculator();
                }
                else
                {
                    MetroMessageBox.Show(this, "Required Qty for " + ItemName + " is Not Available...!!!", "Less Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            SearchBar.Text = null;
            Qty_Box.Text = null;
            ItemPic_Box.Image = null;
        }

        private void Item_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (Item_Grid.CurrentRow.Cells[1].Value != null && Item_Grid.CurrentRow.Cells[0].Value != null)
            //{
            //    string ItemName = Item_Grid.CurrentRow.Cells[0].Value.ToString();
            //    int Qty = Convert.ToInt32(Item_Grid.CurrentRow.Cells[1].Value.ToString());
            //    int avlQty = 0;
            //    string UOMM = "";
            //    double price = 0;
            //    double amount = 0;
            //    if (Category_CBox.Text == "Bakery Products")
            //    {
            //        UOMM = db.ReturnValueFromDB("Select UOM from BakeryItems where Name='" + ItemName + "'");
            //        price = Convert.ToDouble(db.ReturnValueFromDB("Select Price from BakeryItems where Name='" + ItemName + "'"));
            //        avlQty = Convert.ToInt32(db.ReturnValueFromDB("Select Qty From BakeryItems where Name='" + ItemName + "'"));
            //    }
            //    else
            //    {
            //        UOMM = db.ReturnValueFromDB("Select UOM from CompanyProducts where Name='" + ItemName + "'");
            //        price = Convert.ToDouble(db.ReturnValueFromDB("Select Price from CompanyProducts where Name='" + ItemName + "'"));
            //        avlQty = Convert.ToInt32(db.ReturnValueFromDB("Select Qty From CompanyProducts where Name='" + ItemName + "'"));
            //    }
            //    if (avlQty >= Qty)
            //    {
                    
            //                Item_Grid.CurrentRow.Cells[2].Value = UOMM;
            //                Item_Grid.CurrentRow.Cells[3].Value = Category_CBox.Text;
            //                Item_Grid.CurrentRow.Cells[4].Value = price;
            //                amount = Qty * price;
            //                Item_Grid.CurrentRow.Cells[5].Value = amount.ToString();
            //    }
            //    else
            //    {
            //        MetroMessageBox.Show(this, "Required Qty for " + ItemName + " is Not Available...!!!", "Less Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    if (Category_CBox.Text == "Bakery Products")
            //    {
            //        //itemFill(Item_Grid, "Select Name from BakeryItems");
            //        db.search(SearchBar, "Select Name from BakeryItems");
            //    }
            //    else
            //    {
            //        //itemFill(Item_Grid, "Select Name from CompanyProducts");
            //        db.search(SearchBar, "Select Name from CompanyProducts");
            //    }
            //}
        }

        private void Item_Grid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            totalCalculator();
        }

        private void PAmount_Textbox_TextChanged_1(object sender, EventArgs e)
        {
            if (PAmount_Textbox.Text != null && PAmount_Textbox.Text != "")
            {
                PaidAmt = Convert.ToDouble(PAmount_Textbox.Text.ToString());
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
                Balance_Textbox.Text = Balance.ToString();
            }
        }

        private void SearchBar_Leave(object sender, EventArgs e)
        {
            if (SearchBar.Text != null && SearchBar.Text != "")
            {
                string ItemName = SearchBar.Text;
                if (Category_CBox.Text == "Bakery Products")
                {
                    if (db.checkValue("select Name from BakeryItems", ItemName) == true)
                    {
                        WrongItem_Label.Visible = false;
                        Consume_Button.Enabled = true;
                        ItemPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Image from BakeryItems where Name='" + ItemName + "'"));
                    }
                    else
                    {
                        WrongItem_Label.Visible = true;
                        Consume_Button.Enabled = false;
                        ItemPic_Box.Image = null;
                    }
                }
                else
                {
                    if (db.checkValue("select Name from CompanyProducts", ItemName) == true)
                    {
                        WrongItem_Label.Visible = false;
                        Consume_Button.Enabled = true;
                        ItemPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from CompanyProducts where Name='" + ItemName + "'"));
                    }
                    else
                    {
                        WrongItem_Label.Visible = true;
                        Consume_Button.Enabled = false;
                        ItemPic_Box.Image = null;
                    }
                }
            }
        }

        public void totalCalculator()
        {
            totAmt = 0;
            totQty = 0;
            for (int i = 0; i < Item_Grid.RowCount; i++)
            {
                if (Item_Grid.Rows[i].Cells[5].Value.ToString() != "" && Item_Grid.Rows[i].Cells[1].Value.ToString() != "")
                {
                    totAmt += Convert.ToDouble(Item_Grid.Rows[i].Cells[5].Value.ToString());
                    totQty += Convert.ToDouble(Item_Grid.Rows[i].Cells[1].Value.ToString());
                }
            }
            TAmount_Textbox.Text = totAmt.ToString();
            TQty_Textbox.Text = totQty.ToString();
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
                        string Category = Item_Grid.CurrentRow.Cells[3].Value.ToString();
                        string qty = Item_Grid.CurrentRow.Cells[1].Value.ToString();
                        SearchBar.Text = ItemName;
                        Qty_Box.Text = qty;
                        if (Category == "Bakery Products")
                        {
                            ItemPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Image from BakeryItems where Name='" + ItemName + "'"));
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
                this.task = "Add";
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

        private void Update_Button_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                string orderType = "";
                if (Current_RadioButton.Checked == true)
                {
                    orderType = Current_RadioButton.Text;
                }
                else
                {
                    orderType = Delivery_RadioButton.Text;
                }
                string status = "";
                if (PAmount_Textbox.Text == "0")
                {
                    status = "Unpaid";
                }
                else if (Convert.ToDouble(Balance_Textbox.Text) == 0)
                {
                    status = "Paid";
                }
                else if (Convert.ToDouble(Balance_Textbox.Text) > 0 && Convert.ToDouble(PAmount_Textbox.Text) > 0)
                {
                    status = "Partially Paid";
                }
                int cusID = 0;
                if (Customer_CBox.Text == "Mr Walking Customer")
                {
                    cusID = 0;
                }
                else
                {
                    cusID = Convert.ToInt32(db.ReturnValueFromDB("select CustomerID from Customer where Name ='" + Customer_CBox.Text + "'"));
                }
                if (Convert.ToInt32(Balance_Textbox.Text) == 0)
                {
                    db.DataManupulationOperation("insert into Sales(OrderID,OrderType,OrderDate,DeliveryDate,TotalQty,TotalAmount,Remarks,Status,SalesmanID,CustomerID) values('" + Convert.ToInt32(ID_Box.Text) + "','" + orderType + "','" + DateTime.Now + "','" + Convert.ToDateTime(DDate_DTP.Text) + "','" + TQty_Textbox.Text + "','" + TAmount_Textbox.Text + "','" + Remarks_Box.Text + "','" + status + "','" + smanID + "','" + cusID + "')");
                    result = true;
                }
                else if (Convert.ToInt32(Balance_Textbox.Text) > 0)
                {
                    if (Customer_CBox.Text == "Mr Walking Customer")
                    {
                        MetroMessageBox.Show(this, "Loan can only be given to Parmanent Customers...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                    }
                    else
                    {
                        db.DataManupulationOperation("Update Customer set Balance+='" + Balance_Textbox.Text + ",Dues+='" + Dues_Textbox.Text + "' where Name='" + Customer_CBox.Text + "'");
                        db.DataManupulationOperation("insert into Sales(OrderID,OrderType,OrderDate,DeliveryDate,TotalQty,TotalAmount,Remarks,Status,SalesmanID,CustomerID) values('" + Convert.ToInt32(ID_Box.Text) + "','" + orderType + "','" + DateTime.Now + "','" + Convert.ToDateTime(DDate_DTP.Text) + "','" + TQty_Textbox.Text + "','" + TAmount_Textbox.Text + "','" + Remarks_Box.Text + "','" + status + "','" + smanID + "','" + cusID + "')");
                        result = true;
                    }
                }
                for (int i = 0; i < Item_Grid.RowCount; i++)
                {
                    string Name = Item_Grid.Rows[i].Cells[0].Value.ToString();
                    double qty = Convert.ToDouble(Item_Grid.Rows[i].Cells[1].Value.ToString());
                    string category = Item_Grid.Rows[i].Cells[3].Value.ToString();
                    double amt = Convert.ToDouble(Item_Grid.Rows[i].Cells[5].Value.ToString());
                    int itemID = 0;
                    double price = 0;
                    if (result == true)
                    {
                        db.DataManupulationOperation("Delete from ReportData where OrderID<'" + ID_Box.Text + "'");
                        if (category == "Bakery Products")
                        {
                            itemID = Convert.ToInt32(db.ReturnValueFromDB("Select ItemID from BakeryItems where Name='" + Name + "'"));
                            price = Convert.ToDouble(db.ReturnValueFromDB("Select Price from BakeryItems where Name='" + Name + "'"));
                            db.DataManupulationOperation("insert into SalesLineItems(OrderID,BakeryItemID,Qty,Amount,Category) values('" + Convert.ToInt32(ID_Box.Text) + "','" + itemID + "','" + qty + "','" + amt + "','" + category + "')");
                            db.DataManupulationOperation("Update BakeryItems set Qty-='" + qty + "' where ItemID='" + itemID + "'");
                        }
                        else
                        {
                            itemID = Convert.ToInt32(db.ReturnValueFromDB("Select ID from CompanyProducts where Name='" + Name + "'"));
                            price = Convert.ToDouble(db.ReturnValueFromDB("Select Price from CompanyProducts where Name='" + Name + "'"));
                            db.DataManupulationOperation("insert into SalesLineItems(OrderID,CompanyProductID,Qty,Amount,Category) values('" + Convert.ToInt32(ID_Box.Text) + "','" + itemID + "','" + qty + "','" + amt + "','" + category + "')");
                            db.DataManupulationOperation("Update CompanyProducts set Qty-='" + qty + "' where ID='" + itemID + "'");
                        }
                        db.DataManupulationOperation("insert into ReportData(OrderID,Item_Name,Qty,Price,Amount) values('" + Convert.ToInt32(ID_Box.Text) + "','" + Name + "','" + qty + "','" + price + "','" + amt + "')");
                    }
                    else
                    {
                        result = false;
                    }
                }
                if (result == true)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this,ex.Message);
                MetroMessageBox.Show(this, "Failed to Update Data...!!!", "Insertion Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            Login.ActiveForm.Activate();
        }

        private void Return_Textbox_Validating(object sender, CancelEventArgs e)
        {
            if (Return_Textbox.Text == null || Return_Textbox.Text == "")
            {

            }
            else
            {
                int returnamt = Convert.ToInt32(PAmount_Textbox.Text) - Convert.ToInt32(TAmount_Textbox.Text);
                if (Return_Textbox.Text == "")
                {

                }
                else if (Convert.ToInt32(Return_Textbox.Text) < returnamt)
                {
                    int dues = returnamt - Convert.ToInt32(Return_Textbox.Text);
                    Balance_Textbox.Text = "0";
                    Dues_Textbox.Text = dues.ToString();
                }
                else if (Convert.ToInt32(Return_Textbox.Text) > returnamt)
                {
                    int bal = Convert.ToInt32(Return_Textbox.Text) - returnamt;
                    Balance_Textbox.Text = bal.ToString();
                    Dues_Textbox.Text = "0";
                }
                else if (Convert.ToInt32(Return_Textbox.Text) == returnamt)
                {
                    Dues_Textbox.Text = "0";
                }
            }
        }

        private void Manage_Purchase_MouseHover(object sender, EventArgs e)
        {
            Manage_Purchase.Size = new System.Drawing.Size(210, 66);
            Manage_Purchase.Style = MetroFramework.MetroColorStyle.Lime;
        }

        private void Manage_Purchase_MouseLeave(object sender, EventArgs e)
        {
            Manage_Purchase.Size = new System.Drawing.Size(200, 56);
            Manage_Purchase.Style = MetroFramework.MetroColorStyle.Default;
        }

        private void Manage_Purchase_Click(object sender, EventArgs e)
        {
            Purchase pr = new Purchase();
            pr.ShowDialog();
        }

        public void refresh()
        {
            ID_Box.Text = db.autoID("Select MAX(OrderID) from Sales", "Sales").ToString();
            Current_RadioButton.Checked = true;
            db.fillCombo(Customer_CBox, "Select Name from Customer");
            Customer_CBox.Text = "Mr Walking Customer";
            Category_CBox.Text = null;
            for (int i = 0; i < Item_Grid.RowCount; i++)
            {
                Item_Grid.Rows.RemoveAt(i);
            }
            TAmount_Textbox.Text = null;
            PAmount_Textbox.Text = null;
            Return_Textbox.Text = null;
            Balance_Textbox.Text = null;
            Dues_Textbox.Text = null;
            TQty_Textbox.Text = null;
            Remarks_Box.Text = null;
        }

        private void metroTile1_MouseHover(object sender, EventArgs e)
        {
            metroTile1.Size = new System.Drawing.Size(119, 91);
            metroTile1.Style = MetroFramework.MetroColorStyle.Lime;
        }

        private void metroTile1_MouseLeave(object sender, EventArgs e)
        {
            metroTile1.Size = new System.Drawing.Size(109, 81);
            metroTile1.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "Are You sure you Want to Cancel Current Order...???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                refresh();
            }
        }

        private void Logout_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MetroMessageBox.Show(this, "Are You Sure To Logout?", "Confirm...!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Login.ActiveForm.Show();
                this.Close();
            }
        }
    }
}