namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=71
/// Answer: 428570
/// </summary>
public class Problem071 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var size))
        {
            size = 1_000_000;
        }

        var result = Calculate(size);

        return Task.FromResult(result.Nominator.ToString());
    }

    internal static Fraction Calculate(int size)
    {
        var target = new Fraction(3, 7);
        var best = new Fraction(1, size);

        for (int denominator = size; denominator > 1; denominator--)
        {
            var start = (int)(denominator * target.RealValue);
            for (int nominator = start; nominator < size; nominator++)
            {
                var current = new Fraction(nominator, denominator);
                if (current.RealValue >= target.RealValue)
                {
                    break;
                }

                if (current.RealValue > best.RealValue)
                {
                    best = current;
                }
            }
        }

        return best.Reduce();
    }

    internal readonly struct Fraction
    {
        public Fraction(int nominator, int denominator)
        {
            this.Nominator = nominator;
            this.Denominator = denominator;

            this.RealValue = (double)nominator / denominator;
        }

        public int Nominator { get; }

        public int Denominator { get; }

        public double RealValue { get; }

        public Fraction Reduce()
        {
            var nominator = this.Nominator;
            var denominator = this.Denominator;
            while (true)
            {
                var gcd = NumberHelper.GCD(nominator, denominator);
                if (gcd == 1)
                {
                    break;
                }

                nominator /= gcd;
                denominator /= gcd;
            }

            return new(nominator, denominator);
        }

        public override string ToString() => $"{this.Nominator}/{this.Denominator}";
    }
}
