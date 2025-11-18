namespace SK.FinalP.Shared.Utils;

public static class ConvertUtil
{
    public static int? ToIntOrNull(this string? str)
    {
        if (int.TryParse(str, out int result))
        {
            return result;
        }

        return null;
    }
}