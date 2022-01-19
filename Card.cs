namespace TodoAppCSharpConsolePatika
{
    public class Card
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int Size { get; set; }
        public Card(string title, string content, int userId, int size)
        {
            Title = title;
            Content = content;
            UserId = userId;
            Size = size;
        }
    }

}