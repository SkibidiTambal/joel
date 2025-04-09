using Dapper;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace BlazorAppDataBinding2
{
    public class DBService
    {
        private readonly string connectionString;

        public DBService(string connectionString)
        {
            this.connectionString = connectionString;

            //var connection = new MySqlConnection(connectionString);

            //connection.Open();
        }

        //Get all data from specific user mothod
        public Person GetPersonByEmail(string email)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                Person person = connection.QuerySingleOrDefault<Person>("select * from users as T1 WHERE T1.email=@Email", new {Email = email});

                return person;
            }
        }

        public static string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // format as hexadecimal
                }
                return sb.ToString();
            }
        }
    }
}
