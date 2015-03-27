using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_Office_Yabl
{
    class PostOffice
    {
        public Dictionary<int, Magazines> idMagazines;
        int idM = 0;
        public Dictionary<int, Newspaper> idNewspaper;
        int idN = 1000;
        public Dictionary<int, Subscriber> IdSubscriber;
        int IdS = 100000;
        public Dictionary<int, int> idFromId;

        public PostOffice()
        {
            idMagazines = new Dictionary<int, Magazines>();
            idNewspaper = new Dictionary<int, Newspaper>();
            IdSubscriber = new Dictionary<int, Subscriber>();
            idFromId = new Dictionary<int, int>();    
        }

        public void AddMagazin(Magazines M)
        {
            idMagazines.Add(idM++, M);
        }

        public void AddNewspaper(Newspaper N)
        {
            idNewspaper.Add(idN++, N);
        }

        public void AddSubscriber(Subscriber S)
        {
            IdSubscriber.Add(IdS++, S);
        }

        public int IdMagazin(int ind)
        {
            return idMagazines.ElementAt(ind).Key;
        }

        public int IdNewspaper(int ind)
        {
            return idNewspaper.ElementAt(ind).Key;
        }

        public void AddidFromId(Dictionary<int, Subscriber> S, Dictionary<int, Magazines> M, Dictionary<int, Newspaper> N)
        {
            for (int i = 0; i < M.Count; i++)
            {
                
            }
        }

        //static void AddPost(List<Subscriber> S, List<Newspaper> N, List<Magazines> M, ref PostOffice P)
        //{
        //    for (int i = 0; i < S.Count; i++)
        //    {
        //        P.AddSubscriber(S[i]);
        //    }

        //    for (int i = 0; i < N.Count; i++)
        //    {
        //        P.AddNewspaper(N[i]);
        //    }

        //    for (int i = 0; i < M.Count; i++)
        //    {
        //        P.AddMagazin(M[i]);
        //    }
        //}

        public void Print()
        {
            for (int i = 0; i < idMagazines.Count; i++)
            {
                Console.WriteLine(idMagazines.ElementAt(i));
            }
            Console.WriteLine();
            for (int i = 0; i < idNewspaper.Count; i++)
            {
                Console.WriteLine(idNewspaper.ElementAt(i));
            }
            Console.WriteLine();
            for (int i = 0; i < IdSubscriber.Count; i++)
            {
                Console.WriteLine(IdSubscriber.ElementAt(i));
            }
        }
    }
}
