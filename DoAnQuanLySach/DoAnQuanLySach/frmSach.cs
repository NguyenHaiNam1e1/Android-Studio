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
using System.IO;

namespace DoAnQuanLySach
{
    public partial class frmSach : Form
    {
        DBConnect conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        SqlDataAdapter ada_KetQua = new SqlDataAdapter();
        DataColumn[] primarykey = new DataColumn[1];
        public frmSach(string a, string b, string c, string d)
        {
            InitializeComponent();
            tenMay = a;
            tenDB = b;
            tenUser = c;
            pass = d;
            conn = new DBConnect("QuanLyNhaSach_QL", tenMay, tenDB, tenUser, pass);


        }

        public frmSach()
        {
            InitializeComponent();
            
        
            conn = new DBConnect("QuanLyNhaSach_QL", DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.sever, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.CSDL, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.User, DoAnQuanLySach.GiaoDien.FormDangNhap.luuThongTin.Pass);
        }
         string tenMay, tenDB, tenUser, pass ;


    

     

        private void frmSach_Load(object sender, EventArgs e)
        {
            load_cboTenSach();
            load_cboTCD();
            load_dataGV();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSach ts = new frmThemSach();
            ts.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmSuaSach ts = new frmSuaSach();
            ts.Show();
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            //MemoryStream m = new MemoryStream(emp);
            DataTable dt = new DataTable();
            dt = getDSTimKiem();
            if (dt.Rows.Count > 0)
            {
                txtTenSach.Text = dt.Rows[0][1].ToString();
                txtGiaBan.Text = dt.Rows[0][2].ToString();
                //txtMoTa.Text = dt.Rows[0][3].ToString();
                //txtCapNhat.Text = dt.Rows[0][4].ToString();
                byte[] b = (byte[])dt.Rows[0][5];
                pictureBox1.Image = ToByteArrayImage(b);
                //cbotenChuDe.Text = dt.Rows[0][7].ToString();
                txtChuDe.Text = dt.Rows[0][7].ToString();
                txtSoLuong.Text = dt.Rows[0][6].ToString();
                //cboTenNSB.Text = dt.Rows[0][8].ToString();
                //txtMoi.Text = dt.Rows[0][9].ToString();
            }
        }

        public DataTable getDSTimKiem()
        {
            string sqlTKS = "select * from Sach where MaSach ='" + cboSach.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = conn.getTable(sqlTKS);
            return dt;
        }

        public void load_cboTenSach()
        {
            string strSQL = "select * from Sach";
            DataTable dt = conn.getDataTable(strSQL, "Sach");

            cboSach.DataSource = dt;
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
        }

        public void load_dataGV()
        {
            string strSQL = "select tensach,MaChuDe,tentacgia from sach,tacgia,thamgia where sach.masach=thamgia.masach and tacgia.matacgia=thamgia.matacgia";
            DataTable dt = conn.getDataTable(strSQL, "sach,tacgia,thamgia");

            dataGridView1.DataSource = dt;
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
        public void load_cboTCD()
        {
            string strSQL = "select * from ChuDe";
            DataTable dt = conn.getDataTable(strSQL, "ChuDe");

            cbotenChuDe.DataSource = dt;
            cbotenChuDe.DisplayMember = "TenChuDe";
            cbotenChuDe.ValueMember = "MaChuDe";
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            load_dataGV();
        }

        private void cbotenChuDe_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            string strSelect = "select tensach,MaChuDe,tentacgia from sach,tacgia,thamgia where sach.masach=thamgia.masach and tacgia.matacgia=thamgia.matacgia AND sach.machude='" + cbotenChuDe.SelectedValue.ToString() + "'";
            DataSet ds_SV = new DataSet();
            SqlDataAdapter da_SV = new SqlDataAdapter(strSelect, conn.Con);
            da_SV.Fill(ds_SV);
            dataGridView1.DataSource = ds_SV.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThamGia t = new frmThamGia();
            t.Show();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmRptSach s = new frmRptSach();
            s.Show();
        }
    }
}
