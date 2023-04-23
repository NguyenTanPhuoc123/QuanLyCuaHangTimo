﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class EmployeeBUS
    {
        private static EmployeeBUS instance;
        public static EmployeeBUS Instance
        {
            get { if (instance == null) instance = new EmployeeBUS(); return EmployeeBUS.instance; }
            private set { EmployeeBUS.instance = value; }
        }

        public Employee GetEmployeeByEmployeeID(int employeeID)
        {
            return EmployeeDAO.Instance.GetEmployeeByEmployeeID(employeeID);
        }

        public int UpdateEmployeeInFo(int employeeID, string SDT, string NgaySinh, string GioiTinh, string DiaChi)
        {
            return EmployeeDAO.Instance.UpdateEmployeeInFo(employeeID, SDT, NgaySinh, GioiTinh, DiaChi);
        }

        public int DeleteEmployeeInfo(int employeeID)
        {
            return EmployeeDAO.Instance.DeleteEmployeeInfo(employeeID);
        }

        public int UpdateEmployee(int employeeID, string employeeName, string ngaySinh, string gioiTinh, string soDienThoai, string diaChi)
        {
            return EmployeeDAO.Instance.UpdateEmployee(employeeID, employeeName, ngaySinh, gioiTinh, soDienThoai, diaChi);
        }

        public int AddEmployee(string tennv, string ngaysinh, string gioitinh, string ngayvaolam, int chucvu, string sdt, string diachi)
        {
            return EmployeeDAO.Instance.AddEmployee(tennv, ngaysinh, gioitinh, ngayvaolam, chucvu, sdt, diachi);
        }

        public int GetEmployeeIDMax()
        {
            return EmployeeDAO.Instance.GetEmployeeIDMax();
        }

        public int DeleteAllEmployee()
        {
            return EmployeeDAO.Instance.DeleteAllEmployee();
        }
    }
}
