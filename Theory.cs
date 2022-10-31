using Microsoft.VisualBasic;

namespace Lab_7
{
    class Football
    {
        public string name;
        public int points;

        public Football(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }

    class SecondFootball
    {
        public int Goals1;
        public int Goals2;
        public int Points1;
        public int Points2;
        public int Difference1;
        public int Difference2;
        private static int win = 3;
        private static int lose = 0;
        private static int tie = 1;
        public SecondFootball(int Goals1, int Goals2)
        {
            this.Goals1 = Goals1;
            this.Goals2 = Goals2;
            if (Goals1 > Goals2)
            {
                Points1 = win;
                Points2 = lose;
            }
            else if (Goals1 < Goals2)
            {
                Points1 = lose;
                Points2 = win;
            }
            else
            {
                Points1 = tie;
                Points2 = tie;
            }
            Difference1 = Goals1 - Goals2;
            Difference2 = Goals2 - Goals1;
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            static void Task2_3lvl()
            {
                int n;
                List<string> Teams = new List<string>();
                Football[] C = new Football[12];
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"{i + 1} group:");
                    for (int j = 0; j < 12; j++)
                    {
                        Console.WriteLine("Enter the number of points:");
                        if (int.TryParse(Console.ReadLine(), out n))
                        {
                            Console.WriteLine("Enter the name of team:");
                            C[j] = new Football(Console.ReadLine(), n);
                        }
                    }
                    C.OrderBy(x => x.points);
                    for (int j = 0; j < 6; j++)
                    {
                        Teams.Add(C[j].name);
                    }
                }

                Console.WriteLine("12 best teams:");
                Console.WriteLine(String.Join("\n", Teams));
            }

            static void Task5_3lvl()
            {
                Dictionary<string, Tuple<int, int>> Table = new Dictionary<string, Tuple<int, int>>();
                List<Tuple<string, int, int>> FinalTable = new List<Tuple<string, int, int>>();
                do
                {
                    Console.WriteLine("Enter -1 to stop");
                    Console.WriteLine("Enter the match like this: Team1 3-2 Team2");
                    string s = Console.ReadLine();
                    if (s == "-1") break;
                    string[] array = s.Split("-");
                    string[] array1 = new string[2];
                    List<int> goals = new List<int>();
                    List<string> names = new List<string>();
                    int Goals;
                    int k = 1;
                    int Points1 = 0;
                    int Points2 = 0;
                    int Difference1 = 0;
                    int Difference2 = 0;
                    foreach (var x in array)
                    {
                        array1 = x.Split(" ");
                        if (k == 1)
                        {
                            names.Add(array1[0]);
                            if (!Table.ContainsKey(array1[0])) Table.Add(array1[0], Tuple.Create(0, 0));
                            if (int.TryParse(array1[1], out Goals)) goals.Add(Goals);
                            k = 0;
                        }
                        else
                        {
                            names.Add(array1[1]);
                            if (!Table.ContainsKey(array1[1])) Table.Add(array1[1], Tuple.Create(0, 0));
                            if (int.TryParse(array1[0], out Goals)) goals.Add(Goals);
                            k = 1;
                        }
                    }
                    Console.WriteLine(String.Join(" ", goals));
                    SecondFootball C = new SecondFootball(goals[0], goals[1]);
                    Points1 = Table[names[0]].Item1 + C.Points1;
                    Difference1 = Table[names[0]].Item2 + C.Difference1;
                    Table[names[0]] = Tuple.Create(Points1, Difference1);
                    Points2 = Table[names[1]].Item1 + C.Points2;
                    Difference2 = Table[names[1]].Item2 + C.Difference2;
                    Table[names[1]] = Tuple.Create(Points2, Difference2);
                } while (true);
                foreach (var x in Table)
                {
                    FinalTable.Add(Tuple.Create(x.Key, x.Value.Item1, x.Value.Item2));
                }
                FinalTable.Sort((x1, x2) => x2.Item2.CompareTo(x1.Item2));
                FinalTable.Sort((x1, x2) => x2.Item3.CompareTo(x1.Item3));
                Console.WriteLine("Final table:");
                foreach (var x in FinalTable) 
                {
                    Console.WriteLine($"{x.Item1} team - {x.Item2} points, {x.Item3} difference");
                }
            }
            Task2_3lvl();
            Task5_3lvl();
        }
    }
}
