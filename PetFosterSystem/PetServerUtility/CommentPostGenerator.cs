﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFoster.Utility
{
    public class CommentPostGenerator
    {
        public static string user = "\"C##PET\"";
        public static string pwd = "campus";
        public static string db = "localhost:1521/orcl";
        private static string connectionString = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + db + ";"; // 替换为实际的数据库连接字符串
        public static void InsertCommentPosts()
        {

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;

                        // Insert into like_post table
                        for (int i = 1; i <= 50; i++)
                        {
                            string v_user_id = new Random().Next(1, 51).ToString();
                            string v_post_id = new Random().Next(1, 21).ToString();

                            command.CommandText = $"INSERT INTO like_post(user_id, post_id) VALUES ('{v_user_id}', '{v_post_id}')";

                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (OracleException ex)
                            {
                                // Handle exception
                                Console.WriteLine($"An error occurred - {ex.Number} - ERROR - {ex.Message}");
                            }
                        }

                        // Insert into comment_post table
                        string sample_comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                        for (int i = 1; i <= 20; i++)
                        {
                            string v_user_id = new Random().Next(1, 51).ToString();
                            string v_post_id = new Random().Next(1, 21).ToString();
                            string v_comment_contents = sample_comments.Substring(new Random().Next(0, 50), new Random().Next(1, 50));

                            command.CommandText = $"INSERT INTO comment_post(user_id, post_id, comment_contents) " +
                                $"VALUES ('{v_user_id}', '{v_post_id}', '{v_comment_contents}')";

                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (OracleException ex)
                            {
                                // Handle exception
                                Console.WriteLine($"An error occurred - {ex.Number} - ERROR - {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"An error occurred - {ex.Message}");
            }

        }
    }
}
