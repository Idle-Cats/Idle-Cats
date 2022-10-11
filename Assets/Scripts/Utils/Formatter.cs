public class Formatter
{

    // Format a value to a string with a suffix
    public static string formatValue(int value)
    {
        if (value <=10000) { // Less than 10,000
            return value.ToString("#,0");
        } else if (value <= 1000000D) { // Less than 1,000,000 (Thousand)
            return (value / 1000).ToString("0.00K");
        } else if (value <= 1000000000D) { // Less than 1,000,000,000 (Million)
            return (value / 1000000).ToString("0.00M");
        } else if (value <= 1000000000000D) { // Less than 1,000,000,000,000 (Billion)
            return (value / 1000000000).ToString("0.00B");
        } else if (value <= 1000000000000000D) { // Less than 1,000,000,000,000,000 (Trillion)
            return (value / 1000000000000).ToString("0.00T");
        } else if (value <= 1000000000000000000D) { // Less than 1,000,000,000,000,000,000 (Quadrillion)
            return (value / 1000000000000000).ToString("0.00q");
        } else { // Greater than 1,000,000,000,000,000,000 (Quintillion)
            return (value / 1000000000000000000).ToString("#,0Q");
        }
    }
}
