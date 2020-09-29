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
using DoAnQuanLySach.Report;
using DoAnQuanLySach.Forms;

namespace DoAnQuanLySach
{
    public partial class frmKhachHang : Form
    {
        DBConnect conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        DataColumn[] primarykey = new DataColumn[1];
        DateTime d = DateTime.Now;
        public frmKhachHang()
        {
            InitializeComponent();
            createTable_Diem();
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        }
         string tenMay, tenDB, tenUser, pass ;

          public frmKhachHang(string a, string b, string c, string d)
        {
            InitializeComponent();
            tenMay = a;
            tenDB = b;
            tenUser = c;
            pass = d;
            conn = new DBConnect("QuanLyNhaSach_QL",tenMay, tenDB, tenUser, pass);
      

        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load_dataGV2();
        }
        public void load_dataGV2()
        {
            string strSQL = "select * from khachhang";
            DataTable dt = conn.getDataTable(strSQL, "khachhang");

            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtEmail.Enabled = true;
            txtHoten.Enabled = true;     
            dateTimePicker1.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            radNam.Enabled = true;
            radNu.Enabled = true;
            radNam.Checked = true;

            DateTime dt = DateTime.Now;
            string strMaS = "S";
            strMaS += dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00");
            strMaS += dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
            txtMaKH.Text = strMaS;

          
            txtHoten.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();


        }

