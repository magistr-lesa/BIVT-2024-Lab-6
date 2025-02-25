using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Green_3
    {
        public struct Student // Публичная структура студента.
        {
            private string _name; // Его имя.
            private string _surname; // Его фамилия.
            private int[] _marks; // Его оценки. 
            private bool _isExpelled; // Его статус отчисления.
            private int _examCount; // Его кол-во экзаменов.
            private int _passedCount; // Для подсчёта кол-ва людей, прошедших все экзамены.
            public Student(string name, string surname)  // Публичный конструктор, принимающий имя и фамилию, инициализирует массив оценок по нулям.
            {
                _name = name ?? "";
                _surname = surname ?? "";
                _marks = new int[3];
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = 0;
                }
                _isExpelled = false;
                _examCount = 0;
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
                    if (_marks == null || _examCount == 0)
                    {
                        return 0;
                    }
                    double sum = 0;
                    for (int i = 0; i < _examCount; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _examCount;
                }
            }
            public bool IsExpelled // Свойство, возвращающее статус отчисления.
            {
                get
                {
                    if (_marks.Length == 0 || _marks == null)
                    {
                        return false;
                    }
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] <= 2)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public void Exam(int mark) // Студент одноразово проходит экзамен и получает оценку за него.
            {
                if (_marks.Length == 0 || _marks == null)
                {
                    return;
                }
                if (_examCount >= 3)
                {
                    return;
                }
                if (!_isExpelled)
                {
                    if (mark > 2)
                    {
                        _marks[_examCount] = mark;
                        _examCount++;
                    }
                    else
                    {
                        _marks[_examCount] = mark;
                        _examCount++;
                        _isExpelled = true;
                    }
                    if (_examCount == 3 && !_isExpelled)
                    {
                        _passedCount++;
                    }
                }
            }
            public static void SortByAvgMark(Student[] array) // Статический метод сортировки массива студентов по убыванию среднего балла.
            {
                if (array == null || array.Length == 0)
                    return;
                Array.Sort(array, (s1, s2) => s2.AvgMark.CompareTo(s1.AvgMark));
            }
            public void Print() // Публичный метод для вывода информации о необходимых полях структуры.
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-15:F2} {3,-10}", Name, Surname, AvgMark, IsExpelled);
            }
            public static void PrintAll(Student[] students) // Публично-статичный метод для полного вывода.
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-15} {3,-10}", "Name", "Surname", "Average mark", "is expelled");
                Console.WriteLine(new string('—', 60));

                foreach (var s in students)
                {
                    s.Print();
                }
                Console.WriteLine(new string('—', 60));
            }
        }
    }
}