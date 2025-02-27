using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
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
                _name = name;
                _surname = surname;
                _marks = new int[4];
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = 0;
                }
            }
            public string Name // Свойство имени.
            {
                get { return _name; }
            }
            public string Surname // Свойство фамилии.
            {
                get { return _surname; }
            }
            public int[] Marks // Свойство оценок.
            {
                get { return _marks != null ? (int[])_marks.Clone() : []; }
            }
            public double AvgMark // Свойство, возвращающее средний балл.
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
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
                    if (_marks == null || _marks.Length == 0)
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
                if (_marks == null || _marks.Length == 0)
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
            public static void SortByAvgMark(Student[] array)
            {
                if (array == null || array.Length == 0)
                    return;
                bool swapped;
                do
                {
                    swapped = false;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i].AvgMark < array[i + 1].AvgMark)
                        {
                            Student temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            swapped = true;
                        }
                    }
                } while (swapped);
            }
            public void Print() // Публичный метод для вывода информации о необходимых полях структуры.
            {
                Console.WriteLine("{0,-12} {1,-12} {2,-12:F2} {3,-12}", Name, Surname, AvgMark, IsExcellent);
            }
        }
    }
}
