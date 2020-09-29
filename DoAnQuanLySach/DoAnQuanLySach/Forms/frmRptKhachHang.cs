using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnQuanLySach.Report;

namespace DoAnQuanLySach.Forms
{
    public partial class frmRptKhachHang : Form
    {
        public frmRptKhachHang()
        {
            InitializeComponent();
            loadRpt();
        }

        private void frmRptKhachHang_Load(object sender, EventArgs e)
        {

        }

        public void loadRpt()
        {
            rptKhachHang s = new rptKhachHang();
            crystalReportViewer1.ReportSource = s;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
