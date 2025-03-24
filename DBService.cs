using Dapper;
using MySql.Data.MySqlClient;

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


    }
}
