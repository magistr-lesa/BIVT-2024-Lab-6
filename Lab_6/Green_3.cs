using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
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
                _name = name;
                _surname = surname;
                _marks = new int[3];
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = 0;
                }
                _isExpelled = false;
                _examCount = 0;
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
                    if (_marks == null || _marks.Length == 0)
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
                if (_marks == null || _marks.Length == 0)
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
            public static void SortByAvgMark(Student[] array)
            {
                if (array == null || array.Length == 0)
                    return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].AvgMark < array[j].AvgMark || (array[i].AvgMark == array[j].AvgMark && i > j))
                        {
                            Student temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
            public void Print() // Публичный метод для вывода информации о необходимых полях структуры.
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-15:F2} {3,-10}", Name, Surname, AvgMark, IsExpelled);
            }
        }
    }
}
