using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary1;
using System.Data.SqlClient;
namespace DoAnQuanLySach
{
    public partial class frmThamGia : Form
    {


        DBConnect conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
       
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        DataColumn[] primarykey = new DataColumn[2];
        public frmThamGia()
        {
            InitializeComponent();
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        }
        string tenMay, tenDB, tenUser, pass;
     
        public frmThamGia(string a, string b, string c, string d)
        {
            InitializeComponent();
            tenMay = a;
            tenDB = b;
            tenUser = c;
            pass = d;
            conn = new DBConnect("QuanLyNhaSach_QL",tenMay, tenDB, tenUser, pass);
      

        }

    
        private void frmThamGia_Load(object sender, EventArgs e)
        {
            createTable_TG();
            load_cboSach();
            load_cboTG1();
            load_dataGV();
        }

        public void load_cboTG1()
        {
            string strSQL = "select * from TacGia";
            DataTable dt = conn.getDataTable(strSQL, "TacGia");

            cboTacGia.DataSource = dt;
            cboTacGia.DisplayMember = "TenTacGia";
            cboTacGia.ValueMember = "MaTacGia";
        }
        public void load_cboSach()
        {
            string strSQL = "select * from Sach";
            DataTable dt = conn.getDataTable(strSQL, "Sach");

            cboSach.DataSource = dt;
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
        }
        //tao bang sach
        public void createTable_TG()
        {
            //tao 1 database co ten lop de cap nhat du lieu
            string strSQL = "select * from ThamGia";
            ada_KetQua = conn.getDataAdapter(strSQL, "ThamGia");
            // tao khoa chinh cho bang lop cua datasset
            primarykey[1] = conn.Dset.Tables["ThamGia"].Columns["MaTacGia"];
            primarykey[0] = conn.Dset.Tables["ThamGia"].Columns["MaSach"];
            conn.Dset.Tables["ThamGia"].PrimaryKey = primarykey;
        }
        public void load_dataGV()
        {
            string strSQL = "select * from ThamGia ";
            DataTable dt = conn.getDataTable(strSQL, "ThamGia");

            dataGridView1.DataSource = dt;
        }

        private void cboTacGia_SelectionChangeCommitted(object sender, EventArgs e)
        {
           

            string strSQL = "select * from Sach,tacgia,thamgia where sach.MaSach=thamgia.MaSach and tacgia.MaTacGia = thamgia.MaTacGia and TacGia.MatacGia='" + cboTacGia.SelectedValue.ToString() + "' ";
            DataTable dt = conn.getDataTable(strSQL, "Sach,tacgia,thamgia");

            cboSach.DataSource = dt;
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
        }

        private void cboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strSelect = "select * from thamgia where   MaTacGia='" + cboTacGia.SelectedValue.ToString() + "' and MaSach='" + cboSach.SelectedValue.ToString() + "' ";
            //DataSet ds_SV = new DataSet();
            //SqlDataAdapter da_SV = new SqlDataAdapter(strSelect, conn.Con);
            //da_SV.Fill(ds_SV);
            //dataGridView1.DataSource = ds_SV.Tables[0];
        }

        private void cboSach_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string strSelect = "select * from thamgia where   MaTacGia='" + cboTacGia.SelectedValue.ToString() + "' and MaSach='" + cboSach.SelectedValue.ToString() + "' ";
            DataSet ds_SV = new DataSet();
            SqlDataAdapter da_SV = new SqlDataAdapter(strSelect, conn.Con);
            //txtVaiTro.Text = cboTacGia.SelectedValue.ToString();
            //txtViTri.Text = cboSach.SelectedValue.ToString();
            da_SV.Fill(ds_SV);
            dataGridView1.DataSource = ds_SV.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_dataGV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtVaiTro.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập vai trò");
            }
            else if (txtViTri.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập Vị trí");
            }

            else
            {
                string strSQL = "select count(*) from dbo.ThamGia where MatacGia ='" + cboTacGia.SelectedValue.ToString() + "'and MaSach='" + cboSach.SelectedValue.ToString() + "' ";
                if (conn.checkForExistence(strSQL))
                {
                    MessageBox.Show("đã tồn tại mã tác giả và mã sách này ");
                    return;
                }
                // tao 1 dong them va datatable co ten diem
                DataRow newRow = conn.Dset.Tables["ThamGia"].NewRow();
                newRow["MaTacGia"] = cboTacGia.SelectedValue.ToString();
                newRow["MaSach"] = cboSach.SelectedValue.ToString();
                newRow["VaiTro"] = txtVaiTro.Text;
                newRow["ViTri"] = txtViTri.Text;


                conn.Dset.Tables["ThamGia"].Rows.Add(newRow);

                //cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                ada_KetQua.Update(conn.Dset, "ThamGia");
                MessageBox.Show("Thêm thành công");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtVaiTro.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập vai trò");
            }
            else if (txtViTri.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập Vị trí");
            }

            else
            {
                string strSQL = "select count(*) from dbo.ThamGia where MatacGia ='" + cboTacGia.SelectedValue.ToString() + "'and MaSach='" + cboSach.SelectedValue.ToString() + "' ";
                if (!conn.checkForExistence(strSQL))
                {
                    MessageBox.Show("chưa tồn tại mã tác giả và mã sách này ");
                    return;
                }
                // tao 1 dong them va datatable co ten diem
                object[] keyt = new object[2];
                keyt[0] = cboSach.SelectedValue.ToString();
                keyt[1] = cboTacGia.SelectedValue.ToString();
                DataRow dr = conn.Dset.Tables["ThamGia"].Rows.Find(keyt);
                if (dr != null)
                {

                    dr["MaTacGia"] = cboTacGia.SelectedValue.ToString();
                    dr["MaSach"] = cboSach.SelectedValue.ToString();
                    dr["VaiTro"] = txtVaiTro.Text;
                    dr["ViTri"] = txtViTri.Text;


                }
                else
                {
                    MessageBox.Show("Sửa Lỗi");
                }




                //cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                ada_KetQua.Update(conn.Dset, "ThamGia");
                MessageBox.Show("Sửa thành công");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
          

      
            
                string strSQL = "select count(*) from dbo.ThamGia where MatacGia ='" + cboTacGia.SelectedValue.ToString() + "'and MaSach='" + cboSach.SelectedValue.ToString() + "' ";
                if (!conn.checkForExistence(strSQL))
                {
                    MessageBox.Show("chưa tồn tại mã tác giả và mã sách này ");
                    return;
                }
                // tao 1 dong them va datatable co ten diem
                object[] keyt = new object[2];
                keyt[0] = cboSach.SelectedValue.ToString();
                keyt[1] = cboTacGia.SelectedValue.ToString();
                DataRow dr = conn.Dset.Tables["ThamGia"].Rows.Find(keyt);
                if (dr != null)
                {

                    dr.Delete();


                }
                else
                {
                    MessageBox.Show("Xóa Lỗi");
                }




                //cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                ada_KetQua.Update(conn.Dset, "ThamGia");
                MessageBox.Show("Xóa thành công");
            
        }

        private void txtViTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cboTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
