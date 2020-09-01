using System;
using static System.Console;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace AssembliesAndNamespaces
{
    public static class StringExtentions
    {
        public static bool IsValidXmlTag(this string input)
        {
            //(?<word>\w+)	Match one or more word characters up to a word boundary. Name this captured group word.
            //\s+	Match one or more white-space characters.
            return Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }

        public static bool IsValidPassword(this string input)
        {
            //minimum of eight valid characters
            return Regex.IsMatch( input, "^[a-zA-Z0-9_-]{8,}$" );
        }

        public static bool IsValidHex(this string input)
        {
            //three or six valid hex numbers
            return Regex.IsMatch(input, "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Write("Enter a color value in hex:");
            string hex = ReadLine();
            WriteLine($"Is {hex} a valid color value?: {hex.IsValidHex()}");

            Write("Enter an XML tag: ");
            string xmlTag = ReadLine();
            WriteLine($"Is {xmlTag} a valid tag?: {xmlTag.IsValidXmlTag()}");

            Write("Enter a password: ");
            string password = ReadLine();
            WriteLine($"Is {password} a valid password?: {password.IsValidPassword()}");
            */

            Write("Enter your age: ");
            string ageInput = ReadLine();

            // ^ means start of input
            // \d looks for a single digit
            // + looks for one or more of whatever is in front of it
            // $ end of input
            var ageChecker = new Regex(@"^\d+$");
            if(ageChecker.IsMatch(ageInput))
            {
                WriteLine("Thank You, this is validated");
            }
            else
            {
                WriteLine($"Invalid age: {ageInput}");
            }

            //splitting a complex csv string
            string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";
            var csv = new Regex("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
            MatchCollection filmsSmart = csv.Matches(films);
            WriteLine("Smart attempt at splitting: ");
            
            foreach(Match film in filmsSmart)
            {
                WriteLine(film.Groups[2].Value);
            }



        }
    }
}
