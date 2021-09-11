namespace ProjectEuler.Helpers;

public static class ArrayHelper
{
    public static int[] GetRow(this int[,] array, int n)
    {
        var length = array.GetLength(0);
        var heigth = array.GetLength(1);

        if (n > heigth)
            throw new ArgumentOutOfRangeException(nameof(n), "Row number is out of range");

        int[] vector = new int[length];
        for (int i = 0; i < length; i++)
        {
            vector[i] = array[n, i];
        }
        return vector;
    }

    public static int[] GetColumn(this int[,] array, int n)
    {
        var length = array.GetLength(0);
        var heigth = array.GetLength(1);

        if (n > length)
            throw new ArgumentOutOfRangeException(nameof(n), "Column number is out of range");

        int[] vector = new int[heigth];
        for (int i = 0; i < heigth; i++)
        {
            vector[i] = array[i, n];
        }
        return vector;
    }

    public static int[] GetDiagonal(this int[,] array, int n = 0)
    {
        var length = array.GetLength(0);
        var heigth = array.GetLength(1);

        if (n > 0 && n > length)
            throw new ArgumentOutOfRangeException(nameof(n), "Length is out of range");
        if (n < 0 && n > heigth)
            throw new ArgumentOutOfRangeException(nameof(n), "Height is out of range");

        int i = 0, j = 0;

        if (n > 0)
            i = n;
        if (n < 0)
            j = -1 * n;

        var vector = new int[Math.Min(heigth - j, length - i)];
        int k = 0;
        while (i < length && j < heigth)
        {
            vector[k] = array[j, i];
            i++; j++; k++;
        }
        return vector;
    }

    public static int[] GetReverseDiagonal(this int[,] array, int n = 0)
    {
        var length = array.GetLength(0);
        var heigth = array.GetLength(1);

        if (n > 0 && n > length)
            throw new ArgumentOutOfRangeException(nameof(n), "Length is out of range");
        if (n < 0 && n > heigth)
            throw new ArgumentOutOfRangeException(nameof(n), "Height is out of range");

        int i = length - 1, j = 0;

        if (n > 0)
            i -= n;
        if (n < 0)
            j = -1 * n;

        var vector = new int[Math.Min(heigth - j, i + 1)];
        int k = 0;
        while (i >= 0 && j < heigth)
        {
            vector[k] = array[j, i];
            i--; j++; k++;
        }
        return vector;
    }
}
