﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmLogin
{
    public partial class frmSelectDish : Form
    {
        public frmSelectDish()
        {
            InitializeComponent();
        }

        private void btnExitFomSelectDish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSelectDish_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSelectDish_Click(object sender, EventArgs e)
        {
            Usercontrol uc = new Usercontrol();
            uc.TenSP =" "+ txtDishName.Text;
            uc.SoLuong =" "+ numQuantity.Value.ToString();
            uc.DonGia = " "+txtDishPrice.Text;
            flowLayoutPanel1.Controls.Add(uc);
        }
    }
}
