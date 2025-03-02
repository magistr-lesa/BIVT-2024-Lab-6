using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_5
    {
        public struct Student // Публичная структура студента.
        {
            private string _name; // Его имя.
            private string _surname; // Его фамилия.
            private int[] _marks; // Его оценки. 
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
                get { return _marks != null ? (int[])_marks.Clone() : null; }
            }
            public Student(string name, string surname)  // Публичный конструктор, принимающий имя и фамилию, инициализирует массив оценок по нулям.
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = 0;
                }
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
            public void Print() // Публичный метод для вывода информации о необходимых полях структуры.
            {
                Console.WriteLine("{0,-12} {1,-12} {2,-12:F2} {3, -12}", Name, Surname, AvgMark, string.Join(", ", Marks));
            }
        }
        public struct Group // Публичная структура группы.
        {
            private string _name; // Название.
            private Green_5.Student[] _students; // Студенты в ней.
            private int _studentCount; // Их количество.
            public string Name // Свойство имени.
            {
                get { return _name; }
            }

            public Green_5.Student[] Students // Свойство студентов.
            {
                get { return _students; }
            }
            public double AvgMark // Высчитываем средний балл в группе.
            {
                get
                {
                    if (_students == null || _studentCount == 0)
                        return 0;

                    double totalSum = 0;
                    int totalCount = 0;
                    for (int i = 0; i < _studentCount; i++)
                    {
                        foreach (double mark in _students[i].Marks)
                        {
                            totalSum += mark;
                            totalCount++;
                        }
                    }
                    return totalCount == 0 ? 0 : totalSum / totalCount;
                }
            }
            public Group(string name) // Конкструктор группы.
            {
                _name = name;
                _students = new Green_5.Student[0];
                _studentCount = 0;
            }
            public void Add(Green_5.Student student) // Метод добавления одного студента.
            {
                if (_students == null)
                    _students = new Green_5.Student[0];
                Array.Resize(ref _students, _studentCount + 1);
                _students[_studentCount] = student;
                _studentCount++;
            }
            public void Add(Green_5.Student[] newStudents) // Метод добавления нескольких студентов.
            {
                if (newStudents == null)
                    return;
                if (_students == null)
                    _students = new Green_5.Student[0];

                int newLength = _studentCount + newStudents.Length;
                Array.Resize(ref _students, newLength);
                for (int i = 0; i < newStudents.Length; i++)
                {
                    _students[_studentCount + i] = newStudents[i];
                }
                _studentCount = newLength;
            }
            public static void SortByAvgMark(Group[] array)
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
                            Group temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            swapped = true;
                        }
                    }
                } while (swapped);
            }
            public void Print() // Публичный метод для вывода информации о необходимых полях структуры.
            {
                Console.WriteLine("{0,-12} {1,-15:F2}", Name, AvgMark);
            }
        }
    }
}
