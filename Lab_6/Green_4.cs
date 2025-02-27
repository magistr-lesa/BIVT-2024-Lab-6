using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_4
    {
        public struct Participant // Публичная структура участницы. Здесь находятся:
        {
            private string _name; // Имя.
            private string _surname; // Фамилия.
            private double[] _jumps; // Прыжки.
            private double _bestJump; // Объявляем лучший прыжок.
            private int _index = 0;
            public string Name // Свойство имени.
            {
                get { return _name; }
            }
            public string Surname // Свойство фамилии.
            {
                get { return _surname; }
            }
            public double[] Jumps // Свойство прыжков.
            {
                get
                {
                    return _jumps != null ? (double[])_jumps.Clone() : null;
                }
            }
            public double BestJump // Свойство лучшего из них.
            {
                get
                {
                    if (_jumps == null || _jumps.Length == 0)
                        return 0;
                    return _bestJump = _jumps.Max();
                }
            }
            public Participant(string name, string surname) // Публичный конструктор, принимающий имя и фамилию.
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3];
                _bestJump = 0;
            }
            public void Jump(double result) // Прыыыыжок.
            {
                if (_jumps == null || _jumps.Length == 0) return;
                if (_index < 3 && result >= 0)
                {
                    _jumps[_index] = result;
                    _index++;
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0)
                    return;
                bool swapped;
                do
                {
                    swapped = false;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i].BestJump < array[i + 1].BestJump)
                        {
                            Participant temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            swapped = true;
                        }
                    }
                } while (swapped);
            }
            public void Print() // Публичный метод для вывода информации о необходимых полях структуры.
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-15:F2}", Name, Surname, BestJump);
            }
        }
    }
}
