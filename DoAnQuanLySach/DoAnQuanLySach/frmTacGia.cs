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
    public partial class frmTacGia : Form
    {
        DBConnect conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        DataColumn[] primarykey = new DataColumn[1];
       
        public frmTacGia()
        {
            InitializeComponent();
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            txtTenTG.Enabled = false;
            txtTieuSu.Enabled = false;
            btnLuuTG.Enabled = false;
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        }
           string tenMay, tenDB, tenUser, pass ;
         
        public frmTacGia(string a, string b, string c, string d)
        {
            InitializeComponent();
            tenMay = a;
            tenDB = b;
            tenUser = c;
            pass = d;
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
      

        }

     

     

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmtacGia_Load(object sender, EventArgs e)
        {
            createTable_TG();
            load_cboTG();
            load_cboTG1();
            load_cboSach();
            load_dataGV();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = getDSTimKiem();
            if (dt.Rows.Count > 0)
            {
                txtMa.Text = dt.Rows[0][0].ToString();
                txtTenTG.Text = dt.Rows[0][1].ToString();
                txtDiaChi.Text = dt.Rows[0][2].ToString();
                txtTieuSu.Text = dt.Rows[0][3].ToString();
                txtDienThoai.Text = dt.Rows[0][4].ToString();
            }

        }
        public DataTable getDSTimKiem()
        {
            string sqlTKS = "select * from tacGia where MaTacGia ='" + comboBox1.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = conn.getTable(sqlTKS);
            return dt;
        }
        public void load_cboTG()
        {
            string strSQL = "select * from TacGia";
            DataTable dt = conn.getDataTable(strSQL, "TacGia");

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenTacGia";
            comboBox1.ValueMember = "MaTacGia";
        }
        //tao bang sach
        public void createTable_TG()
        {
            //tao 1 database co ten lop de cap nhat du lieu
            string strSQL = "select * from TacGia";
            ada_KetQua = conn.getDataAdapter(strSQL, "TacGia");
            // tao khoa chinh cho bang lop cua datasset
            primarykey[0] = conn.Dset.Tables["TacGia"].Columns["MaTacGia"];
            conn.Dset.Tables["TacGia"].PrimaryKey = primarykey;
        }

        private void btnThemTG_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string strMaS = "S";
            strMaS += dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00");
            strMaS += dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
            txtMa.Text = strMaS;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtTenTG.Enabled = true;
            txtTieuSu.Enabled = true;
            //btnThemTG.Enabled = false;
            btnLuuTG.Enabled = true;
            btnXoaTG.Enabled = false;
            btnSuaTG.Enabled = false;
            txtTenTG.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtTieuSu.Clear();
            btnTim.Enabled = false;
           

        }

        private void btnLuuTG_Click(object sender, EventArgs e)
        {
            if (btnThemTG.Enabled == true)
            {

               
               
                if (txtTenTG.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Tên TG");
                }
                else if (txtDiaChi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Địa Chỉ");
                }
                else if (txtTieuSu.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Tiểu Sử");
                }
                else if (txtDienThoai.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Điện thoại");
                }
                else if (txtDienThoai.Text.Length > 10)
                    MessageBox.Show("Số điện thoại chỉ được nhập 10 số!");

                else
                {

                    string tenTG = txtTenTG.Text.Trim();
                    string diaChi = txtDiaChi.Text.Trim();
                    string tieuSu = txtTieuSu.Text.Trim();
                    string dienthoai = txtDienThoai.Text.Trim();
                    string ma = txtMa.Text.Trim();

                    // tao 1 dong them va datatable co ten diem
                    DataRow newRow = conn.Dset.Tables["TacGia"].NewRow();
                    newRow["MaTacGia"] = ma;
                    newRow["TenTacGia"] = tenTG;
                    newRow["DiaChi"] = diaChi;
                    newRow["TieuSu"] = tieuSu;


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


                    conn.Dset.Tables["TacGia"].Rows.Add(newRow);

                    //cap nhat du lieu dataset xuong database 
                    SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                    ada_KetQua.Update(conn.Dset, "TacGia");
                    MessageBox.Show("Thêm thành công");

                }
                btnTim.Enabled = true;
                btnThemTG.Enabled = true;
                btnXoaTG.Enabled = true;
                btnSuaTG.Enabled = true;

                txtTenTG.Clear();
                txtDiaChi.Clear();
                txtDienThoai.Clear();
                txtTieuSu.Clear();

                btnLuuTG.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                txtTenTG.Enabled = false;
                txtTieuSu.Enabled = false;

            }
            else
            {
           

                if (txtTenTG.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Tên TG");
                }
                else if (txtDiaChi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Địa Chỉ");
                }
                else if (txtTieuSu.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Tiểu Sử");
                }
                else if (txtDienThoai.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Điện thoại");
                }
                else if (txtDienThoai.Text.Length > 10)
                    MessageBox.Show("Số điện thoại chỉ được nhập 10 số!");

                else
                {

                    string tenTG = txtTenTG.Text.Trim();
                    string diaChi = txtDiaChi.Text.Trim();
                    string tieuSu = txtTieuSu.Text.Trim();
                    string dienthoai = txtDienThoai.Text.Trim();
                    string matg = comboBox1.SelectedValue.ToString();

                    //// tao 1 dong them va datatable co ten diem
                    //DataRow newRow = conn.Dset.Tables["TacGia"].NewRow();
                    //newRow["MaTacGia"] = "0";
                    //newRow["TenTacGia"] = tenTG;
                    //newRow["DiaChi"] = diaChi;
                    //newRow["TieuSu"] = tieuSu;
                    //newRow["DienThoai"] = dienthoai;


                    //conn.Dset.Tables["TacGia"].Rows.Add(newRow);
                    // tao 1 dong them va datatable co ten diem
                    DataRow dr = conn.Dset.Tables["TacGia"].Rows.Find(matg);
                    if (dr != null)
                    {

                        dr["TenTacGia"] = tenTG;
                        dr["DiaChi"] = diaChi;
                        dr["TieuSu"] = tieuSu;

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


                    }
                    else
                    {
                        MessageBox.Show("Sửa Lỗi");
                    }

                    //cap nhat du lieu dataset xuong database 
                    SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                    ada_KetQua.Update(conn.Dset, "TacGia");
                    MessageBox.Show("Sửa thành công");
                    btnTim.Enabled = true;
                    btnThemTG.Enabled = true;
                    btnXoaTG.Enabled = true;
                    btnSuaTG.Enabled = true;

                    txtTenTG.Clear();
                    txtDiaChi.Clear();
                    txtDienThoai.Clear();
                    txtTieuSu.Clear();

                    btnLuuTG.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtDienThoai.Enabled = false;
                    txtTenTG.Enabled = false;
                    txtTieuSu.Enabled = false;
                }
            }
        }

        private void btnSuaTG_Click(object sender, EventArgs e)
        {
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtTenTG.Enabled = true;
            txtTieuSu.Enabled = true;
            btnThemTG.Enabled = false;
            btnLuuTG.Enabled = true;
            btnXoaTG.Enabled = false;
            //btnSuaTG.Enabled = false;      
            btnTim.Enabled = false;
        }

        private void btnXoaTG_Click(object sender, EventArgs e)
        {
            string tenTG = txtTenTG.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string tieuSu = txtTieuSu.Text.Trim();
            string dienthoai = txtDienThoai.Text.Trim();
            string matg = comboBox1.SelectedValue.ToString();
            string strSQL;
        
            strSQL = "select count(*) from dbo.tacGia where MatacGia ='" + matg + "' ";
            if (!conn.checkForExistence(strSQL))
            {
                MessageBox.Show("chưa tồn tại mã tác giả  này ");
                return;
            }

            // tao 1 dong them va datatable co ten diem
            DataRow dr = conn.Dset.Tables["TacGia"].Rows.Find(matg);
            if (dr != null)
            {
                dr.Delete();
            }
            else
            {
                MessageBox.Show("xóa Lỗi");
            }

            //cap nhat du lieu dataset xuong database 
            SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
            ada_KetQua.Update(conn.Dset, "TacGia");
            MessageBox.Show("Xóa thành công");
            txtTenTG.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtTieuSu.Clear();
        }

        
        
        public void load_cboTG1()
        {
            string strSQL = "select * from TacGia";
            DataTable dt = conn.getDataTable(strSQL, "TacGia");

            //cboTacGia.DataSource = dt;
            //cboTacGia.DisplayMember = "TenTacGia";
            //cboTacGia.ValueMember = "MaTacGia";
        }
        public void load_cboSach()
        {
            string strSQL = "select * from Sach";
            DataTable dt = conn.getDataTable(strSQL, "Sach");

            //cbosach.DataSource = dt;
            //cbosach.DisplayMember = "TenSach";
            //cbosach.ValueMember = "MaSach";
        }

        private void cboTacGia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            
            //string strSQL = "select TenSach from Sach,tacgia,thamgia where sach.MaSach=thamgia.MaSach and tacgia.MaTacGia = thamgia.MaTacGia and TacGia.MatacGia='"+cboTacGia.SelectedValue.ToString()+"' ";
            //DataTable dt = conn.getDataTable(strSQL, "Sach,tacgia,thamgia");

            //cbosach.DataSource = dt;
            //cbosach.DisplayMember = "TenSach";
            //cbosach.ValueMember = "MaSach";
            
        }

        //private void cbosach_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    string strSelect = "select * from thamgia where   MaTacGia='" + cboTacGia.SelectedValue.ToString() + "' and masach='"+cbosach.SelectedValue.ToString()+"'";
        //    DataSet ds_SV = new DataSet();
        //    SqlDataAdapter da_SV = new SqlDataAdapter(strSelect, conn.Con);
        //    da_SV.Fill(ds_SV);
        //    dataGridView1.DataSource = ds_SV.Tables[0];
        //}
        public void load_dataGV()
        {
            string strSQL = "select * from TacGia ";
            DataTable dt = conn.getDataTable(strSQL, "TacGia");

            dataGridView1.DataSource = dt;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmRptTacGia t = new frmRptTacGia();
            t.Show();
        }
    }
}