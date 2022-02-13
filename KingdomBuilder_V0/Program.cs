using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdomBuilder_V0
{
    class Program
    {
        static void map(string[,] pole, string[,]lokace, int[] prev)
        {
         
            for (int X = 0; X < 10; X++)
            {
                for (int Y = 0; Y < 10; Y++)
                {
                    switch (lokace[X, Y])
                    {
                        case "1":
                            pole[prev[X], prev[Y]] = "/";
                            pole[prev[X], prev[Y] + 1] = "\\ ";
                            pole[prev[X] + 1, prev[Y]] = "█";
                            pole[prev[X] + 1, prev[Y] + 1] = "█ ";
                            break;
                        case "0":
                            pole[prev[X], prev[Y]] = ".";
                            pole[prev[X], prev[Y] + 1] = ". ";
                            pole[prev[X] + 1, prev[Y]] = ".";
                            pole[prev[X] + 1, prev[Y] + 1] = ". ";
                            break;
                        case "2":
                            pole[prev[X], prev[Y]] = "▲";
                            pole[prev[X], prev[Y] + 1] = ".. ";
                            pole[prev[X] + 1, prev[Y]] = "..";
                            pole[prev[X] + 1, prev[Y] + 1] = ".. ";
                            break;

                    }
                }
            }
            for (int i = 0; i < 20; i++)
            {
                for (int y = 0; y < 20; y++)
                {
                    switch (pole[i, y])
                    {
                        case "/":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("/");
                            break;
                        case "\\ ":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\\ ");
                            break;
                        case "█":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("█");
                            break;
                        case "█ ":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("█ ");
                            break;
                        case ".":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("░");
                            break;
                        case ". ":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("░ ");
                            break;
                        case "..":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("░");
                            break;
                        case ".. ":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("░ ");
                            break;
                        case "▲":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("▲");
                            break;
                    }
                }
                Console.WriteLine();
                if (i % 2 == 1) Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        static void Main(string[] args)
        {
         
            string[,] lokace = new string[10, 10];
            string[,] pole = new string[20, 20];
            int[] prev = {0,2,4,6,8,10,12,14,16,18};
            int penize = 10, jidlo = 10, drevo = 10, kamen = 10,pracovnici = 0, X, Y;
            bool hra= Convert.ToBoolean(1), akce ;
            for (X = 0; X < 10; X++)
            {
                for (Y = 0; Y < 10; Y++)
                {
                    lokace[X,Y] = "0";
                }
            }
            for (X = 0; X < 10; X++)
                {
                    for (Y = 0; Y < 10; Y ++)
                    {
                        switch(lokace[X,Y])
                        { case "1":
                                pole[prev[X], prev[Y]] =   "/";
                                pole[prev[X], prev[Y]+1] = "\\ " ;
                                pole[prev[X]+1, prev[Y]] = "█";
                                pole[prev[X]+1, prev[Y]+1] =  "█ ";
                                break;
                            case "0":
                                pole[prev[X], prev[Y]] =  ".";
                                pole[prev[X], prev[Y] + 1] = ". ";
                                pole[prev[X] + 1, prev[Y]] = ".";
                                pole[prev[X] + 1, prev[Y] + 1] = ". ";
                                break;
                        case "2":
                            pole[prev[X], prev[Y]] = "..";
                            pole[prev[X], prev[Y] + 1] = ".. ";
                            pole[prev[X] + 1, prev[Y]] = "..";
                            pole[prev[X] + 1, prev[Y] + 1] = ".. ";
                            break;

                        }
                    }
                }
           
            while (hra)
            {
                
                akce = Convert.ToBoolean(1);
                while (akce)
                {   Console.Clear();
                    Console.WriteLine(" penize:" + penize + " jidlo:" + jidlo + " drevo:" + drevo + " kamen:" + kamen + " pracovnici:" + pracovnici);
                    Console.WriteLine("Co si přejete ukonat milorde?" + Environment.NewLine + "1. Postavit Dům (5 jídla + 2 kameny + 5 dřeva)" + Environment.NewLine + "2. postavit farmu (5 dřeva + 1 pracovník)");
                    Console.WriteLine("3. už nic" + Environment.NewLine + "4. konec");
                    map(pole,lokace,prev);
                    int E = Convert.ToInt32(Console.ReadLine());
                    switch (E)
                    { case 1:
                            {
                                if (jidlo > 4)
                                {
                                    if (kamen > 1) 
                                    { 
                                        if (drevo > 4) 
                                        {      
                                                X =   Convert.ToInt32(Console.ReadLine());
                                                Y =   Convert.ToInt32(Console.ReadLine());
                                                lokace[X, Y] = "1";
                                            jidlo -= 5;
                                            kamen -= 2;
                                            drevo -= 5;
                                            pracovnici += 1;
                                        }
                                        else { Console.WriteLine("nedostatek jídla"); } 
                                    }
                                    else { Console.WriteLine("nedostatek kamene"); }
                                }
                                else { Console.WriteLine("nedostatek dřeva"); }


                            }
                            break;
                        case 2:
                            if (drevo > 4)
                            {
                                if (pracovnici > 0)
                                {
                                    
                                    
                                        X = Convert.ToInt32(Console.ReadLine());
                                        Y = Convert.ToInt32(Console.ReadLine());
                                        lokace[X, Y] = "2";
                                        drevo -= 5;
                                        pracovnici -= 1;
                                  
                                }
                                else { Console.WriteLine("nedostatek pracantů"); }
                            }
                            else { Console.WriteLine("nedostatek dřeva"); }
                            break;
                        case 3:
                            akce = Convert.ToBoolean(0);
                            break;

                        case 4:

                            break;

                    }
                    Console.ReadLine();
                }
                for (int i = 0; i < 10; i++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        switch(lokace[i,y])
                        { case "1":
                                drevo -= 1;
                                jidlo -= 1;
                                break;
                            case "2":
                                jidlo += 7;
                                break;
                        }
                    }
                }
                if(drevo < 0)
                { hra = Convert.ToBoolean(0); Console.Clear(); Console.WriteLine("došlo dřevo v celém království, všichni umrzli"); }
                if (drevo < 0)
                { hra = Convert.ToBoolean(0); Console.Clear(); Console.WriteLine("tvé království vymřelo hlady, všichni jsou mrtví"); }



            }
            Console.ReadLine();
        }
    }
}
