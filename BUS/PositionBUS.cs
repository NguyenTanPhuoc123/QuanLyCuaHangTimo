﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class PositionBUS
    {
        private static PositionBUS instance;
        public static PositionBUS Instance
        {
            get { if (instance == null) instance = new PositionBUS(); return PositionBUS.instance; }
            private set { PositionBUS.instance = value; }
        }

        private PositionBUS()
        {

        }
        public Position GetPositionName(int id)
        {
            return PositionDAO.Instance.GetPositionName(id);
        }

        public List<Position> GetListPosition()
        {
            return PositionDAO.Instance.GetListPosition();
        }

        public int GetPositionIDMax()
        {
            return PositionDAO.Instance.GetPositionIDMax();
        }

        public int AddPosition(string tenchucvu)
        {
            return PositionDAO.Instance.AddPosition(tenchucvu);
        }

        public int UpdatePosition(int macv, string tencv)
        {
            return PositionDAO.Instance.UpdatePosition(macv, tencv);
        }

        public int DeletePosition(int macv)
        {
            return PositionDAO.Instance.DeletePosition(macv);
        }

        public int DeleteAllPosition()
        {
            return PositionDAO.Instance.DeleteAllPosition();
        }
    }
}
