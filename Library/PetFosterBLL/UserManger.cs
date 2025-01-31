﻿using Oracle.ManagedDataAccess.Client;
using PetFoster.DAL;
using PetFoster.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using static PetFoster.Model.PetData;

namespace PetFoster.BLL
{
    public class UserManager
    {
        public static string user = "\"C##PET\"";
        public static string pwd = "campus";
        public static string db = "localhost:1521/orcl";
        private static string conStr = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + db + ";"; // 替换为实际的数据库连接字符串
        public static string JSON;
        static public bool IsValidStatus(string status)
        {
            // 解析JSON字符串
            return JsonHelper.TranslateToEn(status, "status") != null;
        }
        public static void ShowUserProfile(int Limitrow = -1, string Orderby = null)
        {
            DataTable dt = UserServer.UserInfo(Limitrow, Orderby);
            //调试用
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write("{0,-20}", column.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in dt.Rows)
            {
                for(int i=0;i<row.ItemArray.Length;i++)
                {
                    string[] results = row.ItemArray[i].ToString().Split(',');
                    if (i == 4&&results.Length==2)
                    {
                        string result = "";
                        string province = "";
                        province=JsonHelper.TranslateToCn(results[1],"provinces");
                        result += province;
                        result+= JsonHelper.TranslateToCn(results[0], results[1]);
                        Console.Write("{0,-20}", result);
                    }
                    else if (i == 4 && results.Length == 1)
                    {
                        string province = "";
                        province = JsonHelper.TranslateToCn(results[0], "provinces");
                        Console.Write("{0,-20}", province);
                    }
                    else if (i == 3)
                    {
                        Console.Write("{0,-20}", JsonHelper.TranslateToCn(row.ItemArray[i].ToString(),"status"));
                    }
                    else
                        Console.Write("{0,-20}", row.ItemArray[i].ToString());
                }

                Console.WriteLine();
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>返回错误码，在JSON中指定,4为管理员，5为用户</returns>
        public static int Login(string UID,string Pwd)
        {
            bool con = false;
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                // 连接对象将在 using 块结束时自动关闭和释放资源
                // 在此块中执行数据操作
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                User Candidate = UserServer.GetUser(UID, Pwd);
                connection.Close();
                if (Candidate.Account_Status == "Banned")
                    return 1;
                else if (Candidate.User_ID == "-1")
                    return 2;
                else if (Candidate.Password != Pwd)
                    return 3;
                else
                {
                    if (Candidate.Role == "Admin")
                    {
                        Console.WriteLine($"你好，管理员{Candidate.User_Name}已经登陆成功");
                        return 5;
                    }
                    else
                    {
                        Console.WriteLine($"你好，用户{Candidate.User_Name}已经登陆成功");
                        return 4;
                    }
                }
                
            }
        }
        private static bool ValidatePhoneNumber(string phoneNumber)
        {
            string pattern = @"^\d{3}-\d{4}-\d{4}$|^\d{11}$|^\d{3} \d{4} \d{4}$";
            bool isValid = Regex.IsMatch(phoneNumber, pattern);
            return isValid;
        }
        private static bool ValidatePassword(string password)
        {
            bool hasMinimumLength = password.Length >= 10;
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasLowerCase = Regex.IsMatch(password, @"[a-z]");
            bool hasUpperCase = Regex.IsMatch(password, @"[A-Z]");
            bool hasSpecialCharacter = Regex.IsMatch(password, @"[!@#$%^&*()]");

            bool isValid = hasMinimumLength && hasDigit && hasLowerCase && hasUpperCase && hasSpecialCharacter;
            return isValid;
        }
        public static bool IsValidAddress(string address)
        {
            string res=JsonHelper.TranslateAddr(address);
            return  res!= null;
        }
        private static int ValidRegistration(string Username, string pwd, string phoneNumber, string Address = "Beijing")
        {
            if (!IsValidAddress(Address))
            {
                return 0;
            }
            else if (!ValidatePhoneNumber(phoneNumber))
            {
                return 1;
            }
            else if (!ValidatePassword(pwd))
            {
                return 2;
            }
            else if (Username.Length > 20)
            {
                return 3;
            }else 
                return 4;

        }
        /// <summary>
        /// 校验信息并注册
        /// </summary>
        /// <param name="Username">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="Address">地址</param>
        /// <returns>返回状态string</returns>
        public static string Register(string Username, string pwd, string phoneNumber, string Address = "Beijing")
        {
            // 添加新行
            int code = ValidRegistration(Username, pwd, phoneNumber, Address);
            if (code!=4) { return JsonHelper.GetErrorMessage("register",code); }
            Address = JsonHelper.TranslateAddr(Address);
            string UID = UserServer.InsertUser(Username, pwd, phoneNumber, Address);
            //注册时的其他操作，如验证码等等.....
            return $"你好，{Username},您已经注册成功，你的UID是{UID}";
        }
        public static string Unregister(decimal UID)
        {
            bool rows = UserServer.DeleteUser(UID.ToString());
            if (rows)
            {
                return $"{UID},您已经注销成功!";
            }
            else
                return $"不存在UID为{UID}的用户";
        }
        //以下是更改个人信息部分
        //修改密码
        /// <summary>
        /// 封禁或解禁账户
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="status">设置用户相应的状态</param>
        public static string Ban(decimal UID, string status = "Banned")
        {
            User user = UserServer.GetUser(UID.ToString(), "0", true);
            if (IsValidStatus(status))
            {
                UserServer.UpdateUser(UID.ToString(), user.User_Name, user.Password, user.Phone_Number, user.Address, status);
                return $"已将用户{user.User_Name}状态设置为{status}";
            }
            else if(IsValidStatus(JsonHelper.TranslateToEn(status, "status"))){
                UserServer.UpdateUser(UID.ToString(), user.User_Name, user.Password, user.Phone_Number, user.Address, JsonHelper.TranslateToEn(status, "status"));
                return $"已将用户{user.User_Name}状态设置为{status}";
            }
            else
                return $"不存在{status}这种状态";
        }
        static int RemainingTime = 5;
        static bool Waiting = false;
        static CountdownTimer countdownTimer;
        /// <summary>
        /// 改密码
        /// </summary>
        /// <param name="UID">用户名</param>
        /// <param name="Password">旧密码</param>
        /// <param name="NewPassword">新密码</param>
        /// <returns></returns>
        public static string ChangePassword(decimal UID, string Password, string NewPassword)
        {
            TimeSpan timeRemaining;
            User candidate = UserServer.GetUser(UID.ToString(), Password, true);
            if (Waiting && countdownTimer.GetTimeRemaining().Ticks > 0)
            {
                timeRemaining = countdownTimer.GetTimeRemaining();
                return $"Time remaining: {timeRemaining.Hours} hours, {timeRemaining.Minutes} minutes, {timeRemaining.Seconds} seconds";
            }
            else if (Waiting && countdownTimer.GetTimeRemaining().Ticks <= 0)
            {
                Waiting = false;
                RemainingTime = 5;
            }
            if (candidate.Password != Password && --RemainingTime > 0)
            {
                return $"密码不正确,还有{RemainingTime}次机会，共计5次机会";
            }
            else if (RemainingTime == 0)
            {
                DateTime targetTime = DateTime.Now.AddMinutes(180);  // 假设倒计时目标时间为当前时间的10分钟后
                countdownTimer = new CountdownTimer(targetTime);
                Waiting = true;
            }
            else if (candidate.Password == Password)
            {
                if (!ValidatePassword(NewPassword))
                {
                    return "密码长度必须为8~16位，同时包含大小写，数字，特殊字符！";
                }
                UserServer.UpdateUser(UID.ToString(), candidate.User_Name, NewPassword, candidate.Phone_Number, candidate.Address, candidate.Account_Status);
                return $"{candidate.User_Name},你好！密码已成功修改，请不要忘记密码";
            }
            timeRemaining = countdownTimer.GetTimeRemaining();
            return $"Time remaining: {timeRemaining.Hours} hours, {timeRemaining.Minutes} minutes, {timeRemaining.Seconds} seconds";

        }
    }
    public class CountdownTimer
    {
        private DateTime targetTime;

        public CountdownTimer(DateTime targetTime)
        {
            this.targetTime = targetTime;
        }

        public TimeSpan GetTimeRemaining()
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan timeRemaining = targetTime - currentTime;
            return (timeRemaining.Ticks > 0) ? timeRemaining : TimeSpan.Zero;
        }
    }
}
