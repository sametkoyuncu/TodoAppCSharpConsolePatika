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
                    moveCard();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim yaptınız!");
                    break;
            }
        }

        private static void moveCard()
        {
            // index al, kartı al, eskiden sil yeniye ekle 4 işlem
            string _title, _line = String.Empty;
            Card _card = new Card(null, null, -1, -1); // olası patlama
            int index = -1;
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız:");
            _title = Console.ReadLine();

            int todo, inProgress, done;
            todo = _board.TODO.FindIndex(x => x.Title.ToLower() == _title.ToLower());
            inProgress = _board.IN_PROGRESS.FindIndex(x => x.Title.ToLower() == _title.ToLower());
            done = _board.DONE.FindIndex(x => x.Title.ToLower() == _title.ToLower());

            // kart varsa kartı burada çek, ekranda göster
            if (todo >= 0)
            {
                _line = "TODO";
                index = todo;
            }
            else if (inProgress >= 0)
            {
                _line = "IN_PROGRESS";
                index = inProgress;
            }
            else if (done >= 0)
            {
                _line = "DONE";
                index = done;
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                int _choice = Int32.Parse(Console.ReadLine());

                if (_choice == 1)
                    HomePage();
                else if (_choice == 2)
                    moveCard();
                else
                {
                    Console.WriteLine("Geçersiz işlem seçtiniz. İşlem sonlandırılıyor.");
                    HomePage();
                }
            }

            if (_line is not null)
            {
                _card = _board.GetProperty(_line).Find(x => x.Title.ToLower() == _title.ToLower());

                Console.WriteLine("Bulunan Kart Bilgileri:");
                Console.WriteLine("**************************************");
                Console.WriteLine("Başlık      : {0}", _card.Title);
                Console.WriteLine("İçerik      : {0}", _card.Content);
                Console.WriteLine("Atanan Kişi : {0}", _users.all.Find(x => x.Id == _card.UserId).FullName);
                Console.WriteLine("Büyüklük    : {0}", ((SizeEnum)_card.Size).ToString());
                Console.WriteLine("Line        : {0}", _line);

                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");
                int _choice1 = Int32.Parse(Console.ReadLine());

                if (_choice1 == 1)
                {
                    _board.GetProperty(_line).RemoveAt(index);
                    _board.TODO.Add(_card);
                }
                else if (_choice1 == 2)
                {
                    _board.GetProperty(_line).RemoveAt(index);
                    _board.IN_PROGRESS.Add(_card);
                }
                else if (_choice1 == 3)
                {
                    _board.GetProperty(_line).RemoveAt(index);
                    _board.DONE.Add(_card);
                }
                else
                {
                    Console.WriteLine("Geçersiz işlem seçtiniz. İşlem sonlandırılıyor.");
                    HomePage();
                }
                getBoard();
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
            {
                Console.WriteLine("Aradığınız kart bulunamadı.");
                HomePage();
            }
            Console.WriteLine("İşlem başarılı bir şekilde tamamlandı.");
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
