using System;

namespace VedasPortal.Helpers
{
    public static class StringHelper
    {
        public static string GenRandomAlphaNumString()
        {
            Random rand = new Random();
            const string Alphabet = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            char[] chars = new char[6];
            for (int i = 0; i < 6; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }

            return new string(chars);
        }
    }
}
