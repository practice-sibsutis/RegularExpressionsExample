// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

{
    string s = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
    Regex regex = new Regex(@"туп(\w*)");

    /*
     * Compiled: при установке этого значения регулярное выражение компилируется в сборку, что обеспечивает более быстрое выполнение
     * CultureInvariant: при установке этого значения будут игнорироваться региональные различия
     * IgnoreCase: при установке этого значения будет игнорироваться регистр
     * IgnorePatternWhitespace: удаляет из строки пробелы и разрешает комментарии, начинающиеся со знака #
     * Multiline: указывает, что текст надо рассматривать в многострочном режиме. При таком режиме символы "^" и "$" совпадают, соответственно, с началом и концом любой строки, а не с началом и концом всего текста
     * RightToLeft: приписывает читать строку справа налево
     * Singleline: при данном режиме символ "." соответствует любому символу, в том числе последовательности "\n", которая осуществляет переход на следующую строку
     * 
     * Например:
     * Regex regex = new Regex(@"туп(\w*)", RegexOptions.IgnoreCase);
     * Regex regex = new Regex(@"туп(\w*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
     */
    MatchCollection matches = regex.Matches(s);
    if (matches.Count > 0)
    {
        foreach (Match match in matches)
            Console.WriteLine(match.Value);
    }
    else
    {
        Console.WriteLine("Совпадений не найдено");
    }
}

/*
 * ^: соответствие должно начинаться в начале строки (например, выражение @"^пр\w*" соответствует слову "привет" в строке "привет мир")
 * $: конец строки (например, выражение @"\w*ир$" соответствует слову "мир" в строке "привет мир", так как часть "ир" находится в самом конце)
 * .: знак точки определяет любой одиночный символ (например, выражение "м.р" соответствует слову "мир" или "мор")
 * *: предыдущий символ повторяется 0 и более раз
 * +: предыдущий символ повторяется 1 и более раз
 * ?: предыдущий символ повторяется 0 или 1 раз
 * \s: соответствует любому пробельному символу
 * \S: соответствует любому символу, не являющемуся пробелом
 * \w: соответствует любому алфавитно-цифровому символу
 * \W: соответствует любому не алфавитно-цифровому символу
 * \d: соответствует любой десятичной цифре
 * \D : соответствует любому символу, не являющемуся десятичной цифрой
 */
Console.WriteLine();
{
    string s = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
    Regex regex = new Regex(@"\w*губ\w*");

    MatchCollection matches = regex.Matches(s);
    if (matches.Count > 0)
    {
        foreach (Match match in matches)
            Console.WriteLine(match.Value);
    }
    else
    {
        Console.WriteLine("Совпадений не найдено");
    }
}

Console.WriteLine();

{
    string s = "456-435-2318";
    Regex regex = new Regex(@"\d{3}-\d{3}-\d{4}");

    MatchCollection matches = regex.Matches(s);
    if (matches.Count > 0)
    {
        foreach (Match match in matches)
            Console.WriteLine(match.Value);
    }
    else
    {
        Console.WriteLine("Совпадений не найдено");
    }
}

Console.WriteLine();

{
    string s = "456-435-2318";
    Regex regex = new Regex("[0-9]{3}-[0-9]{3}-[0-9]{4}");

    MatchCollection matches = regex.Matches(s);
    if (matches.Count > 0)
    {
        foreach (Match match in matches)
            Console.WriteLine(match.Value);
    }
    else
    {
        Console.WriteLine("Совпадений не найдено");
    }
}

Console.WriteLine();

{
    string s = "456-435-2318";
    //string s = "235-435-2318";
    Regex regex = new Regex(@"(2|3){3}-[0-9]{3}-\d{4}");

    MatchCollection matches = regex.Matches(s);
    if (matches.Count > 0)
    {
        foreach (Match match in matches)
            Console.WriteLine(match.Value);
    }
    else
    {
        Console.WriteLine("Совпадений не найдено");
    }
}

Console.WriteLine();

{
    string s = "456-435-2318";
    //string s = "222.222.2222";
    Regex regex = new Regex(@"(2|3){3}\.[0-9]{3}\.\d{4}");

    MatchCollection matches = regex.Matches(s);
    if (matches.Count > 0)
    {
        foreach (Match match in matches)
            Console.WriteLine(match.Value);
    }
    else
    {
        Console.WriteLine("Совпадений не найдено");
    }
}

Console.WriteLine();

//IsMatch
{
    string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
    var data = new string[]
    {
    "tom@gmail.com",
    "+12345678999",
    "bob@yahoo.com",
    "+13435465566",
    "sam@yandex.ru",
    "+43743989393"
    };

    Console.WriteLine("Email List");
    for (int i = 0; i < data.Length; i++)
    {
        if (Regex.IsMatch(data[i], pattern, RegexOptions.IgnoreCase))
        {
            Console.WriteLine(data[i]);
        }
    }
}

Console.WriteLine();

//Replace
{
    string text = "Мама  мыла  раму. ";
    string pattern = @"\s+";
    string target = " ";
    Regex regex = new Regex(pattern);
    string result = regex.Replace(text, target);
    Console.WriteLine(result);
}

Console.WriteLine();

{
    string phoneNumber = "+1(876)-234-12-98";
    string pattern = @"\D";
    string target = "";
    Regex regex = new Regex(pattern);
    string result = regex.Replace(phoneNumber, target);
    Console.WriteLine(result);  // 18762341298
}