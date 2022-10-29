using System;
using System.Text.RegularExpressions;
namespace _6th_Lab


{
    class Persona
    {
        public string name;
    }

    class Student: Persona
    {
        public List<int> grades = new List<int>();
        public double mean_grade = 0;

        public Student(List<int> x, string name = "UNK")
        {
            int n = x.Count;
            double sum = 0;

            for (int i = 0; i  < n; i++)
            {
                grades.Add(x[i]);
                sum += x[i];
            }

            if (n > 0)
            {
                mean_grade = sum / n;
            }
            this.name = name;
        }
    }

    class Group
    {
        public string name = "unk";
        public List<Student> students = new List<Student>();

        public Group(List<Student> students, string name = "unk")
        {
            this.name = name;
            this.students = students;
        }

        public double calculate_mean_grade()
        {
            int n = students.Count;
            double sum = 0, ans = 0;

            foreach (Student s in students)
            {
                sum += s.mean_grade;
            }

            if (n > 0)
            {
                ans = sum / n;
            }

            return ans;
        }
    }

    class SkiAthlete: Persona
    {
        public double res1, res2, sum;

        public SkiAthlete(double res1, double res2, string name = "unk")
        {
            this.name = name;
            this.res1 = res1;
            this.res2 = res2;
            sum = res1 + res2;
        }
    }

    class Program
    {
        class StudentsComparer : IComparer<Student>
        {
            public int key = 1;

            public StudentsComparer(int k)
            {
                key = k;
            }

            public int Compare(Student stud1, Student stud2)
            {
                if (stud1.mean_grade < stud2.mean_grade)
                {
                    return -key;
                }
                if (stud1.mean_grade > stud2.mean_grade)
                {
                    return key;
                }
                return 0;
            }
        }

        static void sort_overall(List<SkiAthlete> x)
        {
            IOrderedEnumerable<SkiAthlete> xx = x.OrderBy(g => g.sum);

            foreach (SkiAthlete s in xx)
            {
                Console.WriteLine($"{s.name}    -       {s.sum}");
            }
        }

        static void sort_1(List<SkiAthlete> x)
        {
            IOrderedEnumerable<SkiAthlete> xx = x.OrderBy(g => g.res1);

            foreach (SkiAthlete s in xx)
            {
                Console.WriteLine($"{s.name}    -       {s.res1}");
            }
        }

        static void sort_2(List<SkiAthlete> x)
        {
            IOrderedEnumerable<SkiAthlete> xx = x.OrderBy(g => g.res2);

            foreach (SkiAthlete s in xx)
            {
                Console.WriteLine($"{s.name}    -       {s.res2}");
            }
        }

        static void Main(string[] args)
        {
            #region level 3

            #region task 1
            Console.WriteLine("task 1");
            {
                int grades_number = 5, groups_number = 3;
                Group[] groups = new Group[groups_number];

                for (int i = 0; i < groups_number; i++)
                {
                    Console.WriteLine("enter number of group");
                    string group_number = Console.ReadLine();

                    List<Student> students = new List<Student>();

                    Console.WriteLine("enter -1 as a stop sign");

                    while (true)
                    {
                        Console.WriteLine("enter student's surname");
                        string surname = Console.ReadLine();

                        if (surname == "-1")
                        {
                            break;
                        }

                        Console.WriteLine($"enter {grades_number} grades in a row");

                        string[] row = Console.ReadLine().Split(" ");

                        if (row.Count() != grades_number)
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }

                        List<int> tmp = new List<int>();

                        foreach (string s in row)
                        {
                            int value;
                            if (!int.TryParse(s, out value) || value < 2 || value > 5)
                            {
                                Console.WriteLine("incorrect format");
                                return;
                            }

                            tmp.Add(value);
                        }

                        Student stud = new Student(tmp, surname);
                        students.Add(stud);
                    }

                    groups[i] = new Group(students, group_number);
                }

                IOrderedEnumerable<Group> groups1 = groups.OrderBy(g => -g.calculate_mean_grade());

                Console.WriteLine("group number\tmean grade");
                foreach (Group g in groups1)
                {
                    Console.WriteLine($"{g.name}    -   {g.calculate_mean_grade()}");
                }
            }
            #endregion

            #region task 4
            Console.WriteLine("task 4");
            {
                List<SkiAthlete> skiers = new List<SkiAthlete>();

                Console.WriteLine("write -1 as a stop sign when asking for a name");

                while (true)
                {
                    Console.WriteLine("enter name");
                    string name = Console.ReadLine();

                    if (name == "-1")
                    {
                        break;
                    }

                    Console.WriteLine("please enter the first and the second result respectively in a row");

                    string[] row = Console.ReadLine().Split(" ");

                    if (row.Count() != 2)
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }

                    List<double> tmp = new List<double>();

                    foreach (string s in row)
                    {
                        double value;
                        if (!double.TryParse(s, out value))
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }
                        tmp.Add(value);
                    }

                    SkiAthlete skier = new SkiAthlete(tmp[0], tmp[1], name);
                    skiers.Add(skier);
                }

                Console.WriteLine("name    -       result");
                Console.WriteLine();
                Console.WriteLine("1.");
                sort_1(skiers);
                Console.WriteLine();
                Console.WriteLine("2.");
                sort_2(skiers);
                Console.WriteLine();
                Console.WriteLine("overall.");
                sort_overall(skiers);
            }
            #endregion

            #endregion
        }
    }
}