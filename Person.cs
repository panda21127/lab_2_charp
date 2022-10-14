using System;

namespace Person
{
    class Person : IDateAndCopy
    {
        protected string name;
        protected string surname;
        public DateTime date { get; set; }

        public Person()
        {
            name = "Tom";
            surname = "Holland";
            date = new DateTime(2015, 7, 20);
        }//Конструктор
        public Person(string nameTest, string surnameTest, int year, int month, int day)
        {
            name = nameTest;
            surname = surnameTest;
            date = new DateTime(year, month, day);
        }//Конструктор вводимый

        public void Print()
        {
            Console.WriteLine(name + "\n");
            Console.WriteLine(surname + "\n");
            Console.WriteLine(date + "\n");
        }// Вывод информации о человеке 

        public override string ToString()
        {
            string line;
            line = name + " " + surname + " " + date.ToShortDateString();
            return line;
        }//Короткая информация о человеке

        public virtual string ToShortString()
        {
            string line;
            line = name + " " + surname;
            return line;
        }//Краткая информация о человеке

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Person);
        }
        public  bool Equals(Person obj)
        {
            if (!this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person person = (Person)obj;
                return (name == person.name) && (surname == person.surname) && (date == person.date);
            }
        }

        public static bool operator ==(Person A1, Person A2)
        {
            if ((A1.name == A2.name) && (A1.surname == A2.surname) && (A1.date == A2.date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Person A1, Person A2)
        {
            return !(A1==A2);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + surname.GetHashCode() + date.GetHashCode();
        }
        public virtual object DeepCopy()
        {
            Person copyExample = new Person();
            copyExample.name = this.name;
            copyExample.surname = this.surname;
            copyExample.date = this.date;
            return (Person)copyExample;
        }
        ~Person() { }//Деструктор
    }
}
