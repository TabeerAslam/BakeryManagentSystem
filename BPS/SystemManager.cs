using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using MetroFramework;

namespace BPS
{
    public partial class SystemManager : MetroFramework.Forms.MetroForm
    {
        int AuthLevel = 0;
        int EmpID = 0;
        public string systemMgr = "";
        DBClass db = new DBClass();
        Entry en;
        SqlCommand cmd;
        SqlDataReader rd;
        public SystemManager(string name,int ID)
        {
            AuthLevel = Convert.ToInt32(db.ReturnValueFromDB("Select Level from AuthorizationLevel where LevelID=(Select AuthorizationLevelID from Employees where EmployeeID='" + ID + "')"));
            this.systemMgr = name;
            this.EmpID = ID;
            InitializeComponent();
            SMTabs.SelectedIndex = 0;
            Customer_Gview.DataSource = db.DataNavigationOperations("select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance] from Customer where CustomerID>0");
        }

        private void AddCustomer_MouseHover(object sender, EventArgs e)
        {
            AddCustomer.Size = new Size(132, 113);
        }

        private void AddEmployee_MouseHover(object sender, EventArgs e)
        {
            AddEmployee.Size = new Size(132, 113);
        }

        private void AddRawMaterial_MouseHover(object sender, EventArgs e)
        {
            AddRawMaterial.Size = new Size(132, 113);
        }

        private void AddVendor_MouseHover(object sender, EventArgs e)
        {
            AddVendor.Size = new Size(132, 113);
        }

        private void AddItem_MouseHover(object sender, EventArgs e)
        {
            AddItem.Size = new Size(132, 113);
        }

        private void AddCompanyProduct_MouseHover(object sender, EventArgs e)
        {
            AddCompanyProduct.Size = new Size(132, 113);
        }

        private void AddCompanyProduct_MouseLeave(object sender, EventArgs e)
        {
            AddCompanyProduct.Size = new Size(122, 103);
        }

        private void AddRawMaterial_MouseLeave(object sender, EventArgs e)
        {
            AddRawMaterial.Size = new Size(122, 103);
        }

        private void AddItem_MouseLeave(object sender, EventArgs e)
        {
            AddItem.Size = new Size(122, 103);
        }

        private void AddVendor_MouseLeave(object sender, EventArgs e)
        {
            AddVendor.Size = new Size(122, 103);
        }

        private void AddEmployee_MouseLeave(object sender, EventArgs e)
        {
            AddEmployee.Size = new Size(122, 103);
        }

        private void AddCustomer_MouseLeave(object sender, EventArgs e)
        {
            AddCustomer.Size = new Size(122, 103);
        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            en = new Entry("Customer", "Add");
            en.ShowDialog();
            Customer_Gview.DataSource = db.DataNavigationOperations("select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance] from Customer where CustomerID>0");
        }

        private void AddEmployee_Click(object sender, EventArgs e)
        {
            en = new Entry("Employee", "Add");
            en.ShowDialog();
            Employee_Gview.DataSource = db.DataNavigationOperations("select [EmployeeID],[Name],[DeptName] as 'Department',[RoleName] as 'Role',[CNIC],[JoiningDate],[ContactNo],[Email],[Address],[Status],[Pay],[Username],[Password] from Employees,Department,Role where Employees.DeptID=Department.DeptID and Employees.RoleID=Role.RoleID");
            Employee_Gview.Columns[7].Width = 150;
            Employee_Gview.Columns[8].Width = 200;
        }

        private void AddVendor_Click(object sender, EventArgs e)
        {
            en = new Entry("Vendor", "Add");
            en.ShowDialog();
            Vendor_Gview.DataSource = db.DataNavigationOperations("select [VendorID],[Name],[CompanyName],[Category],[ContactNo],[Email],[CNIC],[Dues],[Balance] from Vendor");
            Vendor_Gview.Columns[5].Width = 150;
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            en = new Entry("BakeryItem", "Add");
            en.ShowDialog();
            Item_Gview.DataSource = db.DataNavigationOperations("select [ItemID],[Name],[CategoryName] as 'Category',[Qty],[UnitName] as 'Unit',[Price] from BakeryItems,Category,UOM where BakeryItems.CategoryID=Category.CategoryID and BakeryItems.UOMID=UOM.UnitID");
            Item_Gview.Columns[1].Width = 250;
        }

