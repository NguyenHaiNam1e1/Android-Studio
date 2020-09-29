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
	
namespace DoAnQuanLySach
{
    public partial class frmRptSach : Form
    {
        public frmRptSach()
        {
            InitializeComponent();
            loadRpt();
        }

        public void loadRpt()
        {
            rptSach s = new rptSach();
            crystalReportViewer1.ReportSource = s;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
