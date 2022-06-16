
using System.Text.RegularExpressions;

string text = Console.ReadLine();

var alphabetWords = String.Join(Environment.NewLine, GetAlphaWords(text));
var palindromeWords = String.Join(Environment.NewLine, GetPalindrome(text));

Console.WriteLine(Environment.NewLine + "Слова по алфавиту:");
Console.WriteLine(alphabetWords);
Console.WriteLine(Environment.NewLine + "Слова палиндромы:");
Console.WriteLine(palindromeWords);

List<String> GetAlphaWords(string text)
{
    List<String> words = new List<String>(GetOnlyTextWithoutSymbols(text).Split());
    words = words.Distinct().ToList();
    words.Sort();
    return words;
}

String GetOnlyTextWithoutSymbols(string text)
{
    var newText = Regex.Replace(text, "[-.?!)(,:\n\r]", "");

    return newText;
}

List<String> GetPalindrome(string text)
{
    List<String> words = new List<String>(GetOnlyTextWithoutSymbols(text).Split());
    List<String> palindrome = new List<String>();

    bool flag;

    for (int i = 0; i < words.Count; i++)
    {
        flag = true;
        for (int j = 0; j < words[i].Length / 2; j++)
        {
            string word = words[i];
            if (word[j] != word[word.Length - j - 1])
            {
                flag = false;
            }
        }
        if (flag)
        {
            palindrome.Add(words[i]);
        }
    }

    return palindrome;
}
