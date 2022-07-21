using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;

namespace rapid_auth_dll
{
    internal class crypting
    {
        public static string EncryptString(string plaintext, string password = null)
        {
            password = rapid_auth.OPENSSL_KEY;
            var encryptor = new Encryptor();
            var encrypted = encryptor.Encrypt(Encoding.Default.GetBytes(plaintext), password);

            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptString(string cipherText, string password = null)
        {
            password = rapid_auth.OPENSSL_KEY;
            var decryptor = new Decryptor();
            var decrypted = decryptor.Decrypt(Convert.FromBase64String(cipherText), password);

            return Encoding.Default.GetString(decrypted);
        }
    }
}
