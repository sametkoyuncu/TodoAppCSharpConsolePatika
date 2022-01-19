namespace TodoAppCSharpConsolePatika
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public User(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}