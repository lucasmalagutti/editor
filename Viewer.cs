using System.Text.RegularExpressions;

namespace EditorHtml
{
    public static class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("----------------------------------");
            Replace(text);
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
            Menu.Show();
        }
        public static void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            (
                            (words[i].LastIndexOf('<') - 1) -
                            words[i].IndexOf('>')
                            )
                        )
                    );
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.Write(words[i]);
                    Console.WriteLine(" ");
                }
            }
        }
    }
}

