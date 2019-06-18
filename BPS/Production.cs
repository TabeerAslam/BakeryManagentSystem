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
    public partial class Production : MetroFramework.Forms.MetroForm
    {
        string task = "";
        double TotalRM = 0;
        double TotalRMCost = 0;
        double TotalProduct = 0;
        double TotalCost = 0;
        double ElectCost = 0;
        double GasCost = 0;
        DBClass db = new DBClass();
        public Production()
        {
            InitializeComponent();
        }

        private void Production_Load(object sender, EventArgs e)
        {
            timer.Start();
            ID_Box.Text = db.autoID("Select MAX(ProductionID) from Production", "Production").ToString();
            db.fillCombo(Category_CBox, "Select Distinct CategoryName From Category where MainCategory = 'Bakery Products'");
            db.search(RawMaterial_SearchBar, "Select Name From RawMaterial");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblSec.Text = DateTime.Now.ToString("ss");
        }

        private void Category_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpPic_Box.Image = null;
            Employee_CBox.Text = null;
            if (Category_CBox.Text == null || Category_CBox.Text == "")
            {

            }
            else
            {
                db.fillCombo(Employee_CBox, "select Name from Employees where RoleID=(Select RoleID from Role where RoleName like '%" + Category_CBox.Text + "%')");
                db.search(Product_SearchBar, "Select Name From BakeryItems where CategoryID =(Select CategoryID from Category where CategoryName='" + Category_CBox.Text + "')");
            }
        }

        private void RawMaterial_SearchBar_Leave(object sender, EventArgs e)
        {
            if (RawMaterial_SearchBar.Text != null && RawMaterial_SearchBar.Text != "")
            {
                string RMName = RawMaterial_SearchBar.Text;
                RMPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from RawMaterial where Name='" + RMName + "'"));
            }
        }

        private void Employee_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Employee_CBox.Text==null ||Employee_CBox.Text=="")
            {
                EmpPic_Box.Image = null;
                RawMaterial_GBox.Enabled = false;
                Product_GBox.Enabled = false;
                ShowEmployee_Button.Visible = false;
            }
            else
            {
                RawMaterial_GBox.Enabled = true;
                Product_GBox.Enabled = true;
                string EmpName = Employee_CBox.Text;
                EmpPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where Name='" + EmpName + "'"));
                ShowEmployee_Button.Visible = true;
            }
        }

        private void Product_SearchBar_Leave(object sender, EventArgs e)
        {
            if (Product_SearchBar.Text != null && Product_SearchBar.Text != "")
            {
                string BIName = Product_SearchBar.Text;
                ProductPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Image from BakeryItems where Name='" + BIName + "'"));
            }
        }

        private void AddRM_Button_Click(object sender, EventArgs e)
        {
            TotalCost = 0;
            string ItemName = RawMaterial_SearchBar.Text;
            if (ItemName != null && ItemName != "")
            {
                int ID = 0;
                double Qty = Convert.ToDouble(RMQty_Box.Text);
                double price;
                double amount;
                string UOMM = "";
                double avlQty = Convert.ToDouble(db.ReturnValueFromDB("Select Qty from RawMaterial where Name='" + ItemName + "'"));
                UOMM = db.ReturnValueFromDB("Select UOM from RawMaterial where Name='" + ItemName + "'");
                ID = Convert.ToInt32(db.ReturnValueFromDB("Select RawMaterialID from RawMaterial where Name='" + ItemName + "'"));
                price = Convert.ToInt32(db.ReturnValueFromDB("Select Price from RawMaterial where Name='" + ItemName + "'"));
                amount = price * Qty;
                
                if (task == "Edit")
                {
                    if (avlQty >= Qty)
                    {

                        RawMaterial_Grid.CurrentRow.Cells[0].Value = ID.ToString();
                        RawMaterial_Grid.CurrentRow.Cells[1].Value = ItemName;
                        RawMaterial_Grid.CurrentRow.Cells[2].Value = Qty.ToString();
                        RawMaterial_Grid.CurrentRow.Cells[3].Value = UOMM;
                        RawMaterial_Grid.CurrentRow.Cells[4].Value = price.ToString();
                        RawMaterial_Grid.CurrentRow.Cells[5].Value = amount.ToString();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Required Qty for " + ItemName + " is Not Available...!!!", "Less Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    RawMaterial_Grid.Rows.Add();
                    if (avlQty >= Qty)
                    {
                        for (int i = 0; i < RawMaterial_Grid.RowCount; i++)
                        {
                            if (RawMaterial_Grid.Rows[i].Cells[0].Value == null)
                            {
                                RawMaterial_Grid.Rows[i].Cells[0].Value = ID.ToString();
                                RawMaterial_Grid.Rows[i].Cells[1].Value = ItemName;
                                RawMaterial_Grid.Rows[i].Cells[2].Value = Qty.ToString();
                                RawMaterial_Grid.Rows[i].Cells[3].Value = UOMM;
                                RawMaterial_Grid.Rows[i].Cells[4].Value = price.ToString();
                                RawMaterial_Grid.Rows[i].Cells[5].Value = amount.ToString();
                            }
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Required Qty for " + ItemName + " is Not Available...!!!", "Less Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                TotalRMCost = totalCalculator(RawMaterial_Grid, 5);
                TotalRM = totalCalculator(RawMaterial_Grid, 2);
                RawMaterial_SearchBar.Text = null;
                RMQty_Box.Text = null;
                RMPic_Box.Image = null;
                RMTQty_Label.Text = TotalRM.ToString();
                TotRMCost_Label.Text = TotalRMCost.ToString();
                TotalCost = totalcostCalculator();
                TotalCost_Label.Text = TotalCost.ToString();
                this.task = "";
            }
        }

        private double totalCalculator(DataGridView dgw,int index)
        {
            double totalQty = 0;
            foreach (DataGridViewRow rows in dgw.Rows)
            {
                if (rows.Cells[0].Value != null)
                {
                    totalQty += Convert.ToDouble(rows.Cells[index].Value.ToString());
                }
            }
            return totalQty;
        }

        private double totalcostCalculator()
        {
            TotalCost = TotalRMCost + ElectCost + GasCost;
            return TotalCost;
        }

        private void Electricity_Textbox_TextChanged(object sender, EventArgs e)
        {
            TotalCost = 0;
            if (Electricity_Textbox.Text != null && Electricity_Textbox.Text != "")
            {
                ElectCost = Convert.ToDouble(db.ReturnValueFromDB("Select CostAmount from ExtraCosts where CostName='Electricity'")) * Convert.ToDouble(Electricity_Textbox.Text);
                TotalCost = totalcostCalculator();
                TotalCost_Label.Text = TotalCost.ToString();
            }
        }

        private void Gas_Textbox_TextChanged(object sender, EventArgs e)
        {
            TotalCost = 0;
            if (Gas_Textbox.Text != null && Gas_Textbox.Text != "")
            {
                GasCost = Convert.ToDouble(db.ReturnValueFromDB("Select CostAmount from ExtraCosts where CostName='Gas'")) * Convert.ToDouble(Gas_Textbox.Text);
                TotalCost = totalcostCalculator();
                TotalCost_Label.Text = TotalCost.ToString();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Entry en = new Entry("EG", "Add");
            en.ShowDialog();
        }

        private void CPUpdate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string EmpName = Employee_CBox.Text;
                int CategoryID = Convert.ToInt32(db.ReturnValueFromDB("Select CategoryID from Category where CategoryName='" + Category_CBox.Text + "'"));
                int EmpID;
                EmpID = Convert.ToInt32(db.ReturnValueFromDB("Select EmployeeID from Employees where Name='" + EmpName + "'"));
                db.DataManupulationOperation("insert into Production(ProductionID,ProductionDate,TotalQty,TotalTime,TotalGas,TotalElectricity,RMCost,TotalCost,Remarks,EmployeeID,CategoryID) values('" + Convert.ToInt32(ID_Box.Text) + "','" + Convert.ToDateTime(ProdDate_DTP.Text) + "','" + Convert.ToDouble(ProductsTQty_Label.Text) + "','" + Convert.ToDouble(Time_Textbox.Text) + "','" + Convert.ToDouble(Gas_Textbox.Text) + "','" + Convert.ToDouble(Electricity_Textbox.Text) + "','" + Convert.ToDouble(TotRMCost_Label.Text) + "','" + Convert.ToDouble(TotalCost_Label.Text) + "','" + Remarks_Box.Text + "','" + EmpID + "','" + CategoryID + "')");
                for (int i = 0; i < RawMaterial_Grid.RowCount; i++)
                {
                    int RMID = Convert.ToInt32(RawMaterial_Grid.Rows[i].Cells[0].Value.ToString());
                    //string Name = RawMaterial_Grid.Rows[i].Cells[1].Value.ToString();
                    double qty = Convert.ToDouble(RawMaterial_Grid.Rows[i].Cells[2].Value.ToString());
                    //string UOM = RawMaterial_Grid.Rows[i].Cells[3].Value.ToString();
                    //double price = Convert.ToDouble(RawMaterial_Grid.Rows[i].Cells[4].Value.ToString());
                    double amt = Convert.ToDouble(RawMaterial_Grid.Rows[i].Cells[5].Value.ToString());
                    db.DataManupulationOperation("insert into RawMaterialLineItems(ProductionID,RawMaterialID,Qty,Amount) values('" + Convert.ToInt32(ID_Box.Text) + "','" + RMID + "','" + qty + "','" + amt + "')");
                    db.DataManupulationOperation("Update RawMaterial set Qty-='"+qty+"' where RawMaterialID='"+RMID+"'");
                }
                for (int i = 0; i < Products_Grid.RowCount; i++)
                {
                    int ItemID = Convert.ToInt32(Products_Grid.Rows[i].Cells[0].Value.ToString());
                    //string Name = Products_Grid.Rows[i].Cells[1].Value.ToString();
                    double qty = Convert.ToDouble(Products_Grid.Rows[i].Cells[2].Value.ToString());
                    //string UOM = Products_Grid.Rows[i].Cells[3].Value.ToString();
                    db.DataManupulationOperation("insert into ProductionLineItems(ProductionID,ItemID,Qty) values('" + Convert.ToInt32(ID_Box.Text) + "','" + ItemID + "','" + qty + "')");
                    db.DataManupulationOperation("Update BakeryItems set Qty+='" + qty + "' where ItemID='" + ItemID + "'");
                }
                MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Production Done...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Failed to Update Data...!!!", "Insertion Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refresh();
        }

        private void CPBack_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void refresh()
        {
            Category_CBox.Text = null;
            Employee_CBox.Text = null;
            EmpPic_Box.Image = null;
            for (int i = 0; i < RawMaterial_Grid.RowCount; )
            {
                RawMaterial_Grid.Rows.RemoveAt(i);
            }
            for (int i = 0; i < Products_Grid.RowCount; )
            {
                Products_Grid.Rows.RemoveAt(i);
            }
            TotalCost_Label.Text = "0";
            TotRMCost_Label.Text = "0";
            RMTQty_Label.Text = "0";
            ProductsTQty_Label.Text = "0";
            Electricity_Textbox.Text = null;
            Gas_Textbox.Text = null;
            Time_Textbox.Text = null;
            Remarks_Box.Text = null;
            ID_Box.Text = db.autoID("Select MAX(ProductionID) from Production", "Production").ToString();
            //db.fillCombo(Category_CBox, "Select Distinct CategoryName From Category where MainCategory = 'Bakery Products'");
        }

        private void RawMaterial_Grid_SelectionChanged(object sender, EventArgs e)
        {
            //if (RawMaterial_Grid.RowCount>1)
            //{
            //    string name = RawMaterial_Grid.CurrentRow.Cells[1].Value.ToString();
            //    double qty = Convert.ToDouble(RawMaterial_Grid.CurrentRow.Cells[2].Value.ToString());
            //    RawMaterial_SearchBar.Text = name;
            //    RMQty_Box.Text = qty.ToString();
            //    RMPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from RawMaterial where Name='" + name + "'"));
            //}
            
        }

        private void RawMaterial_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RawMaterial_Grid.CurrentRow.Cells[6].Selected == true && RawMaterial_Grid.CurrentRow.Cells[7].Selected == false)//Edit
            {
                this.task = "Edit";
                if (RawMaterial_Grid.RowCount > 0)
                {
                    if (RawMaterial_Grid.Rows[0].Cells[0].Value != null)
                    {
                        string RMName = RawMaterial_Grid.CurrentRow.Cells[1].Value.ToString();
                        string qty = RawMaterial_Grid.CurrentRow.Cells[2].Value.ToString();
                        RawMaterial_SearchBar.Text = RMName;
                        RMQty_Box.Text = qty;
                        RMPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from RawMaterial where Name='" + RMName + "'"));
                    }
                }
            }
            else if (RawMaterial_Grid.CurrentRow.Cells[6].Selected == false && RawMaterial_Grid.CurrentRow.Cells[7].Selected == true)//Delete
            {
                if (RawMaterial_Grid.RowCount > 0)
                {
                    if (MetroMessageBox.Show(this, "Are You sure you Want to Delete Current Row...???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int index = RawMaterial_Grid.CurrentCell.RowIndex;
                        RawMaterial_Grid.Rows.RemoveAt(index);
                        TotalRMCost = totalCalculator(RawMaterial_Grid, 5);
                        TotalRM = totalCalculator(RawMaterial_Grid, 2);
                        RMTQty_Label.Text = TotalRM.ToString();
                        TotRMCost_Label.Text = TotalRMCost.ToString();
                        TotalCost = totalcostCalculator();
                        TotalCost_Label.Text = TotalCost.ToString();
                        RMPic_Box.Image = null;
                        RawMaterial_SearchBar.Text = null;
                        RMQty_Box.Text = null;
                    }
                }
            }
        }

        private void Products_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Products_Grid.CurrentRow.Cells[4].Selected == true && Products_Grid.CurrentRow.Cells[5].Selected == false)//Edit
            {
                this.task = "Edit";
                if (Products_Grid.RowCount > 0)
                {
                    if (Products_Grid.Rows[0].Cells[0].Value != null)
                    {
                        string Name = Products_Grid.CurrentRow.Cells[1].Value.ToString();
                        string qty = Products_Grid.CurrentRow.Cells[2].Value.ToString();
                        Product_SearchBar.Text = Name;
                        ProductsQty_Box.Text = qty;
                        ProductPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Image from BakeryItems where Name='" + Name + "'"));
                    }
                }
            }
            else if (Products_Grid.CurrentRow.Cells[4].Selected == false && Products_Grid.CurrentRow.Cells[5].Selected == true)//Delete
            {
                if (Products_Grid.RowCount > 0)
                {
                    if (MetroMessageBox.Show(this, "Are You sure you Want to Delete Current Row...???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int index = Products_Grid.CurrentCell.RowIndex;
                        Products_Grid.Rows.RemoveAt(index);
                        TotalProduct = totalCalculator(Products_Grid, 2);
                        Product_SearchBar.Text = null;
                        ProductsQty_Box.Text = null;
                        ProductPic_Box.Image = null;
                        ProductsTQty_Label.Text = TotalProduct.ToString();
                    }
                }
            }
        }

        private void ProductAdd_Button_Click(object sender, EventArgs e)
        {
            string ItemName = Product_SearchBar.Text;
            if (ItemName != null && ItemName != "")
            {
                int ID = 0;
                double Qty = Convert.ToDouble(ProductsQty_Box.Text);
                string UOMM = "";
                UOMM = db.ReturnValueFromDB("Select UnitName From UOM where UnitID=(Select UOMID from BakeryItems where Name='" + ItemName + "')");
                ID = Convert.ToInt32(db.ReturnValueFromDB("Select ItemID from BakeryItems where Name='" + ItemName + "'"));
                if (task == "Edit")
                {
                    Products_Grid.CurrentRow.Cells[0].Value = ID.ToString();
                    Products_Grid.CurrentRow.Cells[1].Value = ItemName;
                    Products_Grid.CurrentRow.Cells[2].Value = Qty.ToString();
                    Products_Grid.CurrentRow.Cells[3].Value = UOMM;
                }
                else
                {
                    Products_Grid.Rows.Add();
                    for (int i = 0; i < Products_Grid.RowCount; i++)
                    {
                        if (Products_Grid.Rows[i].Cells[0].Value == null)
                        {
                            Products_Grid.Rows[i].Cells[0].Value = ID.ToString();
                            Products_Grid.Rows[i].Cells[1].Value = ItemName;
                            Products_Grid.Rows[i].Cells[2].Value = Qty.ToString();
                            Products_Grid.Rows[i].Cells[3].Value = UOMM;
                        }
                    }
                }
                TotalProduct = totalCalculator(Products_Grid, 2);
                Product_SearchBar.Text = null;
                ProductsQty_Box.Text = null;
                ProductPic_Box.Image = null;
                ProductsTQty_Label.Text = TotalProduct.ToString();
            }
            this.task = "";
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

        private void ShowEmployee_Button_Click(object sender, EventArgs e)
        {
            if (Employee_CBox.Text == null || Employee_CBox.Text == "")
            {
                MetroMessageBox.Show(this, "Kindly Select The Employee First...!!!", "Employee Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int ID = Convert.ToInt32(db.ReturnValueFromDB("Select EmployeeID from Employees where Name='" + Employee_CBox.Text + "'"));
                Entry en = new Entry(ID, "Employee", "Show");
                en.ShowDialog();
            }
        }
    }
}
