﻿using PetFoster.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFoster.BLL
{
    public class FosterManager
    {
        public static void ShowFoster(int Limitrow = -1, string Orderby = null)
        {
            DataTable dt = FosterServer.FosterInfo(Limitrow, Orderby);
            //调试用
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write("{0,-15}", column.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write("{0,-15}", item);
                }
                Console.WriteLine();
            }
        }
    }
}
