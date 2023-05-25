﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace frmLogin
{
   
    public partial class frmlogin : Form
    {
        public static int Language = 0;
        public static string username;
        public frmlogin()
        {
            InitializeComponent();
        }

        public static string GetUsername()
        {
            return username;
        }

        public static void SetUsername(string value)
        {
            username = value;
        }

        private void frmlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbDisplay_Click(object sender, EventArgs e)
        {
            pbHide.BringToFront();
            txtPassword.UseSystemPasswordChar= false;
            txtPassword.PasswordChar = '\0';
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
           pbDisplay.BringToFront();
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '●';
        }

        

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            SetUsername(txtUsername.Text);
            if (Language == 0)
            {
                if (string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (AccountBUS.Instance.CheckLogin(txtUsername.Text, txtPassword.Text))
                {
                    Account loginAccount = AccountBUS.Instance.GetAccountForUsername(txtUsername.Text);
                    frmSellManagement login = new frmSellManagement(loginAccount);
                    this.Hide();
                    login.ShowDialog();
                    txtPassword.Clear();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("Please enter full information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (AccountBUS.Instance.CheckLogin(txtUsername.Text, txtPassword.Text))
                {
                    Account loginAccount = AccountBUS.Instance.GetAccountForUsername(txtUsername.Text);
                    frmSellManagement login = new frmSellManagement(loginAccount);
                    this.Hide();
                    login.ShowDialog();
                    txtPassword.Clear();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Invalid data", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmlogin_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            if (Language == 0)
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
            else
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
            this.Controls.Clear();
            InitializeComponent();
            Language = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            this.Controls.Clear();
            InitializeComponent();
            Language = 1;
        }
    }
}
