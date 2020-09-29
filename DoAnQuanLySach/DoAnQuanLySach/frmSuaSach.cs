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
using System.IO;

namespace DoAnQuanLySach
{
    public partial class frmSuaSach : Form
    {
        DBConnect conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        DataColumn[] primarykey = new DataColumn[1];
        public frmSuaSach()
        {
            InitializeComponent();
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        }
         string tenMay, tenDB, tenUser, pass ;
         
        public frmSuaSach(string a, string b, string c, string d)
        {
            InitializeComponent();
            tenMay = a;
            tenDB = b;
            tenUser = c;
            pass = d;
            conn = new DBConnect("QuanLyNhaSach_QL",tenMay, tenDB, tenUser, pass);
      

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //MemoryStream m = new MemoryStream(emp);
            DataTable dt = new DataTable();
            dt = getDSTimKiem();
            if (dt.Rows.Count > 0)
            {
                txtMa.Text = dt.Rows[0][0].ToString();
                txtTenSach.Text = dt.Rows[0][1].ToString();
                txtGiaBan.Text = dt.Rows[0][2].ToString();
                txtMoTa.Text = dt.Rows[0][3].ToString();
                txtCapNhat.Text = dt.Rows[0][4].ToString();
                byte[] b = (byte[])dt.Rows[0][5];
                pictureBox1.Image = ToByteArrayImage(b);
                cbotenChuDe.Text = dt.Rows[0][7].ToString();
                txtSoLuong.Text = dt.Rows[0][6].ToString();
                cboTenNSB.Text = dt.Rows[0][8].ToString();
                txtMoi.Text = dt.Rows[0][9].ToString();


            }
        }
        public DataTable getDSTimKiem()
        {
            string sqlTKS = "select * from Sach where MaSach ='" + cboMaSach.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = conn.getTable(sqlTKS);
            return dt;
        }
        public void load_cboTenSach()
        {
            string strSQL = "select * from Sach";
            DataTable dt = conn.getDataTable(strSQL, "Sach");

            cboMaSach.DataSource = dt;
            cboMaSach.DisplayMember = "TenSach";
            cboMaSach.ValueMember = "MaSach";
        }
        //chọn ảnh
        private void BtnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }
        //==============================
        //chuyển ảnh thành giá trị byte
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        //==============================
        //chuyển byte về ảnh
        Image ToByteArrayImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);

            return Image.FromStream(m);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BtnAnh.Enabled = true;
            btnCapNhat.Enabled = true;
            btnCapNhat.Enabled = true;
            txtTenSach.Enabled = true;
            txtGiaBan.Enabled = true;
            txtMoi.Enabled = true;
            txtMoTa.Enabled = true;
            txtSoLuong.Enabled = true;
            btnTimKiem.Enabled = false;
            btnThoat.Enabled = false;
            btnSua.Enabled = false;
            cbotenChuDe.Enabled = true;
            cboTenNSB.Enabled = true;
         
            this.cbotenChuDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenNSB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        //===========================
        //load cbo
        public void load_cboNXB()
        {
            string strSQL = "select * from NhaXuatBan";
            DataTable dt = conn.getDataTable(strSQL, "NhaXuatBan");

            cboTenNSB.DataSource = dt;
            cboTenNSB.DisplayMember = "TenNXB";
            cboTenNSB.ValueMember = "MaNXB";
        }
        public void load_cboTCD()
        {
            string strSQL = "select * from ChuDe";
            DataTable dt = conn.getDataTable(strSQL, "ChuDe");

            cbotenChuDe.DataSource = dt;
            cbotenChuDe.DisplayMember = "TenChuDe";
            cbotenChuDe.ValueMember = "MaChuDe";
        }
        //tao bang sach
        public void createTable_Diem()
        {
            //tao 1 database co ten lop de cap nhat du lieu
            string strSQL = "select * from Sach";
            ada_KetQua = conn.getDataAdapter(strSQL, "Sach");
            // tao khoa chinh cho bang lop cua datasset
            primarykey[0] = conn.Dset.Tables["Sach"].Columns["MaSach"];
            conn.Dset.Tables["Sach"].PrimaryKey = primarykey;
        }
        private void frmSuaSach_Load(object sender, EventArgs e)
        {
            createTable_Diem();
            load_cboTenSach();
            load_cboNXB();
            load_cboTCD();
        }

        private void frmSuaSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát ko ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (txtTenSach.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập Tên Sách");
            }
            else if (txtGiaBan.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập Giá Bán");
            }
            else if (txtMoTa.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập Mô Tả");
            }
            else if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập số lượng");
            }
            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("Bạn Chưa Chọn hình ảnh");
            }
            else if (txtMoi.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập mới");
            }

            else
            {
                string masach = cboMaSach.SelectedValue.ToString();
                string tensach = txtTenSach.Text.Trim();
                string giaban = txtGiaBan.Text.Trim();
                string mota = txtMoTa.Text.Trim();
                string moi = txtMoi.Text.Trim();
                string ngaycapnhat = txtCapNhat.Text.Trim();
                string soluong = txtSoLuong.Text.Trim();
                string nhaxuatban = cboTenNSB.SelectedValue.ToString();
                string tenchude = cbotenChuDe.SelectedValue.ToString();
                byte[] b = ImageToByteArray(pictureBox1.Image);

                // tao 1 dong them va datatable co ten diem
                DataRow dr = conn.Dset.Tables["Sach"].Rows.Find(masach);
                if (dr != null)
                {
                   
                    dr["TenSach"] = tensach;
                    dr["GiaBan"] = giaban;
                    dr["MoTa"] = mota;
                    //dr["NgayCapNhat"] = ngaycapnhat;
                    dr["AnhBia"] = b;
                    dr["SoLuongTon"] = soluong;
                    //dr["MaChuDe"] = tenchude;
                    //dr["MaNXB"] = nhaxuatban;
                    dr["Moi"] = moi;

                }
                else
                {
                    MessageBox.Show("Sửa Lỗi");
                }




                ////cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                ada_KetQua.Update(conn.Dset, "Sach");
                MessageBox.Show("Sửa Thành công");
                //cboMaSach.Items.Clear();
                //load_cboTenSach();
                btnCapNhat.Enabled = false;
                txtTenSach.Enabled = false;
                txtGiaBan.Enabled = false;
                txtMoi.Enabled = false;
                txtMoTa.Enabled = false;
                txtSoLuong.Enabled = false;
                txtGiaBan.Text = "";
                txtMoi.Text = "";
                txtMoTa.Text = "";
                txtSoLuong.Text = "";
                txtTenSach.Text = "";
                txtTenSach.Focus();
                txtCapNhat.Text = " ";
                pictureBox1.Image = null;
                btnTimKiem.Enabled = true;
                btnThoat.Enabled = true;
                BtnAnh.Enabled = false;
                btnSua.Enabled = true;
                cboMaSach.Enabled = true;
                cboTenNSB.Enabled = true;
                txtMa.Clear();
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string masach = cboMaSach.SelectedValue.ToString();
            string strSQL04 = "SELECT COUNT(*) FROM Sach, Thamgia WHERE sach.masach = thamgia.masach AND sach.MaSach= '" + masach + "'";
            if (conn.checkForExistence(strSQL04))
            {
                MessageBox.Show("Sách này đã tham gia!");
                return;
            }

            DataRow dr = conn.Dset.Tables["Sach"].Rows.Find(masach);

            if (dr != null)
            {
                dr.Delete();
            }    
      
            ////cap nhat du lieu dataset xuong database 
            SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
            ada_KetQua.Update(conn.Dset, "Sach");
            MessageBox.Show("Xóa thành công");
        }
    }
}


      

