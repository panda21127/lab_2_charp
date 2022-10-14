using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Exam : IDateAndCopy
    {
        private string nameObject;
        private int mark;
        public DateTime date { get; set; }
        public Exam()
        {
            nameObject = "Math";
            mark = 4;
            date = new DateTime(2015, 7, 20);
        }
        public Exam(string nameTest, int markTest, int year, int month, int day)
        {
            nameObject = nameTest;
            mark = markTest;
            date = new DateTime(year, month, day);
        }

        public override string ToString()
        {
            string line;
            line = nameObject + " " + mark + " " + date.ToShortDateString();
            return line;
        }// короткая информация о экзаменах

        public int GetMark()
        {
            return mark;
        }// Средняя оценка за все экзамены
        public object DeepCopy()
        {
            Exam copyExample = new Exam();
            copyExample.nameObject = this.nameObject;
            copyExample.mark = this.mark;
            copyExample.date = this.date;
            return copyExample;
        }
        ~Exam()
        {
            //Console.WriteLine($"The {name_object},{mark},{Data_Exam}, finalizer is executing");
        }//Деструктор
    }
}
