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
using System.Data;

namespace DuongThuanQuang_Tuan8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source = A209PC38; database = QLSV; Integrated Security = true";
                conn.Open();
                string Strcmd = "INSERT INTO SINHVIEN VALUES (@ID, @Name)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = Strcmd;
                cmd.Connection = conn;
                int ID = int.Parse(txt_ID.Text);
                string Name = txt_Name.Text;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
                txt_ID.Text = "";
                txt_Name.Text = "";
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source = A209PC38; database = QLSV; Integrated Security = true";
                    conn.Open();

                    string query = "SELECT * FROM SINHVIEN";
                    SqlDataAdapter da = new SqlDataAdapter(query,conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dtrv_ListSV.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source = A209PC38; database = QLSV; Integrated Security = true";
                    conn.Open();
                    string sql = "UPDATE SINHVIEN SET NAME = @NAME WHERE ID = @ID";
                    int id = int.Parse(txt_ID.Text);
                    string name = txt_Name.Text;
                    SqlCommand cmd3 = new SqlCommand(sql, conn);
                    cmd3.Parameters.AddWithValue("@ID", id);
                    cmd3.Parameters.AddWithValue("@NAME", name);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Update thành công!");
                    txt_ID.Text = "";
                    txt_Name.Text = "";
                }
            }
            catch
            {
                throw;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source = A209PC38; database = QLSV; Integrated Security = true";
                    conn.Open();
                    string sql = "DELETE FROM SINHVIEN WHERE ID = @ID";
                    int id = int.Parse(txt_ID.Text);
                    SqlCommand cmd4 = new SqlCommand(sql, conn);
                    cmd4.Parameters.AddWithValue("@ID", id);
                    cmd4.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    txt_ID.Text = "";
                    txt_Name.Text = "";
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
