using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace Person
{
    public enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    class Student : Person, IDateAndCopy
    {
        private Person student;
        private Education infStudy;
        private int numberGroup;
        private ArrayList tests;
        private ArrayList exams;

        public Student()
        {
            student = new Person();
            infStudy = Education.Specialist;
            numberGroup = 101;
            ArrayList test_test = new ArrayList();
            test_test.Add(new Test());
            Tests = test_test;
            ArrayList exams_test = new ArrayList();
            exams_test.Add(new Exam());
            exams = exams_test;
        } //Конструктор пассивный
        public Student(Person studentTest, Education educationTest, int numberGroupTest)
        {
            student = studentTest;
            infStudy = educationTest;
            NumberGroup = numberGroupTest;
            ArrayList test_test = new ArrayList();
            ArrayList exams_test = new ArrayList();
            Tests = test_test;
            Exams = exams_test;

        }//Конструктор вбиваемый

        public ArrayList Tests{
            get
            {
                return tests;
            }
            set
            {
                tests = value;
            }
        }
        public ArrayList Exams{
            get {
                return exams;
            }
            set {
                exams = value;
            }
        }
        public int NumberGroup
        {
            get{ 
                return numberGroup;
            }
            set{
                try
                {
                    if (value <= 100 || value > 599) {
                        throw new ArgumentOutOfRangeException($"\nOutOfRange!\n");
                    }
                    else {
                        this.numberGroup = value;
                    }
                }
                catch(ArgumentOutOfRangeException argumentOutOfRangeException)
                {
                    Console.WriteLine($"Ошибка: {argumentOutOfRangeException}");
                    System.Environment.Exit(0);
                }
            }
        }

public void GetPrintExams()
        {
            if (Exams == null)
            {
                Console.WriteLine("No Exams");
            }
            else
            {
                for (int i = 0; i < Exams.Count; i++)
                {
                    Console.WriteLine(Exams[i].ToString() + "\n");
                }
            }
        } //Вывод списка экзаменов
        public void AddTest(ArrayList items)
        {
            foreach (Test test_test in items)
            {
                Tests.Add(test_test);
            }
        }
        public void AddExams(ArrayList items)
        {
            foreach (Exam exam_test in items)
            {
                Exams.Add(exam_test);
            }
        }
        public double MediumMark(ref ArrayList exams)
        {
            int summa = 0;
            int count = 0;
            double medium;
            if (Exams == null)
            {
                medium = 0;
            }
            else
            {
                foreach (Exam i in exams)
                {
                    summa = summa + i.GetMark();
                    count++;
                }
                medium = (double)summa / count;
            }
            return medium;
        }// Средняя оценка за сумму всех экзаменов
        public bool this[Education frame]
        {
            get { return (frame == Education.Specialist); }
        }
        public bool CheckEducation(Education infStudyTest)
        {
            Console.WriteLine(infStudy == infStudyTest);
            return infStudy == infStudyTest;
        } //Проверка степени образование студента для класса Student

        public IEnumerable GetResults()
        {
            foreach (var exam in Exams)
                yield return exam;
            foreach (var test in Tests)
                yield return test;
        }

        public IEnumerable ExamsOver(int minRate)
        {
            foreach (var exam in Exams)
            {
                Exam ex = (Exam)exam;
                if (ex.GetMark() > minRate)
                    yield return exam;
            }
        }
        public override string ToString()
        {
            string line = (student.ToShortString() + "\nInformation about study:  " + infStudy + "\nGroup:" + numberGroup
                + "\nExams: ");
            if (Exams == null)
            {
                line += "No Exams";
            }
            else
            {
                for (int i = 0; i < Exams.Count; i++)
                {
                    line += (Exams[i].ToString() + "\n");
                }
            }
            return line;
        }//Короткая информация о классе Student

        public override string ToShortString()
        {
            string line = (student.ToShortString() + "\nInformation about study:  " + infStudy + "\nGroup:" + numberGroup
                + "\nAverage rating: " + MediumMark(ref exams));
            return line;
        }//Краткая информация о классе Student
        public override object DeepCopy()
        {
            Student copyExample = new Student();
            copyExample.student = this.student;
            copyExample.infStudy = this.infStudy;
            copyExample.numberGroup = this.numberGroup;
            copyExample.exams = this.exams;
            return (Student)copyExample;
        }
        ~Student() { }//Деструктор
    }
}
