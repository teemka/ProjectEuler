namespace ProjectEuler.Problems._001_100._11_20;

/// <summary>
/// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
/// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
/// NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
/// The use of "and" when writing out numbers is in compliance with British usage.
/// </summary>
public class Problem017 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var names = Enumerable.Range(1, 1000).Select(PrintNumber);
        var sum = names.Select(x => x.Replace(" ", string.Empty).Replace("-", string.Empty).Length).Sum();
        return Task.FromResult(sum.ToString());
    }

    private static string PrintNumber(int n)
    {
        var context = new Context(n);

        var interpreters = new List<Interpreter>
        {
            new ThousandsInterpreter(),
            new HundredsInterpreter(),
            new TensInterpreter(),
        };

        foreach (var interpreter in interpreters)
        {
            interpreter.Interpret(context);
        }

        return context.Name;
    }

    private abstract class Interpreter
    {
        protected static readonly Dictionary<int, string> NumberNames = new()
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
            { 90, "ninety" },
        };

        protected abstract int Multiplier { get; }

        protected abstract string MultiplierName { get; }

        public virtual void Interpret(Context context)
        {
            var n = context.Number;
            var quotient = Math.DivRem(n, this.Multiplier, out n);
            if (quotient > 0)
            {
                context.AddTerm($"{NumberNames[quotient]} {this.MultiplierName}");
            }

            context.Number = n;
        }
    }

    private sealed class ThousandsInterpreter : Interpreter
    {
        protected override int Multiplier => 1000;

        protected override string MultiplierName => "thousand";
    }

    private sealed class HundredsInterpreter : Interpreter
    {
        protected override int Multiplier => 100;

        protected override string MultiplierName => "hundred";
    }

    private sealed class TensInterpreter : Interpreter
    {
        protected override int Multiplier => 10;

        protected override string MultiplierName => string.Empty;

        public override void Interpret(Context context)
        {
            var n = context.Number;
            if (n == 0)
            {
                return; // do nothing
            }

            if (n <= 20)
            {
                context.AddTerm(NumberNames[n]);
            }
            else
            {
                var tens = Math.DivRem(n, this.Multiplier, out n);
                var tensName = NumberNames[tens * this.Multiplier];
                if (n > 0)
                {
                    tensName += $"-{NumberNames[n]}";
                }

                context.AddTerm(tensName);
            }
        }
    }

    private sealed class Context(int number)
    {
        private readonly List<string> terms = [];

        public int Number { get; set; } = number;

        public string Name => string.Join(" and ", this.terms);

        public void AddTerm(string term)
        {
            this.terms.Add(term);
        }
    }
}
