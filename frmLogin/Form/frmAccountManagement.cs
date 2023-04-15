﻿using frmLogin.Data_Access_Layer;
using frmLogin.Data_Tranfer_Object;
using System;
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
    public partial class frmAccountManagement : Form
    {
        public frmAccountManagement()
        {
            InitializeComponent();
        }

        private void frmAccountManagement_Load(object sender, EventArgs e)
        {
            dtgvListAccount.DataSource= AccountMenuDAF.Instance.GetListAccount();
            cbTypeAccount.DataSource = TypeAccountDAF.Instance.GetListTypeAccount();
            cbTypeAccount.DisplayMember = "TenLoai";
            cbTypeAccount.ValueMember = "MaLoai";
            cbEmloyee.DataSource = EmployeeDAF.Instance.GetListEmployee();
            cbEmloyee.DisplayMember = "TenNV";
            cbEmloyee.ValueMember = "MaNV";
            btnSave.Enabled = false;
            btnSave.Enabled = false;
            btnDeleteAllAccount.Enabled = true;
            btnDeleteAccount.Enabled = true;
            btnEditAccount.Enabled = true;
        }

        private void btnAccountDeleted_Click(object sender, EventArgs e)
        {
            frmRecycleBin frm = new frmRecycleBin();
            frm.Show();
        }

        private void btnDeleteAllAccount_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Ban co muon xoa tat ca", "Thong bao", MessageBoxButtons.YesNo))
            {
                int count = AccountDAF.Instance.DeleteAllAccount();
                if (count > 0)
                {
                    MessageBox.Show("Xóa tất cả thành công");
                }
                else
                {
                    MessageBox.Show("Xóa tất cả thất bại");
                }
            }
            frmAccountManagement_Load(sender, e);
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cbEmloyee.SelectedIndex=0;
            cbTypeAccount.SelectedIndex = 0;
            btnSave.Enabled = true;
            btnDeleteAllAccount.Enabled = false;
            btnDeleteAccount.Enabled = false;
            btnEditAccount.Enabled = false;
        }

       

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản này", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
            {
                int count = AccountDAF.Instance.DeleteAccountByUserName(txtUsername.Text);
                if (count > 0)
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại");
                }
            }
            frmAccountManagement_Load(sender, e);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            int count = AccountDAF.Instance.EditAccount(txtUsername.Text,cbEmloyee.SelectedValue.ToString(), cbTypeAccount.SelectedValue.ToString());
            if (count > 0)
            {
                MessageBox.Show("Sửa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại");
            }
            frmAccountManagement_Load(sender, e);
        }

       

        private void dtgvListAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Text = dtgvListAccount.SelectedRows[0].Cells[0].Value.ToString();
            txtPassword.Text = dtgvListAccount.SelectedRows[0].Cells[1].Value.ToString();
            cbEmloyee.SelectedValue = Convert.ToInt32(dtgvListAccount.SelectedRows[0].Cells[2].Value.ToString());
            cbTypeAccount.SelectedValue = Convert.ToInt32(dtgvListAccount.SelectedRows[0].Cells[3].Value.ToString());
            btnSave.Enabled = false;
            btnDeleteAllAccount.Enabled =true;
            btnDeleteAccount.Enabled = true;
            btnEditAccount.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count = AccountDAF.Instance.AddAccount(txtUsername.Text, txtPassword.Text,cbEmloyee.SelectedValue.ToString(), cbTypeAccount.SelectedValue.ToString());
            if (count > 0)
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            frmAccountManagement_Load(sender, e);
        }
    }
}
