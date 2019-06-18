using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework;

namespace BPS
{
    public partial class Entry : MetroFramework.Forms.MetroForm
    {
        DBClass db = new DBClass();
        SqlCommand cmd=new SqlCommand();
        private string task = "";
        private string tab = "";
        private int cusID = 0;
        public Entry(string tab, string task)
        {
            this.tab = tab;
            this.task = task;
            InitializeComponent();
        }
        
        public Entry(int CusID,string tab,string task)
        {
            this.task = task;
            this.tab = tab;
            this.cusID = CusID;
            InitializeComponent();
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            if (task == "Add")
            {
                if (tab == "Customer")
                {
                    EntryTab.SelectedIndex = 0;
                    CustID_Box.Text = db.autoID("Select MAX(CustomerID) from Customer", "Customer").ToString();
                }
                else if (tab == "Employee")
                {
                    EntryTab.SelectedIndex = 1;
                    EmpID_Box.Text = db.autoID("Select MAX(EmployeeID) from Employees", "Employees").ToString();
                }
                else if (tab == "Vendor")
                {
                    EntryTab.SelectedIndex = 2;
                    VenID_Box.Text = db.autoID("Select MAX(VendorID) from Vendor", "Vendor").ToString();
                }
                else if (tab == "RawMaterial" || tab == "Raw Materials")
                {
                    EntryTab.SelectedIndex = 3;
                    RMID_Box.Text = db.autoID("Select MAX(RawMaterialID) from RawMaterial", "RawMaterial").ToString();
                }
                else if (tab == "BakeryItem" || tab == "Bakery Products")
                {
                    EntryTab.SelectedIndex = 4;
                    BIID_Box.Text = db.autoID("Select MAX(ItemID) from BakeryItems", "BakeryItems").ToString();
                }
                else if (tab == "CompanyProduct" || tab == "Company Products")
                {
                    EntryTab.SelectedIndex = 5;
                    CPID_Box.Text = db.autoID("Select MAX(ID) from CompanyProducts", "CompanyProducts").ToString();
                }
                else if (tab == "EG")
                {
                    EntryTab.SelectedIndex = 6;
                }
            }
            else if (task == "Edit")
            {
                if (tab == "Customer")
                {
                    EntryTab.SelectedIndex = 0;
                    CustID_Box.Text = Convert.ToString(cusID);
                    CustName_Box.Text = db.ReturnValueFromDB("select [Name] from Customer where CustomerID='" + cusID + "'");
                    CustEmail_Box1.Text = db.ReturnValueFromDB("select Email from Customer where CustomerID='" + cusID + "'");
                    CustStatus_Box.Text = db.ReturnValueFromDB("select Status from Customer where CustomerID='" + cusID + "'");
                    CustCNIC_Box.Text = db.ReturnValueFromDB("select CNIC from Customer where CustomerID='" + cusID + "'");
                    CustContact_Box.Text = db.ReturnValueFromDB("select Contact from Customer where CustomerID='" + cusID + "'");
                    CustAddress_Box.Text = db.ReturnValueFromDB("select Address from Customer where CustomerID='" + cusID + "'");
                    CustUsername_Box.Text = db.ReturnValueFromDB("select Username from Customer where CustomerID='" + cusID + "'");
                    CustPassword_Box.Text = db.ReturnValueFromDB("select Password from Customer where CustomerID='" + cusID + "'");
                    CustDescp_Box.Text = db.ReturnValueFromDB("select Descp from Customer where CustomerID='" + cusID + "'");
                    CustDues_Box.Text = db.ReturnValueFromDB("select Dues from Customer where CustomerID='" + cusID + "'");
                    CustBal_Box.Text = db.ReturnValueFromDB("select Balance from Customer where CustomerID='" + cusID + "'");
                    CustPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Customer where CustomerID='" + cusID + "'"));
                }
                else if (tab == "Employee")
                {
                    EntryTab.SelectedIndex = 1;
                    EmpID_Box.Text = Convert.ToString(cusID);
                    EmpName_Box.Text = db.ReturnValueFromDB("select [Name] from Employees where EmployeeID='" + cusID + "'");
                    EmpDept_Box.Text = db.ReturnValueFromDB("select DeptName from Department where DeptID=(select DeptID from Employees where EmployeeID='" + cusID + "')");
                    EmpRole_Box.Text = db.ReturnValueFromDB("select RoleName from Role where RoleID=(select RoleID from Employees where EmployeeID='" + cusID + "')");
                    EmpEmail_Box1.Text = db.ReturnValueFromDB("select Email from Employees where EmployeeID='" + cusID + "'");
                    EmpStatus_Box.Text = db.ReturnValueFromDB("select Status from Employees where EmployeeID='" + cusID + "'");
                    EmpCNIC_Box.Text = db.ReturnValueFromDB("select CNIC from Employees where EmployeeID='" + cusID + "'");
                    EmpContact_Box.Text = db.ReturnValueFromDB("select ContactNo from Employees where EmployeeID='" + cusID + "'");
                    EmpAddress_Box.Text = db.ReturnValueFromDB("select Address from Employees where EmployeeID='" + cusID + "'");
                    EmpUsername_Box.Text = db.ReturnValueFromDB("select Username from Employees where EmployeeID='" + cusID + "'");
                    EmpPassword_Box.Text = db.ReturnValueFromDB("select Password from Employees where EmployeeID='" + cusID + "'");
                    EmpDescp_Box.Text = db.ReturnValueFromDB("select Descp from Employees where EmployeeID='" + cusID + "'");
                    EmpJDate_DTP.Text = db.ReturnValueFromDB("select JoiningDate from Employees where EmployeeID='" + cusID + "'");
                    EmpPay_Box.Text = db.ReturnValueFromDB("select Pay from Employees where EmployeeID='" + cusID + "'");
                    EmpPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where EmployeeID='" + cusID + "'"));
                }
                else if (tab == "Vendor")
                {
                    EntryTab.SelectedIndex = 2;
                    VenID_Box.Text = Convert.ToString(cusID);
                    VenName_Box.Text = db.ReturnValueFromDB("select [Name] from Vendor where VendorID='" + cusID + "'");
                    VenEmail_Box1.Text = db.ReturnValueFromDB("select Email from Vendor where VendorID='" + cusID + "'");
                    VenCompany_Box.Text = db.ReturnValueFromDB("select CompanyName from Vendor where VendorID='" + cusID + "'");
                    VenCategory_Box.Text = db.ReturnValueFromDB("select Category from Vendor where VendorID='" + cusID + "'");
                    VenCNIC_Box.Text = db.ReturnValueFromDB("select CNIC from Vendor where VendorID='" + cusID + "'");
                    VenContact_Box.Text = db.ReturnValueFromDB("select ContactNo from Vendor where VendorID='" + cusID + "'");
                    VenDescp_Box.Text = db.ReturnValueFromDB("select Descp from Vendor where VendorID='" + cusID + "'");
                    VenDues_Box.Text = db.ReturnValueFromDB("select Dues from Vendor where VendorID='" + cusID + "'");
                    VenBal_Box.Text = db.ReturnValueFromDB("select Balance from Vendor where VendorID='" + cusID + "'");
                    VenPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Image from Vendor where VendorID='" + cusID + "'"));
                }
                else if (tab == "RawMaterial")
                {
                    EntryTab.SelectedIndex = 3;
                    RMID_Box.Text = Convert.ToString(cusID);
                    RMName_Box.Text = db.ReturnValueFromDB("select [Name] from RawMaterial where RawMaterialID='" + cusID + "'");
                    RMUOM_Box.Text = db.ReturnValueFromDB("select UnitName from UOM where UnitID=(select UOMID from RawMaterial where RawMaterialID='" + cusID + "')");
                    RMPrice_Box.Text = db.ReturnValueFromDB("select Price from RawMaterial where RawMaterialID='" + cusID + "'");
                    RMQty_Box.Text = db.ReturnValueFromDB("select Qty from RawMaterial where RawMaterialID='" + cusID + "'");
                    RMDescp_Box.Text = db.ReturnValueFromDB("select Descp from RawMaterial where RawMaterialID='" + cusID + "'");
                    RMPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from RawMaterial where RawMaterialID='" + cusID + "'"));
                }
                else if (tab == "BakeryItem")
                {
                    EntryTab.SelectedIndex = 4;
                    BIID_Box.Text = Convert.ToString(cusID);
                    BICategory_Box.Text = db.ReturnValueFromDB("select CategoryName from Category where CategoryID=(select CategoryID from BakeryItems where ItemID='" + cusID + "')");
                    BIName_Box.Text = db.ReturnValueFromDB("select [Name] from BakeryItems where ItemID='" + cusID + "'");
                    BISize_Box.Text = db.ReturnValueFromDB("select SizeName from Size where SizeID=(select SizeID from BakeryItems where ItemID='" + cusID + "')");
                    BIShape_Box.Text = db.ReturnValueFromDB("select ShapeName from Shape where ShapeID=(select ShapeID from BakeryItems where ItemID='" + cusID + "')");
                    BIDecoration_Box.Text = db.ReturnValueFromDB("select DecorationName from Decoration where DecorationID=(select DecorationID from BakeryItems where ItemID='" + cusID + "')");
                    BIUOM_Box.Text = db.ReturnValueFromDB("select UnitName from UOM where UnitID=(select UOMID from BakeryItems where ItemID='" + cusID + "')");
                    BIPrice_Box.Text = db.ReturnValueFromDB("select Price from BakeryItems where ItemID='" + cusID + "'");
                    BIQty_Box.Text = db.ReturnValueFromDB("select Qty from BakeryItems where ItemID='" + cusID + "'");
                    BIDescp_Box.Text = db.ReturnValueFromDB("select Descp from BakeryItems where ItemID='" + cusID + "'");
                    BIPicture_Box.Image = db.ByteArrayToImage(db.Ret_image("select Image from BakeryItems where ItemID='" + cusID + "'"));
                }
                else if (tab == "CompanyProduct")
                {
                    EntryTab.SelectedIndex = 5;
                    CPID_Box.Text = Convert.ToString(cusID);
                    CPCategory_Box.Text = db.ReturnValueFromDB("select CategoryName from Category where CategoryID=(select CategoryID from BakeryItems where ItemID='" + cusID + "')");
                    CPName_Box.Text = db.ReturnValueFromDB("select [Name] from CompanyProducts where ID='" + cusID + "'");
                    CPCompany_Box.Text = db.ReturnValueFromDB("select Company from CompanyProducts where ID='" + cusID + "'");
                    CPSize_Box.Text = db.ReturnValueFromDB("select SizeName from Size where SizeID=(select SizeID from CompanyProducts where ID='" + cusID + "')");
                    CPColor_Box.Text = db.ReturnValueFromDB("select ColorName from Color where ColorID=(select ColorID from CompanyProducts where ID='" + cusID + "')");
                    CPWeight_Box.Text = db.ReturnValueFromDB("select Value from Weight where WeightID=(select WeightID from CompanyProducts where ID='" + cusID + "')");
                    CPUOM_Box.Text = db.ReturnValueFromDB("select UnitName from UOM where UnitID=(select UOMID from CompanyProducts where ID='" + cusID + "')");
                    CPPrice_Box.Text = db.ReturnValueFromDB("select Price from CompanyProducts where ID='" + cusID + "'");
                    CPQty_Box.Text = db.ReturnValueFromDB("select Qty from CompanyProducts where ID='" + cusID + "'");
                    CPDescp_Box.Text = db.ReturnValueFromDB("select Descp from CompanyProducts where ID='" + cusID + "'");
                    CPPicture_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from CompanyProducts where ID='" + cusID + "'"));
                }
                else if (tab == "EG")
                {
                    EntryTab.SelectedIndex = 6;
                }
            }
            else
            {
                if (tab == "Vendor")
                {
                    EntryTab.SelectedIndex = 2;
                    VenID_Box.Text = Convert.ToString(cusID);
                    VenName_Box.Text = db.ReturnValueFromDB("select [Name] from Vendor where VendorID='" + cusID + "'");
                    VenEmail_Box1.Text = db.ReturnValueFromDB("select Email from Vendor where VendorID='" + cusID + "'");
                    VenCompany_Box.Text = db.ReturnValueFromDB("select CompanyName from Vendor where VendorID='" + cusID + "'");
                    VenCategory_Box.Text = db.ReturnValueFromDB("select Category from Vendor where VendorID='" + cusID + "'");
                    VenCNIC_Box.Text = db.ReturnValueFromDB("select CNIC from Vendor where VendorID='" + cusID + "'");
                    VenContact_Box.Text = db.ReturnValueFromDB("select ContactNo from Vendor where VendorID='" + cusID + "'");
                    VenDescp_Box.Text = db.ReturnValueFromDB("select Descp from Vendor where VendorID='" + cusID + "'");
                    VenDues_Box.Text = db.ReturnValueFromDB("select Dues from Vendor where VendorID='" + cusID + "'");
                    VenBal_Box.Text = db.ReturnValueFromDB("select Balance from Vendor where VendorID='" + cusID + "'");
                    VenPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Image from Vendor where VendorID='" + cusID + "'"));
                    VenUpdate_Button.Enabled = false;
                }
                else if (tab == "Employee")
                {
                    EntryTab.SelectedIndex = 1;
                    EmpID_Box.Text = Convert.ToString(cusID);
                    EmpName_Box.Text = db.ReturnValueFromDB("select [Name] from Employees where EmployeeID='" + cusID + "'");
                    EmpDept_Box.Text = db.ReturnValueFromDB("select DeptName from Department where DeptID=(select DeptID from Employees where EmployeeID='" + cusID + "')");
                    EmpRole_Box.Text = db.ReturnValueFromDB("select RoleName from Role where RoleID=(select RoleID from Employees where EmployeeID='" + cusID + "')");
                    EmpEmail_Box1.Text = db.ReturnValueFromDB("select Email from Employees where EmployeeID='" + cusID + "'");
                    EmpStatus_Box.Text = db.ReturnValueFromDB("select Status from Employees where EmployeeID='" + cusID + "'");
                    EmpCNIC_Box.Text = db.ReturnValueFromDB("select CNIC from Employees where EmployeeID='" + cusID + "'");
                    EmpContact_Box.Text = db.ReturnValueFromDB("select ContactNo from Employees where EmployeeID='" + cusID + "'");
                    EmpAddress_Box.Text = db.ReturnValueFromDB("select Address from Employees where EmployeeID='" + cusID + "'");
                    EmpUsername_Box.Text = db.ReturnValueFromDB("select Username from Employees where EmployeeID='" + cusID + "'");
                    EmpPassword_Box.Text = db.ReturnValueFromDB("select Password from Employees where EmployeeID='" + cusID + "'");
                    EmpDescp_Box.Text = db.ReturnValueFromDB("select Descp from Employees where EmployeeID='" + cusID + "'");
                    EmpJDate_DTP.Text = db.ReturnValueFromDB("select JoiningDate from Employees where EmployeeID='" + cusID + "'");
                    EmpPay_Box.Text = db.ReturnValueFromDB("select Pay from Employees where EmployeeID='" + cusID + "'");
                    EmpPic_Box.Image = db.ByteArrayToImage(db.Ret_image("select Picture from Employees where EmployeeID='" + cusID + "'"));
                    EmpUpdate_Button.Enabled = false;
                }
            }

            if (EntryTab.SelectedIndex == 0)//"Customer"
            {

            }
            else if (EntryTab.SelectedIndex == 1)//"Employee"
            {
                db.fillCombo(EmpDept_Box, "select DeptName from Department");
            }
            else if (EntryTab.SelectedIndex == 2)//"Vendor"
            {
                db.fillCombo(VenCategory_Box, "select CategoryName from Category");
            }
            else if (EntryTab.SelectedIndex == 3)//"RawMaterial"
            {
                db.fillCombo(RMUOM_Box, "select UnitName from UOM");
            }
            else if (EntryTab.SelectedIndex == 4)//"BakeryItem"
            {
                string main="Bakery Products";
                db.fillCombo(BICategory_Box, "select CategoryName from Category where MainCategory='"+main+"'");
                db.fillCombo(BIUOM_Box, "select UnitName from UOM");
                db.fillCombo(BISize_Box, "select SizeName from Size");
                db.fillCombo(BIShape_Box, "select ShapeName from Shape");
                db.fillCombo(BIDecoration_Box, "select DecorationName from Decoration");
            }
            else if (EntryTab.SelectedIndex == 5)//"CompanyProduct"
            {
                string main = "Company Products";
                db.fillCombo(CPCategory_Box, "select CategoryName from Category where MainCategory='" + main + "'");
                db.fillCombo(CPUOM_Box, "select UnitName from UOM");
                db.fillCombo(CPSize_Box, "select SizeName from Size");
                db.fillCombo(CPColor_Box, "select ColorName from Color");
                db.fillCombo(CPWeight_Box, "Select Value From Weight");
            }
            else if (EntryTab.SelectedIndex == 6)//"Gas And Electricity"
            {
                Elect_Box.Text = db.ReturnValueFromDB("Select CostAmount from ExtraCosts where CostName='Electricity'");
                Gas_Box.Text = db.ReturnValueFromDB("Select CostAmount from ExtraCosts where CostName='Gas'");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustBack_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustImage_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CustPic_Box.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void CustUpdate_Button_Click(object sender, EventArgs e)
        {
            string email = CustEmail_Box1.Text;
            if (task == "Add")
            {
                db.DataManupulationOperationwithPic("Insert into Customer (CustomerID,Name,[Status],Descp,Email,CNIC,[Address],Contact,Picture,Username,[Password],Dues,Balance) values('" + Convert.ToInt32(CustID_Box.Text) + "','" + CustName_Box.Text + "','" + CustStatus_Box.Text + "','" + CustDescp_Box.Text + "','" + email + "','" + CustCNIC_Box.Text + "','" + CustAddress_Box.Text + "','" + CustContact_Box.Text + "',@picture,'" + CustUsername_Box.Text + "','" + CustPassword_Box.Text + "','" + Convert.ToDouble(CustDues_Box.Text) + "','" + Convert.ToDouble(CustBal_Box.Text) + "')", CustPic_Box);
                db.DataManupulationOperation("Update Customer set AuthorizationLevelID =(Select LevelID from AuthorizationLevel where Descp like'%Customer%') where CustomerID='" + Convert.ToInt32(CustID_Box.Text) + "'");
            }
            else if (task == "Edit")
            {
                db.DataManupulationOperationwithPic("Update Customer set Name='" + CustName_Box.Text + "',[Status]='" + CustStatus_Box.Text + "',Descp='" + CustDescp_Box.Text + "',Email='" + email + "',CNIC='" + CustCNIC_Box.Text + "',[Address]='" + CustAddress_Box.Text + "',Contact='" + CustContact_Box.Text + "',Picture=@picture,Username='" + CustUsername_Box.Text + "',[Password]='" + CustPassword_Box.Text + "',Dues='" + Convert.ToDouble(CustDues_Box.Text) + "',Balance='" + Convert.ToDouble(CustBal_Box.Text) + "' where CustomerID='" + Convert.ToInt32(CustID_Box.Text) + "'", CustPic_Box);
                db.DataManupulationOperation("Update Customer set AuthorizationLevelID =(Select LevelID from AuthorizationLevel where Descp like'%Customer%') where CustomerID='" + Convert.ToInt32(CustID_Box.Text) + "'");
            }
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
        }

        private void EmpUpdate_Button_Click(object sender, EventArgs e)
        {            
            string email = EmpEmail_Box1.Text;
            int RoleID = Convert.ToInt32(db.ReturnValueFromDB("select RoleID from Role where RoleName='" + EmpRole_Box.Text + "'"));
            int DeptID = Convert.ToInt32(db.ReturnValueFromDB("select DeptID from Department where DeptName='" + EmpDept_Box.Text + "'"));
            if (task == "Add")
            {
                db.DataManupulationOperationwithPic("Insert into Employees (EmployeeID,Name,CNIC,JoiningDate,ContactNo,Email,[Address],[Status],Descp,Pay,Picture,Username,[Password],RoleID,DeptID) values('" + Convert.ToInt32(EmpID_Box.Text) + "','" + EmpName_Box.Text + "','" + EmpCNIC_Box.Text + "','" + Convert.ToDateTime(EmpJDate_DTP.Value) + "','" + EmpContact_Box.Text + "','" + email + "','" + EmpAddress_Box.Text + "','" + EmpStatus_Box.Text + "','" + EmpDescp_Box.Text + "','" + EmpPay_Box.Text + "',@picture,'" + EmpUsername_Box.Text + "','" + EmpPassword_Box.Text + "','" + RoleID + "','" + DeptID + "')", EmpPic_Box);
                db.DataManupulationOperation("Update Employees set AuthorizationLevelID =(Select LevelID from AuthorizationLevel where Descp like'%" + EmpRole_Box.Text + "%') where EmployeeID='" + Convert.ToInt32(EmpID_Box.Text) + "'");
            }
            else if (task == "Edit")
            {
                db.DataManupulationOperationwithPic("Update Employees set Name='" + EmpName_Box.Text + "',CNIC='" + EmpCNIC_Box.Text + "',JoiningDate='" + Convert.ToDateTime(EmpJDate_DTP.Value) + "',ContactNo='" + EmpContact_Box.Text + "',Email='" + email + "',[Address]='" + EmpAddress_Box.Text + "',[Status]='" + EmpStatus_Box.Text + "',Descp='" + EmpDescp_Box.Text + "',Pay='" + EmpPay_Box.Text + "',Picture=@picture,Username='" + EmpUsername_Box.Text + "',[Password]='" + EmpPassword_Box.Text + "',RoleID='" + RoleID + "',DeptID='" + DeptID + "' where EmployeeID='" + Convert.ToInt32(EmpID_Box.Text) + "'", EmpPic_Box);
                db.DataManupulationOperation("Update Employees set AuthorizationLevelID =(Select LevelID from AuthorizationLevel where Descp like'%" + EmpRole_Box.Text + "%') where EmployeeID='" + Convert.ToInt32(EmpID_Box.Text) + "'");
            }
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
        }

        private void VenUpdate_Button_Click(object sender, EventArgs e)
        {
            string email = VenEmail_Box1.Text ;
            int CategoryID = Convert.ToInt32(db.ReturnValueFromDB("select CategoryID from Category where CategoryName='" + VenCategory_Box.Text + "'"));
            if (task == "Add")
            {
                db.DataManupulationOperationwithPic("Insert into Vendor (VendorID,Name,Descp,CompanyName,Category,ContactNo,Email,CNIC,Image,Dues,Balance,CategoryID) values('" + Convert.ToInt32(VenID_Box.Text) + "','" + VenName_Box.Text + "','" + VenDescp_Box.Text + "','" + VenCompany_Box.Text + "','" + VenCategory_Box.Text + "','" + VenContact_Box.Text + "','" + email + "','" + VenCNIC_Box.Text + "',@picture,'" + Convert.ToDouble(VenDues_Box.Text) + "','" + Convert.ToDouble(VenBal_Box.Text) + "','" + CategoryID + "')", VenPic_Box);
            }
            else if (task == "Edit")
            {
                db.DataManupulationOperationwithPic("Update Vendor set Name='" + VenName_Box.Text + "',Descp='" + VenDescp_Box.Text + "',CompanyName='" + VenCompany_Box.Text + "',Category='" + VenCategory_Box.Text + "',ContactNo='" + VenContact_Box.Text + "',Email='" + email + "',CNIC='" + VenCNIC_Box.Text + "',Image=@picture,Dues='" + Convert.ToDouble(VenDues_Box.Text) + "',Balance='" + Convert.ToDouble(VenBal_Box.Text) + "',CategoryID='" + CategoryID + "' where VendorID='" + Convert.ToInt32(VenID_Box.Text) + "'", VenPic_Box);
            }
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
        }

        private void RMUpdate_Button_Click(object sender, EventArgs e)
        {
            int UnitID = Convert.ToInt32(db.ReturnValueFromDB("select UnitID from UOM where UnitName='" + RMUOM_Box.Text + "'"));
            if (task == "Add")
            {
                db.DataManupulationOperationwithPic("Insert into RawMaterial (RawMaterialID,Name,Price,UOM,Qty,Picture,Descp,UOMID) values('" + Convert.ToInt32(RMID_Box.Text) + "','" + RMName_Box.Text + "','" + Convert.ToDouble(RMPrice_Box.Text) + "','" + RMUOM_Box.Text + "','" + Convert.ToDouble(RMQty_Box.Text) + "',@picture,'" + RMDescp_Box.Text + "','" + UnitID + "')", RMPic_Box);
            }
            else if (task == "Edit")
            {
                db.DataManupulationOperationwithPic("Update RawMaterial set Name='" + RMName_Box.Text + "',Price='" + Convert.ToDouble(RMPrice_Box.Text) + "',UOM='" + RMUOM_Box.Text + "',Qty='" + Convert.ToDouble(RMQty_Box.Text) + "',Picture=@picture,Descp='" + RMDescp_Box.Text + "',UOMID='" + UnitID + "' where RawMaterialID='" + Convert.ToInt32(RMID_Box.Text) + "'", RMPic_Box);
            }
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
        }

        private void BIUpdate_Button_Click(object sender, EventArgs e)
        {
            string name;
            if (BISize_Box.Text != "N/A")
            {
                if (BIDecoration_Box.Text != "N/A")
                {
                    if (BIShape_Box.Text != "N/A")
                    {
                        name = BIName_Box.Text + "(" + BISize_Box.Text + ")" + " " + BIDecoration_Box.Text + " " + BIShape_Box.Text;
                    }
                    else
                    {
                        name = BIName_Box.Text + "(" + BISize_Box.Text + ")" + " " + BIDecoration_Box.Text;
                    }
                }
                else
                {
                    if (BIShape_Box.Text != "N/A")
                    {
                        name = BIName_Box.Text + "(" + BISize_Box.Text + ")" + " " + BIShape_Box.Text;
                    }
                    else
                    {
                        name = BIName_Box.Text + "(" + BISize_Box.Text + ")";
                    }
                }
            }
            else
            {
                if (BIDecoration_Box.Text != "N/A")
                {
                    if (BIShape_Box.Text != "N/A")
                    {
                        name = BIName_Box.Text + " " + BIDecoration_Box.Text + " " + BIShape_Box.Text;
                    }
                    else
                    {
                        name = BIName_Box.Text + " " + BIDecoration_Box.Text;
                    }
                }
                else
                {
                    if (BIShape_Box.Text != "N/A")
                    {
                        name = BIName_Box.Text + " " + BIShape_Box.Text;
                    }
                    else
                    {
                        name = BIName_Box.Text;
                    }
                }
            }
            int CategoryID = Convert.ToInt32(db.ReturnValueFromDB("select CategoryID from Category where CategoryName='" + BICategory_Box.Text + "'"));
            int SizeID = Convert.ToInt32(db.ReturnValueFromDB("select SizeID from Size where SizeName='" + BISize_Box.Text + "'"));
            int ShapeID = Convert.ToInt32(db.ReturnValueFromDB("select ShapeID from Shape where ShapeName='" + BIShape_Box.Text + "'"));
            int DecorationID = Convert.ToInt32(db.ReturnValueFromDB("select DecorationID from Decoration where DecorationName='" + BIDecoration_Box.Text + "'"));
            int UOMID = Convert.ToInt32(db.ReturnValueFromDB("select UnitID from UOM where UnitName='" + BIUOM_Box.Text + "'"));
            if (task == "Add")
            {
                db.DataManupulationOperationwithPic("Insert into BakeryItems (ItemID,Name,Qty,Price,Image,Descp,CategoryID,UOMID,SizeID,ShapeID,DecorationID) values('" + Convert.ToInt32(BIID_Box.Text) + "','" + name + "','" + Convert.ToDouble(BIQty_Box.Text) + "','" + Convert.ToDouble(BIPrice_Box.Text) + "',@picture,'" + BIDescp_Box.Text + "','" + CategoryID + "','" + UOMID + "','" + SizeID + "','" + ShapeID + "','" + DecorationID + "')", BIPicture_Box);
            }
            else if (task == "Edit")
            {
                db.DataManupulationOperationwithPic("Update BakeryItems set Name='" + name + "',Qty='" + Convert.ToDouble(BIQty_Box.Text) + "',Price='" + Convert.ToDouble(BIPrice_Box.Text) + "',Image=@picture,Descp='" + BIDescp_Box.Text + "',CategoryID='" + CategoryID + "',UOMID='" + UOMID + "',SizeID='" + SizeID + "',ShapeID='" + ShapeID + "',DecorationID='" + DecorationID + "' where ItemID='" + Convert.ToInt32(BIID_Box.Text) + "'", BIPicture_Box);
            }
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
        }

        private void CPUpdate_Button_Click(object sender, EventArgs e)
        {
            string name;
            if (CPSize_Box.Text != "N/A")
            {
                if (CPColor_Box.Text!="N/A")
                {
                    if (CPWeight_Box.Text != "N/A")
                    {
                        name = CPName_Box.Text + " " + CPWeight_Box.Text + "(" + CPSize_Box.Text + ")" + " " + CPColor_Box.Text;
                    }
                    else
                    {
                        name = CPName_Box.Text + "(" + CPSize_Box.Text + ")" + " " + CPColor_Box.Text;
                    }
                }
                else
                {
                    if (CPWeight_Box.Text != "N/A")
                    {
                        name = CPName_Box.Text + " " + CPWeight_Box.Text + "(" + CPSize_Box.Text + ")";
                    }
                    else
                    {
                        name = CPName_Box.Text + "(" + CPSize_Box.Text + ")";
                    }
                }
            }
            else
            {
                if (CPColor_Box.Text != "N/A")
                {
                    if (CPWeight_Box.Text != "N/A")
                    {
                        name = CPName_Box.Text + " " + CPWeight_Box.Text + " " + CPColor_Box.Text;
                    }
                    else
                    {
                        name = CPName_Box.Text + " " + CPColor_Box.Text;
                    }
                }
                else
                {
                    if (CPWeight_Box.Text != "N/A")
                    {
                        name = CPName_Box.Text + " " + CPWeight_Box.Text;
                    }
                    else
                    {
                        name = CPName_Box.Text;
                    }
                }
            }
            int CategoryID = Convert.ToInt32(db.ReturnValueFromDB("select CategoryID from Category where CategoryName='" + CPCategory_Box.Text + "'"));
            int SizeID = Convert.ToInt32(db.ReturnValueFromDB("select SizeID from Size where SizeName='" + CPSize_Box.Text + "'"));
            int ColorID = Convert.ToInt32(db.ReturnValueFromDB("select ColorID from Color where ColorName='" + CPColor_Box.Text + "'"));
            int UOMID = Convert.ToInt32(db.ReturnValueFromDB("select UnitID from UOM where UnitName='" + CPUOM_Box.Text + "'"));
            int WeightID = Convert.ToInt32(db.ReturnValueFromDB("select WeightID from Weight where Value='" + CPWeight_Box.Text + "'"));
            if (task == "Add")
            {
                db.DataManupulationOperationwithPic("Insert into CompanyProducts (ID,Name,Company,Qty,Price,Picture,Descp,CategoryID,UOMID,SizeID,ColorID,WeightID) values('" + Convert.ToInt32(CPID_Box.Text) + "','" + name + "','" + CPCompany_Box.Text + "','" + Convert.ToDouble(CPQty_Box.Text) + "','" + Convert.ToDouble(CPPrice_Box.Text) + "',@picture,'" + CPDescp_Box.Text + "','" + CategoryID + "','" + UOMID + "','" + SizeID + "','" + ColorID + "','" + WeightID + "')", CPPicture_Box);
            }
            else if (task == "Edit")
            {
                db.DataManupulationOperationwithPic("Update CompanyProducts set Name='" + name + "',Company='" + CPCompany_Box.Text + "',Qty='" + Convert.ToDouble(CPQty_Box.Text) + "',Price='" + Convert.ToDouble(CPPrice_Box.Text) + "',Picture=@picture,Descp='" + CPDescp_Box.Text + "',CategoryID='" + CategoryID + "',UOMID='" + UOMID + "',SizeID='" + SizeID + "',ColorID='" + ColorID + "',WeightID='" + WeightID + "' where ID='" + Convert.ToInt32(CPID_Box.Text) + "'", CPPicture_Box);
            }
            MetroMessageBox.Show(this, "Record Has been Updated...!!!", "Information...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
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

        private void VenImage_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    VenPic_Box.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void RMImage_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    RMPic_Box.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void BIImage_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    BIPicture_Box.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void CPImage_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CPPicture_Box.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void EGUpdate_Button_Click(object sender, EventArgs e)
        {
            db.DataManupulationOperation("UPDATE ExtraCosts SET CostAmount='" + Convert.ToDouble(Elect_Box.Text) + "' where CostID='1'");
            db.DataManupulationOperation("UPDATE ExtraCosts SET CostAmount='" + Convert.ToDouble(Gas_Box.Text) + "' where CostID='2'");
            MetroMessageBox.Show(this, "Costs of Electricity & Gas are Updated", "Update Successful...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
        }

        private void EGBack_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void refresh()
        {
            //
            //Customer
            //
            CustID_Box.Text = db.autoID("Select MAX(CustomerID) from Customer", "Customer").ToString();
            CustName_Box.Text = null;
            CustEmail_Box1.Text = null;
            CustStatus_Box.Text = null;
            CustCNIC_Box.Text = null;
            CustContact_Box.Text = null;
            CustAddress_Box.Text = null;
            CustUsername_Box.Text = null;
            CustPassword_Box.Text = null;
            CustDescp_Box.Text = null;
            CustDues_Box.Text = null;
            CustBal_Box.Text = null;
            CustPic_Box.Image = null;
            //
            //Employee
            //
            EmpID_Box.Text = db.autoID("Select MAX(EmployeeID) from Employees", "Employees").ToString();
            EmpName_Box.Text = null;
            EmpEmail_Box1.Text = null;
            EmpStatus_Box.Text = null;
            EmpContact_Box.Text = null;
            EmpCNIC_Box.Text = null;
            EmpAddress_Box.Text = null;
            EmpUsername_Box.Text = null;
            EmpPassword_Box.Text = null;
            EmpDescp_Box.Text = null;
            EmpPay_Box.Text = null;
            EmpDept_Box.Text = null;
            EmpPic_Box.Image = null;
            //
            //Vendor
            //
            VenID_Box.Text = db.autoID("Select MAX(VendorID) from Vendor", "Vendor").ToString();
            VenName_Box.Text = null;
            VenEmail_Box1.Text = null;
            VenCompany_Box.Text = null;
            VenCNIC_Box.Text = null;
            VenContact_Box.Text = null;
            VenCategory_Box.Text = null;
            VenDescp_Box.Text = null;
            VenDues_Box.Text = null;
            VenBal_Box.Text = null;
            VenPic_Box.Image = null;
            //
            //Raw Material
            //
            RMID_Box.Text = db.autoID("Select MAX(RawMaterialID) from RawMaterial", "RawMaterial").ToString();
            RMName_Box.Text = null;
            RMPrice_Box.Text = null;
            RMQty_Box.Text = null;
            RMUOM_Box.Text = null;
            RMDescp_Box.Text = null;
            RMPic_Box.Image = null;
            //
            //Bakery Items
            //
            BIID_Box.Text = db.autoID("Select MAX(ItemID) from BakeryItems", "BakeryItems").ToString();
            BIName_Box.Text = null;
            BIPrice_Box.Text = null;
            BIQty_Box.Text = null;
            BIUOM_Box.Text = null;
            BIDescp_Box.Text = null;
            BIPicture_Box.Image = null;
            BISize_Box.Text = null;
            BIShape_Box.Text = null;
            BIDecoration_Box.Text = null;
            BICategory_Box.Text = null;
            //
            //Company Products
            //
            CPID_Box.Text = db.autoID("Select MAX(ID) from CompanyProducts", "CompanyProducts").ToString();
            CPName_Box.Text = null;
            CPPrice_Box.Text = null;
            CPQty_Box.Text = null;
            CPUOM_Box.Text = null;
            CPDescp_Box.Text = null;
            CPPicture_Box.Image = null;
            CPSize_Box.Text = null;
            CPColor_Box.Text = null;
            CPCompany_Box.Text = null;
            CPWeight_Box.Text = null;
            CPCategory_Box.Text = null;
            //
            //Electricity & Gas
            //
            Elect_Box.Text = null;
            Gas_Box.Text = null;

        }

        private void CustEmail_Box1_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (CustEmail_Box1.Text.Length > 0)
            {

                if (!rEMail.IsMatch(CustEmail_Box1.Text))
                {
                    CustUpdate_Button.Enabled = false;
                    Cust_Label.Text = "*Wrong E-mail...!!!";
                    //MetroMessageBox.Show(this, "Wrong Email Entered...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustEmail_Box1.SelectAll();
                    e.Cancel = true;
                }
                else
                {
                    Cust_Label.Text = " ";
                    CustUpdate_Button.Enabled = true;
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
                    //MetroMessageBox.Show(this, "Wrong Email Entered...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void VenEmail_Box1_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (VenEmail_Box1.Text.Length > 0)
            {
                if (!rEMail.IsMatch(VenEmail_Box1.Text))
                {
                    VenUpdate_Button.Enabled = false;
                    Ven_Label.Text = "*Wrong E-mail...!!!";
                    //MetroMessageBox.Show(this, "Wrong Email Entered...!!!", "Error...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    VenEmail_Box1.SelectAll();
                    e.Cancel = true;
                }
                else
                {
                    Ven_Label.Text = " ";
                    VenUpdate_Button.Enabled = true;
                }
            }
        }

        private void EmpDept_Box_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string dept = EmpDept_Box.Text;
            EmpRole_Box.Items.Clear();
            if (EmpDept_Box.Text != null && EmpDept_Box.Text != "")
            {
                int ID = Convert.ToInt32(db.ReturnValueFromDB("select DeptID from Department where DeptName='" + dept + "'"));
                db.fillCombo(EmpRole_Box, "select RoleName from Role where DepartmentID='" + ID + "'");
            }
        }

        private void RM_AddNewUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(UnitID) from UOM", "UOM").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "UOM", "Add New Unit");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(RMUOM_Box, "select UnitName from UOM");
            }
        }

        private void BI_AddNewUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(UnitID) from UOM", "UOM").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "UOM", "Add New Unit");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(BIUOM_Box, "select UnitName from UOM");
            }
        }

        private void CP_AddNewUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(UnitID) from UOM", "UOM").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "UOM", "Add New Unit");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(CPUOM_Box, "select UnitName from UOM");
            }
        }

