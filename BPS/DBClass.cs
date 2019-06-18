using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;

namespace BPS
{
    class DBClass
    {
       // public string data = "Data Source=DESKTOP-7S7BL16/SQLEXPRESS;Initial Catalog=BPS;Integrated Security=True";
      
        public SqlConnection conc;
        public SqlCommand cmd;
        public SqlDataAdapter sda;
        public DataTable dt;
        string conStr = ConfigurationManager.ConnectionStrings["cstring"].ToString();

        public DBClass()
        {
            
        }

        public bool checkValue(string q,string val)
        {
            conc = new SqlConnection(conStr);

            if (conc.State == ConnectionState.Closed)
            {
                conc.Open();
            }

            DataTable dt = DataNavigationOperations(q);
            string ans = "";
            foreach (DataRow item in dt.Rows)
            {
                if (val == item[0].ToString())
                {
                    ans = "Y";
                    break;
                }
                else
                {
                    ans = "N";
                }
            }
            if (ans == "Y")
            {
                return true;
            }
            else return false;
        }

        public void search(TextBox SearchBar,string q)
        {
            conc = new SqlConnection(conStr);

            try
            {

                if (conc.State == ConnectionState.Closed)
                {
                    conc.Open();
                }

                SqlCommand cmd = new SqlCommand(q, conc);
                SqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection Items = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    Items.Add(dr.GetString(0));
                }
                SearchBar.AutoCompleteMode = AutoCompleteMode.Suggest;
                SearchBar.AutoCompleteSource = AutoCompleteSource.CustomSource;
                SearchBar.AutoCompleteCustomSource = Items;
                conc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed!");
            }
        }

        public string ReturnValueFromDB(string q)
        {
            conc = new SqlConnection(conStr);


            if (conc.State == ConnectionState.Closed)
            {
                conc.Open();
            }


            DataTable dt = DataNavigationOperations(q);
            string Val = "";
            foreach (DataRow item in dt.Rows)
            {
                Val = item[0].ToString();
            }
            return Val;
        }

        public void datagridcombox(DataGridViewComboBoxCell c, string q)
        {
            c.Items.Clear();
           
            if (conc.State == ConnectionState.Closed)
            {
                conc.Open();
            }
            SqlCommand cnd = new SqlCommand(q, conc);
            SqlDataReader reader = cnd.ExecuteReader();
            while (reader.Read())
            {
                c.Items.Add(reader[0].ToString());
            }
            reader.Close();
            conc.Close();
        }

        public void fillCombo(ComboBox ComboBox, string query)
        {
            conc = new SqlConnection(conStr);

            cmd = new SqlCommand(query, conc);

            if (conc.State == ConnectionState.Closed)
            {
                conc.Open();
            }
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            try
            {
                ComboBox.Items.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    ComboBox.Items.Add(item[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Failed To Add Data in ComboBox", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conc.Close();
        }

        public int valueexist(string q)
        {
            conc = new SqlConnection(conStr);

            conc.Close();
            int s;

            if (conc.State == ConnectionState.Closed)
            {
                conc.Open();
            }

            cmd = new SqlCommand(q, conc);
            s = (Int32)cmd.ExecuteScalar();
            conc.Close();
            return s;
        }

        public int autoID(string query,string tableName)
        {
            string q = "Select count(*) as IsExists from "+tableName;
            int chk = valueexist(q);
            if (chk >= 1)
            {
                int a=Convert.ToInt32(ReturnValueFromDB(query));
                return a+1;
            }
            else
            {
                return 1;
            }
        }

        public DataTable DataNavigationOperations(string query)
        {
            try
            {
                cmd = new SqlCommand(query, conc);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows != null)
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public bool DataManupulationOperation(string query)
        {
            try
            {
                conc = new SqlConnection(conStr);

                    conc.Open();
                cmd = new SqlCommand(query, conc);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conc.Close();
            return false;
        }

        public bool DataManupulationOperationwithPic(string query,PictureBox pc)
        {
            try
            {
                cmd = new SqlCommand(query, conc);
                MemoryStream ms = new MemoryStream();
                pc.Image.Save(ms, pc.Image.RawFormat);
                byte[] Photo = ms.GetBuffer();
                ms.Close();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@picture", Photo);
                conc = new SqlConnection(conStr);

                if (conc.State == ConnectionState.Closed)
                {
                    conc.Open();
                }

                int count = cmd.ExecuteNonQuery();
                pc.Image = null;
                if (count > 0)
                {
                    conc.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conc.Close();
            return false;
        }

        public string Authentication(string Username, string Password)
        {
            SqlCommand cmd = new SqlCommand("Select * From Employees WHERE Username='" + Username + "' AND Password='" + Password + "'", conc);
            conc = new SqlConnection(conStr);
            if (conc.State == ConnectionState.Closed)
            {
                conc.Open();
            }

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[11].ToString() == Username && reader[12].ToString() == Password)
                {
                    int roleID = Convert.ToInt32(reader[14].ToString());
                    
                    string role = ReturnValueFromDB("Select RoleName from Role where RoleID='" + roleID + "'");
                    reader.Close();
                    conc.Close();
                    return role;
                }
                else
                {
                    conc.Close();
                    return "";
                }
            }
            conc.Close();
            return "";
        }

        #region RetrivalOfPicture
        public System.Drawing.Image ByteArrayToImage(byte[] bArray)
        {
            if (bArray == null)
                return null;
            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bArray));
            return x;
        }
        public Byte[] Ret_image(string q)
        {
            cmd = new SqlCommand(q, conc);
            conc.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Byte[] ar = new Byte[1];
            while (reader.Read())
            {
                ar = (Byte[])(reader[0]);
            }
            conc.Close();
            return ar;
        }
        #endregion

    }
}
