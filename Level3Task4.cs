using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;
using System.Net.Mail;
using System.Runtime.ExceptionServices;
using System.Windows.Markup;

class HelloWorld
{
    static Student[] Sorti(Student[] A)
    {
        int left = 0;
        int right = A.Length - 1;

        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (A[i].Marks < A[i + 1].Marks)
                {
                    Student x = A[i];
                    A[i] = A[i + 1];
                    A[i + 1] = x;
                }

            }
            right--;

            for (int i = right; i > left; i--)
            {
                if (A[i - 1].Marks < A[i].Marks)
                {
                    Student x = A[i];
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
        public double Marks;
        public Student(string Surname, double Marks)
        {
            this.Surname = Surname;
            this.Marks = Marks;
        }
    }
    class Group
    {
        public string GroupName;
        public int KollvoStudents;
        public Student[] Students;
        public Group(string GroupName, int KollvoStudents, Student[] students)
        {
            this.GroupName = GroupName;
            this.KollvoStudents = KollvoStudents;
            this.Students = students;
        }
    }
    static int Main()
    {
        Console.WriteLine("Enter the number of Group: ");
        int n;
        int z = 0;
        int.TryParse(Console.ReadLine(), out n);
        if (n <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
        Group[] Gropus = new Group[n];
        for (int i = 0; i < n; i++) // Вводит группу
        {
            Console.WriteLine("Enter the name of Group number " + (i + 1) + ":");
            string GroupName = Console.ReadLine();
            Console.WriteLine("Enter the number of sportsman on group - " + GroupName + ": ");
            int p;
            int.TryParse(Console.ReadLine(), out p);
            if (p <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
            Student[] student = new Student[p];
            double[] sredmars = new double[p];
            for (int j = 0; j < p; j++) //Вводит студента
            {
                z++;
                Console.WriteLine("Enter the surname of sportsman number " + (j + 1) + ":");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter the result of exams for spotsman - " + surname + ": ");
                double x;
                string line;
                line = Console.ReadLine();
                if (double.TryParse(line, out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                double.TryParse(line, out x);
                student[j] = new Student(surname, x);
            }
            Gropus[i] = new Group(GroupName, p, student);
        }
        for (int i = 0; i < n; i++)
        {
            Sorti(Gropus[i].Students);
        }
        Student[] obsh = new Student[z];
        int l = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < Gropus[i].KollvoStudents; j++)
            {
                obsh[l] = Gropus[i].Students[j];
                l++;
            }
        }
        Sorti(obsh);
        Console.WriteLine("The general summary list:");

        for (int i = 0; i < z; i++)
        {
            Console.WriteLine(obsh[i].Surname + " - " + obsh[i].Marks);
        }

        Console.WriteLine();
        Console.WriteLine("The group list:");

        for (int j = 0; j < n; j++)
        {

            Console.WriteLine("The list of TOP of Group <" + Gropus[j].GroupName + ">: ");
            for (int i = 0; i < Gropus[j].KollvoStudents; i++)
            {
                Console.WriteLine(Gropus[j].Students[i].Surname + " - " + Gropus[j].Students[i].Marks);
            }
        }
        return 0;
    }
}
