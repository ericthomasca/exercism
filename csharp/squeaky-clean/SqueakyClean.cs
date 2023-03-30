using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        // Replace any spaces encountered with underscores
        var spacelessString = identifier.Replace(' ', '_');

        // Replace control characters with the upper case string "CTRL"
        var ctrlString = spacelessString.Replace("\0", "CTRL");

        // Convert kebab-case to camelCase
        var camelCaseString = Regex.Replace(ctrlString, "-.", x => x.Value.ToUpper().Substring(1));

        // Omit characters that are not letters
        var letterOnlyString = Regex.Replace(camelCaseString, @"\W|[0-9]", "");
        
        // Omit Greek lower case letters
        var cleanString = Regex.Replace(letterOnlyString, @"[α-ω]", "");

        return cleanString;
    }
}
