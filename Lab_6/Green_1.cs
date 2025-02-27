using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_1
    {
        public struct Participant // Публичная структура участницы. Здесь находятся:
        {
            private string _surname; // Фамилия.
            private string _group; // Группа.
            private string _trainer; // Фамилия тренера.
            private double _result; // Результат.
            private bool _resultFilled; // Заполненность результата.
            private static double _standard; // Стандарт в виде норматива.
            private static int _passedCount; // Счётчик прошедших норматив.
            private static bool _Printed = false; // Для определения вывода кол-ва людей, прошедших норматив.
            static Participant() // Статичный конструктор для инициализации значений норматива и счётчика.
            {
                _standard = 100;
                _passedCount = 0;
            }
            public Participant(string surname, string group, string trainer) // Публичный конструктор, принимающий фамилию, группу и тренера.
            {
                this._surname = surname;
                this._group = group;
                this._trainer = trainer;
                this._result = 0;
                this._resultFilled = false;
            }
            public string Surname // Публичное свойство фамилии.
            {
                get { return _surname; }
            }
            public string Group // Публичное свойство группы.
            {
                get { return _group; }
            }
            public string Trainer  // Публичное свойство тренера.
            {
                get { return _trainer; }
            }
            public double Result // Публичное свойство результата.
            {
                get { return _result; }
            }
            public bool HasPassed  // Публичное свойство пройденности.
            {
                get { return _resultFilled && _result <= _standard && _result > 0; }
            }
            public static int PassedTheStandard // Публичное свойство пройденных норматива.
            {
                get { return _passedCount; }
            }
            public void Run(double result) // Метода бега участницы.
            {
                if (result <= 0)
                {
                    return;
                }
                if (!_resultFilled) // Если её результат не записан, то
                {
                    this._result = result; // ... записываем её результат.
                    _resultFilled = true; // Результат записан.
                    if (result <= _standard) // Проверка пройденности и корректности норматива.
                    {
                        _passedCount++;
                    }
                }
            }
            public void Print()
            {
                object sync = new object();
                lock (sync)
                {
                    if (!_Printed)
                    {
                        Console.WriteLine("Прошли норматив: {0}", PassedTheStandard);
                        _Printed = true;
                    }
                }
                Console.WriteLine("{0,-12} {1,-10} {2,-12} {3,-10} {4,-10}", Surname, Group, Trainer, Result.ToString("F2"), HasPassed);
            }
        }
    }
}
