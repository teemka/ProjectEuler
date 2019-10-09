using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Problem017
{
    class Program
    {
        /// <summary>
        /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
        /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
        /// NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
        /// The use of "and" when writing out numbers is in compliance with British usage.
        /// </summary>
        static void Main()
        {
            var names = Enumerable.Range(1, 1000).Select(x => PrintNumber(x));
            var sum = names.Select(x => x.Replace(" ", "").Replace("-", "").Count()).Sum();
            Console.WriteLine(sum);
        }

        static string PrintNumber(int n)
        {
            var context = new Context(n);

            var interpreters = new List<Interpreter>
            {
                new ThousandsIterpreter(),
                new HundredsIterpreter(),
                new TensInterpreter()
            };

            foreach (var interpreter in interpreters)
            {
                interpreter.Interpret(context);
            }

            return context.Name;
        }
    }

    abstract class Interpreter
    {
        protected static readonly IReadOnlyDictionary<int, string> numberNames = new ReadOnlyDictionary<int, string>(new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" }
        });

        public virtual void Interpret(Context context)
        {
            int n = context.Number;
            var quotient = Math.DivRem(n, Multiplier, out n);
            if (quotient > 0)
                context.AddTerm($"{numberNames[quotient]} {MultiplierName}");
            context.Number = n;
        }

        protected abstract int Multiplier { get; }

        protected abstract string MultiplierName { get; }
    }

    class ThousandsIterpreter : Interpreter
    {
        protected override int Multiplier => 1000;

        protected override string MultiplierName => "thousand";
    }

    class HundredsIterpreter : Interpreter
    {
        protected override int Multiplier => 100;

        protected override string MultiplierName => "hundred";
    }

    class TensInterpreter : Interpreter
    {
        protected override int Multiplier => 10;

        protected override string MultiplierName => "";

        public override void Interpret(Context context)
        {
            int n = context.Number;
            if (n == 0)
                return; // do nothing
            else if (n <= 20)
                context.AddTerm(numberNames[n]);
            else
            {
                var tens = Math.DivRem(n, Multiplier, out n);
                var tensName = numberNames[tens * Multiplier];
                if (n > 0)
                    tensName += $"-{numberNames[n]}";
                context.AddTerm(tensName);
            }
        }
    }

    class Context
    {
        public int Number { get; set; }

        private readonly List<string> terms = new List<string>();

        public string Name => string.Join(" and ", terms);

        public Context(int number)
        {
            Number = number;
        }

        public void AddTerm(string term)
        {
            terms.Add(term);
        }
    }
}
