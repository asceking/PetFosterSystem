using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using PetFoster.BLL;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.OracleClient;
using PetFoster.Model;
using PetFoster.DAL;
using System.Net;

namespace WebApplicationTest1
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public static string user = "\"C##PET\"";
        public static string pwd = "campus";
        public static string db = "localhost:1521/orcl";
        private static string conStr = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + db + ";"; // 替换为实际的数据库连接字符串
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        //private readonly UserManager _userManager;

        //public LoginController()

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }*/
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            string username = loginModel.Username;
            string password = loginModel.Password;
            Console.WriteLine(username + " " + password);
            IActionResult respond = Ok();
            using (OracleConnection oracle = new OracleConnection(conStr))
            {
                oracle.Open();
               // UserServer.InsertUser(username, password,"13333333333","安徽省合肥市");
                string Username = username;
                string pwd= password;
                string phoneNumber = "13333333333";
                string Address = "安徽省合肥市";
                string UID = "-1";
                try
                {
                    using (OracleConnection connection = new OracleConnection(conStr))
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
                        command.Parameters.Add("phone_number", OracleDbType.Varchar2, phoneNumber, ParameterDirection.Input);
                        command.Parameters.Add("account_status", OracleDbType.Varchar2, account_status, ParameterDirection.Input);
                        command.Parameters.Add("address", OracleDbType.Varchar2, Address, ParameterDirection.Input);
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
                }
                catch (Exception ex)
                {
                    // 处理异常
                    Console.WriteLine(ex.ToString());
                }
                if (UserManager.Login(username, password))
                {
                    respond = Ok();
                }
                else
                {
                    respond = BadRequest();
                }
                oracle.Close();
            }
            return respond;
        }
    }
}
            /*
            OracleConnection oracle=new OracleConnection(conStr);
            oracle.Open();
            if (UserManager.Login(username,password)) {
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}*/
