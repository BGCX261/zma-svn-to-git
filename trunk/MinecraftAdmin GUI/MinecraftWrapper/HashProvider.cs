using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MinecraftWrapper
{
    public class HashProvider
    {
        private static String salt = "gjit295!(%$586";

        public static SHA1Managed SHA1 = new SHA1Managed();
        public static SHA256Managed SHA256 = new SHA256Managed();

        /// <summary>
        /// Returns a salted hash
        /// </summary>
        /// <param name="TextToHash">The text to hash</param>
        /// <param name="crypto">The algorithm to use</param>
        /// <returns>hash as lowerchar string</returns>
        public static string GetHash(string TextToHash, HashAlgorithm crypto)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.

            byte[] textToHash = Encoding.Default.GetBytes(salt +TextToHash + salt);
            byte[] result = crypto.ComputeHash(textToHash);

            return System.BitConverter.ToString(result).Replace("-", string.Empty).ToLower();
        }
    }
}
