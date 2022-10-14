using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace Person
{
    class Program
    {
        static void Main()
        {
            Student student = new Student(); // Создание объекта класса Student по встроенному конструктору
            Student student2 = new Student(new Person("Bill", "Herringtan", 1998, 4, 2), Education.Bachelor, 3);// Создание объекта класса Student вручную


            ArrayList exams = new ArrayList();
            ArrayList tests = new ArrayList();
            Console.WriteLine(student.ToString());
            exams.Add(new Exam("Russian", 3, 2004, 4, 12));
            tests.Add(new Test("Russian", false));
            student.AddExams(exams);//Присваивание студентам экзамены
            student.AddTest(tests);//Присваивание студентам тесты


            Console.WriteLine(student.ToString());
            Console.WriteLine(student.ToShortString());//Краткая информация о классе Student
            Console.WriteLine("==============================");

            Console.WriteLine(student.Students.ToString());

            Person person = new Person();
            Person person2 = new Person();
            Console.WriteLine("Ссылки {0}",Object.ReferenceEquals(person2, person));
            Console.WriteLine(person2.ToString());
            Console.WriteLine("HashCode1 {0}", person.GetHashCode());
            Console.WriteLine("HashCode2 {0}", person2.GetHashCode());
            Console.WriteLine(person == person2);
            Console.WriteLine(person.Equals(person2));

            Console.WriteLine(person.ToString());
            person2 = (Person)person.DeepCopy();
            person = new Person("Bill", "Herringtan", 1998, 4, 2);
            Console.WriteLine(person.ToString());
            Console.WriteLine(person2.ToString());
            Console.WriteLine(person.ToString());
            Console.WriteLine(person == person2);
            Console.WriteLine(person.Equals(person2));
            Console.WriteLine("==============================");


            foreach (var task in student.GetResults())
                Console.WriteLine(task.ToString());
            Console.WriteLine(" ");
            foreach (var task in student.ExamsOver(3))
                Console.WriteLine(task.ToString());
        }
    }
}