        private void btnLuu_Click(object sender, EventArgs e)
        {             
            if (btnThem.Enabled == true)
            {
                if (txtHoten.Text.Length == 0)
                    MessageBox.Show("Bạn chưa nhập họ tên!");

                else if (txtDienThoai.Text.Length == 0)
                    MessageBox.Show("Bạn chưa nhập điện thoại!");

                else if (txtEmail.Text.Length == 0)
                    MessageBox.Show("Bạn chưa nhập email!");

                else if (txtDiaChi.Text.Length == 0)
                    MessageBox.Show("Bạn chưa nhập địa chỉ!");

                else if (txtDienThoai.Text.Length > 10)
                    MessageBox.Show("Số điện thoại chỉ được nhập 10 số!");

                else
                {
                    int i = dataGridView1.RowCount;

                    // tao 1 dong them va datatable co ten diem
                    DataRow newRow = conn.Dset.Tables["khachHang"].NewRow();
                    newRow["MaKH"] = txtMaKH.Text.Trim();
                    newRow["HoTen"] = txtHoten.Text.Trim();
                    newRow["NgaySinh"] = dateTimePicker1.Text;
                    if (radNam.Checked == true)
                    {
                        newRow["GioiTinh"] = "Nam";
                    }
                    else
                        newRow["GioiTinh"] = "Nữ";

                   
                    try
                    {
                        newRow["DienThoai"] = txtDienThoai.Text;
                    }
                    catch
                    {
                        MessageBox.Show("Phải có số 0 ở đầu");
                        txtDienThoai.Clear();
                        txtDienThoai.Focus();
                        return;
                    }
                    newRow["Email"] = txtEmail.Text.Trim();
                    newRow["Diachi"] = txtDiaChi.Text;



                    conn.Dset.Tables["khachHang"].Rows.Add(newRow);

                    //cap nhat du lieu dataset xuong database 
                    SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                    ada_KetQua.Update(conn.Dset, "khachHang");
                    MessageBox.Show("Thêm thành công");
                    btnSua.Enabled = false;
                    btnThem.Enabled = true;
                    btnLuu.Enabled = false;
                    btnXoa.Enabled = false;
                    txtDiaChi.Clear();
                    txtDienThoai.Clear();
                    txtEmail.Clear();
                    txtHoten.Clear();
                    txtMaKH.Clear();
                    dateTimePicker1.Refresh();
                    txtMaKH.Clear();
                    txtDiaChi.Enabled = false;
                    txtDienThoai.Enabled = false;
                    txtEmail.Enabled = false;
                    txtHoten.Enabled = false;
                    radNam.Enabled = false;
                    radNu.Enabled = false;
                    dateTimePicker1.Enabled = false;
                }
            }
            else
            {
                if (txtHoten.Text.Length == 0)
                    MessageBox.Show("Bạn chưa nhập họ tên!");

                else if (txtDienThoai.Text.Length == 0)
                    MessageBox.Show("Bạn chưa nhập điện thoại!");

                else if (txtEmail.Text.Length == 0)
                    MessageBox.Show("Bạn chưa nhập email!");

                else if (txtDiaChi.Text.Length == 0)
                    MessageBox.Show("Bạn chưa nhập địa chỉ!");

                else if (txtDienThoai.Text.Length > 10)
                    MessageBox.Show("Số điện thoại chỉ được nhập 10 số!");

                else
                {

                    string hd = txtMaKH.Text;

                    DataRow dr = conn.Dset.Tables["KhachHang"].Rows.Find(hd);
                    if (dr != null)
                    {
                        dr["HoTen"] = txtHoten.Text.Trim();
                        dr["NgaySinh"] = dateTimePicker1.Text;
                        if (radNam.Checked == true)
                        {
                            dr["GioiTinh"] = "Nam";
                        }
                        else
                        {
                            dr["GioiTinh"] = "Nữ";
                        }
                        try
                        {
                            dr["DienThoai"] = txtDienThoai.Text;
                        }
                        catch
                        {
                            MessageBox.Show("Phải có số 0 ở đầu");                           
                            txtDienThoai.Clear();
                            txtDienThoai.Focus();
                            return;
                        }
                           

                        dr["Email"] = txtEmail.Text.Trim();
                        dr["Diachi"] = txtDiaChi.Text;
                    }

                    SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                    ada_KetQua.Update(conn.Dset, "KhachHang");
                    MessageBox.Show("Sửa thành công!");

                    btnSua.Enabled = false;
                    btnThem.Enabled = true;
                    btnLuu.Enabled = false;
                    btnXoa.Enabled = false;
                    txtDiaChi.Clear();
                    txtDienThoai.Clear();
                    txtEmail.Clear();
                    txtHoten.Clear();
                    txtMaKH.Clear();
                    dateTimePicker1.Refresh();
                    txtMaKH.Clear();
                    txtDiaChi.Enabled = false;
                    txtDienThoai.Enabled = false;
                    txtEmail.Enabled = false;
                    txtHoten.Enabled = false;
                    radNam.Enabled = false;
                    radNu.Enabled = false;
                    dateTimePicker1.Enabled = false;
                }
            }
        }
        public void createTable_Diem()
        {
            //tao 1 database co ten lop de cap nhat du lieu
            string strSQL = "select * from khachHang";
            ada_KetQua = conn.getDataAdapter(strSQL, "khachHang");
            // tao khoa chinh cho bang lop cua datasset
            primarykey[0] = conn.Dset.Tables["khachHang"].Columns["MaKH"];
            conn.Dset.Tables["khachHang"].PrimaryKey = primarykey;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            int numrow;
            numrow = e.RowIndex;
            txtMaKH.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtHoten.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            string str = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            if (str == "Nam")
            {
                radNam.Checked = true;
                radNu.Checked = false;
            }
            else if (str == "Nữ")
            {
                radNam.Checked = false;
                radNu.Checked = true;
            }
            else
            {
                radNam.Checked = false;
                radNu.Checked = false;
            }
            txtDienThoai.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();        
            txtEmail.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
        }

        private void txtHoten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = false;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string hd = txtMaKH.Text;
            string strSQL;

            strSQL = "SELECT COUNT(*) FROM KhachHang,DonHang WHERE KhachHang.MaKH=DonHang.MaKH AND KhachHang.MaKH ='" + hd + "' ";
            if (conn.checkForExistence(strSQL))
            {
                MessageBox.Show("Khách hàng này đã có đơn hàng!");
                return;
            }

            DataRow dr = conn.Dset.Tables["KhachHang"].Rows.Find(hd);
            if (dr != null)
            {
                dr.Delete();
            }

            SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
            ada_KetQua.Update(conn.Dset, "KhachHang");
            MessageBox.Show("Xóa thành công!");

            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtHoten.Clear();
            dateTimePicker1.Refresh();
            txtMaKH.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtEmail.Enabled = true;
            txtHoten.Enabled = true;
            dateTimePicker1.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmRptKhachHang k = new frmRptKhachHang();
            k.Show();
        }
    
    }
}
