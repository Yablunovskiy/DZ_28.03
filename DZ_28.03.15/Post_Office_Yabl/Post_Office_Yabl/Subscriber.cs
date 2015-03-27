using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Post_Office_Yabl
{
    
    class Subscriber
    {
        string Name;
        string SName;
        string Address;
        public List<int> Mag;
        public List<int> News;
        public bool ReceivedNews { set; get; }
        public bool ReceivedMag { set; get; }
        public string msg { set; get; }
        public string msg1 { set; get; }

        public Subscriber()
        {
                
        }

        public Subscriber(string name, string Sname, string address)
        {
            Name = name;
            SName = Sname;
            Address = address;
            Mag= new List<int>();
            News = new List<int>();
            ReceivedNews = false;
            ReceivedMag = false;
        }

        

        public void AddMagazines(int Id)
        {
            Mag.Add(Id);
        }

        public void AddNewspaper(int Id)
        {
            News.Add(Id);
        }

        //public void AddNewspaper(Newspaper N)
        //{
        //    News.Add(N);
        //}

        public delegate void SubscriberEngineHandler(object sender, SubscriberEventArgs e);

        /*        public event EventHandler<CarEngineHandler> Exploded;
                public event EventHandler<CarEngineHandler> AboutToBlow;*/

        public event SubscriberEngineHandler Magazin;
        public event SubscriberEngineHandler Newspepar;

        public void ToGetT(string msg)
        {
            if (ReceivedMag)
            {
                if (Magazin != null)
                    Magazin(this, new SubscriberEventArgs(msg/*"Я рад что получил этот журнал. "*/));
                ReceivedMag = false;
            }
            if (ReceivedNews)
            {
                if (Newspepar != null)
                    Newspepar(this, new SubscriberEventArgs(msg/*"О... будет чем развести костер. "*/));
                ReceivedNews = false;
            }
        }

        public override string ToString()
        {
            return String.Format("\n\tИмя: {0} \n\t Фамилия: {1} \n\t  Адресс рассылки: {2}\n", Name, SName, Address);
        }

        public void Podpiska( PostOffice P)
        {

            Console.WriteLine();
            for (int i = 0; i < Mag.Count; i++)
            {
                Magazines Now = new Magazines();
                if (P.idMagazines.TryGetValue(Mag[i], out Now))
                    Console.WriteLine(Now);
            }
            for (int i = 0; i < News.Count; i++)
            {
                Newspaper Now = new Newspaper();
                if(P.idNewspaper.TryGetValue(News[i], out Now))
                    Console.WriteLine(Now);
            }
        }
        static void Subscriber_Events(object sender, SubscriberEventArgs e)
        {
            Console.WriteLine("{0}", e.msg);
        }

        public delegate void ToGet(int idEdition, List<Subscriber> S);
        private ToGet ListToGet;
        public void RegistrWithToGet(ToGet methodForToGet)
        {
            ListToGet = methodForToGet;
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


    public class SubscriberEventArgs : EventArgs
    {
        public readonly string msg;
        public SubscriberEventArgs(string message)
        {
            msg = message;
        }
    }
}
