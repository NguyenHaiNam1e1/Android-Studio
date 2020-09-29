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
    public partial class frmRptTacGia : Form
    {
        public frmRptTacGia()
        {
            InitializeComponent();
            loadRpt();
        }

        public void loadRpt()
        {
            rptTacGia s = new rptTacGia();
            crystalReportViewer1.ReportSource = s;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
