public class Formatter
{

    // Format a value to a string with a suffix
    public static string formatValue(int value)
    {
        if (value >= 100000000) {
        return (value / 1000000D).ToString("0.00M");
        }
        if (value >= 1000000) {
            return (value / 1000000D).ToString("0.00M");
        }
        if (value >= 100000) {
            return (value / 1000D).ToString("0.00K");
        }
        if (value >= 10000) {
            return (value / 1000D).ToString("0.00K");
        }

        return value.ToString("#,0");
    }
}
