namespace GeliuParduotuveFrontEnd.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }

        public Customer(string firstName, string lastName, string password, string role, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Role = role;
            Username = username;
        }

        public Customer()
        {
        }
    }
}
