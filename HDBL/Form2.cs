using CLSB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HDBL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QL_BANHANGDataSet1.CHITIETHD' table. You can move, or remove it, as needed.
            this.CHITIETHDTableAdapter.Fill(this.QL_BANHANGDataSet1.CHITIETHD, cls_luu.sohd);
           // MessageBox.Show(cls_luu.sohd);
            this.reportViewer1.RefreshReport();
        }
    }
}
