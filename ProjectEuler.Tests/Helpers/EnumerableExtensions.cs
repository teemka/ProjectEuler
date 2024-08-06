namespace ProjectEuler.Tests.Helpers;

public static class EnumerableExtensions
{
    public static TheoryData<T> ToTheoryData<T>(this IEnumerable<T> source)
    {
        var data = new TheoryData<T>();
        foreach (var item in source)
        {
            data.Add(item);
        }

        return data;
    }

    public static TheoryData<T1, T2> ToTheoryData<T1, T2>(this IEnumerable<(T1, T2)> source)
    {
        var data = new TheoryData<T1, T2>();
        foreach (var (item1, item2) in source)
        {
            data.Add(item1, item2);
        }

        return data;
    }
}
