using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Green_2
    {
        public struct Student // Публичная структура студента.
        {
            private string _name; // Его имя.
            private string _surname; // Его фамилия.
            private int[] _marks; // Его оценки.

            public Student(string name, string surname) // Публичный конструктор, принимающий имя и фамилию, инициализирует массив оценок по нулям.
            {
                _name = name ?? "";
                _surname = surname ?? "";
                _marks = new int[4];
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = 0;
                }
            }
            public readonly string Name // Свойство имени.
            {
                get { return _name ?? ""; }
            }
            public readonly string Surname // Свойство фамилии.
            {
                get { return _surname ?? ""; }
            }
            public readonly int[] Marks // Свойство оценок.
            {
                get { return _marks != null ? (int[])_marks.Clone() : []; }
            }
            public double AvgMark // Свойство, возвращающее средний балл.
            {
                get
                {
                    if (_marks.Length == 0 || _marks == null)
                    {
                        return 0;
                    }
                    double sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _marks.Length;
                }
            }
            public bool IsExcellent // Свойство, возвращающее истину, если все оценки >= 4.
            {
                get
                {
                    if (_marks.Length == 0 || _marks == null)
                    {
                        return false;
                    }
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] < 4)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            public void Exam(int mark) // Студент одноразово проходит экзамен и получает оценку за него.
            {
                if (_marks.Length == 0 || _marks == null)
                {
                    return;
                }
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }
            public static void SortByAvgMark(Student[] array) // Статический метод сортировки массива студентов по убыванию среднего балла.
            {
                if (array == null || array.Length == 0)
                { return; }
                Array.Sort(array, (s1, s2) => s2.AvgMark.CompareTo(s1.AvgMark));
            }
            public void Print() // Публичный метод для вывода информации о необходимых полях структуры.
            {
                Console.WriteLine("{0,-12} {1,-12} {2,-12:F2} {3,-12}", Name, Surname, AvgMark, IsExcellent);
            }
            public static void PrintAll(Student[] students) // Публично-статичный метод для полного вывода.
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-13} {3,-10}", "Name", "Surname", "AvgMark", "Result");
                Console.WriteLine(new string('—', 60));

                foreach (var p in students)
                {
                    p.Print();
                }
                Console.WriteLine(new string('—', 60));
            }
        }
    }
}