        private void AddRawMaterial_Click(object sender, EventArgs e)
        {
            en = new Entry("RawMaterial", "Add");
            en.ShowDialog();
            RawMaterial_Gview.DataSource = db.DataNavigationOperations("select [RawMaterialID],[Name],[Price],[Qty],[UOM] as 'Unit' from RawMaterial");
        }

        private void AddCompanyProduct_Click(object sender, EventArgs e)
        {
            en = new Entry("CompanyProduct", "Add");
            en.ShowDialog();
            CompanyProduct_Gview.DataSource = db.DataNavigationOperations("Select [ID] as 'Item_ID',[Name],[CategoryName] as 'Category',[Company] as 'Company_Name',[Qty],[UnitName] as 'Unit',[Price] from CompanyProducts,Category,UOM where CompanyProducts.CategoryID=Category.CategoryID and CompanyProducts.UOMID=UOM.UnitID");
        }

        private void SMTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SMTabs.SelectedIndex == 0)//Customer
            {
                db.fillCombo(Search_Customer, "Select Name from Customer where CustomerID>0");
                Customer_Gview.DataSource = db.DataNavigationOperations("select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance] from Customer where CustomerID>0");
                if (Customer_Gview.RowCount > 0)
                {
                    int ID = Convert.ToInt32(Customer_Gview.CurrentRow.Cells[0].Value.ToString());
                    Customer_pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Customer where CustomerID='" + ID + "'"));
                }
            }
            else if (SMTabs.SelectedIndex == 1)//Employee
            {
                db.fillCombo(Search_Employee, "Select Name from Employees");
                Employee_Gview.DataSource = db.DataNavigationOperations("select [EmployeeID],[Name],[DeptName] as 'Department',[RoleName] as 'Role',[CNIC],[JoiningDate],[ContactNo],[Email],[Address],[Status],[Pay],[Username],[Password] from Employees,Department,Role where Employees.DeptID=Department.DeptID and Employees.RoleID=Role.RoleID");
                Employee_Gview.Columns[7].Width = 150;
                Employee_Gview.Columns[8].Width = 200;
                if (Employee_Gview.RowCount > 0)
                {
                    int ID = Convert.ToInt32(Employee_Gview.CurrentRow.Cells[0].Value.ToString());
                    Employee_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where EmployeeID='" + ID + "'"));
                }
            }
            else if (SMTabs.SelectedIndex == 2)//Vendor
            {
                db.fillCombo(Search_Vendor, "Select Name from Vendor");
                Vendor_Gview.DataSource = db.DataNavigationOperations("select [VendorID],[Name],[CompanyName],[Category],[ContactNo],[Email],[CNIC],[Dues],[Balance] from Vendor");
                Vendor_Gview.Columns[5].Width = 150;
                if (Vendor_Gview.RowCount > 0)
                {
                    int ID = Convert.ToInt32(Vendor_Gview.CurrentRow.Cells[0].Value.ToString());
                    Vendor_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Image from Vendor where VendorID='" + ID + "'"));
                }
            }
            else if (SMTabs.SelectedIndex == 3)//Item
            {
                db.fillCombo(Search_BakeryItem, "Select Name from BakeryItems");
                Item_Gview.DataSource = db.DataNavigationOperations("select [ItemID],[Name],[CategoryName] as 'Category',[Qty],[UnitName] as 'Unit',[Price] from BakeryItems,Category,UOM where BakeryItems.CategoryID=Category.CategoryID and BakeryItems.UOMID=UOM.UnitID");
                Item_Gview.Columns[1].Width = 250;
                if (Item_Gview.RowCount > 0)
                {
                    int ID = Convert.ToInt32(Item_Gview.CurrentRow.Cells[0].Value.ToString());
                    Item_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Image from BakeryItems where ItemID='" + ID + "'"));
                }
            }
            else if (SMTabs.SelectedIndex == 4)//RawMaterial
            {
                db.fillCombo(Search_RawMaterial, "Select Name from RawMaterial");
                RawMaterial_Gview.DataSource = db.DataNavigationOperations("select [RawMaterialID],[Name],[Price],[Qty],[UOM] as 'Unit' from RawMaterial");
                if (RawMaterial_Gview.RowCount > 0)
                {
                    int ID = Convert.ToInt32(RawMaterial_Gview.CurrentRow.Cells[0].Value.ToString());
                    RawMaterial_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from RawMaterial where RawMaterialID='" + ID + "'"));
                }
            }
            else if (SMTabs.SelectedIndex == 5)//Company Products
            {
                db.fillCombo(Search_CompanyProduct, "Select Name from CompanyProducts");
                CompanyProduct_Gview.DataSource = db.DataNavigationOperations("Select [ID] as 'Item_ID',[Name],[CategoryName] as 'Category',[Company] as 'Company_Name',[Qty],[UnitName] as 'Unit',[Price] from CompanyProducts,Category,UOM where CompanyProducts.CategoryID=Category.CategoryID and CompanyProducts.UOMID=UOM.UnitID");
                if (CompanyProduct_Gview.RowCount > 0)
                {
                    int ID = Convert.ToInt32(CompanyProduct_Gview.CurrentRow.Cells[0].Value.ToString());
                    CompanyProduct_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from CompanyProducts where ID='" + ID + "'"));
                }
            }
            else if (SMTabs.SelectedIndex == 6)//Settings
            {
                Settings_Tab.SelectedIndex = 0;
                DataTable values = db.DataNavigationOperations("select JoiningDate,Name,DeptName,RoleName,Email,CNIC,ContactNo,Address,Descp From Employees,Role,Department where Employees.RoleID=Role.RoleID and Employees.DeptID=Department.DeptID and EmployeeID='" + EmpID + "'");
                foreach (DataRow row in values.Rows)
                {
                    EmpJDate_DTP.Value = Convert.ToDateTime(row[0].ToString());
                    EmpID_Box.Text = EmpID.ToString();
                    EmpName_Box.Text = row[1].ToString();
                    EmpDept_Box.Text = row[2].ToString();
                    EmpRole_Box.Text = row[3].ToString();
                    EmpEmail_Box1.Text = row[4].ToString();
                    EmpCNIC_Box.Text = row[5].ToString();
                    EmpContact_Box.Text = row[6].ToString();
                    EmpAddress_Box.Text = row[7].ToString();
                    EmpDescp_Box.Text = row[8].ToString();
                    EmpPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where EmployeeID='" + EmpID + "'"));
                }
            }
        }

        private void SystemManager_Load(object sender, EventArgs e)
        {
            if (AuthLevel > 0 && AuthLevel <= 2)
            {
                timer1.Start();
                SystemManagerName_Label.Text = systemMgr;
                db.fillCombo(Search_Customer, "Select Name from Customer where CustomerID>0");
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
            //int ID = Convert.ToInt32(Customer_Gview.CurrentRow.Cells[0].Value.ToString());
            //Customer_pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Customer where CustomerID='" + ID + "'"));
        }

        private void Customer_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(Customer_Gview.CurrentRow.Cells[0].Value.ToString());
            Customer_pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Customer where CustomerID='" + ID + "'"));
        }

        private void Employee_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(Employee_Gview.CurrentRow.Cells[0].Value.ToString());
            Employee_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where EmployeeID='" + ID + "'"));
        }

        private void Vendor_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(Vendor_Gview.CurrentRow.Cells[0].Value.ToString());
            Vendor_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Image from Vendor where VendorID='" + ID + "'"));
        }

        private void Item_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(Item_Gview.CurrentRow.Cells[0].Value.ToString());
            Item_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Image from BakeryItems where ItemID='" + ID + "'"));
        }

        private void RawMaterial_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(RawMaterial_Gview.CurrentRow.Cells[0].Value.ToString());
            RawMaterial_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from RawMaterial where RawMaterialID='" + ID + "'"));
        }

        private void CompanyProduct_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(CompanyProduct_Gview.CurrentRow.Cells[0].Value.ToString());
            CompanyProduct_Pic.Image = db.ByteArrayToImage(db.Ret_image("select Picture from CompanyProducts where ID='" + ID + "'"));
        }

        private void Customer_EditButton_Click(object sender, EventArgs e)
        {
            if (Customer_Gview.SelectedRows.Count == 0)
            {
                Customer_Label.Text = "*Kindly Select a Row From Table Below To Edit...!!!";
            }
            else if (Customer_Gview.SelectedRows.Count == 1)
            {
                Customer_Label.Text = " ";
                //"select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance]
                Entry en = new Entry(Convert.ToInt32(Customer_Gview.CurrentRow.Cells[0].Value.ToString()), "Customer","Edit");
                en.ShowDialog();
            }
            else
            {
                Customer_Label.Text = "*More Than One Record Cannot be Edited at Once So Make Sure You Have Selected Single Row...!!!";
            }
            Customer_Gview.DataSource = db.DataNavigationOperations("select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance] from Customer where CustomerID>0");
        }

        private void Customer_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Customer_Gview.SelectedRows.Count == 0)
                {
                    Customer_Label.Text = "*Kindly Select a Row From Table Below To Delete...!!!";
                }
                else if (Customer_Gview.SelectedRows.Count == 1)
                {
                    Customer_Label.Text = " ";
                    if (MetroMessageBox.Show(this, "Are You Sure You Want To Delete Selected Record...???", "Confirmation...!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        db.DataManupulationOperation("Delete from Customer Where CustomerID='" + Customer_Gview.CurrentRow.Cells[0].Value + "'");
                        MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Customer_Gview.RowCount > 1)
                {
                    if (MetroMessageBox.Show(this, "Are You Sure You Want To Delete Selected Record...???", "Confirmation...!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < Customer_Gview.SelectedRows.Count; i++)
                        {
                            db.DataManupulationOperation("Delete from Customer Where CustomerID='" + Customer_Gview.SelectedRows[i].Cells[0].Value + "'");
                        }
                        MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error While Deleting Customer Record...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Customer_Gview.DataSource = db.DataNavigationOperations("select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance] from Customer where CustomerID>0");
        }

        private void Employee_EditButton_Click(object sender, EventArgs e)
        {
            if (Employee_Gview.SelectedRows.Count == 0)
            {
                Employee_Label.Text = "*Kindly Select a Row From Table Below To Edit...!!!";
            }
            else if (Employee_Gview.SelectedRows.Count == 1)
            {
                Employee_Label.Text = " ";
                //"select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance]
                Entry en = new Entry(Convert.ToInt32(Employee_Gview.CurrentRow.Cells[0].Value.ToString()), "Employee", "Edit");
                en.ShowDialog();
            }
            else
            {
                Employee_Label.Text = "*More Than One Record Cannot be Edited at Once So Make Sure You Have Selected Single Row...!!!";
            }
            Employee_Gview.DataSource = db.DataNavigationOperations("select [EmployeeID],[Name],[DeptName] as 'Department',[RoleName] as 'Role',[CNIC],[JoiningDate],[ContactNo],[Email],[Address],[Status],[Pay],[Username],[Password] from Employees,Department,Role where Employees.DeptID=Department.DeptID and Employees.RoleID=Role.RoleID");
            Employee_Gview.Columns[7].Width = 150;
            Employee_Gview.Columns[8].Width = 200;
        }

        private void Employee_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Employee_Gview.SelectedRows.Count == 0)
                {
                    Employee_Label.Text = "*Kindly Select a Row From Table Below To Delete...!!!";
                }
                else if (Employee_Gview.SelectedRows.Count == 1)
                {
                    if (MetroMessageBox.Show(this, "Are You Sure You Want To Delete Selected Record...???", "Confirmation...!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        db.DataManupulationOperation("Delete from Employees Where EmployeeID='" + Employee_Gview.CurrentRow.Cells[0].Value + "'");
                        MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Employee_Gview.RowCount > 1)
                {
                    Employee_Label.Text = " ";
                    if (MetroMessageBox.Show(this, "Are You Sure You Want To Delete Selected Record...???", "Confirmation...!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < Employee_Gview.SelectedRows.Count; i++)
                        {
                            db.DataManupulationOperation("Delete from Employees Where EmployeeID='" + Employee_Gview.SelectedRows[i].Cells[0].Value + "'");
                        }
                        MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error While Deleting Employee Record...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Employee_Gview.DataSource = db.DataNavigationOperations("select [EmployeeID],[Name],[DeptName] as 'Department',[RoleName] as 'Role',[CNIC],[JoiningDate],[ContactNo],[Email],[Address],[Status],[Pay],[Username],[Password] from Employees,Department,Role where Employees.DeptID=Department.DeptID and Employees.RoleID=Role.RoleID");
            Employee_Gview.Columns[7].Width = 150;
            Employee_Gview.Columns[8].Width = 200;
        }

        private void Vendor_EditButton_Click(object sender, EventArgs e)
        {
            if (Vendor_Gview.SelectedRows.Count == 0)
            {
                Vendor_Label.Text = "*Kindly Select a Row From Table Below To Edit...!!!";
            }
            else if (Vendor_Gview.SelectedRows.Count == 1)
            {
                Vendor_Label.Text = " ";
                //"select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance]
                Entry en = new Entry(Convert.ToInt32(Vendor_Gview.CurrentRow.Cells[0].Value.ToString()), "Vendor", "Edit");
                en.ShowDialog();
            }
            else
            {
                Vendor_Label.Text = "*More Than One Record Cannot be Edited at Once So Make Sure You Have Selected Single Row...!!!";
            }
            Vendor_Gview.DataSource = db.DataNavigationOperations("select [VendorID],[Name],[CompanyName],[Category],[ContactNo],[Email],[CNIC],[Dues],[Balance] from Vendor");
            Vendor_Gview.Columns[5].Width = 150;
        }

        private void Vendor_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vendor_Gview.SelectedRows.Count == 0)
                {
                    Vendor_Label.Text = "*Kindly Select a Row From Table Below To Delete...!!!";
                }
                else if (Vendor_Gview.SelectedRows.Count == 1)
                {
                    Vendor_Label.Text = " ";
                    db.DataManupulationOperation("Delete from Vendor Where VendorID='" + Vendor_Gview.CurrentRow.Cells[0].Value + "'");
                    MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Vendor_Gview.RowCount > 1)
                {
                    for (int i = 0; i < Vendor_Gview.SelectedRows.Count; i++)
                    {
                        db.DataManupulationOperation("Delete from Vendor Where VendorID='" + Vendor_Gview.SelectedRows[i].Cells[0].Value + "'");
                    }
                    MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error While Deleting Vendor Record...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Vendor_Gview.DataSource = db.DataNavigationOperations("select [VendorID],[Name],[CompanyName],[Category],[ContactNo],[Email],[CNIC],[Dues],[Balance] from Vendor");
            Vendor_Gview.Columns[5].Width = 150;
        }

        private void Item_EditButton_Click(object sender, EventArgs e)
        {
            if (Item_Gview.SelectedRows.Count == 0)
            {
                Item_Label.Text = "*Kindly Select a Row From Table Below To Edit...!!!";
            }
            else if (Item_Gview.SelectedRows.Count == 1)
            {
                Item_Label.Text = " ";
                //"select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance]
                Entry en = new Entry(Convert.ToInt32(Item_Gview.CurrentRow.Cells[0].Value.ToString()), "BakeryItem", "Edit");
                en.ShowDialog();
            }
            else
            {
                Item_Label.Text = "*More Than One Record Cannot be Edited at Once So Make Sure You Have Selected Single Row...!!!";
            }
            Item_Gview.DataSource = db.DataNavigationOperations("select [ItemID],[Name],[CategoryName] as 'Category',[Qty],[UnitName] as 'Unit',[Price] from BakeryItems,Category,UOM where BakeryItems.CategoryID=Category.CategoryID and BakeryItems.UOMID=UOM.UnitID");
            Item_Gview.Columns[1].Width = 250;
        }

        private void Item_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Item_Gview.SelectedRows.Count == 0)
                {
                    Item_Label.Text = "*Kindly Select a Row From Table Below To Delete...!!!";
                }
                else if (Item_Gview.SelectedRows.Count == 1)
                {
                    Item_Label.Text = " ";
                    db.DataManupulationOperation("Delete from BakeryItems Where ItemID='" + Item_Gview.CurrentRow.Cells[0].Value + "'");
                    MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Item_Gview.RowCount > 1)
                {
                    for (int i = 0; i < Item_Gview.SelectedRows.Count; i++)
                    {
                        db.DataManupulationOperation("Delete from BakeryItems Where ItemID='" + Item_Gview.SelectedRows[i].Cells[0].Value + "'");
                    }
                    MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error While Deleting Bakery Item...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Item_Gview.DataSource = db.DataNavigationOperations("select [ItemID],[Name],[CategoryName] as 'Category',[Qty],[UnitName] as 'Unit',[Price] from BakeryItems,Category,UOM where BakeryItems.CategoryID=Category.CategoryID and BakeryItems.UOMID=UOM.UnitID");
            Item_Gview.Columns[1].Width = 250;
        }

        private void RawMaterial_EditButton_Click(object sender, EventArgs e)
        {
            if (RawMaterial_Gview.SelectedRows.Count == 0)
            {
                RawMaterial_Label.Text = "*Kindly Select a Row From Table Below To Edit...!!!";
            }
            else if (RawMaterial_Gview.SelectedRows.Count == 1)
            {
                RawMaterial_Label.Text = " ";
                //"select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance]
                Entry en = new Entry(Convert.ToInt32(RawMaterial_Gview.CurrentRow.Cells[0].Value.ToString()), "RawMaterial", "Edit");
                en.ShowDialog();
            }
            else
            {
                RawMaterial_Label.Text = "*More Than One Record Cannot be Edited at Once So Make Sure You Have Selected Single Row...!!!";
            }
            RawMaterial_Gview.DataSource = db.DataNavigationOperations("select [RawMaterialID],[Name],[Price],[Qty],[UOM] as 'Unit' from RawMaterial");
        }

        private void RawMaterial_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (RawMaterial_Gview.SelectedRows.Count == 0)
                {
                    RawMaterial_Label.Text = "*Kindly Select a Row From Table Below To Delete...!!!";
                }
                else if (RawMaterial_Gview.SelectedRows.Count == 1)
                {
                    RawMaterial_Label.Text = " ";
                    db.DataManupulationOperation("Delete from RawMaterial Where RawMaterialID='" + RawMaterial_Gview.CurrentRow.Cells[0].Value + "'");
                    MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (RawMaterial_Gview.RowCount > 1)
                {
                    for (int i = 0; i < RawMaterial_Gview.SelectedRows.Count; i++)
                    {
                        db.DataManupulationOperation("Delete from RawMaterial Where RawMaterialID='" + RawMaterial_Gview.SelectedRows[i].Cells[0].Value + "'");
                    }
                    MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error While Deleting Raw Material...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RawMaterial_Gview.DataSource = db.DataNavigationOperations("select [RawMaterialID],[Name],[Price],[Qty],[UOM] as 'Unit' from RawMaterial");
        }

        private void CompanyProduct_EditButton_Click(object sender, EventArgs e)
        {
            if (CompanyProduct_Gview.SelectedRows.Count == 0)
            {
                CompanyProduct_Label.Text = "*Kindly Select a Row From Table Below To Edit...!!!";
            }
            else if (CompanyProduct_Gview.SelectedRows.Count == 1)
            {
                CompanyProduct_Label.Text = " ";
                //"select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance]
                Entry en = new Entry(Convert.ToInt32(CompanyProduct_Gview.CurrentRow.Cells[0].Value.ToString()), "CompanyProduct", "Edit");
                en.ShowDialog();
            }
            else
            {
                CompanyProduct_Label.Text = "*More Than One Record Cannot be Edited at Once So Make Sure You Have Selected Single Row...!!!";
            }
            CompanyProduct_Gview.DataSource = db.DataNavigationOperations("Select [ID] as 'Item_ID',[Name],[CategoryName] as 'Category',[Company] as 'Company_Name',[Qty],[UnitName] as 'Unit',[Price] from CompanyProducts,Category,UOM where CompanyProducts.CategoryID=Category.CategoryID and CompanyProducts.UOMID=UOM.UnitID");
        }

        private void CompanyProduct_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CompanyProduct_Gview.SelectedRows.Count == 0)
                {
                    CompanyProduct_Label.Text = "*Kindly Select a Row From Table Below To Delete...!!!";
                }
                else if (CompanyProduct_Gview.SelectedRows.Count == 1)
                {
                    CompanyProduct_Label.Text = " ";
                    db.DataManupulationOperation("Delete from CompanyProducts Where ID='" + CompanyProduct_Gview.CurrentRow.Cells[0].Value + "'");
                    MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (CompanyProduct_Gview.RowCount > 1)
                {
                    for (int i = 0; i < CompanyProduct_Gview.SelectedRows.Count; i++)
                    {
                        db.DataManupulationOperation("Delete from CompanyProducts Where ID='" + CompanyProduct_Gview.SelectedRows[i].Cells[0].Value + "'");
                    }
                    MetroMessageBox.Show(this, "Record Has been Successfully Deleted...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error While Deleting Company Product...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void Logout_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MetroMessageBox.Show(this, "Are You Sure To Logout?", "Confirm...!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Login.ActiveForm.Show();
                this.Close();
            }
        }

        private void Manage_Purchase_MouseHover(object sender, EventArgs e)
        {
            Manage_Purchase.Size = new System.Drawing.Size(210, 66);
            Manage_Purchase.Style = MetroFramework.MetroColorStyle.Lime;
            Manage_Production.Location = new Point(485, 26);
        }

        private void Manage_Purchase_MouseLeave(object sender, EventArgs e)
        {
            Manage_Purchase.Size = new System.Drawing.Size(200, 56);
            Manage_Purchase.Style = MetroFramework.MetroColorStyle.Default;
            Manage_Production.Location = new Point(475, 26);
        }

        private void Manage_Purchase_Click(object sender, EventArgs e)
        {
            Purchase pr = new Purchase();
            pr.ShowDialog();
        }

        private void Manage_Production_MouseHover(object sender, EventArgs e)
        {
            Manage_Production.Size = new System.Drawing.Size(215, 66);
            Manage_Production.Style = MetroFramework.MetroColorStyle.Lime;
        }

        private void Manage_Production_MouseLeave(object sender, EventArgs e)
        {
            Manage_Production.Size = new System.Drawing.Size(205, 56);
            Manage_Production.Style = MetroFramework.MetroColorStyle.Default;
        }

        private void Manage_Production_Click(object sender, EventArgs e)
        {
            Production prd = new Production();
            prd.ShowDialog();
        }

        private void EmpUpdate_Button_Click(object sender, EventArgs e)
        {
            string email = EmpEmail_Box1.Text;
            int RoleID = Convert.ToInt32(db.ReturnValueFromDB("select RoleID from Role where RoleName='" + EmpRole_Box.Text + "'"));
            int DeptID = Convert.ToInt32(db.ReturnValueFromDB("select DeptID from Department where DeptName='" + EmpDept_Box.Text + "'"));
            db.DataManupulationOperationwithPic("Update Employees set Name='" + EmpName_Box.Text + "',CNIC='" + EmpCNIC_Box.Text + "',JoiningDate='" + Convert.ToDateTime(EmpJDate_DTP.Value) + "',ContactNo='" + EmpContact_Box.Text + "',Email='" + email + "',[Address]='" + EmpAddress_Box.Text + "',Descp='" + EmpDescp_Box.Text + "',Picture=@picture,RoleID='" + RoleID + "',DeptID='" + DeptID + "' where EmployeeID='" + Convert.ToInt32(EmpID_Box.Text) + "'", EmpPic_Box);
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            systemMgr = EmpName_Box.Text;
            refreshSettings();
        }

        private void EmpImage_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    EmpPic_Box.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void EmpEmail_Box1_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (EmpEmail_Box1.Text.Length > 0)
            {

                if (!rEMail.IsMatch(EmpEmail_Box1.Text))
                {
                    EmpUpdate_Button.Enabled = false;
                    Emp_Label.Text = "*Wrong E-mail...!!!";
                    EmpEmail_Box1.SelectAll();
                    e.Cancel = true;
                }
                else
                {
                    Emp_Label.Text = " ";
                    EmpUpdate_Button.Enabled = true;
                }
            }
        }

        private void EmpUsername_Box_Validating(object sender, CancelEventArgs e)
        {
            if (EmpUsername_Box.Text.Length > 0)
            {

                if (EmpUsername_Box.Text != db.ReturnValueFromDB("select Username from Employees where EmployeeID='"+EmpID+"'"))
                {
                    SettingsUpdate_Button.Enabled = false;
                    Settings_Label.Text = "*Wrong Username Entered...!!!";
                    EmpUsername_Box.SelectAll();
                    e.Cancel = true;
                }
                else
                {
                    Settings_Label.Text = " ";
                    SettingsUpdate_Button.Enabled = true;
                }
            }
        }

        private void CurrentPassword_Box_Validating(object sender, CancelEventArgs e)
        {
            if (CurrentPassword_Box.Text.Length > 0)
            {
                if (CurrentPassword_Box.Text != db.ReturnValueFromDB("select Password from Employees where EmployeeID='" + EmpID + "'"))
                {
                    NewPassword_Box.Enabled = false;
                    NewUserName_Box.Enabled = false;
                    RepeatNewPassword_Box.Enabled = false;
                    SettingsUpdate_Button.Enabled = false;
                    Settings_Label.Text = "*Wrong Password Entered...!!!";
                    CurrentPassword_Box.SelectAll();
                    e.Cancel = true;
                }
                else
                {
                    NewPassword_Box.Enabled = true;
                    NewUserName_Box.Enabled = true;
                    RepeatNewPassword_Box.Enabled = true;
                    Settings_Label.Text = " ";
                    SettingsUpdate_Button.Enabled = true;
                }
            }
        }

        private void RepeatNewPassword_Box_Validating(object sender, CancelEventArgs e)
        {
            if (RepeatNewPassword_Box.Text.Length > 0)
            {
                if (RepeatNewPassword_Box.Text != NewPassword_Box.Text)
                {
                    SettingsUpdate_Button.Enabled = false;
                    Settings_Label.Text = "*Both New Passwords must Match...!!!";
                    RepeatNewPassword_Box.SelectAll();
                    e.Cancel = true;
                }
                else
                {
                    Settings_Label.Text = " ";
                    SettingsUpdate_Button.Enabled = true;
                }
            }
        }

        private void SettingsUpdate_Button_Click(object sender, EventArgs e)
        {
            db.DataManupulationOperation("Update Employees set UserName='" + NewUserName_Box.Text + "',Password='" + NewPassword_Box.Text + "' where EmployeeID='" + Convert.ToInt32(EmpID_Box.Text) + "'");
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshSettings();
        }

        private void refreshSettings()
        {
            DataTable values = db.DataNavigationOperations("select JoiningDate,Name,DeptName,RoleName,Email,CNIC,ContactNo,Address,Descp From Employees,Role,Department where Employees.RoleID=Role.RoleID and Employees.DeptID=Department.DeptID and EmployeeID='" + EmpID + "'");
            foreach (DataRow row in values.Rows)
            {
                EmpJDate_DTP.Value = Convert.ToDateTime(row[0].ToString());
                EmpID_Box.Text = EmpID.ToString();
                EmpName_Box.Text = row[1].ToString();
                EmpDept_Box.Text = row[2].ToString();
                EmpRole_Box.Text = row[3].ToString();
                EmpEmail_Box1.Text = row[4].ToString();
                EmpCNIC_Box.Text = row[5].ToString();
                EmpContact_Box.Text = row[6].ToString();
                EmpAddress_Box.Text = row[7].ToString();
                EmpDescp_Box.Text = row[8].ToString();
                EmpPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where EmployeeID='" + EmpID + "'"));
                SystemManagerName_Label.Text = row[1].ToString();
            }
            NewPassword_Box.Text = null;
            RepeatNewPassword_Box.Text = null;
            NewUserName_Box.Text = null;
            CurrentPassword_Box.Text = null;
            EmpUsername_Box.Text = null;
        }

        private void Settings_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshSettings();
        }
    }
}
