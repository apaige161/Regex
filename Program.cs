using System;
using static System.Console;
using System.Xml.Linq;
using SharedLibrary;
using System.Text.RegularExpressions;

namespace AssembliesAndNamespaces
{
    public static class StringExtentions
    {
        public static bool IsValidXmlTag(this string input)
        {
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
            var doc = new XDocument();

            Write("Enter a color value in hex:");
            string hex = ReadLine();
            WriteLine($"Is {hex} a valid color value?: {hex.IsValidHex()}");

            Write("Enter an XML tag: ");
            string xmlTag = ReadLine();
            WriteLine($"Is {xmlTag} a valid tag?: {xmlTag.IsValidXmlTag()}");

            Write("Enter a password: ");
            string password = ReadLine();
            WriteLine($"Is {password} a valid password?: {password.IsValidPassword()}");
        }
    }
}
