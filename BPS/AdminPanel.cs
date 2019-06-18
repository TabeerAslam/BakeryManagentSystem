using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework;

namespace BPS
{
    public partial class AdminPanel : MetroFramework.Forms.MetroForm
    {
        int EmpID = 0;
        int authLevel = 0;
        DBClass db = new DBClass();
        public AdminPanel(int autorizationlevel,int ID)
        {
            this.EmpID = ID;
            InitializeComponent();
            this.authLevel = autorizationlevel;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            if (authLevel == 1)
            {
                timer.Start();
                Tab.SelectedIndex = 0;
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

        private void Manage_Customer_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 1;
            Header.Text = "MANAGE CUSTOMERS";
            Customer_Gview.DataSource = db.DataNavigationOperations("select [CustomerID],[Name],[Status],[Email],[CNIC],[Address],[Contact],[Username],[Password],[Dues],[Balance] from Customer where CustomerID>'0'");
        }

        private void Manage_Sales_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 3;
            Header.Text = "MANAGE SALES";
            Sales_Gview.DataSource = db.DataNavigationOperations("select [OrderID],Customer.Name as 'Customer Name',[OrderType],[OrderDate],[DeliveryDate],[TotalQty],[TotalAmount],Sales.Status,Employees.Name as 'Salesman' from Sales,Employees,Customer where Sales.CustomerID=Customer.CustomerID and Sales.SalesmanID=Employees.EmployeeID");
            Sales_Gview.Columns[0].Width = 70;
            Sales_Gview.Columns[1].Width = 120;
        }

        private void Manage_Employee_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 2;
            Header.Text = "MANAGE EMPLOYEES";
            Employee_Gview.DataSource = db.DataNavigationOperations("select [EmployeeID],[Name],[DeptName] as 'Department',[RoleName] as 'Role',[CNIC],[JoiningDate],[ContactNo],[Email],[Address],[Status],[Pay],[Username],[Password] from Employees,Department,Role where Employees.DeptID=Department.DeptID and Employees.RoleID=Role.RoleID");
            Employee_Gview.Columns[7].Width = 150;
            Employee_Gview.Columns[8].Width = 200;
        }

