﻿using frmLogin.Data_Tranfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin.Data_Access_Layer
{
    public class LocationDAF
    {
        private static LocationDAF instance;
        public static LocationDAF Instance
        {
            get { if (instance == null) instance = new LocationDAF(); return LocationDAF.instance; }
            private set { LocationDAF.instance = value; }
        }

        private LocationDAF()
        {

        }
        public List<Location> GetListLocation()
        {
            List<Location> listLocation = new List<Location>();
            string query = "SELECT * FROM VITRI WHERE XOA = 0";
            DataTable data = DataProvider.ExcecuteSelectCommand(query, null);
            foreach(DataRow row in data.Rows)
            {
                Location location = new Location(row);
                listLocation.Add(location);
            }
            return listLocation;
        }

        public int AddLocationTable(string name)
        {
            string query = string.Format("Insert VITRI(TENVITRI,XOA) values(N'{0}',0)", name);
            int row = DataProvider.ExecuteInsertCommand(query, null);

            return row;
        }

        public int UpdateLocationTable(int id, string name)
        {
            string query = string.Format("UPDATE VITRI SET TENVITRI = N'{0}' where MAVITRI = {1}", name, id);
            int row = DataProvider.ExecuteInsertCommand(query, null);

            return row;
        }

        public int DeleteLocationTable(int id)
        {
            string query = string.Format("UPDATE VITRI SET XOA = 1 WHERE MAVITRI = {0} ", id);
            int row = DataProvider.ExecuteInsertCommand(query, null);

            return row;
        }

        public int DeleteAllLocationTable()
        {
            string query = string.Format("UPDATE VITRI SET XOA = 1 ");
            int row = DataProvider.ExecuteInsertCommand(query, null);

            return row;
        }

        public int GetLocationIDMax()
        {
            int locationID = 1;
            int max = DataProvider.ExecuteScalarCommand("SELECT MAX(MAVITRI) from VITRI", null);

            if (max != null)
                locationID = max;
            return locationID+1;
        }
    }
}
