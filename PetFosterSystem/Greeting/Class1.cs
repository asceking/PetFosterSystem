using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    public class Class1
    {
        public static string user = "\"C##PET\"";
        public static string pwd = "campus";
        public static string db = "localhost:1521/orcl";
        private static string conStr = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + db + ";"; // 替换为实际的数据库连接字符串
        public static void Greet(string Username,OracleConnection connection)
        {
            try
            {
                    connection.Open();
                    OracleCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string account_status = "In Good Standing";
                    command.CommandText = "INSERT INTO user2 (user_id, user_name, password, phone_number, account_status, address) " +
                        "VALUES (user_id_seq.NEXTVAL, :user_name, :password, :phone_number, :account_status, :address)";
                    command.Parameters.Clear();
                    command.Parameters.Add("user_name", OracleDbType.Varchar2, Username, ParameterDirection.Input);
                    command.Parameters.Add("password", OracleDbType.Varchar2, pwd, ParameterDirection.Input);
                    command.Parameters.Add("phone_number", OracleDbType.Varchar2, "13333333333", ParameterDirection.Input);
                    command.Parameters.Add("account_status", OracleDbType.Varchar2, account_status, ParameterDirection.Input);
                    command.Parameters.Add("address", OracleDbType.Varchar2, "上海市静安区", ParameterDirection.Input);
                    try
                    {
                        command.ExecuteNonQuery();
                        command.CommandText = "select max(cast(user_id as integer)) from user2";
                        command.Parameters.Clear();
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("错误码" + ex.ErrorCode.ToString());

                        throw;
                    }
                    connection.Close();
            }
            catch (Exception ex)
            {
                // 处理异常
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine($"Hello {Username}");
        }
    }
}
