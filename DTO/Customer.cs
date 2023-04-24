﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer
    {
        private string m_MaKH;
        private string m_TenKH;
        private string m_SoDienThoai;
        private int m_LoaiKH;
        private string m_gioiTinh;

        public Customer(string maKH, string tenKH, string soDienThoai, int loaiKH, string gioiTinh)
        {
            m_MaKH = maKH;
            m_TenKH = tenKH;
            m_SoDienThoai = soDienThoai;
            m_LoaiKH = loaiKH;
            m_gioiTinh = gioiTinh;
        }

        public string MaKH { get => m_MaKH; set => m_MaKH = value; }
        public string TenKH { get => m_TenKH; set => m_TenKH = value; }
        public string SoDienThoai { get => m_SoDienThoai; set => m_SoDienThoai = value; }
        public int LoaiKH { get => m_LoaiKH; set => m_LoaiKH = value; }
        public string GioiTinh { get => m_gioiTinh; set => m_gioiTinh = value; }

        public Customer(DataRow row)
        {
            this.m_MaKH = row["MAKH"].ToString();
            this.m_TenKH = row["TENKH"].ToString();
            this.m_SoDienThoai = row["SODIENTHOAI"].ToString();
            this.m_LoaiKH = (int) row["LoaiKH"];
            this.m_gioiTinh = row["GioiTinh"].ToString();
        }

       
    }
}
