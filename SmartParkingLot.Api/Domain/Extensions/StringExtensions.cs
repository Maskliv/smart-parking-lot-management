namespace SmartParkingLot.Api.Domain.Extensions;

public static class StringExtensions
{
    private static string TitleCaseWord(this string word)
    {
        
        if (string.IsNullOrWhiteSpace(word))
            return word;

        
        return char.ToUpper(word[0]) + word.Substring(1).ToLower();
    }

    public static string ToTitleCase(this string input)
    {
        
        if (string.IsNullOrWhiteSpace(input))
            return input;


        return string.Join(" ", Array.ConvertAll(input.Split(' '), x =>
        {
            return x.TitleCaseWord();
            
        }));
    }
}
