namespace GeliuParduotuveFrontEnd.Models
{
    public class LogInData { 

        public string Password { get; set; }

        public string Username { get; set; }

        public LogInData(string username, string password)
        {
            Password = password;
            Username = username;
        }
    }
}
