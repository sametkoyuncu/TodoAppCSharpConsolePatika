using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoAppCSharpConsolePatika
{
    class Program
    {
        static void Main(string[] args)
        {
            HomePage();
        }

        public static void HomePage()
        {
            int choice;
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    getBoards();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim yaptınız!");
                    break;
            }
        }

        public static void getBoards()
        {
            Board board = new Board();
            UserList users = new UserList();

            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");
            foreach (var item in board.TODO)
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
