﻿using PetFoster.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFoster.BLL
{
    public class LikePostManager
    {
        public static void ShowLikePost(int Limitrow = -1, string Orderby = null)
        {
            DataTable dt = LikePostServer.LikePostInfo(Limitrow, Orderby);
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
        public static void GiveALike(string UID, string PID)
        {
            bool dt = LikePostServer.GetLikePostEntry(UID, PID);
            //调试用
            if (!dt)
            {
                LikePostServer.InsertLikePost(UID, PID);
                Console.WriteLine($"{UID} gives a like to {PID}."); // 输出点赞信息
            }
            else
            {
                LikePostServer.DeleteLikePost(UID, PID);
                Console.WriteLine($"{UID} undo a like to {PID}."); // 输出点赞信息
            }
        }
    }
}
