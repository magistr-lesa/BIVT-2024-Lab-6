using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
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
            public readonly string Name // Свойство имени.
            {
                get { return _name ?? ""; }
            }
            public readonly string Surname // Свойство фамилии.
            {
                get { return _surname ?? ""; }
            }
            public readonly double[] Jumps // Свойство прыжков.
            {
                get
                {
                    return _jumps != null ? (double[])_jumps.Clone() : [];
                }
            }
            public double BestJump // Свойство лучшего из них.
            {
                get
                {
                    return _bestJump = _jumps.Max();
                }
            }
            public Participant(string name, string surname) // Публичный конструктор, принимающий имя и фамилию.
            {
                _name = name ?? "";
                _surname = surname ?? "";
                _jumps = new double[3];
                _bestJump = 0;
            }
            public void Jump(double result) // Прыыыыжок.
            {
                if (_jumps.Length == 0 || _jumps == null) return;
                if (_index < 3 && result >= 0)
                {
                    _jumps[_index] = result;
                    _index++;
                }
            }
            public static void Sort(Participant[] array) // Статический метод сортировки массива прыгунов по убыванию лучшего прыжка.
            {
                if (array == null)
                    return;
                Array.Sort(array, (p1, p2) => p2.BestJump.CompareTo(p1.BestJump));
            }
            public void Print() // Публичный метод для вывода информации о необходимых полях структуры.
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-15:F2}", Name, Surname, BestJump);
            }
            public static void PrintAll(Participant[] participants) // Публично-статичный метод для полного вывода.
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-15}", "Name", "Surname", "The best jump");
                Console.WriteLine(new string('—', 60));

                foreach (var p in participants)
                {
                    p.Print();
                }
                Console.WriteLine(new string('—', 60));
            }
        }
    }
}