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
using BPS.Properties;
using System.Data.SqlClient;

namespace BPS
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        DBClass DB = new DBClass();
        public Login()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            SlideTimer.Start();
            timer.Start();
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Production pd = new Production();
            pd.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserNameBox.Text.Equals("") && PasswordBox.Text.Equals(""))
            {
                uExclimi.Visible = (true);
                pExclimi.Visible = (true);
            }
            else if (UserNameBox.Text.Equals(""))
            {
                uExclimi.Visible = (true);
                pExclimi.Visible = (false);
            }
            else if (PasswordBox.Text.Equals(""))
            {
                uExclimi.Visible = (false);
                pExclimi.Visible = (true);
            }
            else if (DB.Authentication(UserNameBox.Text, PasswordBox.Text)=="Admin")
            {
                MetroMessageBox.Show(this, "Login Successful", "[Confirmation...!!!]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int ID = Convert.ToInt32(DB.ReturnValueFromDB("select EmployeeID from Employees where Username='" + UserNameBox.Text + "' AND Password='" + PasswordBox.Text + "'"));
                int AuthLevel = Convert.ToInt32(DB.ReturnValueFromDB("Select Level from AuthorizationLevel where LevelID=(Select AuthorizationLevelID from Employees where Username='" + UserNameBox.Text + "' AND Password='" + PasswordBox.Text + "')"));
                AdminPanel ap = new AdminPanel(AuthLevel, ID);
                PasswordBox.Text = null;
                ap.ShowDialog();
                //this.Hide();
            }
            else if (DB.Authentication(UserNameBox.Text, PasswordBox.Text) == "Salesman")
            {
                string sman = DB.ReturnValueFromDB("select Name from Employees where Username='" + UserNameBox.Text + "' AND Password='" + PasswordBox.Text + "'");
                int ID = Convert.ToInt32(DB.ReturnValueFromDB("select EmployeeID from Employees where Username='" + UserNameBox.Text + "' AND Password='" + PasswordBox.Text + "'"));
                MetroMessageBox.Show(this, "Login Successful", "[Confirmation...!!!]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sales sa = new Sales(sman,ID);
                PasswordBox.Text = null;
                sa.ShowDialog();
                //this.Hide();
            }
            else if (DB.Authentication(UserNameBox.Text, PasswordBox.Text) == "System Manager")
            {
                string smgr = DB.ReturnValueFromDB("select Name from Employees where Username='" + UserNameBox.Text + "' AND Password='" + PasswordBox.Text + "'");
                int ID = Convert.ToInt32(DB.ReturnValueFromDB("select EmployeeID from Employees where Username='" + UserNameBox.Text + "' AND Password='" + PasswordBox.Text + "'"));
                MetroMessageBox.Show(this, "Login Successful", "[Confirmation...!!!]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SystemManager sm = new SystemManager(smgr, ID);
                PasswordBox.Text = null;
                sm.ShowDialog();
                //this.Hide();
            }
            else
            {
                MetroMessageBox.Show(this, "Wrong Username OR Password...!!!", "ERROR...!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserNameBox_Leave(object sender, EventArgs e)
        {
            
            if (UserNameBox.Text != null && UserNameBox.Text != "")
            {
                string UserName = UserNameBox.Text;
                if (DB.checkValue("select Username from Employees", UserName) == false)
                {
                    WrongUser_Label.Visible = true;
                    LoginButton.Enabled = false;
                    PasswordBox.Enabled = false;
                }
                else
                {
                    WrongUser_Label.Visible = false;
                    LoginButton.Enabled = true;
                    PasswordBox.Enabled = true;
                }
            }
        }

        private void SlideTimer_Tick_1(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
            }
            else if (pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                pictureBox7.Visible = true;
            }
            else if (pictureBox7.Visible == true)
            {
                pictureBox7.Visible = false;
                pictureBox8.Visible = true;
            }
            else if (pictureBox8.Visible == true)
            {
                pictureBox8.Visible = false;
                pictureBox9.Visible = true;
            }
            else if (pictureBox9.Visible == true)
            {
                pictureBox9.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void UserNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void logo_Click(object sender, EventArgs e)
        {

        }
    }
}
