namespace ProjectEuler.Helpers;

public readonly struct ConcatenatedNumber
{
    public ConcatenatedNumber(int left, int right)
    {
        this.Left = left;
        this.Right = right;
        this.Value = int.Parse($"{left}{right}");
    }

    public int Left { get; }

    public int Right { get; }

    public int Value { get; }

    public override string ToString() => this.Value.ToString();
}
