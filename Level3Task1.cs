using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using System.Windows.Markup;

class HelloWorld
{
    static Group[] Sorti(Group[] A)
    {
        int left = 0;
        int right = A.Length - 1;

        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (A[i].GroupSredmark < A[i + 1].GroupSredmark)
                {
                    Group x = A[i];
                    A[i] = A[i + 1];
                    A[i + 1] = x;
                }

            }
            right--;

            for (int i = right; i > left; i--)
            {
                if (A[i - 1].GroupSredmark < A[i].GroupSredmark)
                {
                    Group x = A[i];
                    A[i] = A[i - 1];
                    A[i - 1] = x;
                }
            }
            left++;
        }
        return A;
    }
    class Student
    {
        public string Surname;
        public double[] Marks;
        public double sredmark;
        public Student(string Surname, double[] Marks, int m)
        {
            this.Surname = Surname;
            this.Marks = Marks;
            double sum = 0;
            for (int i = 0; i < m; i++)
            {
                sum = sum + Marks[i];
            }
            this.sredmark = sum / m;
        }
    }
    class Group
    {
        public string GroupName;
        public int KollvoStudents;
        public double GroupSredmark;
        public Student[] Students;
        public Group(string GroupName, int KollvoStudents, Student[] students)
        {
            this.GroupName = GroupName;
            this.KollvoStudents = KollvoStudents;
            this.Students = students;
            double sum = 0;
            for (int i = 0; i < KollvoStudents; i++)
            {
                sum = sum + students[i].sredmark;
            }
            this.GroupSredmark = sum / KollvoStudents;
        }
    }
    static int Main()
    {
        Console.WriteLine("Enter the number of Group: ");
        int n;
        int.TryParse(Console.ReadLine(), out n);
        Console.WriteLine("Enter the number of exams: ");
        int m;
        int.TryParse(Console.ReadLine(), out m);
        if (n <= 0 || m <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
        Group[] Gropus = new Group[n];
        for (int i = 0; i < n; i++) // Ââîäèò ãðóïïó
        {
            Console.WriteLine("Enter the name of Group number " + (i + 1) + ":");
            string GroupName = Console.ReadLine();
            Console.WriteLine("Enter the number of students on group - " + GroupName + ": ");
            int p;
            int.TryParse(Console.ReadLine(), out p);
            if (p <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
            Student[] student = new Student[p];
            double[] sredmars = new double[p];
            for (int j = 0; j < p; j++) //Ââîäèò ñòóäåíòà
            {
                double[] marks = new double[m];
                Console.WriteLine("Enter the surname of student number " + (j + 1) + ":");
                string surname = Console.ReadLine();
                string[] line;
                Console.WriteLine("Enter the results of exams for Student - " + surname + ": ");
                while (true)
                {
                    line = Console.ReadLine().Split(" ");
                    if (line.Length != m) { Console.WriteLine("Re-enter the row!"); continue; }
                    else break;
                }
                for (int l = 0; l < m; l++)
                {
                    double x;
                    if (double.TryParse(line[l], out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                    double.TryParse(line[l], out x);
                    marks[l] = x;
                }
                student[j] = new Student(surname, marks, m);
            }
            Gropus[i] = new Group(GroupName, p, student);
        }
        Sorti(Gropus);
        Console.WriteLine("The list of TOP: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(Gropus[i].GroupName + " - " + Gropus[i].GroupSredmark);
        }
        return 0;
    }
}
