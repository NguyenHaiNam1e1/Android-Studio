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
    public partial class frmNhaXuatBan : Form
    {
        DBConnect conn= new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        DataColumn[] primarykey = new DataColumn[1];
        public frmNhaXuatBan()
        {
            InitializeComponent();
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        }
          string tenMay, tenDB, tenUser, pass ;

          public frmNhaXuatBan(string a, string b, string c, string d)
        {
            InitializeComponent();
            tenMay = a;
            tenDB = b;
            tenUser = c;
            pass = d;
            conn = new DBConnect("QuanLyNhaSach_QL",tenMay, tenDB, tenUser, pass);
      

        }
        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {
            createTable_TG();
            load_dataGV();
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            txtMa.Enabled = false;
            txtTenNXB.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        //tao bang sach
        public void createTable_TG()
        {
            //tao 1 database co ten lop de cap nhat du lieu
            string strSQL = "select * from NhaXuatBan";
            ada_KetQua = conn.getDataAdapter(strSQL, "NhaXuatBan");
            // tao khoa chinh cho bang lop cua datasset
            primarykey[0] = conn.Dset.Tables["NhaXuatBan"].Columns["MaNXB"];
            conn.Dset.Tables["NhaXuatBan"].PrimaryKey = primarykey;
        }
        public void load_dataGV()
        {
            string strSQL = "select * from NhaXuatBan ";
            DataTable dt = conn.getDataTable(strSQL, "NhaXuatBan");

            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string strMaS = "S";
            strMaS += dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00");
            strMaS += dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
            txtMa.Text = strMaS;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            //txtMaNXB.Enabled = true;
            txtTenNXB.Enabled = true;
            txtTenNXB.Clear();
            //txtMaNXB.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            btnLuu.Enabled = true;
            txtTenNXB.Focus();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            txtMa.Text = row.Cells[0].Value.ToString();
            txtTenNXB.Text = row.Cells[1].Value.ToString();
            txtDiaChi.Text = row.Cells[2].Value.ToString();
            txtDienThoai.Text = row.Cells[3].Value.ToString();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (btnThem.Enabled == true)
            {



                if (txtTenNXB.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Tên NXB");
                }
                else if (txtDiaChi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Địa Chỉ");
                }
                else if (txtDienThoai.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Điện thoại");
                }
               
                else
                {

                    string tenTG = txtTenNXB.Text.Trim();
                    string diaChi = txtDiaChi.Text.Trim();                 
                    string dienthoai = txtDienThoai.Text.Trim();
                    string ma = txtMa.Text.Trim();

                    // tao 1 dong them va datatable co ten diem
                    DataRow newRow = conn.Dset.Tables["NhaXuatBan"].NewRow();
                    newRow["MaNXB"] = ma;
                    newRow["TenNXB"] = tenTG;
                    newRow["DiaChi"] = diaChi;                 
                    newRow["DienThoai"] = dienthoai;


                    conn.Dset.Tables["NhaXuatBan"].Rows.Add(newRow);

                    //cap nhat du lieu dataset xuong database 
                    SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                    ada_KetQua.Update(conn.Dset, "NhaXuatBan");
                    MessageBox.Show("Thêm thành công");
                    btnThem.Enabled = true;
                    //btnXoa.Enabled = true;
                    //btnSua.Enabled = true;

                    txtTenNXB.Clear();
                    txtDiaChi.Clear();
                    txtDienThoai.Clear();


                    btnLuu.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtDienThoai.Enabled = false;
                    txtTenNXB.Enabled = false;
                    txtMa.Clear();

                }
            
                //btnThem.Enabled = true;
                ////btnXoa.Enabled = true;
                ////btnSua.Enabled = true;

                //txtTenNXB.Clear();
                //txtDiaChi.Clear();
                //txtDienThoai.Clear();
             

                //btnLuu.Enabled = false;
                //txtDiaChi.Enabled = false;
                //txtDienThoai.Enabled = false;
                //txtTenNXB.Enabled = false;
               

            }
            else
            {


                if (txtTenNXB.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Tên NXB");
                }
                else if (txtDiaChi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Địa Chỉ");
                }
               
                else if (txtDienThoai.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa nhập Điện thoại");
                }
                else
                {
                    string matg = txtMa.Text.Trim();
                    string tenTG = txtTenNXB.Text.Trim();
                    string diaChi = txtDiaChi.Text.Trim();
                    string dienthoai = txtDienThoai.Text.Trim();

                    //// tao 1 dong them va datatable co ten diem
                    //DataRow newRow = conn.Dset.Tables["TacGia"].NewRow();
                    //newRow["MaTacGia"] = "0";
                    //newRow["TenTacGia"] = tenTG;
                    //newRow["DiaChi"] = diaChi;
                    //newRow["TieuSu"] = tieuSu;
                    //newRow["DienThoai"] = dienthoai;


                    //conn.Dset.Tables["TacGia"].Rows.Add(newRow);
                    // tao 1 dong them va datatable co ten diem
                    DataRow dr = conn.Dset.Tables["NhaXuatBan"].Rows.Find(matg);
                    if (dr != null)
                    {

                        dr["TenNXB"] = tenTG;
                        dr["DiaChi"] = diaChi;                     
                        dr["DienThoai"] = dienthoai;


                    }
                    else
                    {
                        MessageBox.Show("Sửa Lỗi");
                    }

                    //cap nhat du lieu dataset xuong database 
                    SqlCommandBuilder buider = new SqlCommandBuilder(ada_KetQua);
                    ada_KetQua.Update(conn.Dset, "NhaXuatBan");
                    MessageBox.Show("Sửa thành công");
             
                    btnThem.Enabled = true;
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;

                    txtTenNXB.Clear();
                    txtDiaChi.Clear();
                    txtDienThoai.Clear();
               

                    btnLuu.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtDienThoai.Enabled = false;
                    txtTenNXB.Enabled = false;
                    txtMa.Clear();
              
                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            //txtMaNXB.Enabled = true;
            txtTenNXB.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
                string matg = txtMa.Text.Trim();
                string tenTG = txtTenNXB.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string dienthoai = txtDienThoai.Text.Trim();

                //// tao 1 dong them va datatable co ten diem
                //DataRow newRow = conn.Dset.Tables["TacGia"].NewRow();
                //newRow["MaTacGia"] = "0";
                //newRow["TenTacGia"] = tenTG;
                //newRow["DiaChi"] = diaChi;
                //newRow["TieuSu"] = tieuSu;
                //newRow["DienThoai"] = dienthoai;


                //conn.Dset.Tables["TacGia"].Rows.Add(newRow);
                // tao 1 dong them va datatable co ten diem
                DataRow dr = conn.Dset.Tables["NhaXuatBan"].Rows.Find(matg);
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
                ada_KetQua.Update(conn.Dset, "NhaXuatBan");
                MessageBox.Show("Xóa thành công");


                txtTenNXB.Clear();
                txtDiaChi.Clear();
                txtDienThoai.Clear();


                btnLuu.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                txtTenNXB.Enabled = false;
                txtMa.Clear();
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmRptNXB n = new frmRptNXB();
            n.Show();
        }

        }

    }

