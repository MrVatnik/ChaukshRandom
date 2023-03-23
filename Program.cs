using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChaukshRandom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random((int)DateTime.Now.Ticks);



            int filmsCount = 24;


            List<string> People = new List<string>()
            {
                "Никита",
                "Илья",
                "Юра",
                "Кирилл",
                "Вова",
                "Олег",
                "Аня",
                "Валера",
                "Саша"/*,
                "Тимон"*/
            };

            Dictionary<string,List<int>> Res = new Dictionary<string,List<int>>(); //тут будет результат

            foreach (string person in People) //наполняем результат людьми
            {
                Res.Add(person, new List<int>());
            }


            List<int> films = new List<int>(); //список всех плёнок
            for(int i = 1; i <= filmsCount; i++)
            {
                films.Add(i);//заполняем список всех плёнок числами
            }


            int maxCount = 0;
            int minCount = 0;

            while(films.Count > 0)
            {
                int person;
                person = rand.Next() % People.Count;     //случайному человеку

                while (Res[People[person]].Count != minCount)   // всегда тому, у кого меньше всего плёнки
                {
                    person = rand.Next() % People.Count;
                }

                int film = films[rand.Next() % films.Count]; //случайную плёнку
                Res[People[person]].Add(film);
                films.Remove(film);                         //удаляем из списка плёнок чтобы не повторялось



                int newmin=maxCount;                //считаем максимум и минимум уже распределённых плёнок на руках
                foreach(string key in Res.Keys)
                {
                    if (Res[key].Count >= maxCount)
                        maxCount = Res[key].Count;
                    if(Res[key].Count < newmin)
                        newmin = Res[key].Count;
                }
                minCount = newmin;
            }




            foreach (string key in Res.Keys)                    //отсортируем по возрастанию плёнки у каждого участника
            {
                Res[key] = Res[key].OrderBy(x => x).ToList();
            }

            
            
            
            foreach (string key in Res.Keys)        //выводим числа
            {
                string temp = key + ": ";

                foreach(int film in Res[key])
                {
                    temp+= film + ", ";
                }

                Console.WriteLine(temp); 
                Console.WriteLine("");
            }



            String resString = "";

            for(int i = 1; i <= filmsCount; i++)    //выводим последовательность людей
            {
                for(int j=0;j<People.Count;j++)
                {
                    if (Res[People[j]].Contains(i))
                    {
                        resString += People[j] + ", ";
                        j = People.Count;
                    }
                }

                if(i%10==0)
                {
                    resString += "\n";
                }
            }

            Console.WriteLine(resString);





            Console.ReadLine();
        }
    }
}
