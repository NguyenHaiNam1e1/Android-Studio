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
    public partial class frmThemSach : Form
    {

        DBConnect conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        DataColumn[] primarykey = new DataColumn[1];
        DateTime d = DateTime.Now;
        public frmThemSach()
        {
            InitializeComponent();            
            load_cboNXB();
            txtCapNhat.Enabled = false;
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        }
          string tenMay, tenDB, tenUser, pass ;

          public frmThemSach(string a, string b, string c, string d)
        {
            InitializeComponent();
            tenMay = a;
            tenDB = b;
            tenUser = c;
            pass = d;
            conn = new DBConnect("QuanLyNhaSach_QL",tenMay, tenDB, tenUser, pass);
      

        }
        //public void load_datagv()
        //{
        //    string strSQL = "SELECT * FROM sach";
        //    DataTable dt = conn.getDataTable(strSQL, "sach");

        //    dataGridView1.DataSource = dt;
        //}
        private void frmThemSach1_Load(object sender, EventArgs e)
        {
            createTable_Diem();
            //load_datagv();
            load_cboTCD();
            txtCapNhat.Text = d.Month + "-" + d.Day + "-" + d.Year + "";
        }

        private void frmThemSach1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát ko ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string strMaS = "S";
            strMaS += dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00");
            strMaS += dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
            txtMa.Text = strMaS ;

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

            else
            {

                string tensach = txtTenSach.Text.Trim();
                string giaban = txtGiaBan.Text.Trim();
                string mota = txtMoTa.Text.Trim();
                string ma = txtMa.Text.Trim();
                string moi = txtMoi.Text.Trim();
                string ngaycapnhat = txtCapNhat.Text.Trim();
                string soluong = txtSoLuong.Text.Trim();
                string nhaxuatban = cboTenNSB.SelectedValue.ToString();
                string tenchude = cbotenChuDe.SelectedValue.ToString();
                byte[] b = ImageToByteArray(pictureBox1.Image);


                // tao 1 dong them va datatable co ten diem
                DataRow newRow = conn.Dset.Tables["Sach"].NewRow();
                newRow["MaSach"] = ma;
                newRow["TenSach"] = tensach;
                newRow["GiaBan"] = giaban;
                newRow["MoTa"] = mota;
                newRow["NgayCapNhat"] = ngaycapnhat;
                newRow["AnhBia"] = b;
                newRow["SoLuongTon"] = soluong;
                newRow["MaChuDe"] = tenchude;
                newRow["MaNXB"] = nhaxuatban;
                newRow["Moi"] = moi;


                conn.Dset.Tables["Sach"].Rows.Add(newRow);

                //cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                ada_KetQua.Update(conn.Dset, "Sach");
                MessageBox.Show("Thêm thành công");
                txtGiaBan.Text = "";
                txtMoi.Text = "";
                txtMoTa.Text = "";
                txtSoLuong.Text = "";
                pictureBox1.Image = null;
                txtTenSach.Text = "";
                txtTenSach.Focus();

                //frmSach s = new frmSach();
                //s.load_dataGV();
            }
        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        public void createTable_Diem()
        {
            //tao 1 database co ten lop de cap nhat du lieu
            string strSQL = "select * from Sach";
            ada_KetQua = conn.getDataAdapter(strSQL, "Sach");
            // tao khoa chinh cho bang lop cua datasset
            primarykey[0] = conn.Dset.Tables["Sach"].Columns["MaSach"];
            conn.Dset.Tables["Sach"].PrimaryKey = primarykey;
        }
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtGiaBan.Text = "";
            txtMoi.Text = "";
            txtMoTa.Text = "";
            txtSoLuong.Text = "";
            txtTenSach.Text = "";
            txtTenSach.Focus();
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


    }
}
