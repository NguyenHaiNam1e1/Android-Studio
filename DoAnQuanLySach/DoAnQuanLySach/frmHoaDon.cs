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
using MyLibrary1;
using DoAnQuanLySach.GiaoDien;

namespace DoAnQuanLySach
{
    public partial class frmHoaDon : Form
    {
        public delegate void SendMessage(string Message);
        public SendMessage Sender;
        string a;
        DBConnect conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        SqlDataAdapter ada_K = new SqlDataAdapter();
        DataColumn[] primarykey1 = new DataColumn[2];
       
        DataColumn[] primarykey = new DataColumn[1];
       
        public frmHoaDon()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);
            createTable_HoaDon();
            createTable_CTHoaDon();
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        }
         string tenMay, tenDB, tenUser, pass ;

          public frmHoaDon(string a, string b, string c, string d)
        {
            InitializeComponent();
            tenMay = a;
            tenDB = b;
            tenUser = c;
            pass = d;
            conn = new DBConnect("QuanLyNhaSach_QL",tenMay, tenDB, tenUser, pass);
      

        }

        private void GetMessage(string Message)
        {
            a = Message;
        }

        public void load_cboHoaDon()
        {
            string strSQL = "SELECT * FROM DonHang";
            DataTable dt = conn.getDataTable(strSQL, "DonHang");

            cboMaHD.DataSource = dt;
            cboMaHD.DisplayMember = "MaDonHang";
            cboMaHD.ValueMember = "MaDonHang";
        }

        public void load_cboHoaDon02()
        {
            //string strSQL = "SELECT * FROM DonHang";
            //DataTable dt = conn.getDataTable(strSQL, "DonHang");

            //cboMaHD02.DataSource = dt;
            //cboMaHD02.DisplayMember = "MaDonHang";
            //cboMaHD02.ValueMember = "MaDonHang";
        }

        public void load_cboMaSach()
        {
            string strSQL = "SELECT * FROM Sach";
            DataTable dt = conn.getDataTable(strSQL, "Sach");

            cboMaSach.DataSource = dt;
            cboMaSach.DisplayMember = "MaSach";
            cboMaSach.ValueMember = "MaSach";
        }

        public void load_cboMaKH()
        {
            string strSQL = "SELECT * FROM KhachHang";
            DataTable dt = conn.getDataTable(strSQL, "KhachHang");

            cboMaKH.DataSource = dt;
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";
        }
       
        public void load_dataGVHoaDon02()
        {
            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-UIRG88N\SQLEXPRESS;Initial Catalog=QuanLyNhaSach_QL;User ID=sa;Password=sql2012");
            SqlCommand cmd = new SqlCommand("SELECT * FROM DonHang", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            //Tải dữ liệu lên dataGridView
            dataGridViewCTHD.DataSource = dt;
        }

        public void load_dataGVCTHD()
        {
            string strSQL = "SELECT * FROM ChiTietDonHang";
            DataTable dt = conn.getDataTable(strSQL, "ChiTietDonHang");

            dataGridViewCTHD.DataSource = dt;
        }

        public void load_dataGVCTHD02()
        {
            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-UIRG88N\SQLEXPRESS;Initial Catalog=QuanLyNhaSach_QL;User ID=sa;Password=sql2012");
            SqlCommand cmd = new SqlCommand("SELECT * FROM ChiTietDonHang", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            //Tải dữ liệu lên dataGridView
            dataGridViewCTHD.DataSource = dt;
        }

        public void createTable_HoaDon()
        {
            //tao 1 database co ten lop de cap nhat du lieu
            string strSQL = "select * from DonHang";
            ada_KetQua = conn.getDataAdapter(strSQL, "DonHang");
            // tao khoa chinh cho bang lop cua datasset
            primarykey[0] = conn.Dset.Tables["DonHang"].Columns["MaDonHang"];
            conn.Dset.Tables["DonHang"].PrimaryKey = primarykey;
        }
          public void createTable_CTHoaDon()
        {
            //tao 1 database co ten lop de cap nhat du lieu
            string strSQL = "select * from ChiTietDonHang";
            ada_K = conn.getDataAdapter(strSQL, "ChiTietDonHang");
            // tao khoa chinh cho bang lop cua datasset
            primarykey1[0] = conn.Dset.Tables["ChiTietDonHang"].Columns["MaDonHang"];
           primarykey1[1] = conn.Dset.Tables["ChiTietDonHang"].Columns["MaSach"];
            conn.Dset.Tables["ChiTietDonHang"].PrimaryKey = primarykey1;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            load_cboHoaDon();
            load_cboMaSach();
            load_cboMaKH();
            load_dataGVCTHD();
            load_cboHoaDon02();
            this.cboMaKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         
        }

        private void btnThem01_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Length == 0)
            {
                MessageBox.Show("chưa nhập mã");
            }
            else
            {
                string makh = cboMaKH.SelectedValue.ToString();
                string ngaylap = txtNgayLap.Text.Trim();
                string ma = txtMa.Text.Trim();

                DataRow newRow = conn.Dset.Tables["DonHang"].NewRow();
                newRow["MaDonHang"] = ma;
                newRow["NgayLapHoaDon"] = ngaylap;
                newRow["MaKH"] = makh;
                if (a == "baolong")
                {
                    newRow["MaNV"] = "NV0002";
                }
                if (a == "anhkhoa")
                {
                    newRow["MaNV"] = "NV0001";
                }
                if (a == "ngocbich")
                {
                    newRow["MaNV"] = "NV0003";
                }

                conn.Dset.Tables["DonHang"].Rows.Add(newRow);

                //cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                ada_KetQua.Update(conn.Dset, "DonHang");

                MessageBox.Show("Thêm thành công!");
                btnLuu01.Enabled = false;
                btnTao01.Enabled = true;
                txtMa.Clear();
            }
        }   

        private void dataGridViewCTHD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            cboMaHD.Enabled = true;
            cboMaSach.Enabled = false;
            txtSoLuong.Enabled = true;
            btnTao.Enabled = true;

            int numrow;
            numrow = e.RowIndex;
            cboMaHD.Text = dataGridViewCTHD.Rows[numrow].Cells[0].Value.ToString();
            cboMaSach.Text = dataGridViewCTHD.Rows[numrow].Cells[1].Value.ToString();
            txtSoLuong.Text = dataGridViewCTHD.Rows[numrow].Cells[2].Value.ToString();
            txtDonGia.Text = dataGridViewCTHD.Rows[numrow].Cells[3].Value.ToString();
            txtThanhTien.Text = dataGridViewCTHD.Rows[numrow].Cells[4].Value.ToString();
        }

        private void btnSua01_Click(object sender, EventArgs e)
        {
            string kh = cboMaKH.SelectedValue.ToString();
            string hd = txtMa.Text.Trim();

            DataRow dr = conn.Dset.Tables["DonHang"].Rows.Find(hd);
            if (dr != null)
            {
                dr["MaKH"] = kh;
            }

            SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
            ada_KetQua.Update(conn.Dset, "DonHang");
            MessageBox.Show("Sửa thành công!");
        }

        private void btnXoa01_Click(object sender, EventArgs e)
        {
            string hd = txtMa.Text.Trim();
            string strSQL;

            strSQL = "SELECT COUNT(*) FROM DonHang WHERE MaDonHang ='" + hd + "' ";
            if (!conn.checkForExistence(strSQL))
            {
                MessageBox.Show("Chưa tồn tại mã này!");
                return;
            }

            DataRow dr = conn.Dset.Tables["DonHang"].Rows.Find(hd);
            if (dr != null)
            {
                dr.Delete();
            }

            SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
            ada_KetQua.Update(conn.Dset, "DonHang");
            MessageBox.Show("Xóa thành công!");
        }

        private void btnTao01_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string strMaS = "HD";
            strMaS += dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00");
            strMaS += dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
            txtMa.Text = strMaS;
     
            btnLuu01.Enabled = true;
            btnTao01.Enabled = false;
            cboMaKH.Enabled = true;
            txtNgayLap.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập Số lượng");
            }
            else
            {

                string MaHD = cboMaHD.SelectedValue.ToString();
                string MaSach = cboMaSach.SelectedValue.ToString();
                string sl = txtSoLuong.Text.Trim();

                  string strSQL = "select count(*) from dbo.ChiTietDonHang where MaDonHang ='" + MaHD + "' And MaSach ='" + MaSach + "'";
                  if (conn.checkForExistence(strSQL))
                  {
                      MessageBox.Show("Đã tồn tai mã Hóa Đơn Và Mã Sách Này");
                      return;
                  }

                // tao 1 dong them va datatable co ten diem
                DataRow newRow = conn.Dset.Tables["ChiTietDonHang"].NewRow();
                newRow["MaDonHang"] = MaHD;
                newRow["MaSach"] = MaSach;
                newRow["SoLuong"] = sl;
            
                conn.Dset.Tables["ChiTietDonHang"].Rows.Add(newRow);

                //cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_K);
                ada_K.Update(conn.Dset, "ChiTietDonHang");
                MessageBox.Show("Thêm thành công");

                string strSQL01 = "UPDATE ChiTietDonHang SET GiaTien=GiaBan FROM Sach WHERE ChiTietDonHang.MaSach=Sach.MaSach AND MaDonHang='" + MaHD + "' AND ChiTietDonHang.MaSach=" + MaSach + "";
                conn.updeteToDB(strSQL01);

                string strSQL02 = "UPDATE ChiTietDonHang SET ThanhTien=SoLuong*GiaTien WHERE ChiTietDonHang.MaSach=MaSach AND MaDonHang='" + MaHD + "' AND ChiTietDonHang.MaSach=" + MaSach + "";
                conn.updeteToDB(strSQL02);

                string strSQL03 = "UPDATE DonHang SET TongTien=(SELECT SUM(ThanhTien) FROM ChiTietDonHang WHERE MaDonHang='" + MaHD + "') WHERE MaDonHang='" + MaHD + "'";
                conn.updeteToDB(strSQL03);

            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            cboMaHD.Enabled = true;
            cboMaSach.Enabled = true;
            txtSoLuong.Enabled = true;
            btnTao.Enabled = false;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập Số lượng");
            }
            else
            {

                string MaHD = cboMaHD.SelectedValue.ToString();
                string MaSach = cboMaSach.Text.Trim();
                string sl = txtSoLuong.Text.Trim();
              


                // tao 1 dong them va datatable co ten diem
                DataRow newRow = conn.Dset.Tables["ChiTietDonHang"].NewRow();
                newRow["MaDonHang"] = MaHD;
                newRow["MaSach"] = MaSach;
                newRow["SoLuong"] = sl;


                object[] keyt = new object[2];
                keyt[0] = MaHD;
                keyt[1] = MaSach;

                DataRow dr = conn.Dset.Tables["ChiTietDonHang"].Rows.Find(keyt);
                if (dr != null)
                {

                    dr.Delete();

                }
                else
                {
                    MessageBox.Show("Xóa Lỗi");
                }




                //cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_K);
                ada_K.Update(conn.Dset, "ChiTietDonHang");
                MessageBox.Show("Xóa thành công");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa nhập Số lượng");
            }
            else
            {

                string MaHD = cboMaHD.SelectedValue.ToString();
                string MaSach = cboMaSach.Text.Trim();
                string sl = txtSoLuong.Text.Trim();
                string dg = txtDonGia.Text.Trim();
                string tt = txtThanhTien.Text.Trim();




                object[] keyt = new object[2];
                keyt[0] = MaHD;
                keyt[1] = MaSach;

                DataRow dr = conn.Dset.Tables["ChiTietDonHang"].Rows.Find(keyt);
                if (dr != null)
                {

                    dr["MaDonHang"] = MaHD;
                    dr["MaSach"] = MaSach;
                    dr["SoLuong"] = sl;
                

                }
                else
                {
                    MessageBox.Show("Sửa Lỗi");
                }




                //cap nhat du lieu dataset xuong database 
                SqlCommandBuilder buider = new SqlCommandBuilder(ada_K);
                ada_K.Update(conn.Dset, "ChiTietDonHang");
                MessageBox.Show("Sửa thành công");
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
   
    }
}
