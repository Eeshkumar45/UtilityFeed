// -----------------------------------------------------------------------
// <copyright file="RandomAny.cs" company="UtilityFeed">
//     Copyright (c) UtilityFeed. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace UtilityFeed.RandomAny;

/// <summary>
/// Provides methods to create random values.
/// </summary>
public class RandomAny
{
    private const string DefaultCharset = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// Instance of Random.
    /// </summary>
    private static readonly Random Random = new ();

    /// <summary>
    /// Generates random string.
    /// </summary>
    /// <param name="length">Length of string to be generated.</param>
    /// <param name="charset">The character set to be used to generate the string.</param>
    /// <param name="caseType">The case tyep of the string to be generated.</param>
    /// <returns>A random string with defined length.</returns>
    public static string RandomString(int length, string charset = DefaultCharset, Case caseType = Case.CamelCase)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Length must be greater than 0");
        }

        if (string.IsNullOrEmpty(charset))
        {
            throw new ArgumentException("Charset cannot be empty");
        }

        StringBuilder result = new (length);

        for (int i = 0; i < length; i++)
        {
            int index = Random.Next(charset.Length);
            result.Append(charset[index]);
        }

        string finalString = result.ToString();

        return caseType switch
        {
            Case.UpperCase => finalString.ToUpper(),
            Case.LowerCase => finalString.ToLower(),
            Case.PascalCase => string.Concat(finalString.Chunk(5).Select((word, i) => char.ToUpper(word[0]) + new string(word[1..]))),
            Case.CamelCase => string.Concat(finalString.Chunk(5).Select((word, i) => i == 0 ? char.ToLower(word[0]) + new string(word[1..]) : char.ToUpper(word[0]) + new string(word[1..]))),
            _ => finalString,
        };
    }

    /// <summary>
    /// Generates random int value between startInt and endInt.
    /// </summary>
    /// <param name="startInt">start int.</param>
    /// <param name="endInt">end int.</param>
    /// <returns>Random int value between startInt and endInt.</returns>
    public static int RandomInt(int startInt = int.MinValue, int endInt = int.MaxValue)
    {
        if (startInt > endInt)
        {
            throw new ArgumentException("startInt must be less than or equal to endInt");
        }

        return Random.Next(startInt, endInt);
    }
}