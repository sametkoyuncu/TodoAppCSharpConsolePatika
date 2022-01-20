using System;
using System.Collections.Generic;

namespace TodoAppCSharpConsolePatika
{
    class Program
    {
        public static Board _board { get; set; }
        public static UserList _users { get; set; }

        static void Main(string[] args)
        {
            _board = new Board();
            _users = new UserList();

            while (true)
            {
                HomePage();
            }
        }

        public static void HomePage()
        {
            int choice;
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");// getBoard and printLine (from getBoard) methods call
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    getBoard();
                    break;
                case 2:
                    newCard();
                    break;
                case 3:
                    removeCard();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim yaptınız!");
                    break;
            }
        }

        private static void removeCard()
        {
            string _title;
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız:");
            _title = Console.ReadLine();

            // AuthorList.RemoveAt(2);
            int todo, inProgress, done;
            todo = _board.TODO.FindIndex(x => x.Title.ToLower() == _title.ToLower());
            inProgress = _board.IN_PROGRESS.FindIndex(x => x.Title.ToLower() == _title.ToLower());
            done = _board.DONE.FindIndex(x => x.Title.ToLower() == _title.ToLower());

            if (todo >= 0)
                _board.TODO.RemoveAt(todo);
            else if (inProgress >= 0)
                _board.IN_PROGRESS.RemoveAt(inProgress);
            else if (done >= 0)
                _board.DONE.RemoveAt(done);
            else
                Console.WriteLine("Aradığınız kart bulunamadı.");
        }

        private static void newCard()
        {
            string _title, _content;
            int _size;
            int _userId;

            Console.WriteLine("Başlık Giriniz                                  :");
            _title = Console.ReadLine();

            Console.WriteLine("İçerik Giriniz                                  :");
            _content = Console.ReadLine();

            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            _size = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Kişi Seçiniz (1-5 arası bir rakam)              :");
            _userId = Int32.Parse(Console.ReadLine());

            _board.TODO.Add(new Card(_title, _content, _userId, _size));
        }

        public static void getBoard()
        {
            // bunlar main veya homepage den alınabilir duruma göre artık

            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");

            if (_board.TODO.Count > 0)
                printLine(_board.TODO, _users);
            else
                Console.WriteLine("~BOŞ~");
            //
            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("************************");

            if (_board.IN_PROGRESS.Count > 0)
                printLine(_board.IN_PROGRESS, _users);
            else
                Console.WriteLine("~BOŞ~");
            //
            Console.WriteLine("DONE Line");
            Console.WriteLine("************************");

            if (_board.DONE.Count > 0)
                printLine(_board.DONE, _users);
            else
                Console.WriteLine("~BOŞ~");
        }
        // kolonları yazdıracak fonksiyon
        public static void printLine(List<Card> col, UserList users)
        {
            foreach (var item in col)
            {
                Console.WriteLine("Başlık      : {0}", item.Title);
                Console.WriteLine("İçerik      : {0}", item.Content);
                Console.WriteLine("Atanan Kişi : {0}", users.all.Find(x => x.Id == item.UserId).FullName);
                Console.WriteLine("Büyüklük    : {0}", ((SizeEnum)item.Size).ToString());
                Console.WriteLine("-");
            }
        }
    }

}
