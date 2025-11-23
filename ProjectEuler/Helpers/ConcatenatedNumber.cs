namespace ProjectEuler.Helpers;

public readonly struct ConcatenatedNumber(int left, int right)
{
    public int Left { get; } = left;

    public int Right { get; } = right;

    public int Value { get; } = int.Parse($"{left}{right}");

    public override string ToString() => this.Value.ToString();
}
