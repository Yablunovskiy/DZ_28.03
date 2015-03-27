using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Post_Office_Yabl
{

    //public delegate void ToGet(int idEdition, List<Subscriber> S);
    

    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            List<Magazines> M = new List<Magazines>();
            List<Newspaper> N = new List<Newspaper>();
            List<Subscriber> S = new List<Subscriber>();
            PostOffice P = new PostOffice();
            MagazinS(ref M);
            NewspapeR(ref N);
            SubscribeS(ref S);
            AddPost(S, N, M, ref P);
            //P.Print();
            AddAubIdMagazin(ref S, P);
            //PrintM(M);
            //Console.WriteLine();
            //PrintN(N);
            //Console.WriteLine();
            //PrintS(S);

            Menu0(S, N, M, ref P);

        }

        static void Menu0(List<Subscriber> S, List<Newspaper> N, List<Magazines> M, ref PostOffice P)
        {
            string[] menu0 = new string[] { " Перечень журналов. ", " Перечень газет. ", " Подписчики. ", " Провести рассылку. ", " ВЫХОД. "};
            bool next = true;
            int I = 0;
            Action<string, ConsoleColor, ConsoleColor> action = DispayMessage;
            for (int i = 0; i < menu0.Length; i++)
            {
                if(i==I)
                    action(menu0[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                else
                    action(menu0[i], ConsoleColor.DarkGreen, ConsoleColor.White);
            }
            while(next)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    --I;
                    if (I < 0) I = menu0.Length-1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    ++I;
                    if (I > menu0.Length-1) I = 0;
                }

                Console.Clear();
                for (int i = 0; i < menu0.Length; i++)
                {
                    if (i == I)
                        action(menu0[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                    else
                        action(menu0[i], ConsoleColor.DarkGreen, ConsoleColor.White);
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    switch (I)
                    {
                        case 0:
                            PrintM(M);
                            break;
                        case 1:
                            PrintN(N);
                            break;
                        case 2:
                            PrintS(S);
                            break;
                        case 3:
                            Delivery(M, N, S, P);
                            break;
                        case 4:
                            next = false;
                            break;
                    }
                }
            }
        }

        static void DispayMessage(string msg, ConsoleColor color, ConsoleColor Bcolor)
        {
            ConsoleColor prev = Console.ForegroundColor;
            ConsoleColor Bprev = Console.BackgroundColor;
            Console.WriteLine();
            Console.Write("\t\t\t\t\t");
            Console.ForegroundColor = color;
            Console.BackgroundColor = Bcolor;
            Console.WriteLine(msg);
            Console.ForegroundColor = prev;
            Console.BackgroundColor = Bprev;
            Console.WriteLine();
        }

        static void DispayMessage1(Dictionary<int, Issue> IdFromName, ConsoleColor color, ConsoleColor Bcolor, int ind)
        {
            ConsoleColor prev = Console.ForegroundColor;
            ConsoleColor Bprev = Console.BackgroundColor;
            Console.WriteLine();
            Console.Write("\t\t\t\t\t");
            Console.ForegroundColor = color;
            Console.BackgroundColor = Bcolor;

            IdFromName.ElementAt(ind).Value.GetIssue();

            Console.ForegroundColor = prev;
            Console.BackgroundColor = Bprev;
            Console.WriteLine();
        }


        static void Delivery(List<Magazines> M, List<Newspaper> N, List<Subscriber> S, PostOffice P)
        {
            Console.Clear();
            int I = 0;
            bool next = true;
            Action<Dictionary<int, Issue>, ConsoleColor, ConsoleColor, int> action = DispayMessage1;
            Dictionary<int, Issue> IdFromName = new Dictionary<int, Issue>();

            for (int i = 0; i < P.idMagazines.Count; i++)
            {
                IdFromName.Add(P.IdMagazin(i), new Issue(P.idMagazines.ElementAt(i).Value.Name, P.idMagazines.ElementAt(i).Value.issue, true));
            }
            for (int i = 0; i < P.idNewspaper.Count; i++)
            {
                IdFromName.Add(P.IdNewspaper(i), new Issue(P.idNewspaper.ElementAt(i).Value.Name, P.idNewspaper.ElementAt(i).Value.issue, false));
            }

            for (int i = 0; i < IdFromName.Count; i++)
            {
                if (i == I)
                    action(IdFromName, ConsoleColor.Yellow, ConsoleColor.Blue, i);
                else
                    action(IdFromName, ConsoleColor.DarkGreen, ConsoleColor.White, i);
            }

            
            while (next)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    --I;
                    if (I < 0) I = IdFromName.Count - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    ++I;
                    if (I > IdFromName.Count - 1) I = 0;
                }

                Console.Clear();
                for (int i = 0; i < IdFromName.Count; i++)
                {
                    if (i == I)
                        action(IdFromName, ConsoleColor.Yellow, ConsoleColor.Blue, I);
                    else
                        action(IdFromName, ConsoleColor.DarkGreen, ConsoleColor.White, i);
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    GetEdition(IdFromName, I, S);
                }

            }
        }

        static void Subscriber_Events(object sender, SubscriberEventArgs e)
        {
            Console.WriteLine("{0}", e.msg);
        }

        static void AddAubIdMagazin(ref List<Subscriber> S, PostOffice P)
        {
            //Console.WriteLine("Введите номера журналов для подписк(0 - вы закончили выбор) ->");
            //Console.WriteLine("________________________________________");
            //Console.WriteLine(S.ElementAt(0));
            S.ElementAt(0).AddMagazines(0);
            S.ElementAt(0).AddMagazines(3);
            S.ElementAt(0).AddMagazines(6);
            S.ElementAt(0).AddNewspaper(1007);
            S.ElementAt(0).msg = " Я рад что получил этот журнал. ";
            S.ElementAt(0).msg1 = " О... будет чем развести костер. ";
            //S.ElementAt(0).Podpiska(P);

            //Console.WriteLine("________________________________________");
            //Console.WriteLine(S.ElementAt(1));
            S.ElementAt(1).AddMagazines(1);
            S.ElementAt(1).AddMagazines(5);
            S.ElementAt(1).AddMagazines(7);
            S.ElementAt(1).AddNewspaper(1003);
            S.ElementAt(1).AddNewspaper(1005);
            S.ElementAt(1).msg = " Прикольные журналы папа выписал посмотрим. ";
            S.ElementAt(1).msg1 = " Эти газеты постоянно задерживаются. ";
            //S.ElementAt(1).Podpiska(P);

            //Console.WriteLine("________________________________________");
            //Console.WriteLine(S.ElementAt(2));
            S.ElementAt(2).AddMagazines(2);
            S.ElementAt(2).AddMagazines(3);
            S.ElementAt(2).AddMagazines(4);
            S.ElementAt(2).AddMagazines(6);
            S.ElementAt(2).AddNewspaper(1006);
            S.ElementAt(2).msg = " Неплохо нужно прочесть. ";
            S.ElementAt(2).msg1 = " Что тут интересного? ";
            //S.ElementAt(2).Podpiska(P);

            //Console.WriteLine("________________________________________");
            //Console.WriteLine(S.ElementAt(3));
            S.ElementAt(3).AddMagazines(7);
            S.ElementAt(3).AddNewspaper(1007);
            S.ElementAt(3).msg = " Этот журнал мне нравится. ";
            S.ElementAt(3).msg1 = " Опять всякую ерунду принесли. ";
            //S.ElementAt(3).Podpiska(P);

            //Console.WriteLine("________________________________________");
            //Console.WriteLine(S.ElementAt(4));
            S.ElementAt(4).AddMagazines(1);
            S.ElementAt(4).AddNewspaper(1000);
            S.ElementAt(4).AddNewspaper(1001);
            S.ElementAt(4).AddNewspaper(1002);
            S.ElementAt(4).AddNewspaper(1003);
            S.ElementAt(4).AddNewspaper(1004);
            S.ElementAt(4).msg = " Хоть бы один такой красавчик подощел.\n Ну хоть посмотрю. ";
            S.ElementAt(4).msg1 = " Эти газеты постоянно задерживаются. ";
            //S.ElementAt(4).Podpiska(P);

            //Console.WriteLine("________________________________________");
            //Console.WriteLine(S.ElementAt(5));
            S.ElementAt(5).AddMagazines(5);
            S.ElementAt(5).AddMagazines(7);
            S.ElementAt(5).AddMagazines(6);
            S.ElementAt(5).msg = " Я тоже хочу быть как эти девчонки. ";
            S.ElementAt(5).msg1 = " А я невыписывала газет! ";
            //S.ElementAt(5).Podpiska(P);
        }

        

        static void GetEdition(Dictionary<int, Issue> IdFromName, int ind, List<Subscriber> S)
        {
            int idEdition = IdFromName.ElementAt(ind).Key;
            bool King = IdFromName.ElementAt(ind).Value.Inf;
            
            //ToGet M = new ToGet(Get.GetEditionM);
            //ToGet N = new ToGet(Get.GetEditionN);
            if (IdFromName.ElementAt(ind).Value.Inf)
            {
                //M (idEdition, S);
                for (int i = 0; i < S.Count; i++)
                {
                    for (int j = 0; j < S.ElementAt(i).Mag.Count; j++)
                    {
                        if (S.ElementAt(i).Mag[j] == idEdition)
                        {
                            Console.WriteLine("Абонент получил журнал");
                            S.ElementAt(i).ReceivedMag = true;
                            S.ElementAt(i).Magazin += Subscriber_Events;
                            S.ElementAt(i).ToGetT(S.ElementAt(i).msg);
                            S.ElementAt(i).Magazin -= Subscriber_Events;
                            Console.WriteLine(S.ElementAt(i));
                        }
                    }
                }
            }
            else
            {
                //N(idEdition, S);
                for (int i = 0; i < S.Count; i++)
                {
                    for (int j = 0; j < S.ElementAt(i).News.Count; j++)
                    {
                        if (S.ElementAt(i).News[j] == idEdition)
                        {
                            Console.WriteLine("Абонент получил газету");
                            S.ElementAt(i).ReceivedNews = true;
                            S.ElementAt(i).Newspepar += Subscriber_Events;
                            S.ElementAt(i).ToGetT(S.ElementAt(i).msg1);
                            S.ElementAt(i).Newspepar -= Subscriber_Events;
                            Console.WriteLine(S.ElementAt(i));
                        }
                    }
                }
            }
        }
        
        static void AddPost(List<Subscriber> S, List<Newspaper> N, List<Magazines> M, ref PostOffice P)
        {
            for (int i = 0; i < S.Count; i++)
            {
                P.AddSubscriber(S[i]);
            }

            for (int i = 0; i < N.Count; i++)
            {
                P.AddNewspaper(N[i]);
            }

            for (int i = 0; i < M.Count; i++)
            {
                P.AddMagazin(M[i]);
            }
        }
        
        static void SubscribeS(ref List<Subscriber> S)
        {
            S.Add(new Subscriber("Андрей", "Яблуновский", "г.Докучаевск ул. Лермантова дом 2"));
            S.Add(new Subscriber("Иван", "Иванов", "г.Иванов ул. Иванова дом 1"));
            S.Add(new Subscriber("Петр", "Петров", "г.Петровск ул. ПетроЗаднипро дом 333"));
            S.Add(new Subscriber("Ильич", "Ульянов", "Москва пл. Красная дом 00"));
            S.Add(new Subscriber("Ирина", "Ирвина", "г.Киев ул. Андріївський узвіз дім 11"));
            S.Add(new Subscriber("Юлия", "Тимощук", "г.Киев ул. Борщагівська дім 11"));
        }

        static void NewspapeR(ref List<Newspaper> N)
        {
            N.Add(new Newspaper("Комсомольская правда",52));
            N.Add(new Newspaper("Факты и коментарии", 162));
            N.Add(new Newspaper("Дзеркало тижня. Україна", 52));
            N.Add(new Newspaper("Kyiv Post", 52));
            N.Add(new Newspaper("Факты и коментарии. Пятница", 52));
            N.Add(new Newspaper("Делаем сами", 24));
            N.Add(new Newspaper("Сельская жизнь в Украине", 52));
            N.Add(new Newspaper("Загадки и тайны", 12));
        }

        static void MagazinS(ref List<Magazines> M)
        {
            M.Add(new Magazines("Men's Health", 12));
            M.Add(new Magazines("MOTOGON", 12));
            M.Add(new Magazines("Украина за рулем", 12));
            M.Add(new Magazines("Світ Рибалки", 6));
            M.Add(new Magazines("Футбол", 106));
            M.Add(new Magazines("MAXIM", 12));
            M.Add(new Magazines("Мир подводной охоты", 6));
            M.Add(new Magazines("XXL", 12));
        }

        static void PrintM(List<Magazines> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                Console.WriteLine(A[i]);
            }
        }

        static void PrintN(List<Newspaper> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                Console.WriteLine(A[i]);
            }
        }

        static void PrintS(List<Subscriber> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                Console.WriteLine(A[i]);
            }
        }  
    }

    //public class Get
    //{
    //    public static void GetEditionM(int idEdition, List<Subscriber> S)
    //    {
    //        //int idEdition = IdFromName.ElementAt(ind).Key;
    //        //bool King = IdFromName.ElementAt(ind).Value.Inf;
    //        for (int i = 0; i < S.Count; i++)
    //        {
    //            for (int j = 0; j < S.ElementAt(i).Mag.Count; j++)
    //            {
    //                if (S.ElementAt(i).Mag[j] == idEdition)
    //                {
    //                    Console.WriteLine("Абонент получил журнал");
    //                    S.ElementAt(i).ReceivedMag = true;
    //                    S.ElementAt(i).Magazin += Subscriber_Events;
    //                    S.ElementAt(i).Accelerate(S.ElementAt(i).msg);
    //                    S.ElementAt(i).Magazin -= Subscriber_Events;
    //                    Console.WriteLine(S.ElementAt(i));
    //                }
    //            }
    //        }
    //    }

    //    public static void GetEditionN(int idEdition, List<Subscriber> S)
    //    {
    //        //int idEdition = IdFromName.ElementAt(ind).Key;
    //        //bool King = IdFromName.ElementAt(ind).Value.Inf;
    //        for (int i = 0; i < S.Count; i++)
    //        {
    //            for (int j = 0; j < S.ElementAt(i).News.Count; j++)
    //            {
    //                if (S.ElementAt(i).News[j] == idEdition)
    //                {
    //                    Console.WriteLine("Абонент получил газету");
    //                    S.ElementAt(i).ReceivedNews = true;
    //                    S.ElementAt(i).Newspepar += Subscriber_Events;
    //                    S.ElementAt(i).Accelerate(S.ElementAt(i).msg1);
    //                    S.ElementAt(i).Newspepar -= Subscriber_Events;
    //                    Console.WriteLine(S.ElementAt(i));
    //                }
    //            }
    //        }
    //    }

    //    static void Subscriber_Events(object sender, SubscriberEventArgs e)
    //    {
    //        Console.WriteLine("{0}", e.msg);
    //    }
    //}

    public struct Issue
    {
        string name;
        int Iss;
        public bool Inf;

        public Issue(string n, int i, bool In)
        {
            name = n;
            Iss = i;
            Inf = In;
        }

        public void GetIssue()
        {
            if(Inf==true)
                Console.WriteLine(" Журнал '{0}' №{1} ", name, Iss);
            else
                Console.WriteLine(" Газета '{0}' №{1} ", name, Iss);
        }
    }
}
