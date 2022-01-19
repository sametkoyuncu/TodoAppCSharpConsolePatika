using System.Collections.Generic;

namespace TodoAppCSharpConsolePatika
{
    public class UserList
    {
        public List<User> all = new List<User>();

        public UserList()
        {
            all.Add(new User(1, "Samet Koyuncu"));
            all.Add(new User(2, "Jane Lorem"));
            all.Add(new User(3, "John Doe"));
            all.Add(new User(4, "Jess Ipsum"));
        }
    }
}