        private void Manage_Purchase_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 4;
            Header.Text = "MANAGE PURCHASE";
            Purchase_Gview.DataSource = db.DataNavigationOperations("select [PurchaseID],Vendor.Name as 'Vendor Name',[Status],[OrderDate],[DeliveryDate],[TotalAmount] from Purchase,Vendor where Purchase.VendorID=Vendor.VendorID");
        }

        private void Manage_Production_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 5;
            Header.Text = "MANAGE PRODUCTION";
            Production_Gview.DataSource = db.DataNavigationOperations("select [ProductionID],Employees.Name as 'Employee Name',Category.CategoryName as 'Category',[TotalTime],[TotalGas],[TotalElectricity],[RMCost],[TotalCost] from Production,Employees,Category where Production.EmployeeID=Employees.EmployeeID and Production.CategoryID=Category.CategoryID");
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 0;
            Header.Text = "HOME";
        }

        private void Manage_Accounts_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 6;
            Header.Text = "MANAGE ACCOUNTS";
        }

        private void Statistics_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 7;
            Header.Text = "STATISTICS";
            Statistics_Tab.SelectedIndex = 0;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 8;
            Header.Text = "SETTINGS";
        }

        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab.SelectedIndex == 7)
            {
                Statistics_Tab.SelectTab(0);
                db.fillCombo(Statistics_Cus_CustomerBox, "Select Name From Customer where CustomerID>0");
            }
            else if (Tab.SelectedIndex == 8)
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

        private void Customer_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Customer_DescpBox.Text = db.ReturnValueFromDB("Select Descp From Customer where CustomerID='" + Customer_Gview.CurrentRow.Cells[0].Value.ToString() + "'");
            Customer_Picbox.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Customer where CustomerID='" + Convert.ToInt32(Customer_Gview.CurrentRow.Cells[0].Value.ToString()) + "'"));
        }

        private void Employee_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Employee_Gview.RowCount > 0)
            {
                Employee_DescpBox.Text = db.ReturnValueFromDB("Select Descp from Employees where EmployeeID='" + Employee_Gview.CurrentRow.Cells[0].Value.ToString() + "'");
                Employee_PicBox.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where EmployeeID='" + Convert.ToInt32(Employee_Gview.CurrentRow.Cells[0].Value.ToString()) + "'"));
                int AuthLevel = Convert.ToInt32(db.ReturnValueFromDB("Select Level from AuthorizationLevel where LevelID=(Select AuthorizationLevelID from Employees where EmployeeID='" + Employee_Gview.CurrentRow.Cells[0].Value.ToString() + "')"));
                if (Employee_Gview.CurrentRow.Cells[12].Value.ToString() == "Production")
                {
                    Employee_UnBlockButton.Enabled = false;
                    Employee_BlockButton.Enabled = false;
                }
                else
                {
                    if (AuthLevel == 0)
                    {
                        Employee_UnBlockButton.Enabled = true;
                        Employee_BlockButton.Enabled = false;
                    }
                    else if (AuthLevel > 0)
                    {
                        Employee_UnBlockButton.Enabled = false;
                        Employee_BlockButton.Enabled = true;
                    }
                }
            }
        }

        private void Sales_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataTable salesLM = new DataTable();
            db.conc.Open();
            SqlDataAdapter dpt1 = new SqlDataAdapter("Select CompanyProducts.Name,SalesLineItems.Qty,CompanyProducts.Price,SalesLineItems.Amount,SalesLineItems.Category From [dbo].[CompanyProducts],[dbo].[SalesLineItems] where SalesLineItems.CompanyProductID=CompanyProducts.ID and SalesLineItems.OrderID='" + Sales_Gview.CurrentRow.Cells[0].Value.ToString() + "'", db.conc);
            dpt1.Fill(salesLM);
            db.conc.Close();
            db.conc.Open();
            SqlDataAdapter dpt2 = new SqlDataAdapter("Select BakeryItems.Name,SalesLineItems.Qty,BakeryItems.Price,SalesLineItems.Amount,SalesLineItems.Category From [dbo].[BakeryItems],[dbo].[SalesLineItems] where SalesLineItems.BakeryItemID=BakeryItems.ItemID and SalesLineItems.OrderID='" + Sales_Gview.CurrentRow.Cells[0].Value.ToString() + "'", db.conc);
            dpt2.Fill(salesLM);
            db.conc.Close();
            Sales_DescpBox.Text = db.ReturnValueFromDB("Select Remarks From Sales where OrderID='" + Sales_Gview.CurrentRow.Cells[0].Value.ToString() + "'");
            SalesLM_GView.DataSource = salesLM;
            SalesLM_GView.Columns[0].Width = 150;
            SalesLM_GView.Columns[1].Width = 30;
            SalesLM_GView.Columns[2].Width = 40;
            SalesLM_GView.Columns[3].Width = 50;
            SalesLM_GView.Columns[4].Width = 100;
        }

        private void Purchase_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataTable purchLM = new DataTable();
            db.conc.Open();
            SqlDataAdapter dpt1 = new SqlDataAdapter("Select CompanyProducts.Name,PurchaseLineItems.Qty,PurchaseLineItems.Price,PurchaseLineItems.Amount,PurchaseLineItems.Category From [dbo].[PurchaseLineItems],[dbo].[CompanyProducts] where PurchaseLineItems.CompanyProductID=CompanyProducts.ID and PurchaseLineItems.PurchaseID='" + Purchase_Gview.CurrentRow.Cells[0].Value.ToString() + "'", db.conc);
            dpt1.Fill(purchLM);
            db.conc.Close();
            db.conc.Open();
            SqlDataAdapter dpt2 = new SqlDataAdapter("Select RawMaterial.Name,PurchaseLineItems.Qty,PurchaseLineItems.Price,PurchaseLineItems.Amount,PurchaseLineItems.Category From [dbo].[PurchaseLineItems],[dbo].[RawMaterial] where PurchaseLineItems.RawMaterialID=RawMaterial.RawMaterialID and PurchaseLineItems.PurchaseID='" + Purchase_Gview.CurrentRow.Cells[0].Value.ToString() + "'", db.conc);
            dpt2.Fill(purchLM);
            db.conc.Close();
            Purchase_DescpBox.Text = db.ReturnValueFromDB("Select Remarks From Purchase where PurchaseID='" + Purchase_Gview.CurrentRow.Cells[0].Value.ToString() + "'");
            PurchaseLM_Gview.DataSource = purchLM;
            PurchaseLM_Gview.Columns[0].Width = 150;
            PurchaseLM_Gview.Columns[1].Width = 30;
            PurchaseLM_Gview.Columns[2].Width = 40;
            PurchaseLM_Gview.Columns[3].Width = 50;
            PurchaseLM_Gview.Columns[4].Width = 100;
        }

        private void Production_Gview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Production_DescpBox.Text = db.ReturnValueFromDB("Select Remarks From Production where ProductionID='" + Production_Gview.CurrentRow.Cells[0].Value.ToString() + "'");
            ProductionPF_Gview.DataSource = db.DataNavigationOperations("Select BakeryItems.Name,ProductionLineItems.Qty,BakeryItems.Price From [dbo].[BakeryItems],[dbo].[ProductionLineItems] where ProductionLineItems.ItemID=BakeryItems.ItemID and ProductionLineItems.ProductionID='" + Production_Gview.CurrentRow.Cells[0].Value.ToString() + "'");
            ProductionPF_Gview.Columns[0].Width = 150;
            ProductionPF_Gview.Columns[1].Width = 30;
            ProductionPF_Gview.Columns[2].Width = 40;
            ProductionRM_Gview.DataSource = db.DataNavigationOperations("Select RawMaterial.Name,RawMaterialLineItems.Qty,RawMaterial.Price From [dbo].[RawMaterial],[dbo].[RawMaterialLineItems] where RawMaterialLineItems.RawMaterialID=RawMaterial.RawMaterialID and RawMaterialLineItems.ProductionID='" + Production_Gview.CurrentRow.Cells[0].Value.ToString() + "'");
            ProductionRM_Gview.Columns[0].Width = 150;
            ProductionRM_Gview.Columns[1].Width = 30;
            ProductionRM_Gview.Columns[2].Width = 40;
        }

        private void Statistics_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
            if (Statistics_Tab.SelectedIndex == 0)
            {
                db.fillCombo(Statistics_Cus_CustomerBox, "Select Name From Customer where CustomerID>0");
            }
            else if (Statistics_Tab.SelectedIndex == 1)
            {
                db.fillCombo(EDept_CBox, "Select DeptName from Department where DeptName!='Administration'");
            }
            else if (Statistics_Tab.SelectedIndex == 2)
            {
                db.fillCombo(Vendor_CBox, "Select Name from Vendor");
            }
        }

        private void EDept_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EEmp_CBox.Text=" ";
            if (EDept_CBox.Text != null && EDept_CBox.Text != "")
            {
                db.fillCombo(EEmp_CBox, "Select Name From Employees where DeptID=(Select DeptID from Department where DeptName='" + EDept_CBox.Text + "')");
                if (EDept_CBox.Text == "Sales")
                {
                    label18.Text = "Minimun Sales Amount:";
                    label15.Text = "Average Sales Amount:";
                    label12.Text = "Maximum Sales Amount:";
                    label16.Text = "First Sale Date:";
                    label14.Text = "Last Sale Date:";
                    label11.Text = "Total Sale:";
                    label17.Text = "Sum:";
                    label13.Text = "Pay:";
                }
                else if (EDept_CBox.Text == "Production")
                {
                    label18.Text = "Minimun Production:";
                    label15.Text = "Average Production:";
                    label12.Text = "Maximum Production:";
                    label16.Text = "First Production Date:";
                    label14.Text = "Last Production Date:";
                    label11.Text = "Total Production:";
                    label17.Text = "Sum:";
                    label13.Text = "Pay:";
                }
            }
        }

        private void EEmp_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EEmp_CBox.Text == " " || EEmp_CBox.Text == null)
            {

            }
            else
            {
                double min = 0;
                double max = 0;
                double avg = 0;
                string first = "";
                string last = "";
                double total = 0;
                double sum = 0;
                double pay = 0;
                if (EDept_CBox.Text == "Sales")
                {
                    total = Convert.ToDouble(db.ReturnValueFromDB("select Count([TotalAmount]) from Sales where SalesmanID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Role where RoleName='Salesman'))"));
                    if (total > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("select MIN([TotalAmount]) from Sales where SalesmanID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Role where RoleName='Salesman'))"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("select AVG([TotalAmount]) from Sales where SalesmanID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Role where RoleName='Salesman'))"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("select MAX([TotalAmount]) from Sales where SalesmanID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Role where RoleName='Salesman'))"));
                        first = db.ReturnValueFromDB("select MIN([OrderDate]) from Sales where SalesmanID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Role where RoleName='Salesman'))");
                        last = db.ReturnValueFromDB("select MAX([OrderDate]) from Sales where SalesmanID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Role where RoleName='Salesman'))");
                        sum = Convert.ToDouble(db.ReturnValueFromDB("select Sum([TotalAmount]) from Sales where SalesmanID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Role where RoleName='Salesman'))"));
                        pay = Convert.ToDouble(db.ReturnValueFromDB("Select Pay from Employees where Name='" + EEmp_CBox.Text + "'"));

                        EMinSale_Box.Text = min.ToString();
                        EAvgSale_Box.Text = avg.ToString();
                        EMaxSale_Box.Text = max.ToString();
                        EFirstSale_Box.Text = first;
                        ELastSale_Box.Text = last;
                        ETotSale_Box.Text = total.ToString();
                        ESum_Box.Text = sum.ToString();
                        EPay_Box.Text = pay.ToString();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (EDept_CBox.Text == "Production")
                {
                    total = Convert.ToDouble(db.ReturnValueFromDB("select Count([TotalCost]) from Production where EmployeeID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Employees where Name = '" + EEmp_CBox.Text + "'))"));
                    if (total > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("select MIN([TotalCost]) from Production where EmployeeID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Employees where Name = '" + EEmp_CBox.Text + "'))"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("select AVG([TotalCost]) from Production where EmployeeID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Employees where Name = '" + EEmp_CBox.Text + "'))"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("select MAX([TotalCost]) from Production where EmployeeID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Employees where Name = '" + EEmp_CBox.Text + "'))"));
                        first = db.ReturnValueFromDB("select MIN(ProductionDate) from Production where EmployeeID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Employees where Name = '" + EEmp_CBox.Text + "'))");
                        last = db.ReturnValueFromDB("select MAX(ProductionDate) from Production where EmployeeID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Employees where Name = '" + EEmp_CBox.Text + "'))");
                        sum = Convert.ToDouble(db.ReturnValueFromDB("select SUM([TotalCost]) from Production where EmployeeID=(Select [EmployeeID] from Employees where Name='" + EEmp_CBox.Text + "' and [RoleID]=(Select [RoleID] from Employees where Name = '" + EEmp_CBox.Text + "'))"));
                        pay = Convert.ToDouble(db.ReturnValueFromDB("Select Pay from Employees where Name='" + EEmp_CBox.Text + "'"));

                        EMinSale_Box.Text = min.ToString();
                        EAvgSale_Box.Text = avg.ToString();
                        EMaxSale_Box.Text = max.ToString();
                        EFirstSale_Box.Text = first;
                        ELastSale_Box.Text = last;
                        ETotSale_Box.Text = total.ToString();
                        ESum_Box.Text = sum.ToString();
                        EPay_Box.Text = pay.ToString();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Vendor_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Vendor_CBox.Text == null || Vendor_CBox.Text == "")
            {

            }
            else
            {
                double min = 0;
                double max = 0;
                double avg = 0;
                string first = "";
                string last = "";
                double total = 0;
                double sum = 0;
                double dues = 0;
                double balance = 0;

                total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalAmount]) from Purchase where [VendorID]=(Select [VendorID] from Vendor where Name='" + Vendor_CBox.Text + "')"));
                if (total > 0)
                {
                    min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalAmount]) from Purchase where [VendorID]=(Select [VendorID] from Vendor where Name='" + Vendor_CBox.Text + "')"));
                    avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalAmount]) from Purchase where [VendorID]=(Select [VendorID] from Vendor where Name='" + Vendor_CBox.Text + "')"));
                    max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalAmount]) from Purchase where [VendorID]=(Select [VendorID] from Vendor where Name='" + Vendor_CBox.Text + "')"));
                    first = db.ReturnValueFromDB("Select MIN([OrderDate]) from Purchase where [VendorID]=(Select [VendorID] from Vendor where Name='" + Vendor_CBox.Text + "')");
                    last = db.ReturnValueFromDB("Select MAX([OrderDate]) from Purchase where [VendorID]=(Select [VendorID] from Vendor where Name='" + Vendor_CBox.Text + "')");
                    sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalAmount]) from Purchase where [VendorID]=(Select [VendorID] from Vendor where Name='" + Vendor_CBox.Text + "')"));
                    dues = Convert.ToDouble(db.ReturnValueFromDB("select Dues from Vendor where Name='" + Vendor_CBox.Text + "'"));
                    balance = Convert.ToDouble(db.ReturnValueFromDB("select Balance from Vendor where Name='" + Vendor_CBox.Text + "'"));

                    VMinPurch_Box.Text = min.ToString();
                    VAvgPurch_Box.Text = avg.ToString();
                    VMaxPurch_Box.Text = max.ToString();
                    VFirstPurch_Box.Text = first;
                    VLastPurch_Box.Text = last;
                    VTotPurch_Box.Text = total.ToString();
                    VSum_Box.Text = sum.ToString();
                    VDues_Box.Text = dues.ToString();
                    VBal_Box.Text = balance.ToString();
                }
                else
                {
                    MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PScenario_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PScenario_CBox.Text == null || PScenario_CBox.Text == "")
            {

            }
            else
            {
                double min = 0;
                double max = 0;
                double avg = 0;
                string first = "";
                string last = "";
                double total = 0;
                double sum = 0;

                DateTime MinDate = DateTime.Now;
                DateTime MaxDate = DateTime.Now;
                if (PScenario_CBox.Text == "Today")
                {
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalAmount]) from Purchase where [OrderDate]='" + MinDate + "'"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalAmount]) from Purchase where [OrderDate]='" + MinDate + "'"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalAmount]) from Purchase where [OrderDate]='" + MinDate + "'"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalAmount]) from Purchase where [OrderDate]='" + MinDate + "'"));
                        first = db.ReturnValueFromDB("Select MIN([OrderDate]) from Purchase where [OrderDate]='" + MinDate + "'");
                        last = db.ReturnValueFromDB("Select MAX([OrderDate]) from Purchase where [OrderDate]='" + MinDate + "'");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalAmount]) from Purchase where [OrderDate]='" + MinDate + "'"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalAmount]) from Purchase where [OrderDate]='" + MinDate + "'"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (PScenario_CBox.Text == "All")
                {
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalAmount]) from Purchase"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalAmount]) from Purchase"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalAmount]) from Purchase"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalAmount]) from Purchase"));
                        first = db.ReturnValueFromDB("Select MIN([OrderDate]) from Purchase");
                        last = db.ReturnValueFromDB("Select MAX([OrderDate]) from Purchase");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalAmount]) from Purchase"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalAmount]) from Purchase"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (PScenario_CBox.Text == "15 Days")
                    {
                        MinDate = DateTime.Now.AddDays(-15);
                        MaxDate = DateTime.Now;
                    }
                    else if (PScenario_CBox.Text == "Month")
                    {
                        MinDate = DateTime.Now.AddMonths(-1);
                        MaxDate = DateTime.Now;
                    }
                    else if (PScenario_CBox.Text == "Three Months")
                    {
                        int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                        int MinMonth = Convert.ToInt32(DateTime.Now.AddMonths(-3).ToString("MM"));
                        int MaxMonth = Convert.ToInt32(DateTime.Now.AddMonths(-1).ToString("MM"));
                        MinDate = Convert.ToDateTime("01 " + MinMonth.ToString() + " " + year.ToString());
                        MaxDate = Convert.ToDateTime("01 " + MaxMonth.ToString() + " " + year.ToString());
                    }
                    else if (PScenario_CBox.Text == "Last Year")
                    {
                        int year = Convert.ToInt32(DateTime.Now.AddYears(-1).ToString("yyyy"));
                        MinDate = Convert.ToDateTime("01 01 " + year.ToString());
                        MaxDate = Convert.ToDateTime("01 12 " + year.ToString());
                    }
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalAmount]) from Purchase where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalAmount]) from Purchase where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalAmount]) from Purchase where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalAmount]) from Purchase where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                        first = db.ReturnValueFromDB("Select MIN([OrderDate]) from Purchase where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'");
                        last = db.ReturnValueFromDB("Select MAX([OrderDate]) from Purchase where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalAmount]) from Purchase where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalAmount]) from Purchase where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MinPurch_Box.Text = min.ToString();
                AvgPurch_Box.Text = avg.ToString();
                MaxPurch_Box.Text = max.ToString();
                FirstPurch_Box.Text = first;
                LastPurch_Box.Text = last;
                TotPurch_Box.Text = total.ToString();
                Sum_Box.Text = sum.ToString();
            }
        }

        private void PdScenario_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PdScenario_CBox.Text == null || PdScenario_CBox.Text == "")
            {

            }
            else
            {
                double min = 0;
                double max = 0;
                double avg = 0;
                string first = "";
                string last = "";
                double total = 0;
                double sum = 0;

                DateTime MinDate = DateTime.Now;
                DateTime MaxDate = DateTime.Now;
                if (PdScenario_CBox.Text == "Today")
                {
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalCost]) from Production where [ProductionDate]='" + MinDate + "'"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalCost]) from Production where [ProductionDate]='" + MinDate + "'"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalCost]) from Production where [ProductionDate]='" + MinDate + "'"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalCost]) from Production where [ProductionDate]='" + MinDate + "'"));
                        first = db.ReturnValueFromDB("Select MIN([ProductionDate]) from Production where [ProductionDate]='" + MinDate + "'");
                        last = db.ReturnValueFromDB("Select MAX([ProductionDate]) from Production where [ProductionDate]='" + MinDate + "'");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalCost]) from Production where [ProductionDate]='" + MinDate + "'"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalCost]) from Production where [ProductionDate]='" + MinDate + "'"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (PdScenario_CBox.Text == "All")
                {
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalCost]) from Production"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalCost]) from Production"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalCost]) from Production"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalCost]) from Production"));
                        first = db.ReturnValueFromDB("Select MIN([ProductionDate]) from Production");
                        last = db.ReturnValueFromDB("Select MAX([ProductionDate]) from Production");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalCost]) from Production"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalCost]) from Production"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (PdScenario_CBox.Text == "15 Days")
                    {
                        MinDate = DateTime.Now.AddDays(-15);
                        MaxDate = DateTime.Now;
                    }
                    else if (PdScenario_CBox.Text == "Month")
                    {
                        MinDate = DateTime.Now.AddMonths(-1);
                        MaxDate = DateTime.Now;
                    }
                    else if (PdScenario_CBox.Text == "Three Months")
                    {
                        int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                        int MinMonth = Convert.ToInt32(DateTime.Now.AddMonths(-3).ToString("MM"));
                        int MaxMonth = Convert.ToInt32(DateTime.Now.AddMonths(-1).ToString("MM"));
                        MinDate = Convert.ToDateTime("01 " + MinMonth.ToString() + " " + year.ToString());
                        MaxDate = Convert.ToDateTime("01 " + MaxMonth.ToString() + " " + year.ToString());
                    }
                    else if (PdScenario_CBox.Text == "Last Year")
                    {
                        int year = Convert.ToInt32(DateTime.Now.AddYears(-1).ToString("yyyy"));
                        MinDate = Convert.ToDateTime("01 01 " + year.ToString());
                        MaxDate = Convert.ToDateTime("01 12 " + year.ToString());
                    }
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalCost]) from Production where [ProductionDate]>='" + MinDate + "' and [ProductionDate]<='" + MaxDate + "'"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalCost]) from Production where [ProductionDate]>='" + MinDate + "' and [ProductionDate]<='" + MaxDate + "'"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalCost]) from Production where [ProductionDate]>='" + MinDate + "' and [ProductionDate]<='" + MaxDate + "'"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalCost]) from Production where [ProductionDate]>='" + MinDate + "' and [ProductionDate]<='" + MaxDate + "'"));
                        first = db.ReturnValueFromDB("Select MIN([ProductionDate]) from Production where [ProductionDate]>='" + MinDate + "' and [ProductionDate]<='" + MaxDate + "'");
                        last = db.ReturnValueFromDB("Select MAX([ProductionDate]) from Production where [ProductionDate]>='" + MinDate + "' and [ProductionDate]<='" + MaxDate + "'");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalCost]) from Production where [ProductionDate]>='" + MinDate + "' and [ProductionDate]<='" + MaxDate + "'"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalCost]) from Production where [ProductionDate]>='" + MinDate + "' and [ProductionDate]<='" + MaxDate + "'"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MinProd_Box.Text = min.ToString();
                AvgProd_Box.Text = avg.ToString();
                MaxProd_Box.Text = max.ToString();
                FirstProd_Box.Text = first;
                LastProd_Box.Text = last;
                TotProd_Box.Text = total.ToString();
                PdSum_Box.Text = sum.ToString();
            }
        }

        private void SaleScenario_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SaleScenario_CBox.Text == null || SaleScenario_CBox.Text == "")
            {

            }
            else
            {
                double min = 0;
                double max = 0;
                double avg = 0;
                string first = "";
                string last = "";
                double total = 0;
                double sum = 0;

                DateTime MinDate = DateTime.Now;
                DateTime MaxDate = DateTime.Now;
                if (SaleScenario_CBox.Text == "Today")
                {
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalAmount]) from Sales where [OrderDate]='" + MinDate + "'"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalAmount]) from Sales where [OrderDate]='" + MinDate + "'"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalAmount]) from Sales where [OrderDate]='" + MinDate + "'"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalAmount]) from Sales where [OrderDate]='" + MinDate + "'"));
                        first = db.ReturnValueFromDB("Select MIN([OrderDate]) from Sales where [OrderDate]='" + MinDate + "'");
                        last = db.ReturnValueFromDB("Select MAX([OrderDate]) from Sales where [OrderDate]='" + MinDate + "'");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalAmount]) from Sales where [OrderDate]='" + MinDate + "'"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalAmount]) from Sales where [OrderDate]='" + MinDate + "'"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (SaleScenario_CBox.Text == "All")
                {
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalAmount]) from Sales"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalAmount]) from Sales"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalAmount]) from Sales"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalAmount]) from Sales"));
                        first = db.ReturnValueFromDB("Select MIN([OrderDate]) from Sales");
                        last = db.ReturnValueFromDB("Select MAX([OrderDate]) from Sales");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalAmount]) from Sales"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalAmount]) from Sales"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (SaleScenario_CBox.Text == "15 Days")
                    {
                        MinDate = DateTime.Now.AddDays(-15);
                        MaxDate = DateTime.Now;
                    }
                    else if (SaleScenario_CBox.Text == "Month")
                    {
                        MinDate = DateTime.Now.AddMonths(-1);
                        MaxDate = DateTime.Now;
                    }
                    else if (SaleScenario_CBox.Text == "Three Months")
                    {
                        int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                        int MinMonth = Convert.ToInt32(DateTime.Now.AddMonths(-3).ToString("MM"));
                        int MaxMonth = Convert.ToInt32(DateTime.Now.AddMonths(-1).ToString("MM"));
                        MinDate = Convert.ToDateTime("01 " + MinMonth.ToString() + " " + year.ToString());
                        MaxDate = Convert.ToDateTime("01 " + MaxMonth.ToString() + " " + year.ToString());
                    }
                    else if (SaleScenario_CBox.Text == "Last Year")
                    {
                        int year = Convert.ToInt32(DateTime.Now.AddYears(-1).ToString("yyyy"));
                        MinDate = Convert.ToDateTime("01 01 " + year.ToString());
                        MaxDate = Convert.ToDateTime("31 12 " + year.ToString());
                    }
                    int count = Convert.ToInt32(db.ReturnValueFromDB("Select Count([TotalAmount]) from Sales where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                    if (count > 0)
                    {
                        min = Convert.ToDouble(db.ReturnValueFromDB("Select MIN([TotalAmount]) from Sales where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                        avg = Convert.ToDouble(db.ReturnValueFromDB("Select AVG([TotalAmount]) from Sales where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                        max = Convert.ToDouble(db.ReturnValueFromDB("Select MAX([TotalAmount]) from Sales where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                        first = db.ReturnValueFromDB("Select MIN([OrderDate]) from Sales where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'");
                        last = db.ReturnValueFromDB("Select MAX([OrderDate]) from Sales where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'");
                        total = Convert.ToDouble(db.ReturnValueFromDB("Select Count([TotalAmount]) from Sales where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                        sum = Convert.ToDouble(db.ReturnValueFromDB("Select SUM([TotalAmount]) from Sales where [OrderDate]>='" + MinDate + "' and [OrderDate]<='" + MaxDate + "'"));
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MinSale_Box.Text = min.ToString();
                AvgSale_Box.Text = avg.ToString();
                MaxSale_Box.Text = max.ToString();
                FirstSale_Box.Text = first;
                LastSale_Box.Text = last;
                TotSale_Box.Text = total.ToString();
                SaleSum_Box.Text = sum.ToString();
            }
        }

        private void Statistics_Cus_CustomerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Statistics_Cus_CustomerBox.Text == null || Statistics_Cus_CustomerBox.Text == "")
            {

            }
            else
            {
                double min = 0;
                double max = 0;
                double avg = 0;
                string first = "";
                string last = "";
                double total = 0;
                double sum = 0;
                double dues = 0;
                double balance = 0;
                total = Convert.ToDouble(db.ReturnValueFromDB("select Count([TotalAmount]) from Sales where [CustomerID]=(Select CustomerID from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "')"));
                if (total > 0)
                {
                    min = Convert.ToDouble(db.ReturnValueFromDB("select MIN([TotalAmount]) from Sales where [CustomerID]=(Select CustomerID from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "')"));
                    avg = Convert.ToDouble(db.ReturnValueFromDB("select AVG([TotalAmount]) from Sales where [CustomerID]=(Select CustomerID from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "')"));
                    max = Convert.ToDouble(db.ReturnValueFromDB("select MAX([TotalAmount]) from Sales where [CustomerID]=(Select CustomerID from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "')"));
                    first = db.ReturnValueFromDB("select MIN([OrderDate]) from Sales where [CustomerID]=(Select CustomerID from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "')");
                    last = db.ReturnValueFromDB("select MAX([OrderDate]) from Sales where [CustomerID]=(Select CustomerID from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "')");
                    sum = Convert.ToDouble(db.ReturnValueFromDB("select Sum([TotalAmount]) from Sales where [CustomerID]=(Select CustomerID from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "')"));
                    dues = Convert.ToDouble(db.ReturnValueFromDB("select Dues from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "'"));
                    balance = Convert.ToDouble(db.ReturnValueFromDB("select Balance from Customer where Name='" + Statistics_Cus_CustomerBox.Text + "'"));
                    CMinPurch_Box.Text = min.ToString();
                    CAvgPurch_Box.Text = avg.ToString();
                    CMaxPurch_Box.Text = max.ToString();
                    CFirstPurch_Box.Text = first;
                    CLastPurch_Box.Text = last;
                    CTotPurch_Box.Text = total.ToString();
                    CSum_Box.Text = sum.ToString();
                    CDues_Box.Text = dues.ToString();
                    CBal_Box.Text = balance.ToString();
                }
                else
                {
                    MetroMessageBox.Show(this, "No Record Found...!!!", "Error..!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Employee_BlockButton_Click(object sender, EventArgs e)
        {
            db.DataManupulationOperation("Update Employees Set AuthorizationLevelID='1' where EmployeeID='" + Employee_Gview.CurrentRow.Cells[0].Value + "'");
            MetroMessageBox.Show(this, "User Has Been Successfully Blocked...!!!", "Task Successful..!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            int AuthLevel = Convert.ToInt32(db.ReturnValueFromDB("Select Level from AuthorizationLevel where LevelID=(Select AuthorizationLevelID from Employees where EmployeeID='" + Convert.ToInt32(Employee_Gview.CurrentRow.Cells[0].Value.ToString()) + "')"));
            if (Employee_Gview.CurrentRow.Cells[12].Value.ToString() == "Production")
            {
                Employee_UnBlockButton.Enabled = false;
                Employee_BlockButton.Enabled = false;
            }
            else
            {
                if (AuthLevel == 0)
                {
                    Employee_UnBlockButton.Enabled = true;
                    Employee_BlockButton.Enabled = false;
                }
                else if (AuthLevel > 0)
                {
                    Employee_UnBlockButton.Enabled = false;
                    Employee_BlockButton.Enabled = true;
                }
            }
        }

        private void Employee_UnBlockButton_Click(object sender, EventArgs e)
        {
            db.DataManupulationOperation("Update Employees set AuthorizationLevelID =(Select LevelID from AuthorizationLevel where Descp like'%" + Employee_Gview.CurrentRow.Cells[3].Value.ToString() + "%') where EmployeeID='" + Convert.ToInt32(Employee_Gview.CurrentRow.Cells[0].Value.ToString()) + "'");
            MetroMessageBox.Show(this, "User Has Been Successfully UnBlocked...!!!", "Task Successful..!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            int AuthLevel = Convert.ToInt32(db.ReturnValueFromDB("Select Level from AuthorizationLevel where LevelID=(Select AuthorizationLevelID from Employees where EmployeeID='" + Convert.ToInt32(Employee_Gview.CurrentRow.Cells[0].Value.ToString()) + "')").ToString());
            if (Employee_Gview.CurrentRow.Cells[12].Value.ToString() == "Production")
            {
                Employee_UnBlockButton.Enabled = false;
                Employee_BlockButton.Enabled = false;
            }
            else
            {
                if (AuthLevel == 0)
                {
                    Employee_UnBlockButton.Enabled = true;
                    Employee_BlockButton.Enabled = false;
                }
                else if (AuthLevel > 0)
                {
                    Employee_UnBlockButton.Enabled = false;
                    Employee_BlockButton.Enabled = true;
                }
            }
        }

        private void Home_MouseHover(object sender, EventArgs e)
        {
            Home.Location = new System.Drawing.Point(0, 0);
            Home.Name = "Home";
            Home.Size = new System.Drawing.Size(200, 56);
            Home.Style = MetroFramework.MetroColorStyle.Orange;
            Home.TabIndex = 0;
            Home.Text = "HOME";
            Home.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Home.TileImage = global::BPS.Properties.Resources.home_5_64;
            Home.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Home.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            Home.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Home.UseSelectable = true;
            Home.UseTileImage = true;
        }

        private void Manage_Customer_MouseHover(object sender, EventArgs e)
        {
            Manage_Customer.Location = new System.Drawing.Point(0, 57);
            Manage_Customer.Name = "Manage_Customer";
            Manage_Customer.Size = new System.Drawing.Size(200, 56);
            Manage_Customer.Style = MetroFramework.MetroColorStyle.Orange;
            Manage_Customer.TabIndex = 1;
            Manage_Customer.Text = "   Manage\r\n  Customer";
            Manage_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Customer.TileImage = global::BPS.Properties.Resources.group_64;
            Manage_Customer.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Customer.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Customer.UseSelectable = true;
            Manage_Customer.UseTileImage = true;
        }

        private void Manage_Employee_MouseHover(object sender, EventArgs e)
        {
            Manage_Employee.Location = new System.Drawing.Point(0, 114);
            Manage_Employee.Name = "Manage_Employee";
            Manage_Employee.Size = new System.Drawing.Size(200, 56);
            Manage_Employee.Style = MetroFramework.MetroColorStyle.Orange;
            Manage_Employee.TabIndex = 2;
            Manage_Employee.Text = "   Manage\r\n   Employee";
            Manage_Employee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Employee.TileImage = global::BPS.Properties.Resources.worker_64;
            Manage_Employee.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Employee.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Employee.UseSelectable = true;
            Manage_Employee.UseTileImage = true;
        }

        private void Manage_Sales_MouseHover(object sender, EventArgs e)
        {
            Manage_Sales.Location = new System.Drawing.Point(20, 231);
            Manage_Sales.Name = "Manage_Sales";
            Manage_Sales.Size = new System.Drawing.Size(200, 56);
            Manage_Sales.Style = MetroFramework.MetroColorStyle.Orange;
            Manage_Sales.TabIndex = 3;
            Manage_Sales.Text = "   Manage\r\n   Sales";
            Manage_Sales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Sales.TileImage = global::BPS.Properties.Resources.combo_64;
            Manage_Sales.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Sales.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Sales.UseSelectable = true;
            Manage_Sales.UseTileImage = true;
        }

        private void Manage_Purchase_MouseHover(object sender, EventArgs e)
        {
            Manage_Purchase.Location = new System.Drawing.Point(0, 228);
            Manage_Purchase.Name = "Manage_Purchase";
            Manage_Purchase.Size = new System.Drawing.Size(200, 56);
            Manage_Purchase.Style = MetroFramework.MetroColorStyle.Orange;
            Manage_Purchase.TabIndex = 4;
            Manage_Purchase.Text = "   Manage\r\n   Purchase";
            Manage_Purchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Purchase.TileImage = global::BPS.Properties.Resources.cart_7_64;
            Manage_Purchase.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Purchase.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Purchase.UseSelectable = true;
            Manage_Purchase.UseTileImage = true;
        }

        private void Manage_Production_MouseHover(object sender, EventArgs e)
        {
            Manage_Production.Location = new System.Drawing.Point(20, 345);
            Manage_Production.Name = "Manage_Production";
            Manage_Production.Size = new System.Drawing.Size(200, 56);
            Manage_Production.Style = MetroFramework.MetroColorStyle.Orange;
            Manage_Production.TabIndex = 5;
            Manage_Production.Text = "   Manage\r\n   Production";
            Manage_Production.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Production.TileImage = global::BPS.Properties.Resources.factory_64;
            Manage_Production.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Production.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Production.UseSelectable = true;
            Manage_Production.UseTileImage = true;
        }

        private void Manage_Accounts_MouseHover(object sender, EventArgs e)
        {
            Manage_Accounts.Location = new System.Drawing.Point(0, 342);
            Manage_Accounts.Name = "Manage_Accounts";
            Manage_Accounts.Size = new System.Drawing.Size(200, 56);
            Manage_Accounts.Style = MetroFramework.MetroColorStyle.Orange;
            Manage_Accounts.TabIndex = 6;
            Manage_Accounts.Text = "   Manage\r\n   Accounts";
            Manage_Accounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Accounts.TileImage = global::BPS.Properties.Resources.report_3_64;
            Manage_Accounts.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Accounts.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Accounts.UseSelectable = true;
            Manage_Accounts.UseTileImage = true;
        }

        private void Statistics_MouseHover(object sender, EventArgs e)
        {
            Statistics.Location = new System.Drawing.Point(0, 399);
            Statistics.Name = "Statistics";
            Statistics.Size = new System.Drawing.Size(200, 56);
            Statistics.Style = MetroFramework.MetroColorStyle.Orange;
            Statistics.TabIndex = 7;
            Statistics.Text = "   Statistics";
            Statistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Statistics.TileImage = global::BPS.Properties.Resources.inbox_5_641;
            Statistics.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Statistics.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            Statistics.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Statistics.UseSelectable = true;
            Statistics.UseTileImage = true;
        }

        private void Settings_MouseHover(object sender, EventArgs e)
        {
            Settings.Location = new System.Drawing.Point(0, 456);
            Settings.Name = "Settings";
            Settings.Size = new System.Drawing.Size(200, 56);
            Settings.Style = MetroFramework.MetroColorStyle.Orange;
            Settings.TabIndex = 8;
            Settings.Text = "   Settings";
            Settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Settings.TileImage = global::BPS.Properties.Resources.settings_5_64;
            Settings.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Settings.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            Settings.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Settings.UseSelectable = true;
            Settings.UseTileImage = true;
        }

        private void Logout_MouseHover(object sender, EventArgs e)
        {
            Logout.Location = new System.Drawing.Point(0, 513);
            Logout.Name = "Logout";
            Logout.Size = new System.Drawing.Size(200, 56);
            Logout.Style = MetroFramework.MetroColorStyle.Orange;
            Logout.TabIndex = 9;
            Logout.Text = "   LOGOUT";
            Logout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Logout.TileImage = global::BPS.Properties.Resources.logout_64;
            Logout.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Logout.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            Logout.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Logout.UseSelectable = true;
            Logout.UseTileImage = true;
        }

        private void Home_MouseLeave(object sender, EventArgs e)
        {
            Home.Location = new System.Drawing.Point(0, 0);
            Home.Name = "Home";
            Home.Size = new System.Drawing.Size(62, 56);
            Home.Style = MetroFramework.MetroColorStyle.Default;
            Home.TabIndex = 0;
            Home.Text = null;
            Home.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Home.TileImage = global::BPS.Properties.Resources.home_5_64;
            Home.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Home.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            Home.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Home.UseSelectable = true;
            Home.UseTileImage = true;
        }

        private void Manage_Customer_MouseLeave(object sender, EventArgs e)
        {
            Manage_Customer.Location = new System.Drawing.Point(0, 57);
            Manage_Customer.Name = "Manage_Customer";
            Manage_Customer.Style = MetroFramework.MetroColorStyle.Default;
            Manage_Customer.Size = new System.Drawing.Size(62, 56);
            Manage_Customer.TabIndex = 1;
            Manage_Customer.Text = null;
            Manage_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Customer.TileImage = global::BPS.Properties.Resources.group_64;
            Manage_Customer.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Customer.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Customer.UseSelectable = true;
            Manage_Customer.UseTileImage = true;
        }

        private void Manage_Employee_MouseLeave(object sender, EventArgs e)
        {
            Manage_Employee.Location = new System.Drawing.Point(0, 114);
            Manage_Employee.Name = "Manage_Employee";
            Manage_Employee.Style = MetroFramework.MetroColorStyle.Default;
            Manage_Employee.Size = new System.Drawing.Size(62, 56);
            Manage_Employee.TabIndex = 2;
            Manage_Employee.Text = null;
            Manage_Employee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Employee.TileImage = global::BPS.Properties.Resources.worker_64;
            Manage_Employee.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Employee.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Employee.UseSelectable = true;
            Manage_Employee.UseTileImage = true;
        }

        private void Manage_Sales_MouseLeave(object sender, EventArgs e)
        {
            Manage_Sales.Location = new System.Drawing.Point(20, 231);
            Manage_Sales.Name = "Manage_Sales";
            Manage_Sales.Style = MetroFramework.MetroColorStyle.Default;
            Manage_Sales.Size = new System.Drawing.Size(62, 56);
            Manage_Sales.TabIndex = 3;
            Manage_Sales.Text = null;
            Manage_Sales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Sales.TileImage = global::BPS.Properties.Resources.combo_64;
            Manage_Sales.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Sales.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Sales.UseSelectable = true;
            Manage_Sales.UseTileImage = true;
        }

        private void Manage_Purchase_MouseLeave(object sender, EventArgs e)
        {
            Manage_Purchase.Location = new System.Drawing.Point(0, 228);
            Manage_Purchase.Name = "Manage_Purchase";
            Manage_Purchase.Style = MetroFramework.MetroColorStyle.Default;
            Manage_Purchase.Size = new System.Drawing.Size(62, 56);
            Manage_Purchase.TabIndex = 4;
            Manage_Purchase.Text = null;
            Manage_Purchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Purchase.TileImage = global::BPS.Properties.Resources.cart_7_64;
            Manage_Purchase.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Purchase.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Purchase.UseSelectable = true;
            Manage_Purchase.UseTileImage = true;
        }

        private void Manage_Production_MouseLeave(object sender, EventArgs e)
        {
            Manage_Production.Location = new System.Drawing.Point(20, 345);
            Manage_Production.Name = "Manage_Production";
            Manage_Production.Style = MetroFramework.MetroColorStyle.Default;
            Manage_Production.Size = new System.Drawing.Size(62, 56);
            Manage_Production.TabIndex = 5;
            Manage_Production.Text = null;
            Manage_Production.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Production.TileImage = global::BPS.Properties.Resources.factory_64;
            Manage_Production.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Production.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Production.UseSelectable = true;
            Manage_Production.UseTileImage = true;
        }

        private void Manage_Accounts_MouseLeave(object sender, EventArgs e)
        {
            Manage_Accounts.Location = new System.Drawing.Point(0, 342);
            Manage_Accounts.Name = "Manage_Accounts";
            Manage_Accounts.Style = MetroFramework.MetroColorStyle.Default;
            Manage_Accounts.Size = new System.Drawing.Size(62, 56);
            Manage_Accounts.TabIndex = 6;
            Manage_Accounts.Text = null;
            Manage_Accounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Manage_Accounts.TileImage = global::BPS.Properties.Resources.report_3_64;
            Manage_Accounts.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Manage_Accounts.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Manage_Accounts.UseSelectable = true;
            Manage_Accounts.UseTileImage = true;
        }

        private void Statistics_MouseLeave(object sender, EventArgs e)
        {
            Statistics.Location = new System.Drawing.Point(0, 399);
            Statistics.Name = "Statistics";
            Statistics.Style = MetroFramework.MetroColorStyle.Default;
            Statistics.Size = new System.Drawing.Size(62, 56);
            Statistics.TabIndex = 7;
            Statistics.Text = null;
            Statistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Statistics.TileImage = global::BPS.Properties.Resources.inbox_5_641;
            Statistics.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Statistics.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            Statistics.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Statistics.UseSelectable = true;
            Statistics.UseTileImage = true;
        }

        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            Settings.Location = new System.Drawing.Point(0, 456);
            Settings.Name = "Settings";
            Settings.Style = MetroFramework.MetroColorStyle.Default;
            Settings.Size = new System.Drawing.Size(62, 56);
            Settings.TabIndex = 8;
            Settings.Text = null;
            Settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Settings.TileImage = global::BPS.Properties.Resources.settings_5_64;
            Settings.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Settings.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            Settings.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Settings.UseSelectable = true;
            Settings.UseTileImage = true;
        }

        private void Logout_MouseLeave(object sender, EventArgs e)
        {
            Logout.Location = new System.Drawing.Point(0, 513);
            Logout.Name = "Logout";
            Logout.Style = MetroFramework.MetroColorStyle.Default;
            Logout.Size = new System.Drawing.Size(62, 56);
            Logout.TabIndex = 9;
            Logout.Text = null;
            Logout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Logout.TileImage = global::BPS.Properties.Resources.logout_64;
            Logout.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Logout.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            Logout.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            Logout.UseSelectable = true;
            Logout.UseTileImage = true;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "Are You Sure To Logout?", "Confirm...!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Login.ActiveForm.Show();
                this.Close();
            }
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
                Entry en = new Entry(Convert.ToInt32(Customer_Gview.CurrentRow.Cells[0].Value.ToString()), "Customer", "Edit");
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

        public void refresh()
        {
            Statistics_Cus_CustomerBox.Text = null;
            EDept_CBox.Text = null;
            EEmp_CBox.Text = null;
            Vendor_CBox.Text = null;
            PScenario_CBox.Text = null;
            PdScenario_CBox.Text = null;
            SaleScenario_CBox.Text = null;
            EMinSale_Box.Text = null;
            EAvgSale_Box.Text = null;
            EMaxSale_Box.Text = null;
            EFirstSale_Box.Text = null;
            ELastSale_Box.Text = null;
            ETotSale_Box.Text = null;
            ESum_Box.Text = null;
            EPay_Box.Text = null;
            CMinPurch_Box.Text = null;
            CAvgPurch_Box.Text = null;
            CMaxPurch_Box.Text = null;
            CFirstPurch_Box.Text = null;
            CLastPurch_Box.Text = null;
            CTotPurch_Box.Text = null;
            CSum_Box.Text = null;
            CDues_Box.Text = null;
            CBal_Box.Text = null;
            MinSale_Box.Text = null;
            AvgSale_Box.Text = null;
            MaxSale_Box.Text = null;
            FirstSale_Box.Text = null;
            LastSale_Box.Text = null;
            TotSale_Box.Text = null;
            SaleSum_Box.Text = null;
            MinProd_Box.Text = null;
            AvgProd_Box.Text = null;
            MaxProd_Box.Text = null;
            FirstProd_Box.Text = null;
            LastProd_Box.Text = null;
            TotProd_Box.Text = null;
            PdSum_Box.Text = null;
            MinPurch_Box.Text = null;
            AvgPurch_Box.Text = null;
            MaxPurch_Box.Text = null;
            FirstPurch_Box.Text = null;
            LastPurch_Box.Text = null;
            TotPurch_Box.Text = null;
            Sum_Box.Text = null;
            VMinPurch_Box.Text = null;
            VAvgPurch_Box.Text = null;
            VMaxPurch_Box.Text = null;
            VFirstPurch_Box.Text = null;
            VLastPurch_Box.Text = null;
            VTotPurch_Box.Text = null;
            VSum_Box.Text = null;
            VDues_Box.Text = null;
            VBal_Box.Text = null;
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
            }
            NewPassword_Box.Text = null;
            RepeatNewPassword_Box.Text = null;
            NewUserName_Box.Text = null;
            CurrentPassword_Box.Text = null;
            EmpUsername_Box.Text = null;
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

        private void EmpUpdate_Button_Click(object sender, EventArgs e)
        {
            string email = EmpEmail_Box1.Text;
            int RoleID = Convert.ToInt32(db.ReturnValueFromDB("select RoleID from Role where RoleName='" + EmpRole_Box.Text + "'"));
            int DeptID = Convert.ToInt32(db.ReturnValueFromDB("select DeptID from Department where DeptName='" + EmpDept_Box.Text + "'"));
            db.DataManupulationOperationwithPic("Update Employees set Name='" + EmpName_Box.Text + "',CNIC='" + EmpCNIC_Box.Text + "',JoiningDate='" + Convert.ToDateTime(EmpJDate_DTP.Value) + "',ContactNo='" + EmpContact_Box.Text + "',Email='" + email + "',[Address]='" + EmpAddress_Box.Text + "',Descp='" + EmpDescp_Box.Text + "',Picture=@picture,RoleID='" + RoleID + "',DeptID='" + DeptID + "' where EmployeeID='" + Convert.ToInt32(EmpID_Box.Text) + "'", EmpPic_Box);
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshSettings();
        }

        private void EmpUsername_Box_Validating(object sender, CancelEventArgs e)
        {
            if (EmpUsername_Box.Text.Length > 0)
            {
                if (EmpUsername_Box.Text != db.ReturnValueFromDB("select Username from Employees where EmployeeID='" + EmpID + "'"))
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

        private void EmpName_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tabHome_Click(object sender, EventArgs e)
        {

        }
    }
}
