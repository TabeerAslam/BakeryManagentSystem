using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPS
{
    public partial class MyMessageBox : MetroFramework.Forms.MetroForm
    {
        DBClass db = new DBClass();
        int ID = 0;
        string table = "";
        public MyMessageBox(int ID,string tablename,string task)
        {
            this.ID = ID;
            this.table = tablename;
            InitializeComponent();
            this.Width = Entry.ActiveForm.Width;
            this.Text = task;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.DataManupulationOperation("Insert into " + table + " values('" + ID_Box.Text + "','" + Data_Box.Text + "','" + Descp_Box.Text + "')");
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            ID_Box.Text = ID.ToString();
            ID_Box.Enabled = false;
        }
    }
}