        private void BI_AddNewSize_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(SizeID) from Size", "Size").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "Size", "Add New Size");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(BISize_Box, "select SizeName from Size");
            }
        }

        private void CP_AddNewSize_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(SizeID) from Size", "Size").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "Size", "Add New Size");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(CPSize_Box, "select SizeName from Size");
            }
        }

        private void CP_AddNewColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(ColorID) from Color", "Color").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "Color", "Add New Color");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(CPColor_Box, "select ColorName from Color");
            }
        }

        private void CP_AddNewWeight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(WeightID) from Weight", "Weight").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "Weight", "Add New Weight");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(CPColor_Box, "select Value from Weight");
            }
        }

        private void BI_AddNewShape_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(ShapeID) from Shape", "Shape").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "Shape", "Add New Shape");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(CPColor_Box, "select ShapeName from Shape");
            }
        }

        private void BI_AddNewDecoration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(db.autoID("Select MAX(DecorationID) from Decoration", "Decoration").ToString());
            MyMessageBox mb = new MyMessageBox(ID, "Decoration", "Add New Decoration");
            if (mb.ShowDialog() == DialogResult.OK)
            {
                db.fillCombo(CPColor_Box, "select DecorationName from Decoration");
            }
        }

        private void Elect_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void Gas_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void CPQty_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void CPPrice_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void BIQty_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void BIPrice_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void RMPrice_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void RMQty_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void VenBal_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void VenDues_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void EmpPay_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void CustBal_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void CustDues_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void CustName_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CustStatus_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EmpName_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EmpStatus_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void VenName_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void RMName_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BIName_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CPName_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
